using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMiningForm
{
    public class MineClass
    {
        public int CaseId { get; set; }
        public DateTime EventDate { get; set; }
        public string Activity { get; set; }
        public string Resource { get; set; }
        public int Costs { get; set; }
    }
}
