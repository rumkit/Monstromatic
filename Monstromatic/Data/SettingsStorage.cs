using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Monstromatic.Extensions;
using Monstromatic.Models;
using Monstromatic.Utils;

namespace Monstromatic.Data
{
    public class SettingsStorage : IDataStorage<MonstromaticSettings>
    {
        private static readonly string BasePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Monstromatic");

        private static readonly string FilePath = Path.Combine(BasePath, "settings.json");
        
        private readonly IDataStorage<MonstromaticSettings> _dataStorage = new FileDataStorage<MonstromaticSettings>(BasePath, FilePath);

        public SettingsStorage()
        {
            var settings = GetDefaultSettings();
            if (!Directory.Exists(BasePath))
                Directory.CreateDirectory(BasePath);
            if (!File.Exists(Path.Combine(BasePath, FilePath)))
                _dataStorage.Save(data: GetDefaultSettings());
        }

        private MonstromaticSettings GetDefaultSettings()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using var stream = assembly.GetManifestResourceStream(typeof(SettingsStorage), "DefaultSettings.json") ??
                        throw new InvalidOperationException("Cannot open resources stream");
                return stream.FromJson<MonstromaticSettings>();
            }
            catch(Exception e)
            {
                throw new AppException("Failed to load settings", e);
            }
        }

        public MonstromaticSettings Read()
        { 
            return _dataStorage.Read();
        }

        public void Save(MonstromaticSettings data)
        {
            _dataStorage.Save(data);
        }
    }
}