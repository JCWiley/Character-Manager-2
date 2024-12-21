using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterManager4.Services.Interfaces;

namespace CharacterManager4.Services.Implementations
{
    public class HardcodedSettings : ISettings
    {
        public string DbPath => "C:\\Users\\JWiley\\source\\CM\\CharacterManager4\\DevData\\testdb.db";
    }
}
