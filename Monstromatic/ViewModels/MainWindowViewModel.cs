using System.Reactive;
using Monstromatic.ViewModels.Design;
using Monstromatic.Views;
using ReactiveUI;

namespace Monstromatic.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            TestWindowCommand = ReactiveCommand.Create(OpenTestWindow);
        }

        private void OpenTestWindow()
        {
            var monster = new DesignVmLocator().DetailsVm;
            var window = new MonsterDetailsView(monster);
            window.Show();
        }

        public string Greeting => "Welcome to Avalonia!";

        public ReactiveCommand<Unit, Unit> TestWindowCommand { get; }
    }
}
