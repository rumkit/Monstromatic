using System.Collections.Generic;

namespace Monstromatic.ViewModels
{
    public class MonsterDetailsViewModel
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public List<string> Features { get; set; }

        public int Moral => Level;

        public int Bravery => Level;
    }
}
