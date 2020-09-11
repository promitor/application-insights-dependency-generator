using System.Net;
using Microsoft.Extensions.Logging;

namespace DependencyGenerator.Worker.Jobs
{
    public class PaymentRequiredDependencyGeneratorJob : DependencyGeneratorJob
    {
        public PaymentRequiredDependencyGeneratorJob(ILogger<PaymentRequiredDependencyGeneratorJob> logger)
            :base(logger)
        {
        }

        protected override HttpStatusCode HttpStatusCode => HttpStatusCode.PaymentRequired;
    }
}
