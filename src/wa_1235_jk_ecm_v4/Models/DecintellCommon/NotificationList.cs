using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_1235_jk_ecm_v4.Models.DecintellCommon
{
    public class NotificationList
    {
        public List<NotificationList> Notificationlist { get; set; }
    }
    public class Notification_List
    {
        public int NotificationID { get; set; }

        public string Message { get; set; }
        public string Subject { get; set; }
    }
}
