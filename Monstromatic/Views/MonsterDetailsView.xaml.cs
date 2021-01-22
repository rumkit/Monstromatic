using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.VisualTree;

namespace Monstromatic.Views
{
    public class MonsterDetailsView : Window
    {
        private double _expanderHeight = 0;
        private bool _isExpanded = true;

        public MonsterDetailsView()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        public MonsterDetailsView(object context) : this()
        {
            this.DataContext = context;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnOpened(EventArgs e)
        {
            base.OnOpened(e);
            UpdateWindowMeasureAsync();
            FillColorSelector();
        }

        private void FillColorSelector()
        {
            var colorSelector = this.FindControl<ComboBox>("ColorSelector");
            var header = this.FindControl<Grid>("WindowHeaderGrid");
            var colors = new List<IBrush>
            {
                header.Background,
                Brushes.CornflowerBlue,
                Brushes.Red,
                Brushes.Brown,
                Brushes.DarkOrange,
                Brushes.Green,
                Brushes.Yellow,
                Brushes.Violet,
                Brushes.DarkGreen
            };

            colorSelector.Items = colors;
            colorSelector.SelectedIndex = 0;
        }

        private void ColorSelectorOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var header = this.FindControl<Grid>("WindowHeaderGrid");
            var colorSelector = this.FindControl<ComboBox>("ColorSelector");
            header.Background = (IBrush)colorSelector.SelectedItem;
        }

        public void Header_PointerPressed(object o, PointerPressedEventArgs e)
        {
            if(e.Source is Grid {Name: "WindowHeaderGrid"})
                this.BeginMoveDrag(e as PointerPressedEventArgs);
        }

        public void CloseButton_Click(object o, RoutedEventArgs e)
        {
            this.Close();
        }

        public void ExpandButton_Click(object o, RoutedEventArgs e)
        {
            var expanderGrid = this.FindControl<Grid>("ExpanderGrid");

            if (_isExpanded)
            {
                _expanderHeight = expanderGrid.Bounds.Height;
                expanderGrid.Height = 0;
            }
            else
            {
                expanderGrid.Height = _expanderHeight;
            }

            _isExpanded = !_isExpanded;

            AnimateButton(o as IVisual, _isExpanded);
            UpdateWindowMeasureAsync();
        }

        private void AnimateButton(IVisual button, in bool isExpanded)
        {
            if (button?.RenderTransform is RotateTransform transform) 
                transform.Angle = isExpanded? 0 : 180;
        }

        // Dirty hack to update window height
        private async void UpdateWindowMeasureAsync()
        {
            await Task.Delay(100);
            this.InvalidateMeasure();
        }
    }
}
