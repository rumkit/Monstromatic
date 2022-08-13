using System.Collections.Generic;
using Monstromatic.Models;
using Monstromatic.Utils;

namespace Monstromatic.Data
{
    public class SettingsStorage : AppDataFileStorageBase<MonstromaticSettings>
    {
        public SettingsStorage() : base(StorageHelper.ApplicationSettingsFileName, "DefaultSettings.json")
        { }

        protected override MonstromaticSettings GetDefaultValue()
        {
            return new MonstromaticSettings()
            {
                MonsterQualities = new Dictionary<string, int>()
            };
        }
    }
}