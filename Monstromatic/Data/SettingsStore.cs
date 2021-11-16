using System;
using System.IO;
using System.Threading.Tasks;

namespace Monstromatic.Data
{
    public class SettingsStore : IDataStore<MonstromaticSettings>
    {
        private static readonly string BasePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Monstromatic");

        private static readonly string FilePath = Path.Combine(BasePath, "settings.json");
        
        private readonly IDataStore<MonstromaticSettings> _dataStore = new FileDataStore<MonstromaticSettings>(BasePath, FilePath);

        public SettingsStore()
        {
            if (!Directory.Exists(BasePath))
                Directory.CreateDirectory(BasePath);
            if (!File.Exists(Path.Combine(BasePath, FilePath)))
                _dataStore.Save(new MonstromaticSettings());
        }

        public MonstromaticSettings Read()
        { 
            return _dataStore.Read();
        }

        public void Save(MonstromaticSettings data)
        {
            _dataStore.Save(data);
        }
    }
}