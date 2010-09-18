namespace DockTab
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;

    /// <summary>
    /// Resizes and arranges child elements into a single row that can be oriented horizontally or vertically where the 
    ///   amount space that each child element consumes can be defined using the <see cref="SplitPanel.LengthProperty"/>
    ///   attached property. See <see cref="SplitPanelUnitType"/> for the different resize behaviors.
    ///   The <see cref="SplitPanel"/> also reacts on child <see cref="SplitThumb"/> drags resizing the all child elements accordingly.
    /// </summary>
    public class SplitPanel : Panel
    {
        /// <summary>
        ///   Identifies the Length attached property.
        /// </summary>
        public static readonly DependencyProperty LengthProperty = DependencyProperty.RegisterAttached(
            "Length", 
            typeof(SplitPanelLength), 
            typeof(SplitPanel), 
            new FrameworkPropertyMetadata(
                new SplitPanelLength(1.0d, SplitPanelUnitType.Star), 
                FrameworkPropertyMetadataOptions.AffectsParentMeasure));

        /// <summary>
        ///   Identifies the <see cref = "Orientation" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(
            "Orientation", 
            typeof(Orientation), 
            typeof(SplitPanel), 
            new FrameworkPropertyMetadata(Orientation.Horizontal, FrameworkPropertyMetadataOptions.AffectsMeasure));

        private double childrenLenghtFixed;
        private SplitPanelLength[] childrenLengths;

        /// <summary>
        ///   Initializes a new instance of the <see cref = "SplitPanel" /> class.
        /// </summary>
        public SplitPanel()
        {
            this.AddHandler(Thumb.DragDeltaEvent, new DragDeltaEventHandler(this.SplitThumbOnDragged));
        }

        /// <summary>
        ///   Gets or sets a value that indicates the dimension by which child elements are stacked. This is a dependency property.
        /// </summary>
        public Orientation Orientation
        {
            get
            {
                return (Orientation)this.GetValue(OrientationProperty);
            }

            set
            {
                this.SetValue(OrientationProperty, value);
            }
        }

        /// <summary>
        /// Gets the value of the Length attached property from a given <see cref="UIElement"/>.
        /// </summary>
        /// <param name="element">
        /// The element from which to read the property value.
        /// </param>
        /// <returns>
        /// The value of the Length attached property.
        /// </returns>
        public static SplitPanelLength GetLength(UIElement element)
        {
            return (SplitPanelLength)element.GetValue(LengthProperty);
        }

        /// <summary>
        /// Sets the value of the Length attached property to a given <see cref="UIElement"/>.
        /// </summary>
        /// <param name="element">
        /// The element on which to set the Length attached property.
        /// </param>
        /// <param name="value">
        /// The property value to set.
        /// </param>
        public static void SetLength(UIElement element, SplitPanelLength value)
        {
            element.SetValue(LengthProperty, value);
        }

        /// <summary>
        /// When overridden in a derived class, positions child elements and determines a size for a <see cref="T:System.Windows.FrameworkElement"/> derived class.
        /// </summary>
        /// <param name="finalSize">
        /// The final area within the parent that this element should use to arrange itself and its children.
        /// </param>
        /// <returns>
        /// The actual size used.
        /// </returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            Rect[] rects = this.CalculateItemRects(finalSize);
            for (int i = 0; i < this.InternalChildren.Count; i++)
            {
                this.InternalChildren[i].Arrange(rects[i]);
            }

            return finalSize;
        }

        /// <summary>
        /// When overridden in a derived class, measures the size in layout required for child elements and determines a size for the <see cref="T:System.Windows.FrameworkElement"/>-derived class.
        /// </summary>
        /// <param name="availableSize">
        /// The available size that this element can give to child elements. Infinity can be specified as a value to indicate that the element will size to whatever content is available.
        /// </param>
        /// <returns>
        /// The size that this element determines it needs during layout, based on its calculations of child element sizes.
        /// </returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            this.GetChildrenLengths();
            Rect[] itemRects = this.CalculateItemRects(availableSize);

            // measure children
            for (int i = 0; i < this.InternalChildren.Count; i++)
            {
                this.InternalChildren[i].Measure(itemRects[i].Size);
            }

            Size requiredSize = availableSize;
            if (this.Orientation == Orientation.Horizontal)
            {
                // wee need at least the width of all fixed lengths
                requiredSize.Width = this.childrenLenghtFixed;
                if (availableSize.Height == double.PositiveInfinity)
                {
                    requiredSize.Height = 0;
                }
            }
            else
            {
                // wee need at least the width of all fixed lengths
                requiredSize.Height = this.childrenLenghtFixed;
                if (availableSize.Width == double.PositiveInfinity)
                {
                    requiredSize.Width = 0;
                }
            }

            return requiredSize;
        }

        private Rect[] CalculateItemRects(Size availableSize)
        {
            var itemRects = new Rect[this.InternalChildren.Count];
            double offset = 0;
            for (int i = 0; i < this.childrenLengths.Length; i++)
            {
                SplitPanelLength length = this.childrenLengths[i];
                if (this.Orientation == Orientation.Horizontal)
                {
                    double width = length.IsAbsolute
                                       ? length.Value
                                       : Math.Max(0, (availableSize.Width - this.childrenLenghtFixed) * length.Value);
                    itemRects[i] = new Rect(offset, 0, width, availableSize.Height);
                    offset += width;
                }
                else if (this.Orientation == Orientation.Vertical)
                {
                    double height = length.IsAbsolute
                                        ? length.Value
                                        : Math.Max(0, (availableSize.Height - this.childrenLenghtFixed) * length.Value);
                    itemRects[i] = new Rect(0, offset, availableSize.Width, height);
                    offset += height;
                }
            }

            return itemRects;
        }

        private void GetChildrenLengths()
        {
            this.childrenLengths = new SplitPanelLength[this.InternalChildren.Count];
            for (int i = 0; i < this.InternalChildren.Count; i++)
            {
                this.childrenLengths[i] = GetLength(this.InternalChildren[i]);
            }

            // normalize all star lengths
            double starLengthsSum = this.childrenLengths.Where(l => l.IsStar).Sum(l => l.Value);

            for (int i = 0; i < this.childrenLengths.Length; i++)
            {
                if (this.childrenLengths[i].IsStar)
                {
                    this.childrenLengths[i] = new SplitPanelLength(
                        this.childrenLengths[i].Value / starLengthsSum, SplitPanelUnitType.Star);
                }
            }

            this.childrenLenghtFixed = this.childrenLengths.Where(l => l.IsAbsolute).Sum(l => l.Value);
        }

        private void SplitThumbOnDragged(object sender, DragDeltaEventArgs e)
        {
            var splitThumb = e.OriginalSource as SplitThumb;
            if (splitThumb == null)
            {
                return;
            }

            // TODO: this is completely incomplete
            for (int i = 0; i < this.Children.Count; i++)
            {
                UIElement currentChild = this.Children[i];
                if (!currentChild.IsAncestorOf(splitThumb))
                {
                    continue;
                }

                // it is a thumb we are interested in
                SplitPanelLength currentLength = GetLength(currentChild);

                double deltaValue = this.Orientation == Orientation.Horizontal ? e.HorizontalChange : e.VerticalChange;

                // TODO: if required calculate new star value based on delta
                // TODO: calculate new value for following control too
                var newValue = new SplitPanelLength(currentLength.Value + deltaValue, currentLength.UnitType);
                e.Handled = true;
                SetLength(currentChild, newValue);
            }
        }
    }
}