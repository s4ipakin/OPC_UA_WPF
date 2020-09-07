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
            "Application.PLC_PRG.rSetForce",
            "Application.PLC_PRG.iSpeed",
            "Application.PLC_PRG.xStart",
            "Application.PLC_PRG.xRelease",
            "Application.PLC_PRG.diActualPosition"
        };

        public List<string> GetOPCitems()
        {
            return itemsList;
        }

    }
}
