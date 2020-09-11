using System.Net;
using Microsoft.Extensions.Logging;

namespace DependencyGenerator.Worker.Jobs
{
    public class InternalServerErrorDependencyGeneratorJob : DependencyGeneratorJob
    {
        public InternalServerErrorDependencyGeneratorJob(ILogger<InternalServerErrorDependencyGeneratorJob> logger)
            :base(logger)
        {
        }

        protected override HttpStatusCode HttpStatusCode => HttpStatusCode.InternalServerError;
    }
}
