using System.IO;
using System.Xml.Linq;
using Seemplest.BngMvc.Core.Infrastructure.TestSupport;

namespace Seemplest.BngMvc.Core.Tests.Helpers
{
    /// <summary>
    /// This class implements a test stream to emulate the HtmlHelper's view contex writer
    /// to test Bng components
    /// </summary>
    public class TestStream: ITestableWriterFactory
    {
        /// <summary>
        /// The writer used for tests
        /// </summary>
        private static StringWriter s_Shadow;

        /// <summary>
        /// The singleton instance of this class
        /// </summary>
        public static TestStream Instance = new TestStream();

        /// <summary>
        /// Initializes the static members
        /// </summary>
        static TestStream()
        {
            Reset();
        }

        /// <summary>
        /// Resets the test stream
        /// </summary>
        public static void Reset()
        {
            s_Shadow = new StringWriter();
        }

        /// <summary>
        /// Gets a TextWriter instance that can be used for testing purposes
        /// </summary>
        /// <param name="primaryWriter">Primary text writer</param>
        /// <returns>
        /// TextWriter suitable for test purposes
        /// </returns>
        public ITestableWriter GetTestableWriter(TextWriter primaryWriter)
        {
            return new ShadowedTextWriter(primaryWriter ?? new StringWriter(), s_Shadow);
        }

        /// <summary>
        /// The content of the test stream
        /// </summary>
        public static string Content
        {
            get { return s_Shadow.ToString(); }
        }

        /// <summary>
        /// The DOM of the test stream
        /// </summary>
        public static XElement Dom
        {
            get { return XElement.Parse(s_Shadow.ToString()); }
        }
    }
}