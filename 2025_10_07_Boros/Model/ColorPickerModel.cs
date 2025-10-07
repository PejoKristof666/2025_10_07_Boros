using _2025_10_07_Boros.Persistence;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_10_07_Boros.Model
{
    public class ColorPickerModel
    {
        private IDataAccess _access;
        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }

        public event EventHandler<ColorEventArgs>? ColorChanged;

        public ColorPickerModel(IDataAccess access)
        {
            _access = access;
            ChangeColorValues(0, 0, 0);
        }

        public void ChangeColorValues(int red, int green, int blue)
        {
            Red = 0;
            Green = 0;
            Blue = 0;

            if (red >= 0 && red <= 255) Red = red;
            if (green >= 0 && green <= 255) Green = green;
            if (blue >= 0 && blue <= 255) Blue = blue;

            OnColorChange(GenerateHexCode());
        }

        public string GenerateHexCode()
        {
            var color = Color.FromArgb(Red,Green,Blue);
            string colorHexCode = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");

            return colorHexCode;
        }   

        public void OnColorChange(string hexCode)
        {
            ColorChanged?.Invoke(this, new ColorEventArgs(Red,Green,Blue, hexCode));

        }

        public void ResetColors()
        {
            ChangeColorValues(0, 0, 0);
        }

        public void Save(string filename)
        {
            _access.Save(filename, new ColorEventArgs(Red,Green,Blue,GenerateHexCode()));
        }

        public async Task Load(string filename)
        {
            ColorEventArgs newColors = await _access.Load(filename);
            ChangeColorValues(newColors.Red, newColors.Green, newColors.Blue);
        }
    }
}
