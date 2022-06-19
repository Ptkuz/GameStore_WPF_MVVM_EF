using GameStore.DAL.Entityes;
using GameStore.Interfaces;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace GameStore_EF_MVVM.ViewModels
{
    internal class GamesEditorWindowViewModel : ViewModel
    {
        private readonly IRepository<Category> categoriesRepository;
        private readonly IRepository<Developer> developersRepository;

        private CollectionViewSource CategoriesViewSource;
        private CollectionViewSource DevelopersViewSource;

        #region ID игры
        private int gameId;
        public int GameId
        {
            get { return gameId; }
            set
            {
                    Set(ref gameId, value);
            }
        }
        #endregion

        #region Название игры
        private string name;
        public string Name { get => name; set => Set(ref name, value); }
        #endregion

        #region Дата релиза
        private DateTime releaseDate;
        public DateTime ReleaseDate
        {
            get => releaseDate;
            set
            {
                if (releaseDate == default)
                    releaseDate = DateTime.Now;
                else
                    Set(ref releaseDate, value);

            }
        }
        #endregion

        #region Выбранная категория
        private Category selectedCategory;
        public Category SelectedCategory
        {
            get => selectedCategory;
            set => Set(ref selectedCategory, value);
        }
        #endregion

        #region Выбранный разработчик
        private Developer selectedDeveloper;
        public Developer SelectedDeveloper
        {
            get => selectedDeveloper;
            set => Set(ref selectedDeveloper, value);
        }
        #endregion

        #region Коллекция категорий 
        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get => categories;
            set
            {
                if (Set(ref categories, value))
                    CategoriesViewSource.Source = value;


            }
        }
        #endregion

        #region Коллекция разработчиков 
        private ObservableCollection<Developer> developers;
        public ObservableCollection<Developer> Developers
        {
            get => developers;
            set
            {
                if (Set(ref developers, value))
                    DevelopersViewSource.Source = value;


            }
        }
        #endregion



        #region Команда загрузки данных о категориях из репозитория
        private ICommand loadCategoriesCommand;
        public ICommand LoadCategoriesCommand => loadCategoriesCommand
            ??= new LambdaCommandAsync(OnLoadCategoriesExecutedAsync, CanLoadCommandExecute);

        private bool CanLoadCommandExecute(object? arg) => true;


        private async Task OnLoadCategoriesExecutedAsync(object? obj)
        {
            Categories = (await categoriesRepository.Items.ToArrayAsync()).ToObservableCollection();
        }
        #endregion

        #region Команда загрузки данных о разработчиках из репозитория
        private ICommand loadDevelopersCommand;
        public ICommand LoadDevelopersCommand => loadDevelopersCommand
            ??= new LambdaCommandAsync(OnLoadDevelopersExecutedAsync, CanLoadDevelopersCommandExecute);

        private bool CanLoadDevelopersCommandExecute(object? arg) => true;


        private async Task OnLoadDevelopersExecutedAsync(object? obj)
        {
            Developers = (await developersRepository.Items.ToArrayAsync()).ToObservableCollection();
        }
        #endregion

        public GamesEditorWindowViewModel() { }

        public GamesEditorWindowViewModel(
            IRepository<Category> categoriesRepository,
            IRepository<Developer> developersRepository,
            Game game)
        {
            this.categoriesRepository = categoriesRepository;
            this.developersRepository = developersRepository;
            GameId = game.Id;
            Name = game.Name;
            ReleaseDate = game.ReleaseDate;
            SelectedCategory = game.Category;
            SelectedDeveloper = game.Developer;

            CategoriesViewSource = new CollectionViewSource()
            {
                SortDescriptions =
                {
                    new SortDescription(nameof(Category.Name), ListSortDirection.Ascending)
                }
            };

            DevelopersViewSource = new CollectionViewSource()
            {
                SortDescriptions =
                {
                    new SortDescription(nameof(Category.Name), ListSortDirection.Ascending)
                }
            };
        }




    }

}
