namespace WhiteTest
{
    using Repository;
    using White.Core.UIItems;
    using White.Core.UIItems.WindowItems;

    /// <summary>
    /// The window under test.
    /// </summary>
    public partial class WindowUnderTest : AppScreen
    {
        private Button buttonOne;
        private Button buttonTwo;
        private Thumb splitter;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowUnderTest"/> class.
        /// </summary>
        /// <param name="window">
        /// The window.
        /// </param>
        /// <param name="screenRepository">
        /// The screen repository.
        /// </param>
        public WindowUnderTest(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowUnderTest"/> class.
        /// </summary>
        protected WindowUnderTest()
        {
        }
    }
}