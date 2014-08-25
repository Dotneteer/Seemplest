namespace Seemplest.BngMvc.Core.Infrastructure
{
    /// <summary>
    /// This interface represents a node in the chain of builders
    /// </summary>
    public interface IBuilderNode
    {
        /// <summary>
        /// Gets the parent builder node
        /// </summary>
        IBuilderNode ParentBuilder { get; }

        /// <summary>
        /// The HTML element associated with the builder node
        /// </summary>
        IHtmlElement HtmlElement { get; }
        
        /// <summary>
        /// The depth of the node within the node hierarchy
        /// </summary>
        int Depth { get; }
    }
}