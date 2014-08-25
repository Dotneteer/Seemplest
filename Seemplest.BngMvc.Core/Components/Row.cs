using System.Collections.Generic;
using Seemplest.BngMvc.Core.Infrastructure;

namespace Seemplest.BngMvc.Core.Components
{
    /// <summary>
    /// This class represents a Bootstrap row component
    /// </summary>
    public class Row: HtmlElementBase<Row>, IColumnWidth
    {
        /// <summary>
        /// Initializes a new row instance
        /// </summary>
        public Row() : base(HtmlTag.Div)
        {
            InitAttributes();
        }

        /// <summary>
        /// Initializes the row with the specified attributes
        /// </summary>
        /// <param name="attribs">Attribute dictionary</param>
        public Row(IDictionary<string, object> attribs)
            : base(HtmlTag.Div, attribs)
        {
            InitAttributes();
        }

        /// <summary>
        /// Initializes the container with the specified attributes
        /// </summary>
        /// <param name="attribs">Attribute key/value enumeration</param>
        public Row(params string[] attribs)
            : base(HtmlTag.Div, attribs)
        {
            InitAttributes();
        }

        private void InitAttributes()
        {
            EnsureClass(RowStyle.Row);
        }

        /// <summary>
        /// Gets the width of an extra small column
        /// </summary>
        public int? XsWidth { get; private set; }

        /// <summary>
        /// Sets the width of an extra small column
        /// </summary>
        /// <param name="width">Column width</param>
        /// <returns>This object</returns>
        public Row WidthXs(int width)
        {
            XsWidth = width.ColumnWidth();
            return this;
        }

        /// <summary>
        /// Gets the width of a small column
        /// </summary>
        public int? SmWidth { get; private set; }

        /// <summary>
        /// Sets the width of an small column
        /// </summary>
        /// <param name="width">Column width</param>
        /// <returns>This object</returns>
        public Row WidthSm(int width)
        {
            SmWidth = width.ColumnWidth();
            return this;
        }

        /// <summary>
        /// Gets the width of a medium column
        /// </summary>
        public int? MdWidth { get; private set; }

        /// <summary>
        /// Sets the width of a medium column
        /// </summary>
        /// <param name="width">Column width</param>
        /// <returns>This object</returns>
        public Row WidthMd(int width)
        {
            MdWidth = width.ColumnWidth();
            return this;
        }

        /// <summary>
        /// Gets the width of a large column
        /// </summary>
        public int? LgWidth { get; private set; }

        /// <summary>
        /// Sets the width of a large column
        /// </summary>
        /// <param name="width">Column width</param>
        /// <returns>This object</returns>
        public Row WidthLg(int width)
        {
            LgWidth = width.ColumnWidth();
            return this;
        }
    }
}