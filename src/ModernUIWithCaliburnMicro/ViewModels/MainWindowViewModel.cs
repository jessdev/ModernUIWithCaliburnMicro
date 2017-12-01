using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace ModernUIWithCaliburnMicro.ViewModels
{
    public class MainWindowViewModel : Conductor<IScreen>.Collection.OneActive
    {
        ModernUIWithCaliburnMicro.FrameNavigationConductor _navigation;

        public MainWindowViewModel() { }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            // Find the frame to attach to for navigation
            _navigation = new FrameNavigationConductor(this);
        }
    }
}
