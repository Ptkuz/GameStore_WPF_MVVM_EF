using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathCore.WPF.ViewModels;
using GameStore.Interfaces;
using GameStore.DAL.Entityes;

namespace GameStore_EF_MVVM.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly IRepository<Game> gamesRepository;

        #region Title
        private string title = "Главное окно программы";
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        #endregion

        public MainWindowViewModel(IRepository<Game> GamesRepository) 
        { 
            gamesRepository = GamesRepository;

            var game = GamesRepository.Items.Take(10).ToArray();
        }


    }
}
