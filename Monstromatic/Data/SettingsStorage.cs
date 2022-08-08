using Monstromatic.Models;

namespace Monstromatic.Data
{
    public class SettingsStorage : AppDataFileStorageBase<MonstromaticSettings>
    {
        public SettingsStorage() : base("settings.json", "DefaultSettings.json")
        { }
    }
}