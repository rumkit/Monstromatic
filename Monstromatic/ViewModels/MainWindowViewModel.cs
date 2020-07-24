﻿using System;
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
using ReactiveUI.Fody.Helpers;

namespace Monstromatic.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        [Reactive]
        public bool IsGroup { get; set; }

        [Reactive]
        public int? GroupCount { get; set; }

        [Reactive]
        public string Name { get; set; }

        public IEnumerable<int> AvailableQualities => Enumerable.Range(1, 5);

        [Reactive]
        public int SelectedQuality { get; set; }

        public IEnumerable<FeatureViewModel> Features { get; }

        public SourceList<FeatureBase> SelectedFeatures { get; }

        public ReactiveCommand<Unit, Unit> TestWindowCommand { get; }

        public MainWindowViewModel()
        {
            TestWindowCommand = ReactiveCommand.Create(OpenTestWindow);
            SelectedFeatures = new SourceList<FeatureBase>();
            Features = GetFeatures();

            this.WhenAnyValue(x => x.IsGroup).Subscribe(b =>
            {
                if (!b)
                    GroupCount = null;
            });
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
    }
}
