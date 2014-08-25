using System.Collections.Generic;
using System.Web.Mvc;
using Seemplest.BngMvc.Core.Builders;
using Seemplest.BngMvc.Core.Components;

namespace Seemplest.BngMvc.Core
{
    /// <summary>
    /// This class contains extensions to HtmlHelper in order to pumb Bng into the
    /// markup generation
    /// </summary>
    public static class BngHtmlExtensions
    {
        /// <summary>
        /// This method creates a new Bootstrap container
        /// </summary>
        /// <typeparam name="TModel">MVC model type</typeparam>
        /// <param name="helper">HtmlHelper to extend</param>
        /// <param name="attribs">Attribute dictionary</param>
        /// <returns>Builder object</returns>
        public static ContainerBuilder<TModel> Container<TModel>(this HtmlHelper<TModel> helper, IDictionary<string, object> attribs)
        {
            return new ContainerBuilder<TModel>(helper, new Container(attribs));
        }

        /// <summary>
        /// This method creates a new Bootstrap container
        /// </summary>
        /// <typeparam name="TModel">MVC model type</typeparam>
        /// <param name="helper">HtmlHelper to extend</param>
        /// <param name="attribs">Attribute key/value enumeration</param>
        /// <returns>Builder object</returns>
        public static ContainerBuilder<TModel> Container<TModel>(this HtmlHelper<TModel> helper, params string[] attribs)
        {
            return new ContainerBuilder<TModel>(helper, new Container(attribs));
        }

        /// <summary>
        /// This method creates a new Bootstrap fluid container
        /// </summary>
        /// <typeparam name="TModel">MVC model type</typeparam>
        /// <param name="helper">HtmlHelper to extend</param>
        /// <param name="attribs">Attribute dictionary</param>
        /// <returns>Builder object</returns>
        public static ContainerBuilder<TModel> FluidContainer<TModel>(this HtmlHelper<TModel> helper, IDictionary<string, object> attribs)
        {
            return new ContainerBuilder<TModel>(helper, new FluidContainer(attribs));
        }

        /// <summary>
        /// This method creates a new Bootstrap fluid container
        /// </summary>
        /// <typeparam name="TModel">MVC model type</typeparam>
        /// <param name="helper">HtmlHelper to extend</param>
        /// <param name="attribs">Attribute key/value enumeration</param>
        /// <returns>Builder object</returns>
        public static ContainerBuilder<TModel> FluidContainer<TModel>(this HtmlHelper<TModel> helper, params string[] attribs)
        {
            return new ContainerBuilder<TModel>(helper, new FluidContainer(attribs));
        }
    }
}