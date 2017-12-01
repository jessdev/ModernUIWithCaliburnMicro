using FirstFloor.ModernUI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModernUIWithCaliburnMicro
{
    public class ModernContentLoader : DefaultContentLoader
    {
        protected override object LoadContent(Uri uri)
        {
            var content = base.LoadContent(uri);

            if (content == null) {
                return null;
            }

            // Locate the right viewmodel for the view
            var vm = Caliburn.Micro.ViewModelLocator.LocateForView(content);

            if (vm == null) return content;

            if (content is DependencyObject) {
                Caliburn.Micro.ViewModelBinder.Bind(vm, content as DependencyObject, null);
            }

            return content;
        }
    }
}
