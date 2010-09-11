namespace DockTab.Test
{
    using System;
    using System.Globalization;
    using NUnit.Framework;

    /// <summary>
    /// The split panel type converter test.
    /// </summary>
    [Category("SplitPanel")]
    [TestFixture]
    public class SplitPanelTypeConverterTest
    {
        /// <summary>
        /// Shoulds the convert from single star string.
        /// </summary>
        [Test]
        public void ShouldConvertFromSingleStarString()
        {
            var c = new SplitPanelLengthConverter();
            var length = (SplitPanelLength)c.ConvertFrom(null, CultureInfo.InvariantCulture, "*");
            Assert.IsTrue(length.IsStar);
            Assert.AreEqual(1.0, length.Value);
        }

        /// <summary>
        /// Shoulds the convert from numbered star string.
        /// </summary>
        [Test]
        public void ShouldConvertFromNumberedStarString()
        {
            var c = new SplitPanelLengthConverter();
            var length = (SplitPanelLength)c.ConvertFrom(null, CultureInfo.InvariantCulture, "123.456*");
            Assert.IsTrue(length.IsStar);
            Assert.AreEqual(123.456, length.Value);
        }

        /// <summary>
        /// Shoulds the throw on convert broken star string.
        /// </summary>
        [Test]
        public void ShouldThrowOnConvertBrokenStarString()
        {
            var c = new SplitPanelLengthConverter();
            Assert.Catch(() => c.ConvertFrom(null, CultureInfo.InvariantCulture, "NotANumber*"));
        }

        /// <summary>
        /// Shoulds the throw on convert broken star string.
        /// </summary>
        [Test]
        public void ShouldConvertFromNumberString()
        {
            var c = new SplitPanelLengthConverter();
            var length = (SplitPanelLength)c.ConvertFrom(null, CultureInfo.InvariantCulture, "123.456");
            Assert.IsTrue(length.IsAbsolute);
            Assert.AreEqual(123.456, length.Value);
        }

        /// <summary>
        /// Shoulds the throw on convert broken star string.
        /// </summary>
        [Test]
        public void ShouldConvertFromEmptyString()
        {
            var c = new SplitPanelLengthConverter();
            var length = (SplitPanelLength)c.ConvertFrom(null, CultureInfo.InvariantCulture, string.Empty);
            Assert.IsTrue(length.IsAuto);
            Assert.AreEqual(0.0, length.Value);
        }
    }
}