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

        #region ID книги
        private int gameId;
        public int GameId { get; }
        #endregion

        #region Название игры
        private string name;
        public string Name { get => name; set => Set(ref name, value); }
        #endregion

        public GamesEditorWindowViewModel(Game game)
        {
            GameId = game.Id;
            Name = game.Name;
        }
        



    }

}
