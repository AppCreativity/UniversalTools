using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml;
using AppCreativity.UniversalTools.Converters;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace AppCreativity.UniversalTools.Tests.Converters
{
    [TestClass]
    public class VisibilityConverterTest
    {
        [TestMethod]
        public void NullIsCollapsed()
        {
            var converter = new VisibilityConverter();
            var result = converter.Convert(null);
            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void TrueIsVisible()
        {
            var converter = new VisibilityConverter();
            var result = converter.Convert(true);
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void FalseIsCollapsed()
        {
            var converter = new VisibilityConverter();
            var result = converter.Convert(false);
            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void StringIsVisible()
        {
            var converter = new VisibilityConverter();
            var result = converter.Convert("test");
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void EmptyStringIsCollapsed()
        {
            var converter = new VisibilityConverter();
            var result = converter.Convert(String.Empty);
            Assert.AreEqual(Visibility.Collapsed, result);
        }

        /// <summary>
        /// String is not null, and IsNullOrEmpty isn't checked when disabled => Visible
        /// </summary>
        [TestMethod]
        public void EmptyStringNotSupportedIsVisible()
        {
            var converter = new VisibilityConverter(){ SupportIsNullOrEmpty = false};
            var result = converter.Convert(String.Empty);
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void NullStringNotSupportedIsCollapsed()
        {
            var converter = new VisibilityConverter() { SupportIsNullOrEmpty = false };
            var result = converter.Convert(null);
            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void RandomIntIsVisible()
        {
            var converter = new VisibilityConverter();
            var result = converter.Convert(56);
            Assert.AreEqual(Visibility.Visible, result);
        }

        /// <summary>
        /// Default value for int = 0 => collapsed
        /// </summary>
        [TestMethod]
        public void ZeroIntIsCollapsed()
        {
            var converter = new VisibilityConverter();
            var result = converter.Convert(0);
            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void RandomDoubleIsVisible()
        {
            var converter = new VisibilityConverter();
            var result = converter.Convert(5.5);
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void RandomAnonymousObjectIsVisible()
        {
            var converter = new VisibilityConverter();
            var result = converter.Convert(new { Test = "test"});
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void RandomObjectIsVisible()
        {
            var converter = new VisibilityConverter();
            var result = converter.Convert(Colors.Aqua);
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void EmptyCollectionIsCollapsed1()
        {
            var converter = new VisibilityConverter();
            var result = converter.Convert(new List<string>());
            Assert.AreEqual(Visibility.Collapsed, result);
        }

        /// <summary>
        /// WARNING: .Count on new string[7] is 7 as empty strings are added to the array
        /// </summary>
        [TestMethod]
        public void EmptyArrayIsNotCollapsed()
        {
            var converter = new VisibilityConverter();
            var result = converter.Convert(new string[7]);
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void EmptyCollectionIsCollapsed3()
        {
            var converter = new VisibilityConverter();
            var result = converter.Convert(new Dictionary<string, string>());
            Assert.AreEqual(Visibility.Collapsed, result);
        }

        /// <summary>
        /// Empty collection supported set to false => new collection = object => visible
        /// </summary>
        [TestMethod]
        public void EmptyCollectionNotSupportedIsVisible()
        {
            var converter = new VisibilityConverter(){ SupportCollectionEmpty = false};
            var result = converter.Convert(new List<string>());
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void CollectionWithElementsIsVisible1()
        {
            var converter = new VisibilityConverter() { SupportCollectionEmpty = false };
            var result = converter.Convert(new List<string>{"Test"});
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void CollectionWithElementsIsVisible2()
        {
            var converter = new VisibilityConverter();
            var result = converter.Convert(new string[] { "Test", "Test2", "Test3" });
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void CollectionWithElementsIsVisible3()
        {
            var converter = new VisibilityConverter();
            var result = converter.Convert(new Dictionary<string, int> { {"Test", 5} });
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void InverseNullIsVisible()
        {
            var converter = new VisibilityConverter(){Inverse = true};
            var result = converter.Convert(null);
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void InverseStringIsCollapsed()
        {
            var converter = new VisibilityConverter(){Inverse = true};
            var result = converter.Convert("test");
            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void InverseEmptyStringIsVisible()
        {
            var converter = new VisibilityConverter(){Inverse = true};
            var result = converter.Convert(String.Empty);
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void InverseRandomIntIsCollapsed()
        {
            var converter = new VisibilityConverter(){Inverse = true};
            var result = converter.Convert(56);
            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void InverseEmptyCollectionIsVisible()
        {
            var converter = new VisibilityConverter(){Inverse =  true};
            var result = converter.Convert(new List<string>());
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void InverseCollectionWithElementsIsCollapsed()
        {
            var converter = new VisibilityConverter() { Inverse = true};
            var result = converter.Convert(new List<string> { "Test" });
            Assert.AreEqual(Visibility.Collapsed, result);
        }
    }
}
