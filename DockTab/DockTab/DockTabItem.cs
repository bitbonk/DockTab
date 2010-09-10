namespace DockTab
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;

    /// <summary>
    ///     The dock tab item.
    /// </summary>
    public class DockTabItem : HeaderedContentControl  // TODO: maybe derive from TabItem ?
    {
        /// <summary>
        ///   Identifies the Collapse dependency property.
        /// </summary>
        public static readonly DependencyProperty IsCollapsedProperty = DependencyProperty.Register(
            "IsCollapsed", typeof(bool), typeof(DockTabItem));

        /// <summary>
        ///   Identifies the IsSelected dependency property.
        /// </summary>
        public static readonly DependencyProperty IsSelectedProperty = Selector.IsSelectedProperty.AddOwner(
            typeof(DockTabItem), 
            new FrameworkPropertyMetadata(
                false, 
                FrameworkPropertyMetadataOptions.Journal | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault |
                FrameworkPropertyMetadataOptions.AffectsParentMeasure, 
                OnIsSelectedChanged));

        /// <summary>
        /// Initializes static members of the <see cref="DockTabItem"/> class.
        /// </summary>
        static DockTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(DockTabItem), new FrameworkPropertyMetadata(typeof(DockTabItem)));
        }

        /// <summary>
        /// Gets or sets a value indicating whether this item is in collapsed state.
        /// </summary>
        public bool IsCollapsed
        {
            get
            {
                return (bool)this.GetValue(IsCollapsedProperty);
            }

            set
            {
                this.SetValue(IsCollapsedProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this item is selected.
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        public bool IsSelected
        {
            get
            {
                return (bool)this.GetValue(IsSelectedProperty);
            }

            set
            {
                this.SetValue(IsSelectedProperty, value);
            }
        }

        private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}