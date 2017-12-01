using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernUIWithCaliburnMicro.ViewModels;
using System.Windows;

namespace ModernUIWithCaliburnMicro
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer container;

        public Bootstrapper()
        {
            Initialize();
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
        }

        protected override void Configure()
        {
            try
            {
                container = new SimpleContainer();
                container.Instance(container);
                container.Singleton<IWindowManager, WindowManager>();
                container.Singleton<IEventAggregator, EventAggregator>();

                try
                {
                    container.Singleton<MainWindowViewModel>();
                    container.Singleton<HomeViewModel>();
                    container.Singleton<SettingsViewModel>();
                    container.Singleton<SettingsAppearanceViewModel>();
                }
                catch (Exception error)
                {
                    throw error;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("MyHandler caught : " + e.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
        }
    }
}
