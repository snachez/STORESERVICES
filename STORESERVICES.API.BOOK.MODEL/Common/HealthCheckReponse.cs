using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.BOOK.MODEL.Common
{
    public class HealthCheckReponse
    {
        public string? Status { get; set; }
        public IEnumerable<IndividualHealthCheckResponse>? HealthChecks { get; set; }
        public string? HealthCheckDuration { get; set; }
    }
}
