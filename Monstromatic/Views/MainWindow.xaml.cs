﻿using System.Reactive;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Monstromatic.ViewModels;
using ReactiveUI;

namespace Monstromatic.Views
{
    public class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel?.ShowNewMonsterWindow.RegisterHandler(DoShowNewMonster)));
            this.WhenActivated(d => d(ViewModel?.ShowAboutDialog.RegisterHandler(DoShowAboutDialog)));
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        private static void DoShowNewMonster(InteractionContext<MonsterDetailsViewModel, Unit> interaction)
        {
            var dialog = new MonsterDetailsView
            {
                DataContext = interaction.Input
            };
            dialog.Show();
            interaction.SetOutput(Unit.Default);
        }
        
        private async Task DoShowAboutDialog(InteractionContext<Unit, Unit> interaction)
        {
            var dialog = new AboutWindow();
            await dialog.ShowDialog(this);
            interaction.SetOutput(Unit.Default);
        }
    }
}
