using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPC_DA_Test
{
    class ListOfItemsOPC
    {
        List<string> itemsList = new List<string>()
        {
            "Application.PLC_PRG.val10",
            "Application.PLC_PRG.val11",
            "Application.PLC_PRG.val12"            
        };

        public List<string> GetOPCitems()
        {
            return itemsList;
        }

    }
}
