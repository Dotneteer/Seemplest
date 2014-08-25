namespace BackgroundTaskHostSample.Messages
{
    /// <summary>
    /// This class describes a simple binary operation
    /// </summary>
    public class BinaryOperationMessage
    {
        public string Operation;
        public int Operand1;
        public int Operand2;

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Operand1, Operation, Operand2);
        }
    }
}