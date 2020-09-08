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
                new SwarmFeature(), new ThornsFeature(), new MassAttackFeature()
            });

        public FeatureViewModel FeatureVm => new FeatureViewModel(new PredatorFeature(), new FeatureController());

        public MainWindowViewModel MainWindowVM => ServiceHub.Default.ServiceProvider.Get<MainWindowViewModel>();
    }
}
