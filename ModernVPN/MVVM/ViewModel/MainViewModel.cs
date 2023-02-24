using ModernVPN.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModernVPN.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        /* Commands */
        public RelayCommand MoveWindowCommand { get; set; }

        public RelayCommand ShutdownWindowCommand { get; set; }

        public RelayCommand MaximizeWindowCommand { get; set; }

        public RelayCommand MinimizeWindowCommand { get; set; }

        public RelayCommand ShowProtectionView { get; set; }

        public RelayCommand ShowSettingView { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                OnPropertyChanged();
            }
        }

        public ProtectionViewModel ProtectionVM { get; set; }

        public SettingViewModel SettingVM { get; set; }

        public MainViewModel()
        {
            //Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            ProtectionVM = new ProtectionViewModel();
            SettingVM = new SettingViewModel();
            CurrentView = ProtectionVM;

            MoveWindowCommand = new RelayCommand(o =>
              {
                  Application.Current.MainWindow.DragMove();
              });

            ShutdownWindowCommand = new RelayCommand(o =>
            {
                Application.Current.Shutdown();
            });

            MaximizeWindowCommand = new RelayCommand(o =>
            {
                if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                {
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                }
                else
                {
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                }
            });

            MinimizeWindowCommand = new RelayCommand(o =>
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            });

            ShowProtectionView = new RelayCommand(o => { CurrentView = ProtectionVM; });
            ShowSettingView = new RelayCommand(o => { CurrentView = SettingVM; });
        }
    }
}
