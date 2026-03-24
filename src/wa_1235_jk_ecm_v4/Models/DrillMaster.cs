using System.Text.Json.Serialization;
using System.Web;
using wa_1235_jk_ecm_v4.Models.DecintellCommon;
using static wa_1235_jk_ecm_v4.Models.Master;

namespace wa_1235_jk_ecm_v4.Models
{
    public class DrillMaster
    {
        public SubtypeDD[] SubtypeDD { get; set; }
        public CTStampDetails[] CTStampDetails { get; set; }
        public SizeModalList[] SizeModalList { get; set; }

        public DrillFileSize[] FileSize_List { get; set; }
        public ProdLineList[] ProdLine_List { get; set; }
        public TypeParameterList[] TypeParameterList { get; set; }
        public KeyDimensionList[] KeyDimensionList { get; set; }
        public CTTypeSizeTableData[] CTTypeSizeTableData { get; set; }
        public DrillFileSize[] DrillFileSize { get; set; }
        public CTCSVData[] CTCSVData { get; set; }


        public int ProdId { get; set; }
        public int Id { get; set; }
        public int SizeID { get; set; }

        public LookupValues[] LookupValues_List { get; set; }
        public LookupValues[] LookupStandard_List { get; set; }
        public TypeList[] FileType_List { get; set; }
        public FileTypeMaster[] FileTypeMasters { get; set; }
        public TypeDropdown[] TypeDropdown { get; set; }
        public Brand[] Brand_List { get; set; }
        public int BrandId { get; set; }
        public string? BrandCode { get; set; }
        public int SubTypeId { get; set; }
        public GetSizeList[] GetSizeList { get; set; }
        public SubTypeList[] SubTypeList { get; set; }
        public DrawingDetails[] DrawingDetails { get; set; }
        public TypeParamByIDList[] TypeParamByIDList { get; set; }

        public CTSubTypeParameterList[] CTSubTypeParameterList { get; set; }

    }


    public class CTTypeSizeTableData
    {
        public int Id { get; set; }
        public int ProductLineRowId { get; set; }
        public string ProductLineName { get; set; }
        public int CTTypeRowId { get; set; }
        public string CTTypeName { get; set; }
        public string SizeCode { get; set; }
        public string ParamName { get; set; }
        public string ParamCode { get; set; }

        public float SizeValue { get; set; }
        public string SizeUOM { get; set; }
        public string CTSizeDetailsJobj { get; set; }
        public string StatusJobj { get; set; }
        public string StatusHistoryJarr { get; set; }
    }


    public class CTCSVData
    {

        public int ProcessSequence { get; set; }
        public string ProcessName { get; set; }
        public string ParamCode { get; set; }
        public string ParamName { get; set; }
        public string ParamUOM { get; set; }
        public int RangeValue { get; set; }
        public int NominalValue { get; set; }
        public int KeyDimension { get; set; }
    }


    public class DrillFileSize
    {
        public int Id { get; set; }
        public string RequestId { get; set; }
        public int ProductLineRowId { get; set; }
        public string ProductLine { get; set; }
        public int CTTypeRowId { get; set; }
        public string CTTypeName { get; set; }
        public string SizeCode { get; set; }
        public float SizeValue { get; set; }
        public string SizeUOM { get; set; }
        public string ParamName { get; set; }
        public string ParamCode { get; set; }
        public object Standard { get; set; }
        public object StandardName { get; set; }
        public string CTSizeDetailsJobj { get; set; }
        public string NewOrExisting { get; set; }
        public int GridNo { get; set; }
        public object Remarks { get; set; }
    }


    //public class DrillFileSize
    //{
    //    public int Id { get; set; }
    //    public string? RequestId { get; set; }
    //    public int? ProductLineId { get; set; }
    //    public string? ProductLine { get; set; }
    //    public string? DimensionCode { get; set; }
    //    public float? DimensionValue { get; set; }
    //    public int? DimensionType { get; set; }
    //    public string? Dimensionname { get; set; }
    //    public int? Standard { get; set; }
    //    public string? Standardname { get; set; }
    //    public string? FileSizeDetailsJobj { get; set; }
    //    public string? NewOrExisting { get; set; }
    //    public int GridNo { get; set; }
    //    public string? Remarks { get; set; }
    //}





    public class SizeModalList
    {
        public int Id { get; set; }
        public int ProductLineRowId { get; set; }
        public int CTTypeRowId { get; set; }
        public string SizeCode { get; set; }
        public float SizeValue { get; set; }
        public string SizeUOM { get; set; }
    }


    public class KeyDimensionList
    {
        public int Id { get; set; }
        public int CTTypeCodesRowId { get; set; }
        public int ParamId { get; set; }
        public string ParamCode { get; set; }
        public string ParamUOM { get; set; }
        public string ParamName { get; set; }
    }



    public class GetSizeList
    {
        public int SizeID { get; set; }
        public string Size { get; set; }
    }



    public class DrawingDetails
    {
        public int Id { get; set; }
        public string RequestNo { get; set; }
        public string ProductLine { get; set; }
        public string ProductLineCode { get; set; }
        public string CTTypeName { get; set; }
        public string CTTypeCode { get; set; }
        public string SizeCode { get; set; }
        public object SizeValue { get; set; }
        public string SubTypeName { get; set; }
        public string SubTypeCode { get; set; }
        public string CsvFileName { get; set; }
        public Csvdata[] CsvData { get; set; }
        public string SKUDesc { get; set; }
        public string SKUCode { get; set; }
        public string SizeType { get; set; }
        public string SubType { get; set; }
        public string ImageFileName { get; set; }

        public int StatusId { get; set; }
        public int GridNo { get; set; }
    }

    public class Csvdata
    {
        [JsonPropertyName("Sq. No.")]
        public string SqNo { get; set; }

        [JsonPropertyName("Process Name")]
        public string ProcessName { get; set; }

        [JsonPropertyName("Parameter Name")]
        public string ParameterName { get; set; }
        public string Value { get; set; }
        public string UOM { get; set; }
        public string Tolerance { get; set; }
    }

    //public class DrawingDetails
    //{
    //    public int Id { get; set; }
    //    public object RequestNo { get; set; }
    //    public string ProductLine { get; set; }
    //    public string ProductLineCode { get; set; }
    //    public string CTTypeName { get; set; }
    //    public string CTTypeCode { get; set; }
    //    public object SizeCode { get; set; }
    //    public object SizeValue { get; set; }
    //    public string SubTypeName { get; set; }
    //    public string SubTypeCode { get; set; }
    //    public string SKUDesc { get; set; }
    //    public object SKUCode { get; set; }
    //    public int StatusId { get; set; }
    //    public int GridNo { get; set; }
    //}


    //public class DrawingDetails
    //{
    //    public int Id { get; set; }
    //    public string ProductLine { get; set; }
    //    public string ProductLineCode { get; set; }
    //    public string CTTypeName { get; set; }
    //    public string CTTypeCode { get; set; }
    //    public object SizeCode { get; set; }
    //    public object SizeValue { get; set; }
    //    public string SubTypeName { get; set; }
    //    public string SubTypeCode { get; set; }
    //    public string SKUDesc { get; set; }
    //    public object SKUCode { get; set; }
    //    public string StatusId { get; set; }
    //}

    public class TypeDropdown
    {
        public int Id { get; set; }
        public string CTTypeCode { get; set; }

        public string CTTypeName { get; set; }
    }




    public class SubTypeList
    {
        public int Id { get; set; }
        public string RequestNo { get; set; }
        public string ProductLine { get; set; }
        public string TypeName { get; set; }
        public float SizeValue { get; set; }
        public string SubTypeCode { get; set; }
        public string SubType { get; set; }
        public string SizeType { get; set; }
        public string SubTypeName { get; set; }
        public string ImageFileName { get; set; }
        public string SKUCode { get; set; }
        public int ProductLineRowId { get; set; }
        public int SizeRowId { get; set; }
        public int CTTypeDetialsRowId { get; set; }
    
        public string CsvFileName { get; set; }
        public Csvdata[] CsvData { get; set; }
        public string StatusId { get; set; }
        public string CTSubTypeCode { get; set; }
        public int GridNo { get; set; }
    }

    //public class SubTypeList
    //{
    //    public int Id { get; set; }
    //    public string RequestNo { get; set; }
    //    public string ProductLine { get; set; }
    //    public string TypeName { get; set; }
    //    public float SizeValue { get; set; }
    //    public string SubTypeCode { get; set; }
    //    public string SubType { get; set; }
    //    public string StatusId { get; set; }
    //    public string CTSubTypeCode { get; set; }
    //    public int GridNo { get; set; }
    //}

    public class CTSubTypeParameterList
    {
        public int SqNo { get; set; }
        public string ProcessName { get; set; }
        public string ParameterName { get; set; }
        public string Value { get; set; }
        public string UOM { get; set; }
        public string Tolerance { get; set; }
    }

    public class SubtypeDD
    {
        public string SubTypeName { get; set; }
        public int SubTypeId { get; set; }
        public string SubTypeCode { get; set; }
    }




    public class CTStampDetails
    {
        public int Id { get; set; }
        public int? BrandId { get; set; }
        public int RequestNo { get; set; }
        public string ProductLine { get; set; }
        public string BrandName { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public string Sales { get; set; }
        public string ImageName { get; set; }
        public string StatusId { get; set; }
        public int GridNo { get; set; }
        public string BrandCode { get; set; }
    }

    public class ProdLineList
    {
        public int Id { get; set; }
        public string? ProductLine { get; set; }
        public string? ProductLineCode { get; set; }
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






    public class TypeParameterList
    {
        public string StatusId { get; set; }
        public string StatusText { get; set; }
        public int TypeDetailsRowId { get; set; }
        public int CTTypeCodesRowId { get; set; }
        public int ProductLineRowId { get; set; }
        public string CTTypeCode { get; set; }
        public string CTTypeName { get; set; }
        public string ProductLineCode { get; set; }
        public string ProductLine { get; set; }
        public string RequestNo { get; set; }
        public string ImageFileName { get; set; }
        public object Remark { get; set; }
        public int GridNo { get; set; }
    }

    //public class TypeParameterList
    //{
    //    public int TypeDetailsRowId { get; set; }
    //    public int CTTypeCodesRowId { get; set; }
    //    public int ProductLineRowId { get; set; }
    //    public string CTTypeCode { get; set; }
    //    public string CTTypeName { get; set; }
    //    public string ProductLineCode { get; set; }
    //    public string ProductLine { get; set; }
    //}




    public class TypeParamByIDList
    {
        public int TypeDetailsRowId { get; set; }
        public int CTTypeCodesRowId { get; set; }
        public int ProductLineRowId { get; set; }
        public string CTTypeCode { get; set; }
        public string CTTypeName { get; set; }
        public string ProductLineCode { get; set; }
        public string ProductLine { get; set; }
        public string RequestNo { get; set; }
        public string ImageFileName { get; set; }
        public string CsvFileName { get; set; }
        public Typeparamsjarr1[] TypeParamsJarr { get; set; }
        public object Remark { get; set; }
        public string StatusId { get; set; }
        public string StatusText { get; set; }
        public int GridNo { get; set; }
    }

    public class Typeparamsjarr1
    {
        public int ParamId { get; set; }
        public int ProcessSequence { get; set; }
        public string ProcessName { get; set; }
        public string ParamName { get; set; }
        public string ParamCode { get; set; }
        public string ParamUOM { get; set; }
        public bool Range { get; set; }
        public bool Nominal { get; set; }
        public bool KeyDim { get; set; }
    }



    //public class TypeParamByIDList
    //{
    //    public int TypeDetailsRowId { get; set; }
    //    public int CTTypeCodesRowId { get; set; }
    //    public int ProductLineRowId { get; set; }
    //    public string CTTypeCode { get; set; }
    //    public string CTTypeName { get; set; }
    //    public string ProductLineCode { get; set; }
    //    public string ProductLine { get; set; }
    //    public string RequestNo { get; set; }
    //    public string ImageFileName { get; set; }
    //    public string CsvFileName { get; set; }
    //    public Typeparamsjarr[] TypeParamsJarr { get; set; }
    //    public object Remark { get; set; }
    //    public string StatusId { get; set; }
    //    public string StatusText { get; set; }
    //    public int GridNo { get; set; }
    //}

    public class Typeparamsjarr
    {
        public int ParamId { get; set; }
        public int ProcessSequence { get; set; }
        public string ParamCode { get; set; }
        public string ParamUOM { get; set; }
        public bool Range { get; set; }
        public bool Nominal { get; set; }
        public bool KeyDim { get; set; }
    }

    public class TypeList
    {
        public int Id { get; set; }
        public int ProductLineID { get; set; }

        public string BatchId { get; set; }
        public string RequestNo { get; set; }
        public string FileTypeName { get; set; }
        public string FileTypeCode { get; set; }
        public string? ImageFileName { get; set; }
        public string ValueStreamCode { get; set; }
        public string TypeDesc { get; set; }
        public string SizeMin { get; set; }
        public string SizeMax { get; set; }
        public object operationJarr { get; set; }
        public int StatusId { get; set; }
        public string Remark { get; set; }
        public string Cutonside { get; set; }
        public string CutSide { get; set; }
        public string? ProductLine { get; set; }
        //public int ProductLineId { get; set; }
        public int GridNo { get; set; }

    }
}
