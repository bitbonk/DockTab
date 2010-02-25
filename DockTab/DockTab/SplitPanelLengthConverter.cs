using System;
using System.ComponentModel;
using System.Globalization;

namespace DockTab
{
    // TODO: finish this implementation (make it robust)
    class SplitPanelLengthConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            var s = value as string;
            if(s != null)
            {
                if(s == "Auto")
                {
                    return SplitPanelLength.Auto;
                }

                if(s.EndsWith("*"))
                {
                    return new SplitPanelLength(Convert.ToDouble(s.Substring(0, s.Length - 1), culture),
                                                SplitPanelUnitType.Star);
                }

                return new SplitPanelLength(Convert.ToDouble(s.Substring(0, s.Length - 1), culture));
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            return base.ConvertTo(context, culture, value, destinationType);
        }

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

                    return (Convert.ToString(length.Value, cultureInfo) + "*");
            }
            return Convert.ToString(length.Value, cultureInfo);
        }


    }
}
