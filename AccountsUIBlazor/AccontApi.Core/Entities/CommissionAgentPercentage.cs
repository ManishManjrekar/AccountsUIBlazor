using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Core
{
    public class CommissionAgentPercentage
    {
        public int CommissionAgentPercentageId { get; set; }
        public int CommissionPercentage { get; set; }
        public bool IsActive { get; set; }
    }
}
