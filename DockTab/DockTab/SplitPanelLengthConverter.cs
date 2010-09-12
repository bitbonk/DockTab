namespace DockTab
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
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

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type"/> that represents the type you want to convert to.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);
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
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }

            if (value is SplitPanelLength && destinationType == typeof(string))
            {
                return ToString((SplitPanelLength)value, culture);
            }

            throw this.GetConvertToException(value, destinationType);
        }

        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="T:System.Type"/> that represents the type you want to convert from.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
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