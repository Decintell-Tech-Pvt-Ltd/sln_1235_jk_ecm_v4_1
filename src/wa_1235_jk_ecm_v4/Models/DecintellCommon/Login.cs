namespace wa_1235_jk_ecm_v4.Models.DecintellCommon
{
    public class Login
    {
        public PolicyList[] PolicyList { get; set; }
    }


    public class TokenDetail
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
    }



    public class ApplicationUser
    {
        public bool ApplicationUserIsUserFirstLogin { get; set; }
        public string ApplicationUserLoginPassword { get; set; }
        public int UserId { get; set; }
        public int OemId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }


    public class PolicyList
    {
        public string PasswordPolicyName { get; set; }
        public int PasswordPolicyValue { get; set; }
    }



    public class Notification_OemList_Logo
    {
        public Notificationcount[] NotificationCount { get; set; }
        public Notificationlist[] NotificationList { get; set; }
        public Oemlist[] OemList { get; set; }
        public Logolist[] LogoList { get; set; }
        public string ApplicationUserProfilePic { get; set; }
        public string UserHexColor { get; set; }
    }

    public class Notificationcount
    {
        public int Notificationcnt { get; set; }
    }

    public class Notificationlist
    {
        public int NotificationID { get; set; }
        public string Subject { get; set; }
    }

    public class Oemlist
    {
        public int OEMID { get; set; }
        public string OEMName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int ApproverId { get; set; }
    }



    public class Logolist
    {
        public string ModuleLogo { get; set; }
        public string OEMLogo { get; set; }
        public string ApplicationUserProfilePic { get; set; }
    }

    //public class Modulelogo
    //{
    //    public string ModuleLogo { get; set; }
    //    public string OEMLogo { get; set; }
    //    public string ApplicationUserProfilePic { get; set; }
    //}


}
