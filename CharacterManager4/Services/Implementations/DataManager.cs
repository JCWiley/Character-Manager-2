using CharacterManager4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager4.Services.Implementations
{
    public class DataManager : IDataManager
    {
        private IDataProvider _dataProvider;
        public DataManager(IDataProvider dataProvider) 
        {
            _dataProvider = dataProvider;
        }
    }
}
