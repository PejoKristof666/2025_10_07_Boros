using _2025_10_07_Boros.Model;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_10_07_Boros.ViewModel
{
    public class ColorPickerViewModel : ViewModelBase
    {
        public int _red;
        public int _green;
        public int _blue;

        private ColorPickerModel _model;
        public int Red { get { return _red; } set { if(_model.Red != value) { _red = value; OnPropertyChanged(nameof(Red)); } } }
        public int Green { get { return _green; } set { if (_model.Green != value) { _green = value; OnPropertyChanged(nameof(Green)); } } }
        public int Blue { get { return _blue; } set { if (_model.Blue != value) { _blue = value; OnPropertyChanged(nameof(Blue)); } } }

        private string _color;
        private string _text;

        public string ButtonText { get { return _text; } set { if (_text != value) { _text = value; OnPropertyChanged(nameof(ButtonText)); } } }
        public string ButtonColor { get { return _color; } set { if (_color != value) { _color = value; OnPropertyChanged(nameof(ButtonColor)); } } }

        public RelayCommand PickColorCommand { get; private set; }
        public RelayCommand<string> MenuCommand { get; private set; }

        public event EventHandler? ExitEvent;
        public event EventHandler? SaveEvent;
        public event EventHandler? LoadEvent;

        public ColorPickerViewModel(ColorPickerModel model)
        {
            _model = model;
            PickColorCommand = new RelayCommand(PickColor);
            MenuCommand = new RelayCommand<string>(MenuOption);
            _model.ColorChanged += OnColorChanged;
        }

        private void OnColorChanged(object? sender, ColorEventArgs e)
        {
            Red = e.Red;
            Green = e.Green;
            Blue = e.Blue;
            ButtonText = e.HexCode;
            ButtonColor = e.HexCode;
        }

        private void MenuOption(string? option)
        {
            switch (option)
            {
                case "RESET": _model.ResetColors(); break;
                case "SAVE": SaveEvent?.Invoke(this, new EventArgs()); break;
                case "LOAD": LoadEvent?.Invoke(this, new EventArgs()); break;
                case "EXIT": ExitEvent?.Invoke(this, new EventArgs()); break;
            }
        }

        public void PickColor()
        {
            _model.ChangeColorValues(Red, Green, Blue);
        }
    }
}
