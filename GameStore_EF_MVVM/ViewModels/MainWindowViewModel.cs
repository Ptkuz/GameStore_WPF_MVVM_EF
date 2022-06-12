using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathCore.WPF.ViewModels;

namespace GameStore_EF_MVVM.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region
        private string title = "Главное окно программы";
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        #endregion


    }
}
