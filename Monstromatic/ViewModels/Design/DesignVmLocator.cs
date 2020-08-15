using System.Collections.Generic;
using System.Collections.ObjectModel;
using DynamicData;
using Monstromatic.Models;

namespace Monstromatic.ViewModels.Design
{
    public class DesignVmLocator
    {
        public MonsterDetailsViewModel DetailsVm => new MonsterDetailsViewModel()
        {
            Name = "TestName",
            Level = 5,
            Features = new List<FeatureBase>(){new AnimalFeature(), new PowerfulAttackFeature(), new PredatorFeature()}
        };

        public FeatureViewModel FeatureVm => new FeatureViewModel(new PredatorFeature(), new SourceList<FeatureBase>());
    }
}
