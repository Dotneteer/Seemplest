using System.IO;

namespace Seemplest.BngMvc.Core.Infrastructure.TestSupport
{
    /// <summary>
    /// This interface defines a writer object that can be used for testing purposes
    /// </summary>
    public interface ITestableWriter
    {
        /// <summary>
        /// Get the string that represents the output
        /// </summary>
        /// <returns>Output of the testable writer</returns>
        string GetOutput();

        /// <summary>
        /// Gets the writer
        /// </summary>
        /// <returns>Primary writer instance</returns>
        TextWriter GetWriter();
    }
}