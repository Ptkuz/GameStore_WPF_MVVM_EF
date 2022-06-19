using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore_EF_MVVM.Services.Interfaces;
using GameStore.DAL.Entityes;
using GameStore_EF_MVVM.ViewModels;
using GameStore_EF_MVVM.Views.Windows;

namespace GameStore_EF_MVVM.Services
{
    internal class UserDialogService : IUserDialog
    {
        public bool Edit(Game game) 
        {
            var game_editor_model = new GamesEditorWindowViewModel(game);
            var game_editor_window = new GamesEditorWindow()
            {
                DataContext = game_editor_model
            };
            var dw = game_editor_window.ShowDialog();

            if (dw != true) return false;

            game.Name = game_editor_model.Name;

            return true;
        }
    }
}
