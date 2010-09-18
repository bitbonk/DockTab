namespace DockTab.UnitTests
{
    using System.Globalization;
    using NUnit.Framework;

    [Category("SplitPanel")]
    [TestFixture]
    public class SplitPanelTypeConverterTest
    {
        [Test]
        public void CanConvertFromString()
        {
            var c = new SplitPanelLengthConverter();
            Assert.IsTrue(c.CanConvertFrom(null, typeof(string)));
        }

        [Test]
        public void CanConvertToString()
        {
            var c = new SplitPanelLengthConverter();
            Assert.IsTrue(c.CanConvertTo(null, typeof(string)));
        }

        [Test]
        public void ConvertFromSingleStarString()
        {
            var c = new SplitPanelLengthConverter();
            var length = (SplitPanelLength)c.ConvertFrom(null, CultureInfo.InvariantCulture, "*");
            Assert.IsTrue(length.IsStar);
            Assert.AreEqual(1.0, length.Value);
        }

        [Test]
        public void ConvertFromNumberedStarString()
        {
            var c = new SplitPanelLengthConverter();
            var length = (SplitPanelLength)c.ConvertFrom(null, CultureInfo.InvariantCulture, "123.456*");
            Assert.IsTrue(length.IsStar);
            Assert.AreEqual(123.456, length.Value);
        }

        [Test]
        public void ThrowOnConvertBrokenStarString()
        {
            var c = new SplitPanelLengthConverter();
            Assert.Catch(() => c.ConvertFrom(null, CultureInfo.InvariantCulture, "NotANumber*"));
        }

        [Test]
        public void ConvertFromNumberString()
        {
            var c = new SplitPanelLengthConverter();
            var length = (SplitPanelLength)c.ConvertFrom(null, CultureInfo.InvariantCulture, "123.456");
            Assert.IsTrue(length.IsAbsolute);
            Assert.AreEqual(123.456, length.Value);
        }

        [Test]
        public void ConvertFromEmptyString()
        {
            var c = new SplitPanelLengthConverter();
            var length = (SplitPanelLength)c.ConvertFrom(null, CultureInfo.InvariantCulture, string.Empty);
            Assert.IsTrue(length.IsAuto);
            Assert.AreEqual(0.0, length.Value);
        }
    }
}