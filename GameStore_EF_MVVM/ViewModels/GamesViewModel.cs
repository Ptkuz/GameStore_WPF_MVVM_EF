using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entityes;
using GameStore.Interfaces;
using MathCore.WPF.ViewModels;

namespace GameStore_EF_MVVM.ViewModels
{
    internal class GamesViewModel : ViewModel
    {
        private readonly IRepository<Game> gamesRepository;

        public GamesViewModel(IRepository<Game> gamesRepository)
        {
            this.gamesRepository = gamesRepository;
        }
    }
}
