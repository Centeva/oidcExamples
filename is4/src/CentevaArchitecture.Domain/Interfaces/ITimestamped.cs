using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentevaArchitecture.Domain.Interfaces
{
    public interface ITimestamped
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? LastUpdatedAt { get; set; }
    }
}
