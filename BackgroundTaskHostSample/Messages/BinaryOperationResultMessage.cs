namespace BackgroundTaskHostSample.Messages
{
    /// <summary>
    /// This class represents a binary operation with its result
    /// </summary>
    public class BinaryOperationResultMessage : BinaryOperationMessage
    {
        public string Result;

        public override string ToString()
        {
            return string.Format("{0} = {1}", base.ToString(), Result);
        }
    }
}