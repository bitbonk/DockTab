using System;
using System.Windows;
using System.Windows.Controls;

namespace DockTab
{
    /// <summary>
    /// Arranges child elements into a single line that can be oriented horizontally or vertically where the 
    /// amount space that each child element consumes can be defined using the <see cref="SplitPanel.LengthProperty"/>
    /// attached property. 
    /// </summary>
    public class SplitPanel : Panel
    {
        /// <summary>
        /// Identifies the <see cref="Orientation" /> dependency property.
        /// </summary>
        public static DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(SplitPanel), new PropertyMetadata(Orientation.Horizontal, OnOrientationChanged));

        /// <summary>
        /// Gets or sets a value that indicates the dimension by which child elements are stacked. This is a dependency property. 
        /// </summary>
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        private static void OnOrientationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}