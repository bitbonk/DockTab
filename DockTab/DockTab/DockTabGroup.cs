using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DockTab
{
    // TODO: maybe derive from TabControl ? 
    /// <summary>
    /// 
    /// </summary>
    [TemplatePart(Name = SelectedContentHostTemplateName, Type = typeof(ContentPresenter)), StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(DockTabItem))]
    public class DockTabGroup : HeaderedItemsControl
    {
        private const string SelectedContentHostTemplateName = "PART_SelectedContentHost";
        
        static DockTabGroup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockTabGroup), new FrameworkPropertyMetadata(typeof(DockTabGroup)));
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
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
