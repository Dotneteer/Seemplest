using System;
using System.ComponentModel;
using System.IO;
using System.Web.Mvc;
using Seemplest.BngMvc.Core.Infrastructure.TestSupport;
using Seemplest.Core.DependencyInjection;

namespace Seemplest.BngMvc.Core.Infrastructure
{
    /// <summary>
    /// This base class is used to build the markup for a specific element.
    /// </summary>
    /// <typeparam name="TModel">MVC model type</typeparam>
    /// <typeparam name="TElement">HTML element to build</typeparam>
    public abstract class BuilderBase<TModel, TElement> : IBuilderNode, IDisposable 
        where TElement : HtmlElementBase<TElement>
    {
        /// <summary>
        /// The element this builder builds
        /// </summary>
        protected readonly TElement Element;

        /// <summary>
        /// The output stream
        /// </summary>
        protected readonly TextWriter TextWriter;
        
        /// <summary>
        /// The HtmlHelper used to build the markup
        /// </summary>
        protected readonly HtmlHelper<TModel> HtmlHelper;

        /// <summary>
        /// The parent builder node
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IBuilderNode ParentBuilder { get; private set; }

        /// <summary>
        /// The HTML element associated with the builder node
        /// </summary>
        public IHtmlElement HtmlElement 
        {
            get { return Element; }
        }

        /// <summary>
        /// The depth of the node within the node hierarchy
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Depth { get; private set; }

        /// <summary>
        /// Initializes this builder instance
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper to use</param>
        /// <param name="element">Element to build</param>
        /// <param name="parent">Parent element</param>
        protected BuilderBase(HtmlHelper<TModel> htmlHelper, TElement element, IBuilderNode parent = null)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            HtmlHelper = htmlHelper;
            ParentBuilder = parent;
            Element = element;
            Element.SetBuilder(this);
            Depth = parent != null 
                ? parent.Depth + 1 
                : 1;

            // --- Hook in a testable writer
            var factory = ServiceManager.GetService<ITestableWriterFactory>();
            TextWriter = factory != null
                ? factory
                    .GetTestableWriter(htmlHelper.ViewContext.Writer)
                    .GetWriter()
                : htmlHelper.ViewContext.Writer;
            var elementLine = string.Format("{0}{1}", new String(' ', Depth*2), Element.StartTag);
            TextWriter.WriteLine(elementLine);
        }

        /// <summary>
        /// Places the end tag when the builder is disposed
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void Dispose()
        {
            var elementLine = string.Format("{0}{1}", new String(' ', Depth * 2), Element.EndTag);
            TextWriter.WriteLineAsync(elementLine);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return base.ToString(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        // ReSharper disable once BaseObjectEqualsIsObjectEquals
        public override bool Equals(object obj) { return base.Equals(obj); }

        // ReSharper disable once NonReadonlyFieldInGetHashCode
        [EditorBrowsable(EditorBrowsableState.Never)]
        // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
        public override int GetHashCode() { return base.GetHashCode(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() { return base.GetType(); }
    }
}