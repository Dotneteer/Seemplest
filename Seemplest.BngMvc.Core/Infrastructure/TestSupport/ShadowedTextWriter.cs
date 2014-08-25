using System;
using System.IO;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Seemplest.BngMvc.Core.Infrastructure.TestSupport
{
    public class ShadowedTextWriter: TextWriter, ITestableWriter
    {
        private readonly TextWriter _primaryWriter;
        private readonly StringWriter _shadowWriter;

        /// <summary>
        /// Initializes this writer with the specified writer instances
        /// </summary>
        /// <param name="primaryWriter">Primary writer</param>
        /// <param name="shadowWriter">Shadow writer</param>
        public ShadowedTextWriter(TextWriter primaryWriter, StringWriter shadowWriter)
        {
            if (primaryWriter == null)
            {
                throw new ArgumentNullException("primaryWriter");
            }
            _primaryWriter = primaryWriter;
            if (shadowWriter == null)
            {
                throw new ArgumentNullException("shadowWriter");
            }
            _shadowWriter = shadowWriter;
        }

        /// <summary>
        /// Closes the current writer and releases any system resources associated with the writer.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        public override void Close()
        {
            _primaryWriter.Close();
            _shadowWriter.Close();
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.IO.TextWriter"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _primaryWriter.Dispose();
                _shadowWriter.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Clears all buffers for the current writer and causes any buffered data to be written to the underlying device.
        /// </summary>
        public override void Flush()
        {
            _primaryWriter.Flush();
            _shadowWriter.Flush();
        }

        /// <summary>
        /// Writes a character to the text string or stream.
        /// </summary>
        /// <param name="value">The character to write to the text stream. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(char value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes a character array to the text string or stream.
        /// </summary>
        /// <param name="buffer">The character array to write to the text stream. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(char[] buffer)
        {
            _primaryWriter.Write(buffer);
            _shadowWriter.Write(buffer);
        }

        /// <summary>
        /// Writes a subarray of characters to the text string or stream.
        /// </summary>
        /// <param name="buffer">The character array to write data from. </param>
        /// <param name="index">The character position in the buffer at which to start retrieving data. </param>
        /// <param name="count">The number of characters to write. </param>
        /// <exception cref="T:System.ArgumentException">The buffer length minus <paramref name="index"/> is less than <paramref name="count"/>. </exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="buffer"/> parameter is null. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> or <paramref name="count"/> is negative. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(char[] buffer, int index, int count)
        {
            _primaryWriter.Write(buffer, index, count);
            _shadowWriter.Write(buffer, index, count);
        }

        /// <summary>
        /// Writes the text representation of a Boolean value to the text string or stream.
        /// </summary>
        /// <param name="value">The Boolean value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(bool value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of a 4-byte signed integer to the text string or stream.
        /// </summary>
        /// <param name="value">The 4-byte signed integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(int value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of a 4-byte unsigned integer to the text string or stream.
        /// </summary>
        /// <param name="value">The 4-byte unsigned integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(uint value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of an 8-byte signed integer to the text string or stream.
        /// </summary>
        /// <param name="value">The 8-byte signed integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(long value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of an 8-byte unsigned integer to the text string or stream.
        /// </summary>
        /// <param name="value">The 8-byte unsigned integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(ulong value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of a 4-byte floating-point value to the text string or stream.
        /// </summary>
        /// <param name="value">The 4-byte floating-point value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(float value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of an 8-byte floating-point value to the text string or stream.
        /// </summary>
        /// <param name="value">The 8-byte floating-point value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(double value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of a decimal value to the text string or stream.
        /// </summary>
        /// <param name="value">The decimal value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(decimal value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes a string to the text string or stream.
        /// </summary>
        /// <param name="value">The string to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(string value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of an object to the text string or stream by calling the ToString method on that object.
        /// </summary>
        /// <param name="value">The object to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(object value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes a formatted string to the text string or stream, using the same semantics as the <see cref="M:System.String.Format(System.String,System.Object)"/> method.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks). </param>
        /// <param name="arg0">The object to format and write. </param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="format"/> is null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException"><paramref name="format"/> is not a valid composite format string.-or- The index of a format item is less than 0 (zero), or greater than or equal to the number of objects to be formatted (which, for this method overload, is one). </exception>
        public override void Write(string format, object arg0)
        {
            _primaryWriter.Write(format, arg0);
            _shadowWriter.Write(format, arg0);
        }

        /// <summary>
        /// Writes a formatted string to the text string or stream, using the same semantics as the <see cref="M:System.String.Format(System.String,System.Object,System.Object)"/> method.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks). </param>
        /// <param name="arg0">The first object to format and write. </param>
        /// <param name="arg1">The second object to format and write. </param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="format"/> is null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException"><paramref name="format"/> is not a valid composite format string.-or- The index of a format item is less than 0 (zero) or greater than or equal to the number of objects to be formatted (which, for this method overload, is two). </exception>
        public override void Write(string format, object arg0, object arg1)
        {
            _primaryWriter.Write(format, arg0, arg1);
            _shadowWriter.Write(format, arg0, arg1);
        }

        /// <summary>
        /// Writes a formatted string to the text string or stream, using the same semantics as the <see cref="M:System.String.Format(System.String,System.Object,System.Object,System.Object)"/> method.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks). </param>
        /// <param name="arg0">The first object to format and write. </param>
        /// <param name="arg1">The second object to format and write. </param>
        /// <param name="arg2">The third object to format and write. </param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="format"/> is null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException"><paramref name="format"/> is not a valid composite format string.-or- The index of a format item is less than 0 (zero), or greater than or equal to the number of objects to be formatted (which, for this method overload, is three). </exception>
        public override void Write(string format, object arg0, object arg1, object arg2)
        {
            _primaryWriter.Write(format, arg0, arg1, arg2);
            _shadowWriter.Write(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// Writes a formatted string to the text string or stream, using the same semantics as the <see cref="M:System.String.Format(System.String,System.Object[])"/> method.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks). </param>
        /// <param name="arg">An object array that contains zero or more objects to format and write. </param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="format"/> or <paramref name="arg"/> is null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException"><paramref name="format"/> is not a valid composite format string.-or- The index of a format item is less than 0 (zero), or greater than or equal to the length of the <paramref name="arg"/> array. </exception>
        public override void Write(string format, params object[] arg)
        {
            _primaryWriter.Write(format, arg);
            _shadowWriter.Write(format, arg);
        }

        /// <summary>
        /// Writes a line terminator to the text string or stream.
        /// </summary>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine()
        {
            _primaryWriter.WriteLine();
            _shadowWriter.WriteLine();
        }

        /// <summary>
        /// Writes a character followed by a line terminator to the text string or stream.
        /// </summary>
        /// <param name="value">The character to write to the text stream. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(char value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes an array of characters followed by a line terminator to the text string or stream.
        /// </summary>
        /// <param name="buffer">The character array from which data is read. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(char[] buffer)
        {
            _primaryWriter.WriteLine(buffer);
            _shadowWriter.WriteLine(buffer);
        }

        /// <summary>
        /// Writes a subarray of characters followed by a line terminator to the text string or stream.
        /// </summary>
        /// <param name="buffer">The character array from which data is read. </param>
        /// <param name="index">The character position in <paramref name="buffer"/> at which to start reading data. </param>
        /// <param name="count">The maximum number of characters to write. </param>
        /// <exception cref="T:System.ArgumentException">The buffer length minus <paramref name="index"/> is less than <paramref name="count"/>. </exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="buffer"/> parameter is null. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> or <paramref name="count"/> is negative. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(char[] buffer, int index, int count)
        {
            _primaryWriter.WriteLine(buffer, index, count);
            _shadowWriter.WriteLine(buffer, index, count);
        }

        /// <summary>
        /// Writes the text representation of a Boolean value followed by a line terminator to the text string or stream.
        /// </summary>
        /// <param name="value">The Boolean value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(bool value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of a 4-byte signed integer followed by a line terminator to the text string or stream.
        /// </summary>
        /// <param name="value">The 4-byte signed integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(int value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of a 4-byte unsigned integer followed by a line terminator to the text string or stream.
        /// </summary>
        /// <param name="value">The 4-byte unsigned integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(uint value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of an 8-byte signed integer followed by a line terminator to the text string or stream.
        /// </summary>
        /// <param name="value">The 8-byte signed integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(long value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of an 8-byte unsigned integer followed by a line terminator to the text string or stream.
        /// </summary>
        /// <param name="value">The 8-byte unsigned integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(ulong value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of a 4-byte floating-point value followed by a line terminator to the text string or stream.
        /// </summary>
        /// <param name="value">The 4-byte floating-point value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(float value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of a 8-byte floating-point value followed by a line terminator to the text string or stream.
        /// </summary>
        /// <param name="value">The 8-byte floating-point value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(double value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of a decimal value followed by a line terminator to the text string or stream.
        /// </summary>
        /// <param name="value">The decimal value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(decimal value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes a string followed by a line terminator to the text string or stream.
        /// </summary>
        /// <param name="value">The string to write. If <paramref name="value"/> is null, only the line terminator is written. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(string value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of an object by calling the ToString method on that object, followed by a line terminator to the text string or stream.
        /// </summary>
        /// <param name="value">The object to write. If <paramref name="value"/> is null, only the line terminator is written. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(object value)
        {
            _primaryWriter.Write(value);
            _shadowWriter.Write(value);
        }

        /// <summary>
        /// Writes a formatted string and a new line to the text string or stream, using the same semantics as the <see cref="M:System.String.Format(System.String,System.Object)"/> method.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg0">The object to format and write. </param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="format"/> is null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException"><paramref name="format"/> is not a valid composite format string.-or- The index of a format item is less than 0 (zero), or greater than or equal to the number of objects to be formatted (which, for this method overload, is one). </exception>
        public override void WriteLine(string format, object arg0)
        {
            _primaryWriter.WriteLine(format, arg0);
            _shadowWriter.WriteLine(format, arg0);
        }

        /// <summary>
        /// Writes a formatted string and a new line to the text string or stream, using the same semantics as the <see cref="M:System.String.Format(System.String,System.Object,System.Object)"/> method.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg0">The first object to format and write. </param>
        /// <param name="arg1">The second object to format and write. </param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="format"/> is null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception><exception cref="T:System.FormatException"><paramref name="format"/> is not a valid composite format string.-or- The index of a format item is less than 0 (zero), or greater than or equal to the number of objects to be formatted (which, for this method overload, is two). </exception>
        public override void WriteLine(string format, object arg0, object arg1)
        {
            _primaryWriter.WriteLine(format, arg0, arg1);
            _shadowWriter.WriteLine(format, arg0, arg1);
        }

        /// <summary>
        /// Writes out a formatted string and a new line, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg0">The first object to format and write. </param>
        /// <param name="arg1">The second object to format and write. </param>
        /// <param name="arg2">The third object to format and write. </param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="format"/> is null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException"><paramref name="format"/> is not a valid composite format string.-or- The index of a format item is less than 0 (zero), or greater than or equal to the number of objects to be formatted (which, for this method overload, is three). </exception>
        public override void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            _primaryWriter.WriteLine(format, arg0, arg1, arg2);
            _shadowWriter.WriteLine(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// Writes out a formatted string and a new line, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg">An object array that contains zero or more objects to format and write. </param>
        /// <exception cref="T:System.ArgumentNullException">A string or object is passed in as null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException"><paramref name="format"/> is not a valid composite format string.-or- The index of a format item is less than 0 (zero), or greater than or equal to the length of the <paramref name="arg"/> array. </exception>
        public override void WriteLine(string format, params object[] arg)
        {
            _primaryWriter.WriteLine(format, arg);
            _shadowWriter.WriteLine(format, arg);
        }

        /// <summary>
        /// Writes a character to the text string or stream asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous write operation.
        /// </returns>
        /// <param name="value">The character to write to the text stream.</param>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        public override Task WriteAsync(char value)
        {
            return Task.WhenAll(
                _primaryWriter.WriteAsync(value), 
                _shadowWriter.WriteAsync(value));
        }

        /// <summary>
        /// Writes a string to the text string or stream asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous write operation. 
        /// </returns>
        /// <param name="value">The string to write. If <paramref name="value"/> is null, nothing is written to the text stream.</param>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        public override Task WriteAsync(string value)
        {
            return Task.WhenAll(
                _primaryWriter.WriteAsync(value),
                _shadowWriter.WriteAsync(value));
        }

        /// <summary>
        /// Writes a subarray of characters to the text string or stream asynchronously. 
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous write operation.
        /// </returns>
        /// <param name="buffer">The character array to write data from. </param>
        /// <param name="index">The character position in the buffer at which to start retrieving data. </param>
        /// <param name="count">The number of characters to write. </param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="buffer"/> is null.</exception>
        /// <exception cref="T:System.ArgumentException">The <paramref name="index"/> plus <paramref name="count"/> is greater than the buffer length.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> or <paramref name="count"/> is negative.</exception>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        public override Task WriteAsync(char[] buffer, int index, int count)
        {
            return Task.WhenAll(
                _primaryWriter.WriteAsync(buffer, index, count),
                _shadowWriter.WriteAsync(buffer, index, count));
        }

        /// <summary>
        /// Writes a character followed by a line terminator asynchronously to the text string or stream.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous write operation.
        /// </returns>
        /// <param name="value">The character to write to the text stream.</param>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        public override Task WriteLineAsync(char value)
        {
            return Task.WhenAll(
                _primaryWriter.WriteAsync(value),
                _shadowWriter.WriteAsync(value));
        }

        /// <summary>
        /// Writes a string followed by a line terminator asynchronously to the text string or stream. 
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous write operation.
        /// </returns>
        /// <param name="value">The string to write. If the value is null, only a line terminator is written. </param>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        public override Task WriteLineAsync(string value)
        {
            return Task.WhenAll(
                _primaryWriter.WriteAsync(value),
                _shadowWriter.WriteAsync(value));
        }

        /// <summary>
        /// Writes a subarray of characters followed by a line terminator asynchronously to the text string or stream.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous write operation.
        /// </returns>
        /// <param name="buffer">The character array to write data from. </param>
        /// <param name="index">The character position in the buffer at which to start retrieving data. </param>
        /// <param name="count">The number of characters to write. </param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="buffer"/> is null.</exception>
        /// <exception cref="T:System.ArgumentException">The <paramref name="index"/> plus <paramref name="count"/> is greater than the buffer length.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> or <paramref name="count"/> is negative.</exception>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        public override Task WriteLineAsync(char[] buffer, int index, int count)
        {
            return Task.WhenAll(
                _primaryWriter.WriteAsync(buffer, index, count),
                _shadowWriter.WriteAsync(buffer, index, count));
        }

        /// <summary>
        /// Writes a line terminator asynchronously to the text string or stream.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous write operation. 
        /// </returns>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        public override Task WriteLineAsync()
        {
            return Task.WhenAll(
                _primaryWriter.WriteLineAsync(),
                _shadowWriter.WriteLineAsync());
        }

        /// <summary>
        /// Asynchronously clears all buffers for the current writer and causes any buffered data to be written to the underlying device. 
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous flush operation. 
        /// </returns>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The writer is currently in use by a previous write operation. </exception>
        public override Task FlushAsync()
        {
            return Task.WhenAll(
                _primaryWriter.FlushAsync(),
                _shadowWriter.FlushAsync());
        }

        /// <summary>
        /// Gets an object that controls formatting.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.IFormatProvider"/> object for a specific culture, or the formatting of the current culture if no other culture is specified.
        /// </returns>
        public override IFormatProvider FormatProvider
        {
            get { return _primaryWriter.FormatProvider; }
        }

        /// <summary>
        /// Obtains a lifetime service object to control the lifetime policy for this instance.
        /// </summary>
        /// <returns>
        /// An object of type <see cref="T:System.Runtime.Remoting.Lifetime.ILease"/> used to control the lifetime policy for this instance. This is the current lifetime service object for this instance if one exists; otherwise, a new lifetime service object initialized to the value of the <see cref="P:System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime"/> property.
        /// </returns>
        /// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission. </exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="RemotingConfiguration, Infrastructure"/></PermissionSet>
        public override object InitializeLifetimeService()
        {
            return _primaryWriter.InitializeLifetimeService();
        }

        /// <summary>
        /// Creates an object that contains all the relevant information required to generate a proxy used to communicate with a remote object.
        /// </summary>
        /// <returns>
        /// Information required to generate a proxy.
        /// </returns>
        /// <param name="requestedType">The <see cref="T:System.Type"/> of the object that the new <see cref="T:System.Runtime.Remoting.ObjRef"/> will reference. </param><exception cref="T:System.Runtime.Remoting.RemotingException">This instance is not a valid remoting object. </exception><exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission. </exception><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="Infrastructure"/></PermissionSet>
        public override ObjRef CreateObjRef(Type requestedType)
        {
            return _primaryWriter.CreateObjRef(requestedType);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return _primaryWriter.ToString();
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            return _primaryWriter.Equals(obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return _primaryWriter.GetHashCode();
        }

        /// <summary>
        /// When overridden in a derived class, returns the character encoding in which the output is written.
        /// </summary>
        /// <returns>
        /// The character encoding in which the output is written.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public override Encoding Encoding
        {
            get { return _primaryWriter.Encoding; }
        }

        /// <summary>
        /// Get the string that represents the output
        /// </summary>
        /// <returns>Output of the testable writer</returns>
        public string GetOutput()
        {
            return _shadowWriter.ToString();
        }

        /// <summary>
        /// Gets the writer
        /// </summary>
        /// <returns>Primary writer instance</returns>
        public TextWriter GetWriter()
        {
            return this;
        }
    }
}