using System;
using System.Collections.Generic;
using Seemplest.BngMvc.Core.Infrastructure;

namespace Seemplest.BngMvc.Core.Components
{
    /// <summary>
    /// This class represents a Bootstrap column component
    /// </summary>
    public class Column: HtmlElementBase<Column>, IColumnWidth
    {
        /// <summary>
        /// Initializes a new row instance
        /// </summary>
        internal Column() : base(HtmlTag.Div)
        {
        }

        /// <summary>
        /// Initializes the row with the specified attributes
        /// </summary>
        /// <param name="attribs">Attribute dictionary</param>
        internal Column(IDictionary<string, object> attribs)
            : base(HtmlTag.Div, attribs)
        {
        }

        /// <summary>
        /// Initializes the container with the specified attributes
        /// </summary>
        /// <param name="attribs">Attribute key/value enumeration</param>
        internal Column(params string[] attribs)
            : base(HtmlTag.Div, attribs)
        {
        }

        /// <summary>
        /// Sets up the HTML element after it has been attached to its builder
        /// </summary>
        protected override void OnBuilderAttached()
        {
            // --- Initialize widths from this node
            var xsWidth = XsWidth;
            var smWidth = SmWidth;
            var mdWidth = MdWidth;
            var lgWidth = LgWidth;

            if (Builder != null)
            {
                // --- Initialize uninitialized widths from the upper hierarchy
                var node = Builder;
                IColumnWidth widths;
                while (xsWidth == null && node != null && (widths = node.HtmlElement as IColumnWidth) != null)
                {
                    xsWidth = widths.XsWidth;
                    node = node.ParentBuilder;
                }
                node = Builder;
                while (smWidth == null && node != null && (widths = node.HtmlElement as IColumnWidth) != null)
                {
                    smWidth = widths.SmWidth;
                    node = node.ParentBuilder;
                }
                node = Builder;
                while (mdWidth == null && node != null && (widths = node.HtmlElement as IColumnWidth) != null)
                {
                    mdWidth = widths.MdWidth;
                    node = node.ParentBuilder;
                }
                node = Builder;
                while (lgWidth == null && node != null && (widths = node.HtmlElement as IColumnWidth) != null)
                {
                    lgWidth = widths.LgWidth;
                    node = node.ParentBuilder;
                }
            }

            // --- Set the attributes according to widths
            if (xsWidth != null)
            {
                EnsureClass(String.Format(ColumnStyle.ColXsN, xsWidth));                
            }
            if (smWidth != null)
            {
                EnsureClass(String.Format(ColumnStyle.ColSmN, smWidth));
            }
            if (mdWidth != null)
            {
                EnsureClass(String.Format(ColumnStyle.ColMdN, mdWidth));
            }
            if (lgWidth != null)
            {
                EnsureClass(String.Format(ColumnStyle.ColLgN, lgWidth));
            }
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
        public Column WidthXs(int width)
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
        public Column WidthSm(int width)
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
        public Column WidthMd(int width)
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
        public Column WidthLg(int width)
        {
            LgWidth = width.ColumnWidth();
            return this;
        }
    }
}