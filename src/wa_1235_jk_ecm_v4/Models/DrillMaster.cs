using System.Web;
using wa_1235_jk_ecm_v4.Models.DecintellCommon;
using static wa_1235_jk_ecm_v4.Models.Master;

namespace wa_1235_jk_ecm_v4.Models
{
    public class DrillMaster
    {
        public DrillFileSize[] FileSize_List { get; set; }
        public ProdLineList[] ProdLine_List { get; set; }
        public LookupValues[] LookupValues_List { get; set; }
        public LookupValues[] LookupStandard_List { get; set; }
        public int ProdId { get; set; }
    }



    public class DrillFileSize
    {
        public int Id { get; set; }
        public string? RequestId { get; set; }
        public int? ProductLineId { get; set; }
        public string? ProductLine { get; set; }
        public string? DimensionCode { get; set; }
        public float? DimensionValue { get; set; }
        public int? DimensionType { get; set; }
        public string? Dimensionname { get; set; }
        public int? Standard { get; set; }
        public string? Standardname { get; set; }
        public string? FileSizeDetailsJobj { get; set; }
        public string? NewOrExisting { get; set; }
        public int GridNo { get; set; }
        public string? Remarks { get; set; }
    }

    public class ProdLineList
    {
        public int Id { get; set; }
        public string? ProductLine { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDateUtc { get; set; }
    }
    public class LookupValues
    {
        public int SrNo { get; set; }
        public int? ID { get; set; }
        public string? LookupValue { get; set; }
    }

}
