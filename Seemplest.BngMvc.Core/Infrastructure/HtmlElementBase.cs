using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using Seemplest.BngMvc.Core.Components;

namespace Seemplest.BngMvc.Core.Infrastructure
{
    /// <summary>
    /// This abstract class represents an HTML element that can be written to the
    /// response stream.
    /// </summary>
    public abstract class HtmlElementBase<TThis> : IHtmlElement 
        where TThis: HtmlElementBase<TThis>
    {
        /// <summary>
        /// The Html attributes held by this instance
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, object> HtmlAttributes { get; protected set; }
        
        /// <summary>
        /// HTML tag
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Tag { get; private set; }

        /// <summary>
        /// Gets the associated builder element
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IBuilderNode Builder { get; private set; }

        /// <summary>
        /// Initializes a new instance with the specified tag name
        /// </summary>
        /// <param name="tag">Tag name</param>
        protected HtmlElementBase(string tag)
        {
            HtmlAttributes = new Dictionary<string, object>();
            Tag = tag;
        }

        /// <summary>
        /// Initializes a new instance with the specified tag name and extra attributes
        /// </summary>
        /// <param name="tag">Tag name</param>
        /// <param name="attribs">Attribute enumeration</param>
        protected HtmlElementBase(string tag, IDictionary<string, object> attribs)
        {
            HtmlAttributes = new Dictionary<string, object>(attribs);
            Tag = tag;
        }

        /// <summary>
        /// Initializes a new instance with the specified tag name and extra attributes
        /// </summary>
        /// <param name="tag">Tag name</param>
        /// <param name="attribs">Attribute enumeration</param>
        protected HtmlElementBase(string tag, params string[] attribs)
        {
            var attribDict = new Dictionary<string, object>();
            for (var i = 0; i < attribs.Length; i += 2)
            {
                var key = attribs[i];
                var value = i < attribs.Length - 1 ? attribs[i + 1] : "";
                attribDict.Add(key, value);
            }
            HtmlAttributes = attribDict;
            Tag = tag;
        }

        /// <summary>
        /// Assigns the builder object to this HTML element
        /// </summary>
        /// <param name="builder">Builder node</param>
        internal void SetBuilder(IBuilderNode builder)
        {
            Builder = builder;
            OnBuilderAttached();
        }

        /// <summary>
        /// Sets up the HTML element after it has been attached to its builder
        /// </summary>
        protected virtual void OnBuilderAttached()
        {
        }

        /// <summary>
        /// Gets the end tag
        /// </summary>
        internal string EndTag
        {
            get
            {
                return string.IsNullOrEmpty(Tag)
                    ? string.Empty
                    : string.Format("</{0}>", Tag);
            }
        }

        /// <summary>
        /// Gets the start tag
        /// </summary>
        internal virtual string StartTag
        {
            get
            {
                if (string.IsNullOrEmpty(Tag)) return string.Empty;
                var builder = new TagBuilder(Tag);
                builder.MergeAttributes(HtmlAttributes);
                return builder.ToString(TagRenderMode.StartTag);
            }
        }

        /// <summary>
        /// Ensures that the specified class name is added to the definition of this instance
        /// </summary>
        /// <param name="className">Class name to ensure</param>
        protected void EnsureClass(string className)
        {
            if (HtmlAttributes.ContainsKey("class"))
            {
                var currentValue = HtmlAttributes["class"].ToString();
                if (!currentValue.Contains(className))
                {
                    HtmlAttributes["class"] += " " + className;
                }
            }
            else
            {
                MergeHtmlAttribute("class", className);
            }
        }

        /// <summary>
        /// Ensures that the specified class is removed from the definition of this instance
        /// </summary>
        /// <param name="className">Class name to remove</param>
        protected void EnsureClassRemoval(string className)
        {
            // TODO: fix this implementation, as this removes partially recognized class names
            if (!HtmlAttributes.ContainsKey("class")) return;
            var currentValue = HtmlAttributes["class"].ToString();
            if (currentValue.Contains(className))
            {
                HtmlAttributes["class"] = currentValue.Replace(className, "").Replace("  ", "").Trim();
            }
        }

        /// <summary>
        /// Ensures that this instance will contain the specified attribute
        /// </summary>
        /// <param name="key">Attribute name</param>
        /// <param name="value">Attribute value</param>
        protected void EnsureHtmlAttribute(string key, string value)
        {
            HtmlAttributes[key] = value;
        }

        /// <summary>
        /// Adds the specified set of attributes to this instance.
        /// </summary>
        /// <param name="htmlAttributes">Attributes to add to this instance</param>
        internal void SetHtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            HtmlAttributes.MergeHtmlAttributes(htmlAttributes.ObjectToHtmlAttributesDictionary());
        }

        /// <summary>
        /// Adds the specified set of attributes to this instance.
        /// </summary>
        /// <param name="data">Object the properties of which define the attributes</param>
        internal void SetHtmlAttributes(object data)
        {
            SetHtmlAttributes(data.ToDictionary().FormatHtmlAttributes());
        }

        /// <summary>
        /// Merges the specified attribute to the definition of this instance
        /// </summary>
        /// <param name="key">Attribute name</param>
        /// <param name="value">Attribute value</param>
        protected void MergeHtmlAttribute(string key, string value)
        {
            if (HtmlAttributes != null)
            {
                if (HtmlAttributes.ContainsKey(key))
                {
                    HtmlAttributes[key] = value;
                }
                else
                {
                    HtmlAttributes.Add(key, value);
                }
            }
            else
            {
                HtmlAttributes = new Dictionary<string, object> {{key, value}};
            }
        }

        /// <summary>
        /// Decorates the related HTML element with the specified attributes
        /// </summary>
        /// <param name="data">Anonymous object describing attributes</param>
        /// <returns>This builder element</returns>
        public TThis Decorate(object data)
        {
            SetHtmlAttributes(data);
            return (TThis)this;
        }

        /// <summary>
        /// Decorates the related HTML elements with the attributes specified
        /// </summary>
        /// <param name="htmlAttributes">Set of HTML attributes</param>
        /// <returns>This builder element</returns>
        public TThis Decorate(IDictionary<string, object> htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return (TThis)this;
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