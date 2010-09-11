namespace DockTab
{
    using System;
    using System.ComponentModel;
    using System.Globalization;

    /// <summary>
    /// The split panel length converter.
    /// </summary>
    internal class SplitPanelLengthConverter : TypeConverter
    {
        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context">
        /// An <see cref="ITypeDescriptorContext"/> that provides a format context.
        /// </param>
        /// <param name="culture">
        /// The <see cref="CultureInfo"/> to use as the current culture.
        /// </param>
        /// <param name="value">
        /// The <see cref="object"/> to convert.
        /// </param>
        /// <returns>
        /// An <see cref="object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// The conversion cannot be performed. 
        /// </exception>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            // TODO: make this more robust
            var s = value as string;
            if (s != null)
            {
                if (string.IsNullOrEmpty(s) || s == "Auto")
                {
                    return SplitPanelLength.Auto;
                }

                if (s.EndsWith("*"))
                {
                    if (s.Length == 1)
                    {
                        return new SplitPanelLength(1.0, SplitPanelUnitType.Star);
                    }

                    return new SplitPanelLength(
                        Convert.ToDouble(s.Substring(0, s.Length - 1), culture), SplitPanelUnitType.Star);
                }

                return new SplitPanelLength(Convert.ToDouble(s, culture));
            }

            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">
        /// An <see cref="ITypeDescriptorContext"/> that provides a format context.
        /// </param>
        /// <param name="culture">
        /// A <see cref="CultureInfo"/>. If null is passed, the current culture is assumed.
        /// </param>
        /// <param name="value">
        /// The <see cref="Object"/> to convert.
        /// </param>
        /// <param name="destinationType">
        /// The <see cref="Type"/> to convert the <paramref name="value"/> parameter to.
        /// </param>
        /// <returns>
        /// An <see cref="Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="destinationType"/> parameter is null. 
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// The conversion cannot be performed. 
        /// </exception>
        public override object ConvertTo(
            ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a <see cref="String"/> that represents this instance.
        /// </summary>
        /// <param name="length">
        /// The length.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture info.
        /// </param>
        /// <returns>
        /// A <see cref="String"/> that represents this instance.
        /// </returns>
        internal static string ToString(SplitPanelLength length, CultureInfo cultureInfo)
        {
            switch (length.UnitType)
            {
                case SplitPanelUnitType.Auto:
                    return "Auto";

                case SplitPanelUnitType.Star:
                    if (length.Value == 1.0d)
                    {
                        return "*";
                    }

                    return Convert.ToString(length.Value, cultureInfo) + "*";
            }

            return Convert.ToString(length.Value, cultureInfo);
        }
    }
}