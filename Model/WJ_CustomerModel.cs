using Model.SystemModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WJ_CustomerModel
    {
    }

    public class WJ_CustomerFilter : PageModel
    {
        public string CusName { get; set; }

        public string PhoneNo { get; set; }
    }
}
