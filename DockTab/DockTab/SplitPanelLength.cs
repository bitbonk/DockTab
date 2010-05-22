using System;
using System.ComponentModel;
using System.Globalization;

namespace DockTab
{
    /// <summary>
    /// Represents the length of elements in a <see cref="SplitPanel"/> that that supports <see cref="SplitPanelUnitType"/>.
    /// </summary>
    [TypeConverter(typeof(SplitPanelLengthConverter))]
    public struct SplitPanelLength : IEquatable<SplitPanelLength>
    {
        private static readonly SplitPanelLength autoSingleton = new SplitPanelLength(0, SplitPanelUnitType.Auto);
        private readonly SplitPanelUnitType unitType;
        private readonly double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="SplitPanelLength"/> structure using the specified absolute value in pixels.
        /// </summary>
        /// <param name="pixels">The number of device-independent pixels (96 pixels-per-inch).</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="pixels"/> is equal to <see cref="double.NegativeInfinity"/>, <see cref="double.PositiveInfinity"/> or <see cref="double.NaN"/>.
        /// </exception>
        public SplitPanelLength(double pixels)
            : this(pixels, SplitPanelUnitType.Pixels)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SplitPanelLength"/> struct.
        /// </summary>
        /// <param name="value">The pixels.</param>
        /// <param name="unitType">Type of the unit.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="value"/> is equal to <see cref="double.NegativeInfinity"/>, <see cref="double.PositiveInfinity"/> or <see cref="double.NaN"/>.
        /// </exception>
        public SplitPanelLength(double value, SplitPanelUnitType unitType)
        {
            if (double.IsInfinity(value) || double.IsNaN(value))
            {
                throw new ArgumentException();
            }

            this.value = value;
            this.unitType = unitType;
        }

        /// <summary>
        /// Gets an instance of <see cref="SplitPanelLength"/> that holds a value whose size is determined by the size properties 
        /// of the content object.
        /// </summary>
        public static SplitPanelLength Auto
        {
            get { return autoSingleton; }
        }

        /// <summary>
        /// Gets the associated <see cref="SplitPanelUnitType"/> for the <see cref="SplitPanelLength"/>. 
        /// </summary>
        public SplitPanelUnitType UnitType
        {
            get { return unitType; }
        }

        /// <summary>
        /// Gets a <see cref="double"/> that represents the value of the <see cref="SplitPanelLength"/>.
        /// </summary>
        public double Value
        {
            get { return value; }
        }

        /// <summary>
        /// Gets a value that indicates whether the <see cref="SplitPanelLength"/> holds a value whose 
        /// size is determined by the size properties of the content object.
        /// </summary>
        public bool IsAuto
        {
            get { return unitType == SplitPanelUnitType.Auto; }
        }

        /// <summary>
        /// Gets a value that indicates whether the <see cref="SplitPanelLength"/> holds a value that 
        /// is expressed as a weighted proportion of available space. 
        /// </summary>
        public bool IsStar
        {
            get { return unitType == SplitPanelUnitType.Star; }
        }

        /// <summary>
        /// Gets a value that indicates whether the <see cref="SplitPanelLength"/> holds a value that 
        /// is expressed in pixels. 
        /// </summary>
        public bool IsAbsolute
        {
            get { return unitType == SplitPanelUnitType.Pixels; }
        }

        /// <summary>
        /// Determines whether the specified <see cref="SplitPanelLength"/> is equal to the current GridLength instance.
        /// </summary>
        /// <param name="other">The <see cref="SplitPanelLength"/> structure to compare with the current instance.</param>
        /// <returns>
        /// <c>true</c> if the two instances of <see cref="SplitPanelLength"/> have the same value 
        /// and <see cref="SplitPanelUnitType"/> otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(SplitPanelLength other)
        {
            return value == other.value && unitType == other.unitType;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is SplitPanelLength))
            {
                return false;
            }

            return Equals((SplitPanelLength)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return (((int)value) + (int)unitType);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return SplitPanelLengthConverter.ToString(this, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Compares two <see cref="SplitPanelLength"/> structures for equality.
        /// </summary>
        /// <param name="length1">The first instance of <see cref="SplitPanelLength"/> to compare.</param>
        /// <param name="length2">The first instance of <see cref="SplitPanelLength"/> to compare.</param>
        /// <returns>
        /// <c>true</c> if the two instances of <see cref="SplitPanelLength"/> have the same value
        /// and <see cref="SplitPanelUnitType"/> otherwise, <c>false</c>.</returns>
        public static bool operator ==(SplitPanelLength length1, SplitPanelLength length2)
        {
            return length1.Equals(length2);
        }

        /// <summary>
        /// Compares two <see cref="SplitPanelLength"/> structures for inequality.
        /// </summary>
        /// <param name="length1">The first instance of <see cref="SplitPanelLength"/> to compare.</param>
        /// <param name="length2">The first instance of <see cref="SplitPanelLength"/> to compare.</param>
        /// <returns>
        /// <c>true</c> if the two instances of <see cref="SplitPanelLength"/> have the same value 
        /// and <see cref="SplitPanelUnitType"/> otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(SplitPanelLength length1, SplitPanelLength length2)
        {
            return !length1.Equals(length2);
        }
    }
}