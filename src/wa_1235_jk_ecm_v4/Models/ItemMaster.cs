
using static wa_1235_jk_ecm_v4.Models.Master;
namespace wa_1235_jk_ecm_v4.Models
{
    public class ItemMaster
    {
        public int CategoryId { get; set; }
        public CategoryList[] CategoryList { get; set; }
        public int MaterialId { get; set; }
        public MaterialList[] MaterialList { get; set; }
        //HandleTypeMaster
        public CutType[] CutTypelist { get; set; }
        public CutType[] StampProcesslist { get; set; }

        public CutType[] HandlePresencelist { get; set; }

        public HandleTypeMaster[] HandleTypeList { get; set; }

        public DimentionAttribute[] DimentionAttribute { get; set; }
        public CustomerMaster[] ecm_CustomerMaster { get; set; }
        public BrandMaster[] ecm_BrandMaster { get; set; }
        public FileType[] FileType_List { get; set; }
        public FileSubTypeMaster[] FileSubType_List { get; set; }
        public ShipToCountryList[] ShipToCountry_List { get; set; }
        public StampMaster[] StampMaster_List { get; set; }
        public CutSpecificationsList[] CutSpecification_List { get; set; }
        public FileSizes[] FileSizes_List { get; set; }
        public LookupTypes[] LookupTypes_List { get; set; }
        public LookupTypes[] TangTempering_List { get; set; }
        public LookupTypes[] TangColor_List { get; set; }

        public LookupTypes[] Blackodising_List { get; set; }
        public LookupTypes[] QualitySeal_List { get; set; }
        public LookupTypes[] LineNo_List { get; set; }
        public LookupTypes[] Hologram_List { get; set; }
        public LookupTypes[] PriceSticker_List { get; set; }
        public LookupTypes[] MadeInIndia_List { get; set; }
        public LookupTypes[] PolytheneBag_List { get; set; }
        public LookupTypes[] SilicaGel_List { get; set; }
        public LookupTypes[] Fumigation_List { get; set; }
        public LookupTypes[] PromotionalItem_List { get; set; }
        public LookupTypes[] Strap_List { get; set; }
        public LookupTypes[] CelloTape_List { get; set; }
        public LookupTypes[] ShrinkWrap_List { get; set; }
        public LookupTypes[] Paperwool_List { get; set; }
        public LookupTypes[] PONO_List { get; set; }
        public LookupTypes[] PreInspection_List { get; set; }
        public LookupTypes[] Stencil_List { get; set; }
        public LookupTypes[] InsertQualityCard_List { get; set; }
        public LookupTypes[] BarCodeWrapper1_List { get; set; }
        public LookupTypes[] BarCodeWrapper2_List { get; set; }
        public LookupTypes[] BarCodeInner_List { get; set; }
        public LookupTypes[] BarCodeOuter_List { get; set; }

        public ProductionDetails ProductionDetails_List { get; set; }
        public StampMaster StampMasterDispatchDetails { get; set; }
        public HandleMasterForEdit HandleMasterForEditDetails { get; set; }

        public OtherPackingForEdit OtherPackingForEditDetails { get; set; }
        public int Position { get; set; }
        public int LabelTypeId { get; set; }
        public ApprovedSKUDetails[] ApprovedSKUDetails_List { get; set; }
        public ApprovedCommingSKUDetails[] ApprovedCommingSKUDetails_List { get; set; }
        public PackingMaterialList[] PackingMaterialLists { get; set; }

        public DrawingNewSet[] DrawingNewSetList { get; set; }

        public WrapperDrawingSet[] WrapperDrawingSetList { get; set; }
        public WithdrawnRequests[] WithdrawnRequestsList { get; set; }

        public PackingDetails[] PackingDetailsList { get; set; }
        public WrapperDetails Wrapper1Details { get; set; }
        public WrapperDetails Wrapper2Details { get; set; }
        public WrapperDetails InnerboxDetails { get; set; }
        public WrapperDetails OuterboxDetails { get; set; }
        public WrapperDetails OuterDetails { get; set; }
        public WrapperDetails PalletDetails { get; set; }
        public LabelDetails[] LabelDetailsList { get; set; }

        public MaterialDimensions[] MaterialDimensionsList { get; set; }
        public SKUSet[] SKUSetList { get; set; }
    }



    public class PackingMaterialList
    {
        public int Id { get; set; }
        public int TxnRequestId { get; set; }
        public int DimensionValuesRowId { get; set; }
        public int MaterialId { get; set; }
        public int CategoryId { get; set; }
        public string MaterialSampleBox { get; set; }
        public string MaterialArtwork { get; set; }
        public string MaterialPantone { get; set; }
        public int ContainsCategoryId { get; set; }
        public int QtyOfContains { get; set; }
        public int QtyOfProdSku { get; set; }
        public string CategoryName { get; set; }
        public string MaterialName { get; set; }
        public string MaterialClassName { get; set; }
    }


    public class CategoryList
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }


    public class MaterialList
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
    }

    public class BrandMaster
    {
        public int BrandId { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public int StatusId { get; set; }
    }

    public class CustomerMaster
    {
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerHistoryJarr { get; set; }
        public string CustomerDetailsJobj { get; set; }
        public int StatusId { get; set; }

    }
    //CustomerMaster
    public class StampMaster
    {
        public int Id { get; set; }
        public string BatchId { get; set; }
        public int BrandId { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public string RequestType { get; set; }
        public string RequestNo { get; set; }
        public string ChartNo { get; set; }
        public string StampChartImage { get; set; }
        public string Remark { get; set; }
        public string StampProcess { get; set; }
    }
    public class HandleTypeMaster
    {
        public int Id { get; set; }
        public string BatchId { get; set; }
        public string RequestType { get; set; }
        public string RequestNo { get; set; }
        public string HandleType { get; set; }
        public string HandleChartNo { get; set; }
        public string handleChart { get; set; }
        public string InsertChart { get; set; }
        public string InsertChartimg { get; set; }
    }

    public class HandleMasterForEdit
    {
        public int HandlePresenceId { get; set; }
        public int HandleTypeId { get; set; }
        public string HandleChartNo { get; set; }
        public string InsertChartNo { get; set; }
        public string HandleColor { get; set; }

        public string InsertColor { get; set; }
        public string HandlePresence { get; set; }
        public string RequestNo { get; set; }
        public string HandleType { get; set; }
        public string HandleChartName { get; set; }
    }

    public class OtherPackingForEdit
    {
        public int TangTempering { get; set; }
        public string TangTemperingValue { get; set; }
        public int TangColor { get; set; }
        public string TangColorValue { get; set; }
        public int Blackodising { get; set; }
        public string BlackodisingValue { get; set; }
        public int QualitySeal { get; set; }
        public string QualitySealValue { get; set; }
        public int LineNumber { get; set; }
        public string LineNumberValue { get; set; }
        public int Hologram { get; set; }
        public string HologramValue { get; set; }
        public int PriceSticker { get; set; }
        public string PriceStickerValue { get; set; }
        public int MadeInIndia { get; set; }
        public string MadeInIndiaValue { get; set; }
        public int PolytheneBag { get; set; }
        public string PolytheneBagValue { get; set; }
        public int SilicaGel { get; set; }
        public string SilicaGelValue { get; set; }
        public int Fumigation { get; set; }
        public string FumigationValue { get; set; }
        public int PromotionalItem { get; set; }
        public string PromotionalItemValue { get; set; }
        public int Strap { get; set; }
        public string StrapValue { get; set; }
        public int CelloTape { get; set; }
        public string CelloTapeValue { get; set; }
        public int ShrinkWrap { get; set; }
        public string ShrinkWrapValue { get; set; }
        public int Paperwool { get; set; }
        public string PaperwoolValue { get; set; }
        public int PONO { get; set; }
        public string PONOValue { get; set; }
        public int PreInspection { get; set; }
        public string PreInspectionValue { get; set; }
        public int Stencil { get; set; }
        public string StencilValue { get; set; }
        public int InsertQualityCard { get; set; }
        public string InsertQualityCardValue { get; set; }
        public int BarCodeWrapper1 { get; set; }
        public string BarCodeWrapper1Value { get; set; }
        public int BarCodeWrapper2 { get; set; }
        public string BarCodeWrapper2Value { get; set; }
        public int BarCodeInner { get; set; }
        public string BarCodeInnerValue { get; set; }
        public int BarCodeOuter { get; set; }
        public string BarCodeOuterValue { get; set; }
        public string SapDescription { get; set; }
        public string Remark { get; set; }
        public string CelloTapeImageName { get; set; }

    }
    public class DimentionAttribute
    {
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
    }

    public class ProductionDetails
    {
        public string ProdSKU { get; set; }
        public string RequestCode { get; set; }
        public int CustomerId { get; set; }
        public int BrandId { get; set; }
        public string CustomerCode { get; set; }
        public string BrandCode { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Continent { get; set; }
        public string SAPNO { get; set; }
        public string CustomerPartNumber { get; set; }
        public string Sales { get; set; }
        public string FileSizeCode { get; set; }
        public int FileType { get; set; }
        public int FileSubType { get; set; }
        public int CutType { get; set; }
        public string CutTypeName { get; set; }
        public int CutStandard { get; set; }
        public string ProductionRemark { get; set; }

        public string FileSizeInch { get; set; }
        public string FileTypeName { get; set; }
        public string FileSubTypeName { get; set; }
        public string CutSpecName { get; set; }
        public string CutStandardValue { get; set; }
        public string CustomerName { get; set; }
        public string BrandName { get; set; }
        public int RequestNo { get; set; }

        public string FileCode { get; set; }
        public string ReqType { get; set; }
        public int FileTypeCodeId { get; set; }
        public string FileTypeCode { get; set; }
    }




    public class ApprovedSKUDetails
    {
        public int ReqId { get; set; }
        public string RequestNo { get; set; }
        public string FalcoSKU { get; set; }
        public string SKUHistory { get; set; }
        public string DrwRevision { get; set; }
        public string Description { get; set; }
        public string CustomerSKU { get; set; }
    }

    public class DrawingNewSet
    {
        public string ProdSku { get; set; }
        public string PrdSKUNumber { get; set; }
    }

    public class WrapperDrawingSet
    {
        public int DrawingDetailsRowId { get; set; }
        public string DrawingNumber { get; set; }

    }


    public class WithdrawnRequests
    {
        public int Id { get; set; }
        public string RequestNo { get; set; }
        public string FalcoCode { get; set; }
        public string CreatedBy { get; set; }
        public string CreationDate { get; set; }
        public string RequestStatusName { get; set; }
    }




    public class PackingDetails
    {
        public int? Id { get; set; }
        public int? TxnRequestId { get; set; }
        public int? DimensionValuesRowId { get; set; }
        public int? MaterialId { get; set; }
        public int? CategoryId { get; set; }
        public string? MaterialSampleBox { get; set; }
        public string? MaterialArtwork { get; set; }
        public string? MaterialPantone { get; set; }
        public object? ContainsCategoryId { get; set; }
        public int? QtyOfContains { get; set; }
        public object? QtyOfProdSku { get; set; }
        public string? CategoryName { get; set; }
        public string? CustomerCode { get; set; }
        public string? BrandCode { get; set; }
        public string? DimensionList { get; set; }
        public string? MaterialClassName { get; set; }
        public string? PackingDrawingImage { get; set; }
    }

    public class WrapperDetails
    {
        public int? Id { get; set; }
        public int? TxnRequestId { get; set; }
        public int? DimensionValuesRowId { get; set; }
        public int? MaterialId { get; set; }
        public int? CategoryId { get; set; }
        public string? MaterialSampleBox { get; set; }
        public string? MaterialArtwork { get; set; }
        public string? MaterialPantone { get; set; }
        public object? ContainsCategoryId { get; set; }
        public int? QtyOfContains { get; set; }
        public object? QtyOfProdSku { get; set; }
        public string? CategoryName { get; set; }
        public string? CustomerCode { get; set; }
        public string? BrandCode { get; set; }
        public string? DimensionList { get; set; }
        public string? MaterialClassName { get; set; }
        public string? PackingDrawingImage { get; set; }
    }

    public class LabelDetails
    {
        public int TxnRequestId { get; set; }
        public string ImageFileName { get; set; }
        public string LabelType { get; set; }
        public string PositionName { get; set; }
        public string CategoryName { get; set; }
        public string CustomerCode { get; set; }
        public string BrandCode { get; set; }
    }

    public class MaterialDimensions
    {
        public int CategoryId { get; set; }
        public Dictionary<string, string> Dimensions { get; set; }  // Dynamic key-value pair for dimensions
    }

    public class SKUSet
    {
        public string FileSizeCode { get; set; }
        public string FileTypeName { get; set; }
        public string FileSubTypeName { get; set; }
        public string CutTypeName { get; set; }
        public string CutSpecName { get; set; }
        public string Drawing { get; set; }
        public string StampChartNo { get; set; }
        public string StampProcess { get; set; }
        public string BrandCode { get; set; }
        public string HandleType { get; set; }
        public string HandlePresence { get; set; }
        public string HandleChartNo { get; set; }
        public string SetSKU { get; set; }
        public string Qty { get; set; }
        public int CutStandard { get; set; }
        public int? DrawingDetailsRowId { get; set; }
    }




    public class ApprovedCommingSKUDetails
    {
        public int ReqId { get; set; }

        // Strings can already be null, so no change needed
        public string? RequestNo { get; set; }
        public string? FalcoSKU { get; set; }
        public string? SKUHistory { get; set; }
        public string? DrwRevision { get; set; }
        public string? Description { get; set; }
        public string? CustomerSKU { get; set; }

        // Use DateTime? for nullable datetime fields
        public DateTime? ApprovalDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
    }




}