using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DependencyGenerator.Worker.Jobs
{
    public abstract class DependencyGeneratorJob : BackgroundService
    {
        private readonly ILogger<DependencyGeneratorJob> _logger;
        private readonly Faker _faker = new Faker();

        protected abstract HttpStatusCode HttpStatusCode { get; }

        public DependencyGeneratorJob(ILogger<DependencyGeneratorJob> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("DependencyGeneratorJob running at: {time}", DateTimeOffset.Now);

                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:1337");

                var startTime = _faker.Date.Recent();
                var duration = TimeSpan.FromMilliseconds(_faker.Random.Int(min: 10, max: 100000));

                _logger.LogHttpDependency(httpRequestMessage, HttpStatusCode, startTime, duration);
                await Task.Delay(200, stoppingToken);
            }
        }
    }
}
