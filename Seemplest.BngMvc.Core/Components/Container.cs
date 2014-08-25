using System.Collections.Generic;
using Seemplest.BngMvc.Core.Infrastructure;

namespace Seemplest.BngMvc.Core.Components
{
    /// <summary>
    /// This class represents a container with its properties
    /// </summary>
    public class Container: HtmlElementBase<Container>
    {
        /// <summary>
        /// Initializes the properties of the container
        /// </summary>
        public Container() : base(HtmlTag.Div)
        {
            InitAttributes();
        }

        /// <summary>
        /// Initializes the container with the specified attributes
        /// </summary>
        /// <param name="attribs">Attribute dictionary</param>
        public Container(IDictionary<string, object> attribs)
            : base(HtmlTag.Div, attribs)
        {
            InitAttributes();
        }

        /// <summary>
        /// Initializes the container with the specified attributes
        /// </summary>
        /// <param name="attribs">Attribute key/value enumeration</param>
        public Container(params string[] attribs)
            : base(HtmlTag.Div, attribs)
        {
            InitAttributes();
        }

        /// <summary>
        /// Initializes the container attributes
        /// </summary>
        private void InitAttributes()
        {
            EnsureClass(GetContainerAttribute());
        }

        /// <summary>
        /// Gets the attribute initializing this container
        /// </summary>
        /// <returns></returns>
        protected virtual string GetContainerAttribute()
        {
            return ContainerStyle.Container;
        }
    }
}