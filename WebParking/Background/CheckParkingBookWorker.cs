using WebParking.Service.Services;

namespace WebParking.Background
{
    public class CheckParkingBookWorker : BackgroundService
    {
        private readonly ILogger<CheckParkingBookWorker> _logger;
        private static int count;
        public CheckParkingBookWorker(ILogger<CheckParkingBookWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Interlocked.Increment(ref count);
                _logger.LogInformation($"the count if {count} from Worker");
                await Task.Delay(1000, stoppingToken);
            }
        }
        //private void UpdateBookLot(object state)
        //{
        //    foreach (var item inS _bookingService.GetBooks())
        //    {

        //    }
        //}
    }
}
