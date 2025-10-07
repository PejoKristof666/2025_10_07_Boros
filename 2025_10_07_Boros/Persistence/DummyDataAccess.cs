using _2025_10_07_Boros.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_10_07_Boros.Persistence
{
    public class DummyDataAccess : IDataAccess
    {
        public Task<ColorEventArgs> Load(string path)
        {
            throw new NotImplementedException();
        }
        public Task Save(string path, ColorEventArgs colors)
        {
            throw new NotImplementedException();
        }
    }
}
