using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace DockTab
{
    // TODO: maybe derive from TabItem ?
    /// <summary>
    /// 
    /// </summary>
    public class DockTabItem : HeaderedContentControl
    {
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

        static DockTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockTabItem),
                                                     new FrameworkPropertyMetadata(typeof(DockTabItem)));
        }

        /// <summary>
        /// 
        /// </summary>
        public DockTabItem()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Collapse
        {
            get { return (bool) GetValue(CollapseProperty); }

            set { SetValue(CollapseProperty, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        [Bindable(true), Category("Appearance")]
        public bool IsSelected
        {
            get { return (bool) base.GetValue(IsSelectedProperty); }
            set { base.SetValue(IsSelectedProperty, value); }
        }

        private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}