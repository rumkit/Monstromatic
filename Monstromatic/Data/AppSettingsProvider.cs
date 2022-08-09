using System;
using System.Collections.Generic;
using System.Linq;
using Monstromatic.Models;

namespace Monstromatic.Data;

public interface IAppSettingsProvider
{
    MonstromaticSettings Settings { get; }
    IEnumerable<MonsterFeature> Features { get; }
    void Reload();
}

public class AppSettingsProvider : IAppSettingsProvider
{
    private readonly IDataStorage<MonstromaticSettings> _settingsStorage;
    private readonly IDataStorage<MonsterFeature[]> _featuresStorage;
    
    public MonstromaticSettings Settings { get; private set; }
    public IEnumerable<MonsterFeature> Features { get; private set; }

    public AppSettingsProvider(IDataStorage<MonstromaticSettings> settingsStorage, IDataStorage<MonsterFeature[]> featuresStorage)
    {
        _settingsStorage = settingsStorage;
        _featuresStorage = featuresStorage;
        Reload();
    }

    public void Reload()
    {
        Settings = _settingsStorage.Read();
        
        var features = _featuresStorage.Read().ToDictionary(feature => feature.Key);
        
        //todo: there is should be an error handling mechanism
        foreach (var feature in features.Values)
        {
            feature.IncludedFeatures = feature.IncludedFeaturesKeys.Select(key => features[key]).ToArray();
            feature.ExcludedFeatures = feature.ExcludedFeaturesKeys.Select(key => features[key]).ToArray();
            feature.IncompatibleFeatures = feature.IncompatibleFeaturesKeys.Select(key => features[key]).ToArray();
        }

        Features = features.Values;
    }
}