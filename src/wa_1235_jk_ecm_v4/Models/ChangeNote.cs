

namespace wa_1235_jk_ecm_v4.Models
{
    public class ChangeNote
    {
        public ChangeNoteList[] ChangeNote_List { get; set; }
        public ChangeNoteDetails[] ChangeNoteDetails_List { get; set; }
        //StampDetails
        public StampDetails[] StampDetails_List { get; set; }
        public ChangeNoteApproval[] ChangeNoteApproval_List { get; set; }

    }
    public class ChangeNoteList
    {
        public int SrNo { get; set; }

        public string? ReqType { get; set; }
        public string? BatchId { get; set; }
        public string? RequestNo { get; set; }
        public string? RequestNumber { get; set; }
        public string? FalcoCode { get; set; }
        public string? CreationDate { get; set; }
        public int AgingInDays { get; set; }
        public string? Production { get; set; }
        public string? Dispatch { get; set; }
        public string? Status { get; set; }
        public int Id { get; set; }
        public string? RequestStatusName { get; set; }
        public string? Description { get; set; }
        public string? WorkflowStatus { get; set; }

    }
    public class ChangeNoteDetails
    {
        //public string? BatchId { get; set; }
        //public string? Brand { get; set; }
        //public int? BrandID { get; set; }
        //public string? Customer { get; set; }
        //public string? ShiftOtCountry { get; set; }
        //public string? Continent { get; set; }
        public string? Sales { get; set; }
        //public string? FileSize { get; set; }

        //public string? FileType { get; set; }
        //public string? FileSubType { get; set; }
        //public string? FileCode { get; set; }
        //public string? CutType { get; set; }
        ////Cut Standard
        //public string? CutStandard { get; set; }
        //public string? SAPNo { get; set; }
        //public string? FalcoCode { get; set; }
        //public string? SubmissionDate { get; set; }
        //public string? Production { get; set; }
        //public string? Dispatch { get; set; }

        public string? LookupValue { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? BrandId { get; set; }
        public string? BrandName { get; set; }
        public int? ShipToCountryId { get; set; }
        public string? CountryName { get; set; }
        public object? SAPNO { get; set; }
        public string? CustomerPartNumber { get; set; }
        public int? FileSizeId { get; set; }
        public string? FileSizeInch { get; set; }
        public string? FileTypeName { get; set; }
        public int? Id { get; set; }
        public string? FileSubTypeName { get; set; }

    }

    public class StampDetails
    {
        public string? RequestNo { get; set; }
        public string? StampProcess { get; set; }
        public string? ChartNo { get; set; }
        public string? Brand { get; set; }
        public string? StampChartImage { get; set; }
        public string? Remark { get; set; }

    }
    public class ChangeNoteApproval
    {
        public int RequestId { get; set; }
        public string RequestNo { get; set; }
        public int SaleFlag { get; set; }
        public int QAFlag { get; set; }
        public int GMFlag { get; set; }
        public int DirectorFlag { get; set; }
        public int CFOFlag { get; set; }
        public int CEOFlag { get; set; }
        public string SaleDate { get; set; }
        public string QADate { get; set; }
        public string GMDate { get; set; }
        public string DirectorDate { get; set; }
        public string CFODate { get; set; }
        public string CEODate { get; set; }
        public string FalcoCode { get; set; }
        public string RequestStatusName { get; set; }
        public string ReqType { get; set; }
    }


    public class FinalApproval
    {
        public FinalApprovallist[] FinalApprovallist { get; set; }
    }

    public class FinalApprovallist
    {
        public string RequestNo { get; set; }
        public int TransationId { get; set; }
        public string FalcoCode { get; set; }
        public string Description { get; set; }
        public string CurrentApprover { get; set; }
        public string CurrentStatus { get; set; }
        public string NextApprover { get; set; }
    }



    public class ApprovalList
    {
        public int TxnRequestId { get; set; }
        public string WorkFlowCode { get; set; }
        public string WorkFlowName { get; set; }
        public string Flag { get; set; }
        public string stageId { get; set; }
        public string stageName { get; set; }
        public string approvalType { get; set; }
        public string message { get; set; }
        public string approvers_userid { get; set; }
        public string approvers_username { get; set; }
        public string approvers_role { get; set; }
        public string approvers_sequence { get; set; }
        public string approvers_status { get; set; }
        public string approvers_date { get; set; }
        public string colorCode { get; set; }
    }


}
