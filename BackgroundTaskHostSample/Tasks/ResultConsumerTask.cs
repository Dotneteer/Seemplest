using System;
using Seemplest.Core.Tasks;

namespace BackgroundTaskHostSample.Tasks
{
    /// <summary>
    /// This task is responsible for displaying the results of the binary operation
    /// </summary>
    public class ResultConsumerTask : TaskBase<string>
    {
        /// <summary>
        /// Runs the specific task.
        /// </summary>
        public override void Run()
        {
            Console.WriteLine(Argument);
        }
    }
}