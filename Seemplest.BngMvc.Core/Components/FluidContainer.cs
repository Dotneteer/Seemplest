using System.Collections.Generic;
using Seemplest.BngMvc.Core.Infrastructure;

namespace Seemplest.BngMvc.Core.Components
{
    /// <summary>
    /// This class represents a fluid container with its properties
    /// </summary>
    public class FluidContainer : Container
    {
        /// <summary>
        /// Initializes the properties of the container
        /// </summary>
        public FluidContainer()
        {
        }

        /// <summary>
        /// Initializes the container with the specified attributes
        /// </summary>
        /// <param name="attribs">Attribute dictionary</param>
        public FluidContainer(IDictionary<string, object> attribs)
            : base(attribs)
        {
        }

        /// <summary>
        /// Initializes the container with the specified attributes
        /// </summary>
        /// <param name="attribs">Attribute key/value enumeration</param>
        public FluidContainer(params string[] attribs)
            : base(attribs)
        {
        }

        /// <summary>
        /// Gets the attribute initializing this container
        /// </summary>
        /// <returns></returns>
        protected override string GetContainerAttribute()
        {
            return ContainerStyle.ContainerFluid;
        }
    }
}