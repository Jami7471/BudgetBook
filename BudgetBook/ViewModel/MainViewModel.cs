using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(MainModel mainModel)
        {
            _mainModel = mainModel;
        }

        private readonly MainModel _mainModel;
        private RelayCommand? _closeCommand;

        public RelayCommand CloseCommand
        {
            get
            {
                _closeCommand ??= new RelayCommand(excute => CloseApplication());
                return _closeCommand;
            }
            set
            {
                if (value != CloseCommand)
                {
                    _closeCommand = value;
                    OnPropertyChanged();
                }
            }
        }

        private void CloseApplication()
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
