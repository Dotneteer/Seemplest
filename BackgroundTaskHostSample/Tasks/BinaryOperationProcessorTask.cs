using System;
using System.Globalization;
using BackgroundTaskHostSample.Messages;
using Seemplest.Core.Tasks;

namespace BackgroundTaskHostSample.Tasks
{
    /// <summary>
    /// This class is responsible for processing operation messages
    /// </summary>
    public class BinaryOperationProcessorTask : TaskBase<BinaryOperationMessage, BinaryOperationResultMessage>,
        ITaskArgumentConverter<BinaryOperationMessage>,
        ITaskResultConverter<BinaryOperationResultMessage>
    {
        /// <summary>
        /// Runs the specific task.
        /// </summary>
        public override void Run()
        {
            Result = new BinaryOperationResultMessage
            {
                Operand1 = Argument.Operand1,
                Operation = Argument.Operation,
                Operand2 = Argument.Operand2
            };
            try
            {
                switch (Argument.Operation)
                {
                    case "+":
                        Result.Result = (Argument.Operand1 + Argument.Operand2).ToString(CultureInfo.InvariantCulture);
                        break;
                    case "-":
                        Result.Result = (Argument.Operand1 - Argument.Operand2).ToString(CultureInfo.InvariantCulture);
                        break;
                    case "*":
                        Result.Result = (Argument.Operand1 * Argument.Operand2).ToString(CultureInfo.InvariantCulture);
                        break;
                    case "/":
                        Result.Result = (Argument.Operand1 / Argument.Operand2).ToString(CultureInfo.InvariantCulture);
                        break;
                    case "%":
                        Result.Result = (Argument.Operand1 % Argument.Operand2).ToString(CultureInfo.InvariantCulture);
                        break;
                    default:
                        Result.Result = String.Format("Invalid operation: '{0}'", Argument.Operation);
                        break;
                }
            }
            catch (Exception ex)
            {
                Result.Result = ex.Message;
            }
        }

        /// <summary>
        /// Gets the argument converter of this task
        /// </summary>
        public override ITaskArgumentConverter<BinaryOperationMessage> ArgumentConverter
        {
            get { return this; }
        }

        /// <summary>
        /// Gets the result converter of this task
        /// </summary>
        public override ITaskResultConverter<BinaryOperationResultMessage> ResultConverter
        {
            get { return this; }
        }

        /// <summary>
        /// Converts the string message into an argument understandable by the task.
        /// </summary>
        /// <param name="message">Message representing the task argument.</param>
        /// <returns>Task argument</returns>
        public BinaryOperationMessage ConvertToArgument(string message)
        {
            var parts = message.Split(new[] { ' ' });
            return new BinaryOperationMessage
            {
                Operand1 = Int32.Parse(parts[0].Trim()),
                Operation = parts[1].Trim(),
                Operand2 = Int32.Parse(parts[2].Trim())
            };
        }

        /// <summary>
        /// Converts the result of the task to a string message.
        /// </summary>
        /// <param name="result">Task result instance</param>
        /// <returns>String representation of the task result.</returns>
        public string ConvertToResult(BinaryOperationResultMessage result)
        {
            return result.ToString();
        }
    }
}