using _2025_10_07_Boros.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_10_07_Boros.Persistence
{
    public class TextDataAccess : IDataAccess
    {
        public TextDataAccess() { }
        public async Task<ColorEventArgs> Load(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string red = await sr.ReadLineAsync() ?? string.Empty;
                    string green = await sr.ReadLineAsync() ?? string.Empty;
                    string blue = await sr.ReadLineAsync() ?? string.Empty;
                    string hexCode = await sr.ReadLineAsync() ?? string.Empty;

                    return new ColorEventArgs(int.Parse(red), int.Parse(green), int.Parse(blue), hexCode);
                }   
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task Save(string path, ColorEventArgs colors)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    await sw.WriteLineAsync(colors.Red.ToString());
                    await sw.WriteLineAsync(colors.Green.ToString());
                    await sw.WriteLineAsync(colors.Blue.ToString());
                    await sw.WriteLineAsync(colors.HexCode);
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
