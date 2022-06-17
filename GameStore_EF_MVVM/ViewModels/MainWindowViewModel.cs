using GameStore.DAL.Entityes;
using GameStore.Interfaces;
using GameStore_EF_MVVM.Services.Interfaces;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System;
using System.Linq;
using System.Windows.Input;

namespace GameStore_EF_MVVM.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly IRepository<Game> gamesRepository;
        private readonly IRepository<Buyer> buyersRepository;
        private readonly IRepository<Seller> sellerRepository;
        private readonly IRepository<Developer> developersRepository;
        private readonly IRepository<Publicher> publishersReposirory;
        private readonly IRepository<Deal> dealsRepository;
        private readonly IRepository<Category> categoryRepository;
        private readonly ISalesService salesService;

        #region Заголовок главного окна
        private string title = "Главное окно программы";
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        #endregion

        #region Текущая дочерняя модель представления 
        private ViewModel? currentModel;
        public ViewModel CurrentModel
        {
            get { return currentModel; }
            private set { Set(ref currentModel, value); }
        }
        #endregion

        #region Отобразить представление книг
        private ICommand showGamesViewModel;
        public ICommand ShowGamesViewModel => showGamesViewModel
            ??= new LambdaCommand(OnShowGamesViewCommandExecuted, CanShowGamesViewCommandExecute);

        private bool CanShowGamesViewCommandExecute(object? arg) => true;
        

        private void OnShowGamesViewCommandExecuted(object? obj)
        {
            CurrentModel = new GamesViewModel(gamesRepository);
        }

        #endregion

        #region Отобразить представление покупателей
        private ICommand showBuyersViewModel;
        public ICommand ShowBuyersViewModel => showBuyersViewModel
            ??= new LambdaCommand(OnShowBuyersViewCommandExecuted, CanShowBuyersViewCommandExecute);

        private bool CanShowBuyersViewCommandExecute() => true;


        private void OnShowBuyersViewCommandExecuted()
        {
            CurrentModel = new BuyersViewModel(buyersRepository);  
        }

        #endregion

        #region Отобразить представление статистики
        private ICommand showStatisticsViewModel;
        public ICommand ShowStatisticsViewModel => showStatisticsViewModel
            ??= new LambdaCommand(OnShowStatisticsViewCommandExecuted, CanShowStatisticsViewCommandExecute);

        private bool CanShowStatisticsViewCommandExecute() => true;


        private void OnShowStatisticsViewCommandExecuted()
        {
            CurrentModel = new StatisticViewModel(gamesRepository, buyersRepository, sellerRepository, dealsRepository);
        }

        #endregion

        public MainWindowViewModel
            (
            IRepository<Game> GamesRepository, 
            IRepository<Seller> Seller, 
            IRepository<Buyer> Buyer, 
            IRepository<Deal> Deal,
            ISalesService SalesService)
        {
            gamesRepository = GamesRepository;
            salesService = SalesService;
            dealsRepository = Deal;

            //var deals_count_before = SalesService.Deals.Count();


            var game = GamesRepository.Get(5);
            var buyer = Buyer.Get(3);
            var seller = Seller.Get(7);

            var deal = SalesService.MakeADeal(game.Name, seller, buyer, 2000m);

            //var deals_count_after = SalesService.Deals.Count();


        }


    }
}
