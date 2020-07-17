using System.Collections.Generic;

namespace Monstromatic.ViewModels.Design
{
    public class DesignVmLocator
    {
        public MonsterDetailsViewModel DetailsVm => new MonsterDetailsViewModel()
        {
            Name = "TestName",
            Level = 5,
            Features = new List<string>(){"Особенность №1","Особенность №2","Особенность №3"}
        };
    }
}
