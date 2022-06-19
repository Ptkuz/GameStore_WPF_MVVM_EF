using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore_EF_MVVM.Services.Interfaces;
using GameStore.DAL.Entityes;
using GameStore_EF_MVVM.ViewModels;
using GameStore_EF_MVVM.Views.Windows;
using GameStore.Interfaces;

namespace GameStore_EF_MVVM.Services
{
    internal class UserDialogService : IUserDialog
    {
        public bool Edit(           
            IRepository<Category> categoriesRepository, 
            IRepository<Developer> developersRepository,
            Game game) 
        {
            var game_editor_model = new GamesEditorWindowViewModel(categoriesRepository, developersRepository, game);
            var game_editor_window = new GamesEditorWindow()
            {
                DataContext = game_editor_model
            };

            if (game_editor_window.ShowDialog() != true) return false;

            game.Name = game_editor_model.Name;
            game.ReleaseDate = game_editor_model.ReleaseDate;
            game.Category = game_editor_model.SelectedCategory;
            game.Developer = game_editor_model.SelectedDeveloper;

            return true;
        }
    }
}
