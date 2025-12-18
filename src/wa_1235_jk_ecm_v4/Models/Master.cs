using wa_1235_jk_ecm_v4.Models.DecintellCommon;
using System.Web;

namespace wa_1235_jk_ecm_v4.Models
{
    public class Master
    {

        public ProfileParameterData_List[] ProfileParameterData_List { get; set; }
        public ParametersList[] ParametersLists { get; set; }
        //CutType
        public CutSpecParametersjarr[] CutSpecParameterslist { get; set; }

        public CutType[] CutTypelist { get; set; }

        public GetFileSubTypeParametersList[] GetFileSubTypeParametersList { get; set; }
        public EditFileSubTypeMaster[] EditFileSubType_List { get; set; }
        //CutSpecificationEdit
        public ShipToCountryList[] ShipToCountry_List { get; set; }
        public CutSpecificationEdit[] CutSpecificationEdit_List { get; set; }
        public CutSpecificationEdit[] CutSpecificationEditData { get; set; }
        public LookupTypes[] LookupTypes_List { get; set; }
        public LookupList[] Lookup_Lists { get; set; }
        public EditFileTypeList[] EditFileType_List { get; set; }
        //CutSpecificationsList
        public CutSpecificationsList[] CutSpecificationsLists { get; set; }

        public EditOperationList[] EditOperation_List { get; set; }

        public EditHandle_List[] EditHandleList { get; set; }
        public OperationList[] OperationList { get; set; }
        public FileParemeter[] FileParemeter_List { get; set; }
        public Parameters[] Parameters_LIst { get; set; }
        public Customer[] CustomerList { get; set; }
        public RawMaterial[] RawMaterialList { get; set; }
        public Brand[] Brand_List { get; set; }
        public BrandList[] BrandCodeList { get; set; }
        public FileSize[] FileSize_List { get; set; }
        public FileSizes[] FileSizes_List { get; set; }
        //cutSidesarr
        public cutSidesarr[] cutSidesarr_list { get; set; }

        public Valuestream[] Valuestream_List { get; set; }

        public FileTypeMaster[] FileTypeMasters { get; set; }
        public FileSubTypeMaster[] FileSubType_List { get; set; }
        public FileType[] FileType_List { get; set; }
        public Stamp[] Stamp_List { get; set; }
        public ddBrandList[] ddBrandList { get; set; }
        // CutOnSidesList,CutsidesList
        public CutOnSidesList[] CutOnSides_List { get; set; }
        public CutsidesList[] Cutsides_List { get; set; }

        public Stamp[] StampRequestApproval_List { get; set; }
        public Stamp[] StampRequestApproved_List { get; set; }
        public Handle[] Handle_List { get; set; }
        public int FileID { get; set; }
        public String valcode { get; set; }
        public int Id { get; set; }
        public int CutOnSidesID { get; set; }
        public int BrandId { get; set; }
        public string? BrandCode { get; set; }
        public int FileSubTypeId { get; set; }

        public SubmittedRequestList[] SubmittedRequest_List { get; set; }

        public ApprovedSKUDetails[] ApprovedSKUDetails_List { get; set; }

        public Drawing[] Drawing_List { get; set; }




        public class EditHandle_List
        {
            public int Id { get; set; }
            public string HandleType { get; set; }
            public string HandleChartNo { get; set; }
            public string handleChart { get; set; }
            public string InsertType { get; set; }
            public string insertChartNo { get; set; }
            public string insertChart { get; set; }
        }




        public class Paramoperationlist
        {
            public int Id { get; set; }
            public string ParamName { get; set; }
            public string ParamCode { get; set; }
        }


        public class EditFileTypeList
        {
            public int Id { get; set; }
            public string BatchId { get; set; }
            public string RequestNo { get; set; }
            public string FileTypeName { get; set; }
            public object CutSide { get; set; }
            public object Cutonnsides { get; set; }
            public string FileTypeCode { get; set; }
            public string fileTypeProfileImage { get; set; }
            public string valueStreamCode { get; set; }
            public string fileSizeMin { get; set; }
            public string fileSizeMax { get; set; }
            public string opr_operation_name { get; set; }
            public int SeqNo { get; set; }
            public string Operation_id { get; set; }
            public string fileName { get; set; }
            public Paramoperationlist[] ParamOperationList { get; set; }



            //public class Rootobject
            //{
            //    public Class1[] Property1 { get; set; }
            //}

            //public class Class1
            //{
            //    public int Id { get; set; }
            //    public string BatchId { get; set; }
            //    public string RequestNo { get; set; }
            //    public string FileTypeName { get; set; }
            //    public string FileTypeCode { get; set; }
            //    public string fileTypeProfileImage { get; set; }
            //    public string valueStreamCode { get; set; }
            //    public string fileSizeMin { get; set; }
            //    public object CutSide { get; set; }
            //    public object Cutonnsides { get; set; }
            //    public string fileSizeMax { get; set; }
            //    public string opr_operation_name { get; set; }
            //    public int SeqNo { get; set; }
            //    public string Operation_id { get; set; }
            //    public string fileName { get; set; }
            //}

        }

        public class EditOperationList
        {
            public int seqNo { get; set; }
            public int opr_operation_id { get; set; }
            public string opr_operation_name { get; set; }


        }


        public class Customer
        {
            public int CustomerId { get; set; }
            public string? CustomerName { get; set; }
            public string? CustomerCode { get; set; }

            public decimal CustomerPct { get; set; }
            public int PackingDays { get; set; }
            public string? CustomerDetailsJobj { get; set; }
            public string? CustomerHistoryJarr { get; set; }
        }
        public class RawMaterial
        {
            public int RawMaterialId { get; set; }
            public string? RawMaterialDescription { get; set; }
            public string? RawMaterialCode { get; set; }
            public string? RMDetailsJobj { get; set; }
            public string? RMHistoryJarr { get; set; }
        }

        public class LookupTypes
        {
            public int LookupId { get; set; }
            public int LookupTypeId { get; set; }
            public string? LookupValue { get; set; }
            public string? LookupType { get; set; }
        }


        public class LookupList
        {
            public int SrNo { get; set; }
            public int? ID { get; set; }
            public string? LookupValue { get; set; }
        }


        public class BrandList
        {
            public string BrandId { get; set; }
            public string BrandCode { get; set; }
            public string BrandName { get; set; }
        }


        public class Brand
        {
            public int BrandId { get; set; }
            public string? BrandName { get; set; }
            public string? BrandCode { get; set; }
        }
        public class FileSize
        {
            //    public int? Id { get; set; }
            //    public string? BatchId { get; set; }
            //    public string? RequestType { get; set; }
            //    public string? RequestId { get; set; }
            //    public string? FileSizeInch { get; set; }
            //    public string FileSizeMM { get; set; }
            //    public string? FileSizeCode { get; set; }
            //    public string? Remarks { get; set; }
            //    public string? FileSizeDetailsJobj { get; set; }
            //    public string? FileSizeHistoryArr { get; set; }
            //    public int? StatusId { get; set; }
            //} 
            //public class Class1
            //{
            public int Id { get; set; }
            public string RequestId { get; set; }
            public string FileSizeCode { get; set; }
            public float FileSizeInch { get; set; }
            public float MM { get; set; }
            public string FileSizeDetailsJobj { get; set; }
            public string NewOrExisting { get; set; }
            public int GridNo { get; set; }
            public string? Remarks { get; set; }
        }


        //public class FileType
        //{
        //    public int Id { get; set; }
        //    public string BatchId { get; set; }
        //    public string RequestType { get; set; }
        //    public string RequestNo { get; set; }
        //    public string FileTypeName { get; set; }
        //    public string FileTypeCode { get; set; }
        //    public string ValueStreamCode { get; set; }
        //    public int FileSizeMin { get; set; }
        //    public int FileFizeMax { get; set; }
        //    public int StatusId { get; set; }
        //}


        public class FileType
        {
            public int Id { get; set; }
            public string BatchId { get; set; }
            public string RequestNo { get; set; }
            public string FileTypeName { get; set; }
            public string FileTypeCode { get; set; }
            public string ValueStreamCode { get; set; }
            public string SizeMin { get; set; }
            public string SizeMax { get; set; }
            public object operationJarr { get; set; }
            public int StatusId { get; set; }
            public string Remark { get; set; }
            public string Cutonside { get; set; }
            public string CutSide { get; set; }
            public int GridNo { get; set; }

        }




    }
    public class FileSizes
    {
        public int Id { get; set; }
        public decimal FileSizeInch { get; set; }
        public string FileSizeInch1 { get; set; }
        public string FileSizeCode { get; set; }
        public string Remarks { get; set; }
        public string NewOrExisting { get; set; }
    }

    public class Drawing
    {

        public string SKUKey { get; set; }
        public string Description { get; set; }
        public string FileSizeCode { get; set; }
        public string FileTypeCode { get; set; }
        public int RequestNo { get; set; }
        public int GridNo { get; set; }
        public int DrawingId { get; set; }
        public int FileSubTypeDetailsRowId { get; set; }
        public int CutSpecDetailsRowId { get; set; }
        public string FileTypeImage { get; set; }
        public string CutTypeCode { get; set; }
        public string CutSpecCode { get; set; }
    }

 
    public class CutSpecificationsList
    {
        public int Id { get; set; }
        public string BatchCode { get; set; }
        public string RequestType { get; set; }

        public string Request { get; set; }
        public string RequestNo { get; set; }
        public string FileSizeCode { get; set; }
        public string FileTypeCode { get; set; }
        public string CutType { get; set; }
        public string CutSpecName { get; set; }
        public string CutSpecCode { get; set; }
        public string CutSpecParametersJarr { get; set; }
        public string CutSpecJobj { get; set; }
        public string CutSpecHistoryJarr { get; set; }
        public int StatusId { get; set; }
        public int GridNo { get; set; }
    }

    public class ShipToCountryList
    {

        public int Id { get; set; }
        public String CountryCode { get; set; }
        public String CountryName { get; set; }
        public String Teretary { get; set; }
        public String Continent { get; set; }
    }

    public class Valuestream
    {
        public String val_valuestream_code { get; set; }
        public String ValustreamNameCode { get; set; }
    }
    public class FileTypeMaster
    {
        public int ID { get; set; }
        public String FileTypeNamecode { get; set; }
    }
    public class CutType
    {

        public int LookupId { get; set; }
        public String LookupValue { get; set; }
    }


    public class cutSidesarr
    {
        public string seqNo { get; set; }
        public string opr_operation_id { get; set; }
        public string CutSides { get; set; }
        public string CutOnSides { get; set; }
    }

    public class CutOnSidesList
    {
        public int ID { get; set; }
        public String CutOnSides { get; set; }
    }


    public class CutsidesList
    {
        public int ID { get; set; }
        public String CutSides { get; set; }
    }


    public class EditFileSubTypeMaster
    {
        public int Id { get; set; }
        public string FileType { get; set; }
        public string effStartDate { get; set; }
        public string effEndDate { get; set; }
        public string remark { get; set; }
    }

    public class FileSubTypeMaster
    {
        public int Id { get; set; }
        public string BatchId { get; set; }
        public string RequestType { get; set; }
        public string FileSubTypeName { get; set; }
        public string RequestNo { get; set; }
        public string FileType { get; set; }
        public decimal FileSize { get; set; }
        public string SubType { get; set; }
        public string SubTypeCode { get; set; }
        public int GridNo { get; set; }
        public string FileSubtypeCode { get; set; }
        public int FileTypeId { get; set; }
    }
    public class valuestreamoperations
    {
        public string opr_operation_name { get; set; }
        public int opr_operation_seq { get; set; }
        public int opr_operation_id { get; set; }
        public int sequence { get; set; }
    }

    public class OperationList
    {
        public string ValueStreamCode { get; set; }
        public int SeqNo { get; set; }
        public int OperationId { get; set; }
        public string opr_operation_name { get; set; }
        public int StatusId { get; set; }
    }


    public class ProfileParameterData_List
    {
        public string ParameterCategorySequence { get; set; }
        public string ParameterCategory { get; set; }
        public string ParameterName { get; set; }
        public string ParameterCode { get; set; }
        public string ParameterPresentOnReport { get; set; }
        public string UOM { get; set; }
    }



    public class ParametersList
    {
        public string fileTypeProfileImage { get; set; }

        public int ParameterCategorySequence { get; set; }
        public string ParameterCategory { get; set; }
        public string ParameterName { get; set; }
        public string ParameterCode { get; set; }
        public string UoM { get; set; }
        public string InputType { get; set; }
        public int IsDisplay { get; set; }
    }

    public class CutSpecificationEdit
    {
        public string CutSides { get; set; }
        public string CutOnSides { get; set; }
        public string CutType { get; set; }
        public string CutSideId { get; set; }
        public string CutOnsideId { get; set; }
        public string Value { get; set; }
        public string UOM { get; set; }
        public int StatusId { get; set; }
        public int Id { get; set; }
        public string BatchCode { get; set; }
        public string RequestType { get; set; }
        public string RequestNo { get; set; }
        public string FileSizeCode { get; set; }
        public string FileTypeCode { get; set; }
        public string CutSpecName { get; set; }
        public string CutSpecCode { get; set; }
        public object Remark { get; set; }


    }

    public class CutSpecParametersjarr
    {
        public string Parametername { get; set; }
        public string Parametervalue { get; set; }
    }


    public class EditStampViewModel
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string StampChartNo { get; set; }
    }

    public class ddBrandList
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string StampChartNo { get; set; }
        public string StampChartImage { get; set; }
    }



    public class Stamp
    {

        public int BrandId { get; set; }
        public int Id { get; set; }
        public string BatchId { get; set; }
        public string RequestType { get; set; }
        public string RequestNo { get; set; }
        public string BrandName { get; set; }
        public string StampChartNo { get; set; }
        // public string FileName { get; set; }
        public int StatusId { get; set; }

        public string BrandCode { get; set; }
        public string ImageFile { get; set; }
        public int GridNo { get; set; }

    }

    public class Handle
    {
        public int Id { get; set; }
        public string BatchId { get; set; }
        public string RequestType { get; set; }
        public string RequestNo { get; set; }
        public string HandleType { get; set; }
        public string HandleChartNo { get; set; }
        public string handleChart { get; set; }
        public string handleDrawingNo { get; set; }
        public string handleDrawingChart { get; set; }
        public string insertChartNo { get; set; }
        public string insertChart { get; set; }
        public int StatusId { get; set; }
        public int GridNo { get; set; }
    }


    public class Rootobject
    {
        public Filesubtypedetailsjobj FileSubTypeDetailsJobj { get; set; }
    }

    public class Filesubtypedetailsjobj
    {
        public string ftCode { get; set; }
        public string sftCode { get; set; }
        public string sftSzCode { get; set; }
        public string FileSubTypeName { get; set; }
        public string EffectiveFrom { get; set; }
        public string EffectiveTo { get; set; }
        public int createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public int statusId { get; set; }
        public Formdata formData { get; set; }
    }

    public class Formdata
    {
        public string csvFileName { get; set; }
        public int csvFileSize { get; set; }
        public DateTime csvLastModifiedDate { get; set; }
        public string csvFilePath { get; set; }
    }



    public class SubTypeParameters
    {
        public string seqId { get; set; }
        public string cat_name { get; set; }
        public string p_name { get; set; }
        public string p_code { get; set; }
        public string p_flg { get; set; }
        public string p_uom { get; set; }
        public string p_value { get; set; }
        public string p_tol { get; set; }
    }



    public class Parameters
    {
        public string ParameterCategorySequence { get; set; }
        public string ParameterCategory { get; set; }
        public string ParameterName { get; set; }
        public string ParameterCode { get; set; }
        public string ParameterPresentOnReport { get; set; }
        public string UOM { get; set; }

    }




    public class GetFileSubTypeParametersList
    {
        public int Sequence { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Tolerance { get; set; }
        public string Remark { get; set; }
        public string IsDisplay { get; set; }
    }

    //public class GetFileSubTypeParametersList
    //{
    //    public string Category { get; set; }
    //    public string Name { get; set; }
    //    public object ParameterCategorySequence { get; set; }
    //    public string Value { get; set; }
    //    public string Tolerance { get; set; }
    //    public string Remark { get; set; }
    //}

    public class FileParemeter
    {
        public object FileTypeJobj { get; set; }
    }

    public class SubmittedRequestList
    {
        public string BatchId { get; set; }
        public string RequestCode { get; set; }
        public string SKUKey { get; set; }
        public string SAPNo { get; set; }
        public string Description { get; set; }
        public int RequestId { get; set; }
        public string RequestStatusName { get; set; }
        public int StatusId { get; set; }
        public int GridNo { get; set; }
        public string ReqType { get; set; }
    }




}
