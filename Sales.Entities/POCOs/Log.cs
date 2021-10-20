using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.POCOs
{
    public class Log
    {
        public int Id {  get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public Log(DateTime createDate, string description) => 
            (CreatedDate, Description) = (createDate, description);
        public Log(string description) : this(DateTime.Now, description) { }
    }
}
