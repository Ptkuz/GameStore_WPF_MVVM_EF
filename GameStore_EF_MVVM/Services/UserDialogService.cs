using GameStore.DAL.Entityes;
using GameStore.Interfaces;
using GameStore_EF_MVVM.Services.Interfaces;
using GameStore_EF_MVVM.ViewModels;
using GameStore_EF_MVVM.Views.Windows;
using System.Windows;

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

        public bool ConfirmInformation(string information, string caption) =>
            MessageBox.Show(information, caption, MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes;

        public bool ConfirmWarning(string information, string caption) =>
            MessageBox.Show(information, caption, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes;

        public bool ConfirmError(string information, string caption) =>
            MessageBox.Show(information, caption, MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes;

    }
}
