using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OpcUA_WPF.ViewModel
{
    class MainWindowModel
    {
        private ICommand _setVar;
        public ICommand SetVar
        {
            get
            {
                return _setVar ?? (_setVar = new RelayCommand(() => { }));
            }
        }

        public void WriteVar()
        {

        }
    }
}
