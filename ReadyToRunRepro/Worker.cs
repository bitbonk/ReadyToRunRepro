namespace ReadyToRunRepro;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> logger;
    private readonly IService service;

    public Worker(ILogger<Worker> logger, IService service)
    {
        this.logger = logger;
        this.service = service;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Make sure the type from the type hierarchy is actually used (deleting this line will make the error go away)
        this.logger.LogInformation("Service {service} acquired", this.service);
        
        while (!stoppingToken.IsCancellationRequested)
        {
            if (this.logger.IsEnabled(LogLevel.Information))
            {
                this.logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
