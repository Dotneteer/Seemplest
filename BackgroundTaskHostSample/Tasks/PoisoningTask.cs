using Seemplest.Core.Configuration.ResourceConnections;
using Seemplest.Core.Queue;
using Seemplest.Core.Tasks;

namespace BackgroundTaskHostSample.Tasks
{
    /// <summary>
    /// This task generates poisoning messages
    /// </summary>
    public class PoisoningTask : TaskBase
    {
        private const string QUEUE_KEY = "requestQueue";
        private const int VISIBILITY_SECONDS = 1000;

        /// <summary>
        /// Runs the specific task.
        /// </summary>
        public override void Run()
        {
            var queue = ResourceConnectionFactory.CreateResourceConnection<INamedQueue>(QUEUE_KEY);

            // --- This message is poisoning
            queue.PutMessage("blablabla...", VISIBILITY_SECONDS);

            // --- This message raises a processing exception
            queue.PutMessage("1 / 0", VISIBILITY_SECONDS);
        }
    }
}