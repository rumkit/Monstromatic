using System;
using System.Collections.Generic;
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
                _dataStore.Save(data: GetDefaultSettings());
        }

        private MonstromaticSettings GetDefaultSettings()
        {
            return new MonstromaticSettings()
            {
                MonsterQualities = new Dictionary<string, int>()
                {
                    { "Слабый", 1 }, { "Обыватель", 2 },{ "Элита/Спец", 3 },{ "Сюжетный/Mary Sue", 4 },{ "Каноничный", 5 },
                }
            };
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