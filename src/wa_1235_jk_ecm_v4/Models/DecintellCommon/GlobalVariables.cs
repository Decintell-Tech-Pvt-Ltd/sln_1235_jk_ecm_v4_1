namespace wa_1235_jk_ecm_v4.Models.DecintellCommon
{

    public class GlobalVariables
    {
        private static GlobalVariables instance;

        // Properties
        public int UserId { get; set; }
        public int OemId { get; set; }
        public string AccessToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        //Additional Variables For TEM
        public string Language { get; set; }
        public int ReportingManager { get; set; }
        public string EmployeeGrade { get; set; }
        public string EmployeeGradeName { get; set; }
        public string ITCountryLoc { get; set; }
        public string RoleName { get; set; }
        public string FinancialYear { get; set; }
        public string IsCountryIndia { get; set; }
        // Private constructor to prevent instantiation outside the class
        private GlobalVariables() { }

        // Public method to get the singleton instance
        public static GlobalVariables Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GlobalVariables();
                }
                return instance;
            }
        }

        // Method to reset all properties to their default values
        public void ClearAllVariables()
        {
            UserId = 0;
            OemId = 0;
            AccessToken = null;
            FirstName = null;
            LastName = null;
            FullName = null;
        }
    }


}
