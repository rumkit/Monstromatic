using System;
using System.Collections.Generic;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Monstromatic.ViewModels
{
    public class MonsterDetailsViewModel : ReactiveObject
    {
        [Reactive]
        public string Name { get; set; }

        private int _level;

        public int Level
        {
            get => _level + GetLevelModifier();
            set => this.RaiseAndSetIfChanged(ref _level, value);
        }

        public List<string> Features { get; set; }

        public int Moral { [ObservableAsProperty] get; }

        public int Bravery { [ObservableAsProperty] get; }

        [Reactive]
        public bool HasAdvantage { get; set; }

        [Reactive]
        public bool HasDisadvantage { get; set; }

        public MonsterDetailsViewModel()
        {
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

            this.WhenAnyValue(x => x.Level).ToPropertyEx(this, x => x.Moral);
            this.WhenAnyValue(x => x.Level).ToPropertyEx(this, x => x.Bravery);
        }

        private int GetLevelModifier()
        {
            return (HasAdvantage ? 1 : 0) - (HasDisadvantage ? 1 : 0);
        }
    }
}
