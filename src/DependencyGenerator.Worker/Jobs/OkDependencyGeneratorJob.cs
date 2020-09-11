using System.Net;
using Microsoft.Extensions.Logging;

namespace DependencyGenerator.Worker.Jobs
{
    public class OkDependencyGeneratorJob : DependencyGeneratorJob
    {
        public OkDependencyGeneratorJob(ILogger<OkDependencyGeneratorJob> logger)
            :base(logger)
        {
        }

        protected override HttpStatusCode HttpStatusCode => HttpStatusCode.OK;
    }
}
