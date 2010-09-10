namespace DockTab
{
    using System.Windows;
    using System.Windows.Controls.Primitives;

    /// <summary>
    /// Provides a thumb that allows the elements within a SplitPanel to be resized using mouse interaction.
    /// </summary>
    public class SplitThumb : Thumb
    {
        /// <summary>
        /// Initializes static members of the <see cref="SplitThumb"/> class.
        /// </summary>
        static SplitThumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(SplitThumb), new FrameworkPropertyMetadata(typeof(SplitThumb)));
        }
    }
}