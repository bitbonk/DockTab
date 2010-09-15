namespace WhiteTest
{
    using System.Threading;
    using System.Windows;
    using NUnit.Framework;
    using White.Core;
    using White.Core.Factory;
    using White.Core.InputDevices;
    using White.Core.UIItems;
    using White.Core.UIItems.Finders;
    using White.Core.UIItems.WindowItems;

    [TestFixture]
    internal class Test
    {
        [Test]
        public void TestIt()
        {
            Application a =
                Application.Launch(
                    @"d:\Privat\DockTab\Source Control\docktab\WhiteTest\WhiteTest\WhiteTest.ApplicationUnderTest\bin\Debug\WhiteTest.ApplicationUnderTest.exe");
            Window w = a.GetWindow("WindowUnderTest", InitializeOption.NoCache);
            Assert.IsNotNull(w);
            var b1 = w.Get<Button>(SearchCriteria.ByText("Click me!"));
            Assert.IsNotNull(b1);
            var b2 = w.Get<Button>(SearchCriteria.ByText("Click me too!"));
            Assert.IsNotNull(b2);
            var t = w.Get<Thumb>("splitter");
            Assert.IsNotNull(t);
            Rect r = t.Bounds;
            var b1b = b1.Bounds;
            t.SlideHorizontally(100);
            Assert.AreEqual(b1b.Width + 100, b1.Bounds.Width);
            //Mouse.Instance.Location = new Point(t.Location.X + 2, t.Location.Y + 2);
            //Mouse.LeftDown();
            //Mouse.Instance.Location = new Point(Mouse.Instance.Location.X + 100, Mouse.Instance.Location.Y);
            //Mouse.LeftUp();
            //Mouse.Instance.DragHorizontally(t, 100);
            //b2.Click();
        }
    }
}