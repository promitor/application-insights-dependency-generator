using System.Net;
using Microsoft.Extensions.Logging;

namespace DependencyGenerator.Worker.Jobs
{
    public class TooManyRequestsDependencyGeneratorJob : DependencyGeneratorJob
    {
        public TooManyRequestsDependencyGeneratorJob(ILogger<TooManyRequestsDependencyGeneratorJob> logger)
            :base(logger)
        {
        }

        protected override HttpStatusCode HttpStatusCode => HttpStatusCode.TooManyRequests;
    }
}
