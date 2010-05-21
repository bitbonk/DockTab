using System;
using System.Windows;
using System.Windows.Controls;

namespace DockTab
{
    /// <summary>
    /// Arranges child elements into a single line that can be oriented horizontally or vertically where the 
    /// amount space that each child element consumes can be defined using the <see cref="SplitPanel.LengthProperty"/>
    /// attached property. 
    /// The <see cref="SplitPanel"/> also reacts on child <see cref="SplitThumb"/> drags resizing the all child elements accordingly.
    /// </summary>
    public class SplitPanel : Panel
    {
        /// <summary>
        /// Identifies the <see cref="Orientation" /> dependency property.
        /// </summary>
        public static DependencyProperty OrientationProperty = DependencyProperty.Register(
            "Orientation",
            typeof(Orientation),
            typeof(SplitPanel),
            new FrameworkPropertyMetadata(Orientation.Horizontal, FrameworkPropertyMetadataOptions.AffectsMeasure));


        /// <summary>
        /// Identifies the Length attached property. 
        /// </summary>
        public static DependencyProperty LengthProperty = DependencyProperty.RegisterAttached(
            "Length",
            typeof(double),
            typeof(SplitPanel),
            new FrameworkPropertyMetadata(0.0d, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

        /// <summary>
        ///Gets or sets a value that indicates the dimension by which child elements are stacked. This is a dependency property.
        /// </summary>
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        /// <summary>
        ///Sets the value of the Length attached property to a given <see cref="UIElement"/>. 
        /// </summary>
        /// <param name="element">The element on which to set the Length attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetLength(UIElement element, double value)
        {
            element.SetValue(LengthProperty, value);
        }

        /// <summary>
        /// Gets the value of the Length attached property from a given <see cref="UIElement"/>. 
        /// </summary>
        /// <param name="element">The element from which to read the property value.</param>
        /// <returns>The value of the Length attached property.</returns>
        public static double GetLength(UIElement element)
        {
            return (double)element.GetValue(LengthProperty);
        }

        /// <summary>
        /// When overridden in a derived class, measures the size in layout required for child elements and determines a size for the <see cref="T:System.Windows.FrameworkElement"/>-derived class.
        /// </summary>
        /// <param name="availableSize">The available size that this element can give to child elements. Infinity can be specified as a value to indicate that the element will size to whatever content is available.</param>
        /// <returns>
        /// The size that this element determines it needs during layout, based on its calculations of child element sizes.
        /// </returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            if (availableSize.Width == double.PositiveInfinity || availableSize.Height == double.PositiveInfinity)
                return Size.Empty;

            Rect[] rects = CalculateItemRects(availableSize);
            for (int i = 0; i < InternalChildren.Count; i++)
            {
                InternalChildren[i].Measure(rects[i].Size);
            }
            return availableSize;
        }

        /// <summary>
        /// When overridden in a derived class, positions child elements and determines a size for a <see cref="T:System.Windows.FrameworkElement"/> derived class.
        /// </summary>
        /// <param name="finalSize">The final area within the parent that this element should use to arrange itself and its children.</param>
        /// <returns>The actual size used.</returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            Rect[] rects = CalculateItemRects(finalSize);
            for (int i = 0; i < InternalChildren.Count; i++)
            {
                InternalChildren[i].Arrange(rects[i]);
            }
            return finalSize;
        }

        private Rect[] CalculateItemRects(Size panelSize)
        {
            var rects = new Rect[InternalChildren.Count];
            double offset = 0;
            for (int i = 0; i < InternalChildren.Count; i++)
            {
                if (Orientation == Orientation.Horizontal)
                {
                    double width = SplitPanel.GetLength(this.Children[i]);
                    rects[i] = new Rect(offset, 0, width, panelSize.Height);
                    offset += width;
                }
                else if (Orientation == Orientation.Vertical)
                {
                    double height = SplitPanel.GetLength(this.Children[i]);
                    rects[i] = new Rect(0, offset, panelSize.Width, height);
                    offset += height;
                }
            }

            return rects;
        }
    }
}