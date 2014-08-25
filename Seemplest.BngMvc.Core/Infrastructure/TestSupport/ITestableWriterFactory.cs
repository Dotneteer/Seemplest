using System.IO;

namespace Seemplest.BngMvc.Core.Infrastructure.TestSupport
{
    /// <summary>
    /// This interface defines factory for a writer object that can be used for unit test
    /// </summary>
    public interface ITestableWriterFactory
    {
        /// <summary>
        /// Gets a TextWriter instance that can be used for testing purposes
        /// </summary>
        /// <param name="primaryWriter">Primary text writer</param>
        /// <returns>
        /// TextWriter suitable for test purposes
        /// </returns>
        ITestableWriter GetTestableWriter(TextWriter primaryWriter);
    }
}