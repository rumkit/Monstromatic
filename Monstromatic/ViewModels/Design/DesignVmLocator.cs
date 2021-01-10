using System.Collections.Generic;
using Monstromatic.Models;
using Monstromatic.Utils;

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
                new SwarmFeature(), new MassAttackFeature(), new RangeAtackFeature()
            });

        public FeatureViewModel FeatureVm => new FeatureViewModel(new AnimalFeature(), new FeatureController());

        public MainWindowViewModel MainWindowVM => ServiceHub.Default.ServiceProvider.Get<MainWindowViewModel>();
    }
}
