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
    }
}
