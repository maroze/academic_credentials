using WebParking.Data.Repositories;
using WebParking.Service.Services;

namespace WebParking.Background
{
    public class CheckParkingBookWorker : BackgroundService
    {
        private readonly ILogger<CheckParkingBookWorker> _logger;
        public readonly IServiceScopeFactory _serviceScopeFactory;

        public CheckParkingBookWorker(ILogger<CheckParkingBookWorker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var repo = scope.ServiceProvider.GetRequiredService<IBookingLotRepository>();
                    var lot = scope.ServiceProvider.GetRequiredService<ILotRepository>();
                    foreach (var pendingTask in repo.GetStartBooks())
                    {
                        var l = await lot.GetLot(pendingTask.IdLots);
                        l.IsBooked = true;
                        await lot.UpdateLot(l);
                    }

                    foreach (var pendingTask in repo.GetEndBooks())
                    {
                        var l = await lot.GetLot(pendingTask.IdLots);
                        l.IsBooked = false;
                        await lot.UpdateLot(l);
                        pendingTask.IsExpired = true;
                        await repo.UpdateBook(pendingTask);
                    }
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
