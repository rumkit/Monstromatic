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
        
        var features = _featuresStorage.Read().ToHashSet();
        
        Features = features.Select(f =>
        {
            var incompatibleFeaturesKeys = f.IncompatibleFeaturesKeys ?? Array.Empty<string>();
            var includedFeaturesKeys = f.IncludedFeaturesKeys ?? Array.Empty<string>();
            var excludedFeaturesKeys = f.ExcludedFeaturesKeys ?? Array.Empty<string>();
            
            return new MonsterFeature()
            {
                Key = f.Key,
                DisplayName = f.DisplayName,
                DetailsDisplayName = f.DetailsDisplayName,
                LevelModifier = f.LevelModifier,
                AttackModifier = f.AttackModifier,
                DefenceModifier = f.DefenceModifier,
                Description = f.Description,
                IsHidden = f.IsHidden,
                IncompatibleFeaturesKeys = incompatibleFeaturesKeys,
                IncludedFeaturesKeys = includedFeaturesKeys,
                ExcludedFeaturesKeys = excludedFeaturesKeys,
                IncompatibleFeatures = features.Where(feature => incompatibleFeaturesKeys.Contains(feature.Key)).ToArray(),
                IncludedFeatures = features.Where(feature => includedFeaturesKeys.Contains(feature.Key)).ToArray(),
                ExcludedFeatures = features.Where(feature => excludedFeaturesKeys.Contains(feature.Key)).ToArray()
            };
        }).ToArray();
    }
}