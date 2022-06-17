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

        public IEnumerable<Game> Games => gamesRepository.Items;

        public string TestValue { get; } = "Test Value!!!";

        public GamesViewModel() 
        {
            if (!App.IsDesignTime) 
                throw new InvalidOperationException("Данный конструктор не предназначен для использования вне дизайнера VisualStudio");
        }

        public GamesViewModel(IRepository<Game> gamesRepository)
        {
            this.gamesRepository = gamesRepository;
        }
    }
}
