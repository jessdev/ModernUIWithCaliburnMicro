using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;
using System.Windows;
using System.Windows.Controls;

namespace ModernUIWithCaliburnMicro
{
    public class FrameNavigatorConductor
    {
        private readonly ModernFrame _frame;
        private IContent _navigationFrom;

        public FrameNavigatorConductor(IViewAware modernWindowViewModel)
        {
            _frame = FindFrame(modernWindowViewModel);

            if (_frame != null) {
                _frame.FragmentNavigation += frame_FragmentNavigation;
                _frame.Navigated += frame_Navigated;
                _frame.Navigating += frame_Navigating;
            }
        }

        #region Navigation Events
        void frame_Navigating(object sender, NavigatingCancelEventArgs e) {
            var content = GetIContent(_frame.Content);

            if (content != null) {
                _navigationFrom = content;
                _navigationFrom.OnNavigatingFrom(e);
            }
            else
            {
                _navigationFrom = null;
            }
        }

        void frame_Navigated(object sender, NavigationEventArgs e) {
            var content = GetIContent(_frame.Content);

            if (content != null)
            {
                content.OnNavigatedTo(e);
            }
            else
            {
                _navigationFrom.OnNavigatedFrom(e);
            }
        }

        void frame_FragmentNavigation(object sender, FragmentNavigationEventArgs e) {
            var content = GetIContent(_frame.Content);

            if (content != null) {
                content.OnFragmentNavigation(e);
            }
        }

        #endregion

        #region Helpers
        protected ModernFrame FindFrame(IViewAware viewAware)
        {
            var view = viewAware.GetView() as Control;

            if (view != null)
            {
                var frame = view.Template.FindName("ContentFrame", view) as ModernFrame;

                if (frame != null)
                {
                    return frame;
                }
            }

            return null;
        }

        protected IContent GetIContent(object source)
        {
            var frameworkElement = (source as FrameworkElement);

            if (frameworkElement != null)
            {
                var content = frameworkElement.DataContext as IContent;

                if (content != null)
                {
                    return content;
                }
            }

            return null;
        }

        #endregion
    }
}
