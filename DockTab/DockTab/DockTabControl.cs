namespace DockTab
{
    using System.Windows;
    using System.Windows.Controls.Primitives;

    /// <summary>
    /// The dock tab control.
    /// </summary>
    public class DockTabControl : Selector
    {
        /// <summary>
        /// Initializes static members of the <see cref="DockTabControl"/> class. 
        /// </summary>
        static DockTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(DockTabControl), new FrameworkPropertyMetadata(typeof(DockTabControl)));
        }

        /// <summary>
        /// Creates or identifies the element that is used to display the given item.
        /// </summary>
        /// <returns>
        /// The element that is used to display the given item.
        /// </returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DockTabGroup();
        }

        /// <summary>
        /// Determines if the specified item is (or is eligible to be) its own container.
        /// </summary>
        /// <param name="item">
        /// The item to check.
        /// </param>
        /// <returns>
        /// true if the item is (or is eligible to be) its own container; otherwise, false.
        /// </returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is DockTabGroup;
        }
    }
}