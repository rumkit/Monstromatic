using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Text.Json;
using Monstromatic.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Monstromatic.ViewModels
{
    public class MonsterDetailsViewModel : ViewModelBase
    {
        [Reactive] public string Name { get; set; }

        private int _level;

        public int Level
        {
            get => _level + GetResultLevelModifier();
            set => this.RaiseAndSetIfChanged(ref _level, value);
        }

        public IEnumerable<FeatureBase> DescriptiveFeatures =>
            Features.Where(f => !string.IsNullOrEmpty(f.Description));

        public List<FeatureBase> Features { get; set; }

        [Reactive] public int Attack { get; set; }

        [Reactive] public int Defence { get; set; }

        [Reactive] public int Stamina { get; set; }

        [Reactive] public bool HasAdvantage { get; set; }

        [Reactive] public bool HasDisadvantage { get; set; }

        [Reactive] public int HitCounter { get; set; }

        [Reactive] public bool IsGroup { get; set; }

        public ReactiveCommand<Unit, Unit> ResetDefenceCounterCommand { get; }
        public ReactiveCommand<Unit, Unit> ResetAttackCounterCommand { get; }
        public ReactiveCommand<Unit, Unit> ResetStaminaCounterCommand { get; }

        public ReactiveCommand<Unit, Unit> SaveMonsterCommand { get; }

        private int AttackModifier => Features.Sum(f => f.AttackModifier) + 1;

        private int DefenceModifier => Features.Sum(f => f.DefenceModifier) + 1;

        public MonsterDetailsViewModel()
        {
            Features = new List<FeatureBase>();

            this.WhenAnyValue(x => x.HasAdvantage).Subscribe(x =>
            {
                if (x)
                    HasDisadvantage = false;
                this.RaisePropertyChanged(nameof(Level));
             });

            this.WhenAnyValue(x => x.HasDisadvantage).Subscribe(x =>
            {
                if (x)
                    HasAdvantage = false;
                this.RaisePropertyChanged(nameof(Level));
            });

            this.WhenAnyValue(x => x.IsGroup).Subscribe(x =>
            {
                if (x)
                    Features.Add(new GroupFeature());
                else
                    Features.Remove(new GroupFeature());
                
                this.RaisePropertyChanged(nameof(DescriptiveFeatures));
                this.RaisePropertyChanged(nameof(Level));
            });

            this.WhenAnyValue(x => x.Level).Subscribe(_ => SetCounterDefaults());

            ResetDefenceCounterCommand = ReactiveCommand.Create(ResetDefence);
            ResetAttackCounterCommand = ReactiveCommand.Create(ResetAttack);
            ResetStaminaCounterCommand = ReactiveCommand.Create(ResetStamina);
            SaveMonsterCommand = ReactiveCommand.Create(SaveMonster);
        }
        
        public MonsterDetailsViewModel(string name, int baseLevel, IEnumerable<FeatureBase> features) : this()
        {
            Features.AddRange(features);
            Name = name;
            Level = baseLevel;
            SetCounterDefaults();
        }
        
        private void SetCounterDefaults()
        {
            ResetAttack();
            ResetDefence();
            ResetStamina();
        }

        private void ResetDefence()
        {
            Defence = Level * DefenceModifier;
        }

        private void ResetAttack()
        {
            Attack = Level * AttackModifier;
        }

        private void ResetStamina()
        {
            Stamina = Features.Contains(new RegenerationFeature()) ? Defence * 2 + Level : Defence * 2;
        }
        
        private void SaveMonster()
        {
            var monster = new Monster(Name, _level, Features.Select(f => f.Id).ToList());
            var jsonString = JsonSerializer.Serialize(monster);
            File.WriteAllText(@"C:\Users\anton\Downloads\test.monster", jsonString);
        }
        
        private int GetResultLevelModifier()
        {
            var advantageModifier = (HasAdvantage ? 1 : 0) - (HasDisadvantage ? 1 : 0);
            var featuresModifier = Features.Sum(f => f.LevelModifier);
            return advantageModifier + featuresModifier;
        }
    }
}
