namespace DockTab
{
    /// <summary>
    /// Describes the kind of value that a <see cref="SplitPanelLength"/>  object is holding. 
    /// </summary>
    public enum SplitPanelUnitType : int
    {
        /// <summary>
        /// The length is determined by the size properties of the content object.
        /// </summary>
        Auto,
        
        /// <summary>
        /// The value is expressed as a pixel.
        /// </summary>
        Pixels,
        
        /// <summary>
        /// The value is expressed as a weighted proportion of available space. 
        /// </summary>
        Star
    }
}