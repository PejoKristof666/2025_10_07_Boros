using _2025_10_07_Boros.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_10_07_Boros.Persistence
{
    public interface IDataAccess
    {
        Task<ColorEventArgs> Load(string path);

        Task Save (string path, ColorEventArgs colors);
    }
}
