namespace DockTab
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// The dock tab group.
    /// </summary>
    [TemplatePart(Name = SelectedContentHostTemplateName, Type = typeof(ContentPresenter))]
    [StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(DockTabItem))]
    public class DockTabGroup : HeaderedItemsControl // TODO: maybe derive from TabControl ? 
    {
        private const string SelectedContentHostTemplateName = "PART_SelectedContentHost";

        /// <summary>
        /// Initializes static members of the <see cref="DockTabGroup"/> class.
        /// </summary>
        static DockTabGroup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(DockTabGroup), new FrameworkPropertyMetadata(typeof(DockTabGroup)));
        }

        /// <summary>
        /// Creates or identifies the element that is used to display the given item.
        /// </summary>
        /// <returns>
        /// The element that is used to display the given item.
        /// </returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DockTabItem();
        }

        /// <summary>
        /// Determines if the specified item is (or is eligible to be) its own container.
        /// </summary>
        /// <param name="item">The item to check.</param>
        /// <returns>
        /// true if the item is (or is eligible to be) its own container; otherwise, false.
        /// </returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is DockTabItem;
        }

        /// <summary>
        /// Prepares the specified element to display the specified item.
        /// </summary>
        /// <param name="element">Element used to display the specified item.</param>
        /// <param name="item">Specified item.</param>
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
        }
    }
}