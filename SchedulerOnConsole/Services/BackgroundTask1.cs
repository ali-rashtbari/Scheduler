namespace SchedulerOnConsole.Services
{
    public class BackgroundTask1
    {
        private Task? _timerTask;
        private readonly PeriodicTimer _timer;
        private readonly CancellationTokenSource _cancellationTokenSource = new();

        public BackgroundTask1(TimeSpan interval)
        {
            _timer = new PeriodicTimer(interval);
        }

        public void Start()
        {
            _timerTask = DoWorkAsync1();
        }

        private async Task DoWorkAsync1()
        {
            try
            {
                while(await _timer.WaitForNextTickAsync(_cancellationTokenSource.Token)) // درستش اینه که سعی میکنه زمان رو نزدیک به زمان استارت نگه داره و در طولانی مدت باعث افزایش اخلاف نشه ---
                {
                    Console.WriteLine($"DoWork-1: {DateTime.Now:O}");
                }

                //while (true) // این کاملا اشتباهه ---
                //{
                //    Console.WriteLine(DateTime.Now:O);
                //    Thread.Sleep(1000);
                //}

            }
            catch (OperationCanceledException ex)
            {
                throw;
            }
        }


        public async Task StopAsync()
        {
            if (_timer is null) return;
            _cancellationTokenSource.Cancel();
            await _timerTask;
            _cancellationTokenSource.Dispose();
            Console.WriteLine("Task was Cancelled :)");
        }

    }


    public class BackgroundTask2
    {
        private Task? _timerTask;
        private readonly PeriodicTimer _timer;
        private readonly CancellationTokenSource _cancellationTokenSource = new();

        public BackgroundTask2(TimeSpan interval)
        {
            _timer = new PeriodicTimer(interval);
        }

        public async void Start()
        {
            _timerTask = DoWorkAsync2();
        }

        private async Task DoWorkAsync2()
        {
            try
            {
                //while (await _timer.WaitForNextTickAsync(_cancellationTokenSource.Token)) // درستش اینه که سعی میکنه زمان رو نزدیک به زمان استارت نگه داره و در طولانی مدت باعث افزایش اخلاف نشه ---
                //{
                //    Console.WriteLine($"DoWork-2: {DateTime.Now:O}");
                //}

                while (true) // این کاملا اشتباهه ---
                {
                    Console.WriteLine($"DoWork-2: {DateTime.Now:O}");
                    await Task.Delay(1000);
                }

            }
            catch (OperationCanceledException ex)
            {
                throw;
            }
        }


        public async Task StopAsync()
        {
            if (_timer is null) return;
            _cancellationTokenSource.Cancel();
            await _timerTask;
            _cancellationTokenSource.Dispose();
            Console.WriteLine("Task was Cancelled :)");
        }

    }


}
