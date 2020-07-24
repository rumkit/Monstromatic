using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reflection;
using DynamicData;
using Monstromatic.Models;
using Monstromatic.ViewModels.Design;
using Monstromatic.Views;
using ReactiveUI;

namespace Monstromatic.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public IEnumerable<FeatureViewModel> Features { get; }

        public SourceList<FeatureBase> SelectedFeatures { get; }

        public MainWindowViewModel()
        {
            TestWindowCommand = ReactiveCommand.Create(OpenTestWindow);
            SelectedFeatures = new SourceList<FeatureBase>();
            Features = GetFeatures();
        }

        private IEnumerable<FeatureViewModel> GetFeatures()
        {
            var features = Assembly.GetCallingAssembly().GetTypes()
                .Where(t => t.BaseType == typeof(FeatureBase))
                .Select(t => Activator.CreateInstance(t) as FeatureBase);

            return features
                .Where(f => f != null)
                .Select(f => new FeatureViewModel(f, SelectedFeatures));
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
