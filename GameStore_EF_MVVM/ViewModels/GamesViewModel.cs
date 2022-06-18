using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using GameStore.DAL.Entityes;
using GameStore.Interfaces;
using MathCore.WPF.ViewModels;

namespace GameStore_EF_MVVM.ViewModels
{
    internal class GamesViewModel : ViewModel
    {
        private readonly IRepository<Game> gamesRepository;
        private CollectionViewSource GamesViewSource;

        public IEnumerable<Game> Games => gamesRepository.Items;

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


        public ICollectionView GamesView { get { return GamesViewSource.View; } }

        public GamesViewModel(IRepository<Game> gamesRepository)
        {
            this.gamesRepository = gamesRepository;
            GamesViewSource = new CollectionViewSource()
            {
                Source = gamesRepository.Items.ToArray(),
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
