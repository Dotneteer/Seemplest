using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seemplest.BngMvc.Core.Infrastructure;
using Seemplest.BngMvc.Core.Infrastructure.TestSupport;
using Seemplest.BngMvc.Core.Tests.Helpers;
using Seemplest.Core.DependencyInjection;
using SoftwareApproach.TestingExtensions;

namespace Seemplest.BngMvc.Core.Tests.Builders
{
    [TestClass]
    public class ContainerBuilderTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            ServiceManager.Reset();
            ServiceManager.Register<ITestableWriterFactory, TestStream>(
                ltManager: new SingletonLifetimeManager(TestStream.Instance));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            TestStream.Reset();
        }

        [TestMethod]
        public void ContainerBuilderWorksAsExpected()
        {
            // --- Arrange
            var htmlHelper = Utility.CreateHtmlHelper<int>();

            // --- Act
            using (htmlHelper.Container())
            {
            }

            // --- Assert
            var dom = TestStream.Dom;
            dom.Name.ShouldEqual("div");
            dom.Attribute("class").Value.ShouldEqual(ContainerStyle.Container);
        }

        [TestMethod]
        public void ContainerBuilderWithAttributesWorksAsExpected()
        {
            // --- Arrange
            var htmlHelper = Utility.CreateHtmlHelper<int>();
            const string STYLE_VALUE = "padding-top: 70px;";
            
            // --- Act
            using (htmlHelper.Container("style", STYLE_VALUE))
            {
            }

            // --- Assert
            var dom = TestStream.Dom;
            dom.Name.ShouldEqual("div");
            dom.Attribute("class").Value.ShouldEqual(ContainerStyle.Container);
            dom.Attribute("style").Value.ShouldEqual(STYLE_VALUE);
        }

        [TestMethod]
        public void ContainerBuilderWithAttributesDictionaryWorksAsExpected()
        {
            // --- Arrange
            var htmlHelper = Utility.CreateHtmlHelper<int>();
            const string STYLE_VALUE = "padding-top: 70px;";

            // --- Act
            using (htmlHelper.Container(new Dictionary<string, object> { { "style", "padding-top: 70px;"} }))
            {
            }

            // --- Assert
            var dom = TestStream.Dom;
            dom.Name.ShouldEqual("div");
            dom.Attribute("class").Value.ShouldEqual(ContainerStyle.Container);
            dom.Attribute("style").Value.ShouldEqual(STYLE_VALUE);
        }

        [TestMethod]
        public void ContainerBuilderWithArgWorksAsExpected()
        {
            // --- Arrange
            var htmlHelper = Utility.CreateHtmlHelper<int>();

            // --- Act
            using (htmlHelper.FluidContainer())
            {
            }

            // --- Assert
            var dom = TestStream.Dom;
            dom.Name.ShouldEqual("div");
            dom.Attribute("class").Value.ShouldEqual(ContainerStyle.ContainerFluid);
        }
    }
}
