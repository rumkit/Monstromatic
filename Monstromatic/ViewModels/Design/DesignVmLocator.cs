using System.Collections.Generic;
using System.Collections.ObjectModel;
using DynamicData;
using Monstromatic.Models;

namespace Monstromatic.ViewModels.Design
{
    public class DesignVmLocator
    {
        public MonsterDetailsViewModel DetailsVm => new MonsterDetailsViewModel(
            "TestName",
            5,
            new List<FeatureBase>()
            {
                new AnimalFeature(), new PowerfulAttackFeature(), new FlyingFeature(),
                new SwarmFeature(), new ThornsFeature(), new MassAttackFeature()
            },
            55);

        public FeatureViewModel FeatureVm => new FeatureViewModel(new PredatorFeature(), new SourceList<FeatureBase>());
    }
}
