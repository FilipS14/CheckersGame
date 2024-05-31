using CheckersProject.Utilities;
using CheckersProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CheckersProject.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private object _currentView;

        public MenuViewModel MenuView { get; } = new MenuViewModel();
        public GameViewModel GameView { get; } = new GameViewModel();
        public OptionsViewModel OptionsView { get; } = new OptionsViewModel();
        public LeaderBoardViewModel LeaderBoardView { get; } = new LeaderBoardViewModel();

        public AboutViewModel AboutView { get; } = new AboutViewModel();

        public ICommand SwitchToAboutViewCommand { get;}
        public ICommand BackFromAboutToMenuCommand { get; }
        public ICommand SwitchToGameViewCommand { get; }
        public ICommand SwitchToMenuViewCommand { get;}
        public ICommand BackFromGameToMenuCommand { get; }
        public ICommand BackFromOptionsToMenuCommand { get; }
        public ICommand BackFromLeaderBoardToMenuCommand { get; }
        public ICommand SwitchToOptionsViewCommand { get; }
        public ICommand SwitchToLeaderBoardViewCommand { get; }

        public MainViewModel()
        {
            SwitchToMenuViewCommand = new RelayCommand(SwitchToMenuView);
            SwitchToGameViewCommand = new RelayCommand(SwitchToGameView);
            SwitchToOptionsViewCommand = new RelayCommand(SwitchToOptionsView);
            SwitchToLeaderBoardViewCommand = new RelayCommand(SwitchToLeaderBoardView);
            SwitchToAboutViewCommand = new RelayCommand(SwitchToAboutView);
            BackFromAboutToMenuCommand = new RelayCommand(BackFromAboutToMenu);
            BackFromGameToMenuCommand = new RelayCommand(BackFromGameToMenu);
            BackFromOptionsToMenuCommand = new RelayCommand(BackFromOptionsToMenu);
            BackFromLeaderBoardToMenuCommand = new RelayCommand(BackFromLeaderBoardToMenu);
            CurrentView = MenuView;
        }

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        private void SwitchToMenuView(object parameter) => CurrentView = MenuView;
        private void SwitchToGameView(object parameter) => CurrentView = GameView;
        private void SwitchToOptionsView(object parameter) => CurrentView = OptionsView;
        private void SwitchToLeaderBoardView(object parameter) => CurrentView = LeaderBoardView;
        private void BackFromGameToMenu(object parameter) => CurrentView = MenuView;
        private void BackFromOptionsToMenu(object parameter) => CurrentView = MenuView;
        private void BackFromLeaderBoardToMenu(object parameter) => CurrentView = MenuView;
        private void BackFromAboutToMenu(object parameter) => CurrentView = MenuView;
        private void SwitchToAboutView(object parameter) => CurrentView = AboutView;

    }
}
