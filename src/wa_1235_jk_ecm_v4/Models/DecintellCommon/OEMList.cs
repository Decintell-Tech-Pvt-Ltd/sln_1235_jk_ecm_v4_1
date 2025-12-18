using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_1235_jk_ecm_v4.Models.DecintellCommon
{
    public class OEMList
    {
        public List<OEM_List> oemlist { get; set; }
    }

    public class OEM_List
    {
        public int OEMID { get; set; }
        public string OEMName { get; set; }
        public string OEMAcronym { get; set; }
        public string ComboOEMIDOEMName => $"{OEMID}-{OEMName}";

    }
}
