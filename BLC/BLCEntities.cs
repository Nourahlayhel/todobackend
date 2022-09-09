using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLC
{
    public partial class Params_Get_Todo_By_USER_ID
    {
        public int USER_ID { get; set; }

    }
    public partial class Params_Get_Person_By_EMAIL_ADDRESS
    {
        public string EMAIL_ADDRESS{ get; set; }

    }
    public partial class Params_Edit_Task {
        public int id { get; set; }
        public string description { get; set; } 
        public int user_id { get; set; }
    }

}
