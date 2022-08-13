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
            new List<MonsterFeature>()
            {
                new MonsterFeature(){Key = "Test", DisplayName = "Test Display Name"}
            });

        public FeatureViewModel FeatureVm => new FeatureViewModel(new MonsterFeature(){Key = "Test", DisplayName = "Test Display Name"}, new FeatureController());

        public MainWindowViewModel MainWindowVM => ServiceHub.Default.ServiceProvider.Get<MainWindowViewModel>();
    }
}
