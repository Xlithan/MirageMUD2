using MirageMUD2_WPFClient.Core;

namespace MirageMUD2_WPFClient.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand NewAccViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public NewAccViewModel NewAccVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            NewAccVM = new NewAccViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            NewAccViewCommand = new RelayCommand(o =>
            {
                CurrentView = NewAccVM;
            });
        }
    }
}
