using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;


namespace DockTab
{
    /// <summary>
    /// Provides a thumb that allows the elements within a SplitPanel to be resized using mouse interaction. 
    /// </summary>
    public class SplitThumb : Thumb
    {
        static SplitThumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SplitThumb), new FrameworkPropertyMetadata(typeof(SplitThumb)));
        }
    }
}
