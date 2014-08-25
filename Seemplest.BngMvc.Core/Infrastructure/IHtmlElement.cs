using System.Collections.Generic;

namespace Seemplest.BngMvc.Core.Infrastructure
{
    /// <summary>
    /// This interface represents an HTML element
    /// </summary>
    public interface IHtmlElement
    {
        /// <summary>
        /// The Html attributes held by this instance
        /// </summary>
        IDictionary<string, object> HtmlAttributes { get; }

        /// <summary>
        /// HTML tag
        /// </summary>
        string Tag { get; }

        /// <summary>
        /// Gets the associated builder element
        /// </summary>
        IBuilderNode Builder { get; }
    }
}