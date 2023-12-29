
using SchedulerOnConsole.Services;

Console.WriteLine("Press any key to start Taks ...");
Console.ReadKey();

//var task1 = new BackgroundTask1(TimeSpan.FromMilliseconds(1000));
var task2 = new BackgroundTask2(TimeSpan.FromMilliseconds(1000));

//task1.Start();
task2.Start();

Console.WriteLine("Press any button to stop the Task ... ");
Console.ReadKey();

//await task1.StopAsync();
await task2.StopAsync();