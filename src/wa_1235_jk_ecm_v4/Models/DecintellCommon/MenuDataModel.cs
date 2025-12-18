namespace wa_1235_jk_ecm_v4.Models.DecintellCommon
{

    public class MenuDataModel
    {
        public object id { get; set; }
        public int PageType { get; set; }
        public int ModuleId { get; set; }
        public int PageId { get; set; }
        public int ParentId { get; set; }
        public string href { get; set; }
        public string label { get; set; }
        public object[] ul { get; set; }

    }

}
