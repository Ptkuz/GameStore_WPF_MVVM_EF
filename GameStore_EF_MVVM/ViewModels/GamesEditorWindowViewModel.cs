using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathCore.WPF.ViewModels;
using GameStore.DAL.Entityes;
using GameStore.Interfaces;

namespace GameStore_EF_MVVM.ViewModels
{
    internal class GamesEditorWindowViewModel : ViewModel
    {
        private readonly IRepository<Game> gamesRepository;
        private readonly IRepository<Buyer> buyersRepository;
        private readonly IRepository<Seller> sellerRepository;
        private readonly IRepository<Deal> dealRepository;


        #region ID книги
        private string gameId;
        public string GameId { get => gameId; set => Set(ref gameId, value); }
        #endregion

        #region Название игры
        private string name;
        public string Name { get => name; set => Set(ref name, value); }
        #endregion

        #region Список жанров
        
        public IRepository<Game> Categories 
        { 
            get => categories; 
            set => Set(ref categories, value);
        }
        #endregion

        #region Список разработчиков
        private IEnumerable<Category> developers;
        public IEnumerable<Category> Developers
        {
            get => developers;
            set => Set(ref developers, value);
        }
        #endregion


        public GamesEditorWindowViewModel
           (
           IRepository<Game> gamesRepository,
           IRepository<Buyer> buyersRepository,
           IRepository<Seller> sellerRepository,
           IRepository<Deal> dealRepository
           )
        {
            this.gamesRepository = gamesRepository;
            this.buyersRepository = buyersRepository;
            this.sellerRepository = sellerRepository;
            this.dealRepository = dealRepository;
        }
    }

}
