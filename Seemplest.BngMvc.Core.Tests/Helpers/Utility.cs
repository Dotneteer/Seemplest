using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace Seemplest.BngMvc.Core.Tests.Helpers
{
    /// <summary>
    /// This class provides utility operations for testing Bng components
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Creates a new mock HtmlHelper
        /// </summary>
        /// <typeparam name="T">Model type</typeparam>
        /// <param name="viewData">ViewData</param>
        /// <returns>Mock HtmlHelper instance</returns>
        public static HtmlHelper<T> CreateHtmlHelper<T>(ViewDataDictionary viewData)
        {
            var cc = new Mock<ControllerContext>(
                new Mock<HttpContextBase>().Object,
                new RouteData(),
                new Mock<ControllerBase>().Object);

            var mockViewContext = new Mock<ViewContext>(
                cc.Object,
                new Mock<IView>().Object,
                viewData,
                new TempDataDictionary(),
                TextWriter.Null);

            var mockViewDataContainer = new Mock<IViewDataContainer>();

            mockViewDataContainer.Setup(v => v.ViewData).Returns(viewData);

            return new HtmlHelper<T>(
                mockViewContext.Object, mockViewDataContainer.Object);
        }

        /// <summary>
        /// Creates a new mock HtmlHelper with an empty model
        /// </summary>
        /// <typeparam name="T">Model type</typeparam>
        /// <returns>Mock HtmlHelper instance</returns>
        public static HtmlHelper<T> CreateHtmlHelper<T>()
        {
            return CreateHtmlHelper<T>(new ViewDataDictionary(default(T)));
        }
    }
}