using CM4_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_Core.DataAccess
{
    public interface IDataAccess
    {
        public string StoragePath { get; set; }
        public ICharacterAccess CA { get;}

        public bool CreateDB();
    }
}
