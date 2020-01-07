using System;
using System.Collections.Generic;
using System.Text;

namespace Inventorydata.data
{
    public class Staff
    {
        public int ID { get; set; }

        public int PermissionsID { get; set; }

        public Permissions Permissions { get; set; }

    }
}
