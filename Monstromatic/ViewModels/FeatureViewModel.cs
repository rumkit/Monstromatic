using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using DynamicData;
using DynamicData.Binding;
using Monstromatic.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Monstromatic.ViewModels
{
    public class FeatureViewModel : ViewModelBase
    {
        private readonly FeatureBase _feature;
        private readonly SourceList<FeatureBase> _selectedFeatures;

        public string Id => _feature.Id;

        public string DisplayName => _feature.DisplayName;

        public bool IsFeatureSelected { [ObservableAsProperty] get; }

        public FeatureViewModel(FeatureBase feature, SourceList<FeatureBase> selectedFeatures)
        {
            _feature = feature;
            _selectedFeatures = selectedFeatures;

            var canAddFeature = _selectedFeatures
                .Connect()
                .QueryWhenChanged(CanAddFeature);

            canAddFeature = canAddFeature.StartWith(true);

            AddFeatureCommand = ReactiveCommand.Create<bool>(AddFeature, canAddFeature);

            _selectedFeatures
                .Connect()
                .QueryWhenChanged(x => x.Contains(_feature))
                .ToPropertyEx(this, x => x.IsFeatureSelected);
        }

        private bool CanAddFeature(IReadOnlyCollection<FeatureBase> selectedFeatures)
        {
            var containsIncompatibleFeatures = selectedFeatures.Any(
                f => _feature.IncompatibleFeatures.Contains(f.Id));

            return !containsIncompatibleFeatures;
        }

        private void AddFeature(bool isChecked)
        {
            if (isChecked)
                _selectedFeatures.Add(_feature);
            else
                _selectedFeatures.Remove(_feature);
        }

        public ReactiveCommand<bool, Unit> AddFeatureCommand { get; }
    }
}