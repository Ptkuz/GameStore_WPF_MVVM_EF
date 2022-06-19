using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using GameStore.DAL.Entityes;
using GameStore.Interfaces;
using GameStore_EF_MVVM.Services.Interfaces;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GameStore_EF_MVVM.ViewModels
{
    internal class GamesViewModel : ViewModel
    {
        private readonly IRepository<Game> gamesRepository;
        private readonly IRepository<Category> categoriesRepository;
        private readonly IRepository<Developer> developersRepository;
        private readonly IUserDialog userDialog;
        private CollectionViewSource GamesViewSource;

        //public IEnumerable<Game> Games => gamesRepository.Items;

        #region Фильтруищее выражение
        private string gamesFilter;
        public string GamesFilter 
        { 
            get 
            { 
                return gamesFilter; 
            }
            set 
            {
                if (Set(ref gamesFilter, value)) 
                    GamesViewSource.View.Refresh();
            }
        }
        #endregion

        #region Коллекция книг
        private ObservableCollection<Game> games;
        public ObservableCollection<Game> Games { 
            get => games;
            set 
            {

                if (Set(ref games, value))
                {
                    GamesViewSource.Source = value;
                    OnPropertyChanged(nameof(GamesView));
                }
            }
        }
        #endregion

        #region Выбранная игра
        private Game selectedGame;
        public Game SelectedGame 
        {
            get => selectedGame;
            set => Set(ref selectedGame, value);
        }

        #endregion

        #region команда загрузки данных из репозитория 
        private ICommand loadDataCommand;
        public ICommand LoadDataCommand => loadDataCommand
            ??= new LambdaCommandAsync(OnLoadDataCommandExecutedAsync, CanLoadCommandExecute);

        private bool CanLoadCommandExecute(object? arg) => true;


        private async Task OnLoadDataCommandExecutedAsync(object? obj)
        {
            Games = (await gamesRepository.Items.ToArrayAsync()).ToObservableCollection();
            
        }
        #endregion

        #region Команда добавления новой игры
        private Command addNewGameCommand;
        public Command AddNewGameCommand => addNewGameCommand
            ??= new LambdaCommand(OnAddNewCommandExecuted, CanAddNewCommandExecuted);

        private bool CanAddNewCommandExecuted(object? arg) => true;
        

        private void OnAddNewCommandExecuted(object? obj)
        {
            var game = new Game();
            if (!userDialog.Edit(categoriesRepository, developersRepository, game)) return;
            Games.Add(gamesRepository.Add(game));

            SelectedGame = game;




        }

        #endregion

        #region Команда удаления выбранной игры
        private Command removeGameCommand;
        public Command RemoveGameCommand => removeGameCommand
            ??= new LambdaCommand<Game>(OnRemoveCommandExecuted, CanRemoveCommandExecuted);

        private bool CanRemoveCommandExecuted(Game game) => game != null || SelectedGame != null;
       

        private void OnRemoveCommandExecuted(Game game)
        {
            var game_to_remove = game ?? SelectedGame;
        }

        #endregion

        public ICollectionView GamesView { get { return GamesViewSource.View; } }

        public GamesViewModel(
            IRepository<Game> gamesRepository, 
            IRepository<Category> categoriesRepository,
            IRepository<Developer> developersRepository,
            IUserDialog userDialog)
        {
            this.gamesRepository = gamesRepository;
            this.categoriesRepository = categoriesRepository;
            this.developersRepository = developersRepository;
            this.userDialog = userDialog;
            GamesViewSource = new CollectionViewSource()
            {                
                SortDescriptions =
                {
                    new SortDescription(nameof(Game.Name), ListSortDirection.Ascending)
                }
                
            
            };
            GamesViewSource.Filter += OnGamesFilter;
        }

        private void OnGamesFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Game game) || string.IsNullOrEmpty(GamesFilter)) return;

            if (!game.Name.Contains(GamesFilter) &&
                !game.Developer.Name.Contains(GamesFilter) &&
                !game.ReleaseDate.ToString().Contains(GamesFilter)) 
            {
                e.Accepted = false;
            }
        }
    }
}
