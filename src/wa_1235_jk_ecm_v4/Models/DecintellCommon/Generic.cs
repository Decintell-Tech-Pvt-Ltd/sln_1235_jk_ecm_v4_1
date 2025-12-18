namespace wa_1235_jk_ecm_v4.Models.DecintellCommon
{
    public class Generic
    {
        // public int OemId { get; set; }
    }

    public class UpdateResponse
    {
        public string Result { get; set; }
        public string LoginID { get; set; }
        public int NewTxnRequestId { get; set; }
        public string UserEmailID { get; set; }
    }


    public class PageAccess
    {
        public int UserID { get; set; }
        public int OEMID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int ModuleID { get; set; }
        public int PageID { get; set; }
        public int EventID { get; set; }
        public string AttributeID { get; set; }
    }



    public class UserDetail
    {
        public string ApplicationUserEmailID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string UserMobileNo { get; set; }
        public int ReportingManager { get; set; }
    }

    public class Mail
    {
        public string mailStatus { get; set; }
    }
    //public class DropdownValue_List
    //{
    //    public int Id { get; set; }
    //    public string DropdownList { get; set; }
    //}
    public class DropdownValue
    {
        public int Id { get; set; }
        public string DropdownList { get; set; }
    }
    //public class DropdownValueList
    //{
    //    public int Id { get; set; }
    //    public string DropdownList { get; set; }
    //}

}
