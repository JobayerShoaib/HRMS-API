using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class AuditSecrets
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserID { get; set; }
        public string Secret { get; set; }
    }
}
