using System;
using BackgroundTaskHostSample.Messages;
using Seemplest.Core.Configuration.ResourceConnections;
using Seemplest.Core.Queue;
using Seemplest.Core.Tasks;

namespace BackgroundTaskHostSample.Tasks
{
    /// <summary>
    /// This class generates random binary operations
    /// </summary>
    public class BinaryOperationProducerTask : TaskBase
    {
        private const string BATCH_SIZE_PROPERTY = "BatchSize";
        private const string QUEUE_KEY = "requestQueue";
        private const int VISIBILITY_SECONDS = 1000;

        private int _batchSize;

        /// <summary>
        /// Sets up the task that will be run in the specified context.
        /// </summary>
        /// <param name="context">Task execution context</param>
        public override void Setup(ITaskExecutionContext context)
        {
            base.Setup(context);
            _batchSize = context.GetProperty(BATCH_SIZE_PROPERTY, 100);
        }

        /// <summary>
        /// Runs the specific task.
        /// </summary>
        public override void Run()
        {
            // --- Obtain the queue to put the results in
            var queue = ResourceConnectionFactory.CreateResourceConnection<INamedQueue>(QUEUE_KEY);
            var rnd = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < _batchSize; i++)
            {
                string opCode;
                switch (rnd.Next(0, 5))
                {
                    case 0: opCode = "+"; break;
                    case 1: opCode = "-"; break;
                    case 2: opCode = "*"; break;
                    case 3: opCode = "/"; break;
                    default: opCode = "%"; break;
                }
                var opMessage = new BinaryOperationMessage
                {
                    Operation = opCode,
                    Operand1 = rnd.Next(0, 1000),
                    Operand2 = rnd.Next(0, 1000)
                };
                queue.PutMessage(opMessage.ToString(), VISIBILITY_SECONDS);
            }
        }
    }
}