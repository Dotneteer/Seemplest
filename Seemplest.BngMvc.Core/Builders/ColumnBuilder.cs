using System.Collections.Generic;
using System.Web.Mvc;
using Seemplest.BngMvc.Core.Components;
using Seemplest.BngMvc.Core.Infrastructure;

namespace Seemplest.BngMvc.Core.Builders
{
    /// <summary>
    /// This class provides builder methods for a Bootstrap row
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class ColumnBuilder<TModel>: BuilderBase<TModel, Column>
    {
        /// <summary>
        /// Initializes the row builder
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper instance</param>
        /// <param name="element">Element used by the builder</param>
        /// <param name="parent">Parent HTML element</param>
        public ColumnBuilder(HtmlHelper<TModel> htmlHelper, Column element, IBuilderNode parent = null)
            : base(htmlHelper, element, parent)
        {
        }

        #region Child container builders

        /// <summary>
        /// This method creates a new Bootstrap container
        /// </summary>
        /// <param name="attribs">Attribute dictionary</param>
        /// <returns>Builder object</returns>
        public ContainerBuilder<TModel> Container(IDictionary<string, object> attribs)
        {
            return new ContainerBuilder<TModel>(HtmlHelper, new Container(attribs), this);
        }

        /// <summary>
        /// This method creates a new Bootstrap container
        /// </summary>
        /// <param name="attribs">Attribute key/value enumeration</param>
        /// <returns>Builder object</returns>
        public ContainerBuilder<TModel> Container(params string[] attribs)
        {
            return new ContainerBuilder<TModel>(HtmlHelper, new Container(attribs), this);
        }

        /// <summary>
        /// This method creates a new Bootstrap fluid container
        /// </summary>
        /// <param name="attribs">Attribute dictionary</param>
        /// <returns>Builder object</returns>
        public ContainerBuilder<TModel> FluidContainer(IDictionary<string, object> attribs)
        {
            return new ContainerBuilder<TModel>(HtmlHelper, new FluidContainer(attribs), this);
        }

        /// <summary>
        /// This method creates a new Bootstrap fluid container
        /// </summary>
        /// <param name="attribs">Attribute key/value enumeration</param>
        /// <returns>Builder object</returns>
        public ContainerBuilder<TModel> FluidContainer(params string[] attribs)
        {
            return new ContainerBuilder<TModel>(HtmlHelper, new FluidContainer(attribs), this);
        }

        #endregion

        #region Child row builders

        /// <summary>
        /// Creates a new Bootstrap row builder
        /// </summary>
        /// <param name="row">Row object</param>
        /// <returns>Builder object</returns>
        public RowBuilder<TModel> Row(Row row)
        {
            return new RowBuilder<TModel>(HtmlHelper, row, this);
        }

        /// <summary>
        /// Creates a new Bootstrap row builder
        /// </summary>
        /// <returns>Builder object</returns>
        public RowBuilder<TModel> Row()
        {
            return new RowBuilder<TModel>(HtmlHelper, new Row(), this);
        }

        /// <summary>
        /// Creates a new Bootstrap row builder with the specified attributes
        /// </summary>
        /// <param name="attribs">Attributes dictionary</param>
        /// <returns>Builder object</returns>
        public RowBuilder<TModel> Row(IDictionary<string, object> attribs)
        {
            return new RowBuilder<TModel>(HtmlHelper, new Row(attribs), this);
        }

        /// <summary>
        /// Creates a new Bootstrap row builder with the specified attributes
        /// </summary>
        /// <param name="attribs">Attribute key/value enumeration</param>
        /// <returns>Builder object</returns>
        public RowBuilder<TModel> Row(params string[] attribs)
        {
            return new RowBuilder<TModel>(HtmlHelper, new Row(attribs), this);
        }

        #endregion


        #region Child column builders

        /// <summary>
        /// Creates a new Bootstrap column builder
        /// </summary>
        /// <param name="column">Column object</param>
        /// <returns>Builder object</returns>
        public ColumnBuilder<TModel> Column(Column column)
        {
            return new ColumnBuilder<TModel>(HtmlHelper, column, this);
        }

        /// <summary>
        /// Creates a new Bootstrap column builder
        /// </summary>
        /// <returns>Builder object</returns>
        public ColumnBuilder<TModel> Column()
        {
            return new ColumnBuilder<TModel>(HtmlHelper, new Column(), this);
        }

        /// <summary>
        /// Creates a new Bootstrap column builder with the specified attributes
        /// </summary>
        /// <param name="attribs">Attributes dictionary</param>
        /// <returns>Builder object</returns>
        public ColumnBuilder<TModel> Column(IDictionary<string, object> attribs)
        {
            return new ColumnBuilder<TModel>(HtmlHelper, new Column(attribs), this);
        }

        /// <summary>
        /// Creates a new Bootstrap column builder with the specified attributes
        /// </summary>
        /// <param name="attribs">Attribute key/value enumeration</param>
        /// <returns>Builder object</returns>
        public ColumnBuilder<TModel> Column(params string[] attribs)
        {
            return new ColumnBuilder<TModel>(HtmlHelper, new Column(attribs), this);
        }

        #endregion
    }
}