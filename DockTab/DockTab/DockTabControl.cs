using System.Windows;
using System.Windows.Controls.Primitives;

namespace DockTab
{
    /// <summary>
    /// 
    /// </summary>
    public class DockTabControl : Selector
    {
        static DockTabControl()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof (DockTabControl),
            //                                         new FrameworkPropertyMetadata(typeof (DockTabControl)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DockTabItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is DockTabItem;
        }
    }
}