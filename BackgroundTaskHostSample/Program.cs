using System;
using System.Linq;
using System.Threading;
using Seemplest.Core.Configuration;
using Seemplest.Core.Configuration.ResourceConnections;
using Seemplest.Core.PerformanceCounters;
using Seemplest.Core.Queue;
using Seemplest.Core.Tasks;
using Seemplest.Core.Tasks.Configuration;

namespace BackgroundTaskHostSample
{
    class Program
    {
        private const string BACKGROUND_TASK_HOST_SECTION = "BackgroundTaskHost";
        private const string REQUEST_QUEUE = "requestQueue";
        private const string RESPONSE_QUEUE = "responseQueue";

        static void Main()
        {
            // --- Create performance counters if not installed yet
            var counter = PmcManager.GetCounter<TasksProcessedPmc>("consumer");
            if (!counter.HasInstance)
            {
                Console.WriteLine("Installing performance counters...");
                var pmcData = new PmcCreationData();
                pmcData.MergeCountersFromAssembly(typeof(TasksProcessedPmc).Assembly);
                PmcManager.InstallPerformanceCounters(pmcData);
            }

            // --- Clean up the message queues
            var requestQueue = ResourceConnectionFactory.CreateResourceConnection<INamedQueue>(REQUEST_QUEUE);
            requestQueue.Clear();
            var responseQueue = ResourceConnectionFactory.CreateResourceConnection<INamedQueue>(RESPONSE_QUEUE);
            responseQueue.Clear();

            // --- Set up the background host
            var settings = AppConfigurationManager.GetSettings<BackgroundTaskHostSettings>(BACKGROUND_TASK_HOST_SECTION);
            var host = new BackgroundTaskHost(settings);

            // --- Do the work for 10 seconds
            Console.WriteLine("Starting background task host.");
            host.Start();
            Thread.Sleep(5000);

            var context = host.Configuration.DefaultContext;
            var processors = host.Configuration.GetTaskProcessors();
            foreach (var processor in processors.Where(processor => processor.Name == "Processor"))
            {
                processor.InstanceCount = 3;
                break;
            }

            host.Reconfigure(new BackgroundTaskHostSettings(context, processors));

            Thread.Sleep(5000);

            Console.WriteLine("Stopping background task host.");
            host.Stop();
        }
    }
}
