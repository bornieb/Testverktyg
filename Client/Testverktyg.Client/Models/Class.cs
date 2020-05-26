using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testverktyg.Client.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public Class(int classid, string classname)
        {
            ClassId = classid;
            ClassName = classname;
        }
    }
}
