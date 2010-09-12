namespace DockTab
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;

    /// <summary>
    /// Provides a thumb that allows the elements within a <see cref="SplitPanel"/> to be resized using mouse interaction.
    /// </summary>
    public class SplitThumb : Thumb
    {
        /// <summary>
        ///   Identifies the <see cref = "Orientation" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(
            "Orientation", typeof(Orientation), typeof(SplitThumb), null);

        /// <summary>
        ///   Initializes static members of the <see cref = "SplitThumb" /> class.
        /// </summary>
        static SplitThumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(SplitThumb), new FrameworkPropertyMetadata(typeof(SplitThumb)));
        }

        /// <summary>
        ///   Gets or sets the Orientation. This is a dependency property.
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
    }
}