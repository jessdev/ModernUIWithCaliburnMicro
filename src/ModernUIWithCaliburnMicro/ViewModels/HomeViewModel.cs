using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace ModernUIWithCaliburnMicro.ViewModels
{
    public class HomeViewModel : PropertyChangedBase
    {
        public HomeViewModel() {
            HomePageBlock = "Hello World";
        }

        protected string _homePageBlock;
        public string HomePageBlock
        {
            get { return _homePageBlock; }
            set
            {
                if (_homePageBlock == value) return;
                _homePageBlock = value;
                NotifyOfPropertyChange(() => HomePageBlock);
            }
        }
    }
}
