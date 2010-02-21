using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace DockTab
{
    /// <summary>
    /// 
    /// </summary>
    public class DockTabItem : HeaderedItemsControl
    {
        /// <summary>
        /// Identifies the Dock dependency property.
        /// </summary>
        public static DependencyProperty DockProperty =
            DependencyProperty.Register("Dock", typeof (DockPosition), typeof (DockTabItem), null);

        /// <summary>
        /// Identifies the Join dependency property.
        /// </summary>
        public static DependencyProperty JoinProperty =
            DependencyProperty.Register("Join", typeof (bool), typeof (DockTabItem), null);

        /// <summary>
        /// Identifies the Collapse dependency property.
        /// </summary>
        public static DependencyProperty CollapseProperty =
            DependencyProperty.Register("Collapse", typeof (bool), typeof (DockTabItem), null);

        /// <summary>
        /// Identifies the IsSelected dependency property.
        /// </summary>
        public static DependencyProperty IsSelectedProperty = Selector.IsSelectedProperty.AddOwner(typeof (DockTabItem),
            new FrameworkPropertyMetadata (false, FrameworkPropertyMetadataOptions.Journal | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions. AffectsParentMeasure, OnIsSelectedChanged));

        public DockTabItem()
        {
            Header = "DefaultHeader";
        }

        /// <summary>
        /// Gets or sets the Dock dependency property. This property indicates the dock poisition of this
        /// item within the parent <see cref="DockTabControl"/> 
        /// </summary>
        public DockPosition Dock
        {
            get { return (DockPosition) GetValue(DockProperty); }

            set { SetValue(DockProperty, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Join
        {
            get { return (bool) GetValue(JoinProperty); }

            set { SetValue(JoinProperty, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Collapse
        {
            get { return (bool) GetValue(CollapseProperty); }

            set { SetValue(CollapseProperty, value); }
        }

        [Bindable(true), Category("Appearance")]
        public bool IsSelected
        {
            get { return (bool) base.GetValue(IsSelectedProperty); }
            set { base.SetValue(IsSelectedProperty, value); }
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DockTabItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is DockTabItem;
        }

        private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}