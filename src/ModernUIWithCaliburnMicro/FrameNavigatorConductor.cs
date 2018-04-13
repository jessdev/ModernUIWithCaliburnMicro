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
    public class FrameNavigationConductor
    {
        #region Properties

        // Keep a ref to the frame
        private readonly ModernFrame _frame;

        // Keep this to handle NavigatingFrom and NavigatedFrom events as this functionality
        // is usually wrapped in the frame control and it doesn't pass the 'old content' in the
        // event args
        private IContent _navigatingFrom;

        #endregion

        public FrameNavigationConductor(IViewAware modernWindowViewModel)
        {
            // Find the frame by looking in the control template of the window
            _frame = FindFrame(modernWindowViewModel);

            if (_frame != null)
            {
                // Wire up the events
                _frame.FragmentNavigation += Frame_FragmentNavigation;
                _frame.Navigated += Frame_Navigated;
                _frame.Navigating += Frame_Navigating;
            }
        }

        #region Navigation Events

        void Frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            var content = GetIContent(_frame.Content);

            if (content != null)
            {
                _navigatingFrom = content;
                _navigatingFrom.OnNavigatingFrom(e);
            }
            else {
                _navigatingFrom = null;
            }
        }

        void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            var content = GetIContent(_frame.Content);

            if (content != null) {
                content.OnNavigatedTo(e);
            }

            if (_navigatingFrom != null) {
                _navigatingFrom.OnNavigatedFrom(e);
            }
        }

        void Frame_FragmentNavigation(object sender, FragmentNavigationEventArgs e)
        {
            var content = GetIContent(_frame.Content);

            if (content != null) {
                content.OnFragmentNavigation(e);
            }
        }

        #endregion

        #region Helpers

        protected ModernFrame FindFrame(IViewAware viewAware)
        {
            // Get the view for the window
            var view = viewAware.GetView() as Control;

            if (view != null)
            {
                // Find the frame by name in the template
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
            // Try to cast the datacontext of the attached viewmodel to IContent
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
