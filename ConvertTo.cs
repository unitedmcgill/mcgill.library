using System;
using System.Globalization;
using System.Text;

namespace McGill.Library
{
    /// <summary>
    /// Namespace:   McGill.Library
    /// ClassName:   UMCLib
    /// Created By:  TBaltzer
    /// Created On:  4/21/2008
    /// Description: The UMCLib class is a class of static methods from the old UMCLib
    /// </summary>
    public partial class UMCLib
    {
        private static char[] _TrimHex = new char[] { '0', 'x' };

        #region ConvertToFraction
		/// <summary>
		/// Converts a decimal to a fraction.
		/// </summary>
		/// <param name="mNumber">The Number.</param>
		/// <param name="nDenominator">The denominator to round to.</param>
		/// <returns>
		/// The mNumber converted to a string fraction.
		/// </returns>
		public static string ConvertToFraction(decimal mNumber, int nDenominator)
		{
			// Initialize values and store IsNegative bool
			StringBuilder myValue = new StringBuilder(String.Empty);
			bool bIsNegative = (Math.Sign(mNumber) == -1);

			if (bIsNegative)
			{
				mNumber *= -1;
				myValue.Append('-');
			}

			// Extract WholeNumber, Remainder, Divisor, and Numerator from input
			int nWholeNumber = (Int32)(Math.Floor(mNumber));
			decimal dRemainder = mNumber - nWholeNumber;
			decimal dDivisor = (decimal)(1.0 / nDenominator);
			int nNumerator = (Int32)(Math.Round(dRemainder / dDivisor));

			// Fraction has been rounded to 8/8 or 16/16 or something similar
			if (nNumerator > 0 && nNumerator == nDenominator)
			{
				nWholeNumber++;
				nNumerator = 0;
			}
			// Find the GCD and reduce the fraction
			else if (nNumerator != 0)
			{
				int x = nNumerator;
				int y = nDenominator;

				while (y % x != 0)
				{
					int nTemp = x;
					x = y % x;
					y = nTemp;
				}

				nNumerator = nNumerator / x;
				nDenominator = nDenominator / x;
			}

			// Create the correctly formatted output
			if (nNumerator == 0)
			{
				myValue.Append(nWholeNumber);
			}
			else if (nWholeNumber == 0)
			{
				myValue.AppendFormat("{0}/{1}", nNumerator, nDenominator);
			}
			else
			{
				myValue.AppendFormat("{0} {1}/{2}", nWholeNumber, nNumerator, nDenominator);
			}

			return myValue.ToString();
		}

        /// <summary>
        /// Converts to fraction.
        /// </summary>
        /// <param name="mNumber">The m number.</param>
        /// <returns></returns>
		public static String ConvertToFraction(decimal mNumber)
		{
			return ConvertToFraction(mNumber, 64);
        }

        #endregion ConvertToFraction

        #region ConvertToBoolean
        /// <summary>
        /// Converts to boolean.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        public static bool ConvertToBoolean(object myValue)
        {
            bool myReturnVal;

            if (TryConvertToBoolean(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Boolean.", myValue));
        }

        // Needed for compatibility with old code
        public static bool ConvertToBoolean(string myValue)
        {
            bool myReturnVal;

            if (TryConvertToBoolean(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Boolean.", myValue));
        }


        /// <summary>
        /// Tries the convert to boolean.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">if set to <c>true</c> [my return value].</param>
        /// <returns></returns>
        public static bool TryConvertToBoolean(object myValue, out bool myReturnVal)
        {
            myReturnVal = false;

            if (myValue == null)
            {
                return true;
            }

            Type t = myValue.GetType();

            if (t == typeof(bool) || t == typeof(Boolean))
            {
                myReturnVal = (Boolean)myValue;
                return true;
            }

            return TryConvertToBoolean(myValue.ToString(), out myReturnVal);
        }

        /// <summary>
        /// Tries the convert to boolean.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">if set to <c>true</c> [my return value].</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        private static bool TryConvertToBoolean(string myValue, out bool myReturnVal)
        {
            myReturnVal = false;

            myValue = myValue.Trim();
            if (String.IsNullOrEmpty(myValue))
            {
                return true;
            }

            // Try to parse the value normally
            if (Boolean.TryParse(myValue, out myReturnVal))
            {
                return true;
            }

            string sValue = myValue.Trim().ToLower();
            if (sValue == "n" || sValue == "f" || sValue == "0")
            {
                return true;
            }

            if (sValue == "y" || sValue == "t" || sValue == "1")
            {
                myReturnVal = true;
                return true;
            }

            return false;

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Boolean.", myValue));
        }
        #endregion ConvertToBoolean

        #region ConvertToByte
        /// <summary>
        /// Converts to byte.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        public static byte ConvertToByte(object myValue)
        {
            byte myReturnVal;

            if (TryConvertToByte(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Byte.", myValue));
        }

        // Needed for compatibility with old code
        public static byte ConvertToByte(string myValue)
        {
            byte myReturnVal;

            if (TryConvertToByte(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Byte.", myValue));
        }

        /// <summary>
        /// Tries the convert to byte.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        public static bool TryConvertToByte(object myValue, out byte myReturnVal)
        {
            myReturnVal = 0;

            if (myValue == null)
            {
                return true;
            }

            Type t = myValue.GetType();

            if (t == typeof(Byte) || t == typeof(byte))
            {
                myReturnVal = (Byte)myValue;
                return true;
            }

            return TryConvertToByte(myValue.ToString(), out myReturnVal);
        }

        /// <summary>
        /// Tries the convert to byte.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        private static bool TryConvertToByte(string myValue, out byte myReturnVal)
        {
            myReturnVal = 0;

            myValue = myValue.Trim();
            if (String.IsNullOrEmpty(myValue))
            {
                return true;
            }

            // Try to parse the value normally
            if (Byte.TryParse(myValue, out myReturnVal))
            {
                return true;
            }

            // If that fails, try to parse any number format
            if (Byte.TryParse(myValue, NumberStyles.Any, new CultureInfo("en-US"), out myReturnVal))
            {
                return true;
            }

            return false;
        }
        #endregion ConvertToByte

        #region ConvertToChar
        /// <summary>
        /// Converts to character.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        public static char ConvertToChar(object myValue)
        {
            char myReturnVal;

            if (TryConvertToChar(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Char.", myValue));
        }

        // Needed for compatibility with old code
        public static char ConvertToChar(string myValue)
        {
            char myReturnVal;

            if (TryConvertToChar(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Char.", myValue));
        }


        /// <summary>
        /// Tries the convert to character.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        public static bool TryConvertToChar(object myValue, out char myReturnVal)
        {
            myReturnVal = '\0';

            if (myValue == null)
            {
                return true;
            }

            // Try to parse the value normally
            if (Char.TryParse(myValue.ToString(), out myReturnVal))
            {
                return true;
            }

            // Try to parse the value as int
            int nVal;
            if (TryConvertToInt32(myValue, out nVal))
            {
                try
                {
                    myReturnVal = Char.ConvertFromUtf32(nVal)[0];
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }
        #endregion ConvertToChar

        #region ConvertToDateTime
        /// <summary>
        /// Converts to date time.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        public static DateTime ConvertToDateTime(object myValue)
        {
            DateTime myReturnVal;

            if (TryConvertToDateTime(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to DateTime.", myValue));
        }

        // Needed for compatibility with old code
        public static DateTime ConvertToDateTime(string myValue)
        {
            DateTime myReturnVal;

            if (TryConvertToDateTime(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to DateTime.", myValue));
        }

        /// <summary>
        /// Tries the convert to date time.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        public static bool TryConvertToDateTime(object myValue, out DateTime myReturnVal)
        {
            myReturnVal = DateTime.MinValue;

            if (myValue == null)
            {
                return true;
            }

            Type t = myValue.GetType();

            if (t == typeof(DateTime))
            {
                myReturnVal = (DateTime)myValue;
                return true;
            }
            
            return TryConvertToDateTime(myValue.ToString(), out myReturnVal);
        }

        /// <summary>
        /// Tries the convert to date time.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        private static bool TryConvertToDateTime(string myValue, out DateTime myReturnVal)
        {
            myReturnVal = DateTime.MinValue;

            myValue = myValue.Trim();
            if (String.IsNullOrEmpty(myValue))
            {
                return true;
            }

            // Try to parse the value normally
            if (DateTime.TryParse(myValue, out myReturnVal))
            {
                return true;
            }

            DateTimeStyles style = DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal;

            // If that fails, try to parse any number format
            if (DateTime.TryParse(myValue, new CultureInfo("en-US"), style, out myReturnVal))
            {
                return true;
            }

            return false;
        }
        #endregion ConvertToDateTime

        #region ConvertToDecimal
        /// <summary>
        /// Converts to decimal.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        public static decimal ConvertToDecimal(object myValue)
        {
            decimal myReturnVal;

            if (TryConvertToDecimal(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Decimal.", myValue));
        }

        // Needed for compatibility with old code
        public static decimal ConvertToDecimal(string myValue)
        {
            decimal myReturnVal;

            if (TryConvertToDecimal(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Decimal.", myValue));
        }

        /// <summary>
        /// Tries the convert to decimal.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        public static bool TryConvertToDecimal(object myValue, out decimal myReturnVal)
        {
            myReturnVal = 0.0M;

            if (myValue == null)
            {
                return true;
            }

            Type t = myValue.GetType();

            if (t == typeof(decimal) ||  t == typeof(Decimal))
            {
                myReturnVal = (decimal)myValue;
                return true;
            }

            return TryConvertToDecimal(myValue.ToString(), out myReturnVal);
        }

        /// <summary>
        /// Tries the convert to decimal.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        private static bool TryConvertToDecimal(string myValue, out decimal myReturnVal)
        {
            myReturnVal = 0.0M;

            myValue = myValue.Trim();
            if (String.IsNullOrEmpty(myValue))
            {
                return true;
            }

            if (myValue == ".")
            {
                return true;
            }

            // Try to parse the value normally
            if (Decimal.TryParse(myValue, out myReturnVal))
            {
                return true;
            }

            // If that fails, try to parse any number format
            if (Decimal.TryParse(myValue, NumberStyles.Any, new CultureInfo("en-US"), out myReturnVal))
            {
                return true;
            }

            return false;
        }
        #endregion ConvertToDecimal

        #region ConvertToDouble
        /// <summary>
        /// Converts to double.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        public static double ConvertToDouble(object myValue)
        {
            double myReturnVal;

            if (TryConvertToDouble(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Double.", myValue));
        }

        // Needed for compatibility with old code
        public static double ConvertToDouble(string myValue)
        {
            double myReturnVal;

            if (TryConvertToDouble(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Double.", myValue));
        }

        /// <summary>
        /// Tries the convert to double.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        public static bool TryConvertToDouble(object myValue, out double myReturnVal)
        {
            myReturnVal = 0.0;

            if (myValue == null)
            {
                return true;
            }

            Type t = myValue.GetType();

            if (t == typeof(double) || t == typeof(Double))
            {
                myReturnVal = (double)myValue;
                return true;
            }

            return TryConvertToDouble(myValue.ToString(), out myReturnVal);
        }

        /// <summary>
        /// Tries the convert to double.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        private static bool TryConvertToDouble(string myValue, out double myReturnVal)
        {
            myReturnVal = 0.0;
            myValue = myValue.Trim();

            if (String.IsNullOrEmpty(myValue))
            {
                return true;
            }

            if (myValue == ".")
            {
                return true;
            }

            // Try to parse the value normally
            if (Double.TryParse(myValue, out myReturnVal))
            {
                return true;
            }

            // If that fails, try to parse any number format
            if (Double.TryParse(myValue, NumberStyles.Any, new CultureInfo("en-US"), out myReturnVal))
            {
                return true;
            }

            return false;
        }
        #endregion ConvertToDouble

        #region ConvertToFloat
        /// <summary>
        /// Converts to float.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        public static float ConvertToFloat(object myValue)
        {
            float myReturnVal;

            if (TryConvertToFloat(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Float.", myValue));
        }

        // Needed for compatibility with old code
        public static float ConvertToFloat(string myValue)
        {
            float myReturnVal;

            if (TryConvertToFloat(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Float.", myValue));
        }

        /// <summary>
        /// Tries the convert to float.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        public static bool TryConvertToFloat(object myValue, out float myReturnVal)
        {
            myReturnVal = 0.0F;

            if (myValue == null)
            {
                return true;
            }

            Type t = myValue.GetType();

            if (t == typeof(float))
            {
                myReturnVal = (float)myValue;
                return true;
            }

            return TryConvertToFloat(myValue.ToString(), out myReturnVal);
        }

        /// <summary>
        /// Tries the convert to float.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        private static bool TryConvertToFloat(string myValue, out float myReturnVal)
        {
            myReturnVal = 0.0F;

            myValue = myValue.Trim();
            if (String.IsNullOrEmpty(myValue))
            {
                return true;
            }

            if (myValue == ".")
            {
                return true;
            }

            // Try to parse the value normally
            if (Single.TryParse(myValue, out myReturnVal))
            {
                return true;
            }

            // If that fails, try to parse any number format
            if (Single.TryParse(myValue, NumberStyles.Any, new CultureInfo("en-US"), out myReturnVal))
            {
                return true;
            }

            return false;
        }
        #endregion ConvertToFloat

        #region ConvertToInt16
        /// <summary>
        /// Converts to int16.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        public static Int16 ConvertToInt16(object myValue)
        {
            Int16 myReturnVal;

            if (TryConvertToInt16(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Int16.", myValue));
        }

        // Needed for compatibility with old code
        public static Int16 ConvertToInt16(string myValue)
        {
            Int16 myReturnVal;

            if (TryConvertToInt16(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Int16.", myValue));
        }

        /// <summary>
        /// Tries the convert to int16.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        public static bool TryConvertToInt16(object myValue, out Int16 myReturnVal)
        {
            myReturnVal = 0;

            if (myValue == null)
            {
                return true;
            }

            Type t = myValue.GetType();

            if (t == typeof(short) || t == typeof(Int16))
            {
                myReturnVal = (Int16)myValue;
                return true;
            }
            else if (t == typeof(bool))
            {
                if ((bool)myValue)
                {
                    myReturnVal = 1;
                }

                return true;
            }
            else
            {
                return TryConvertToInt16(myValue.ToString(), out myReturnVal);
            }
        }

        /// <summary>
        /// Tries the convert to int16.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        private static bool TryConvertToInt16(string myValue, out Int16 myReturnVal)
        {
            myReturnVal = 0;

            myValue = myValue.Trim();
            if (String.IsNullOrEmpty(myValue))
            {
                return true;
            }

            // Try to parse the value normally
            if (Int16.TryParse(myValue, out myReturnVal))
            {
                return true;
            }

            // If that fails, try to parse any number format
            if (Int16.TryParse(myValue, NumberStyles.Any, new CultureInfo("en-US"), out myReturnVal))
            {
                return true;
            }

            // If that fails, try to parse as hex
            if (Int16.TryParse(myValue.TrimStart(_TrimHex), NumberStyles.HexNumber, new CultureInfo("en-US"), out myReturnVal))
            {
                return true;
            }

            return false;
        }

        #endregion ConvertToInt16

        #region ConvertToInt32
        /// <summary>
        /// Converts to int32.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        public static Int32 ConvertToInt32(object myValue)
        {
            Int32 myReturnVal;

            if (TryConvertToInt32(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Int32.", myValue));
        }

        // Needed for compatibility with old code
        public static Int32 ConvertToInt32(string myValue)
        {
            Int32 myReturnVal;

            if (TryConvertToInt32(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Int32.", myValue));
        }

        /// <summary>
        /// Tries the convert to int32.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        public static bool TryConvertToInt32(object myValue, out Int32 myReturnVal)
        {
            myReturnVal = 0;

            if (myValue == null)
            {
                return true;
            }

            Type t = myValue.GetType();

            if (t == typeof(int) || t == typeof(Int32))
            {
                myReturnVal = (Int32)myValue;
                return true;
            }
            else if (t == typeof(decimal) || t == typeof(Decimal))
            {
                return TryConvertToInt32(Math.Truncate((decimal)myValue).ToString(), out myReturnVal);
            }
            else if (t == typeof(double) || t == typeof(Double))
            {
                return TryConvertToInt32(Math.Truncate((double)myValue).ToString(), out myReturnVal);
            }
            else if (t == typeof(bool))
            {
                if ((bool)myValue)
                {
                    myReturnVal = 1;
                }

                return true;
            }
            else
            {
                return TryConvertToInt32(myValue.ToString(), out myReturnVal);
            }
        }

        /// <summary>
        /// Tries the convert to int32.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        private static bool TryConvertToInt32(string myValue, out Int32 myReturnVal)
        {
            myReturnVal = 0;

            myValue = myValue.Trim();
            if (String.IsNullOrEmpty(myValue))
            {
                return true;
            }

            // Try to parse the value normally
            if (Int32.TryParse(myValue, out myReturnVal))
            {
                return true;
            }

            // If that fails, try to parse any number format
            if (Int32.TryParse(myValue, NumberStyles.Any, new CultureInfo("en-US"), out myReturnVal))
            {
                return true;
            }

            char[] trimHex = new char[] { '0', 'x' };
			// If that fails, try to parse as hex
			if (Int32.TryParse(myValue.TrimStart(trimHex), NumberStyles.HexNumber, new CultureInfo("en-US"), out myReturnVal))
			{
				return true;
			}

            return false;

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Int32.", myValue));
        }

        #endregion ConvertToInt32

        #region ConvertToInt64
        /// <summary>
        /// Converts to int64.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        public static Int64 ConvertToInt64(object myValue)
        {
            Int64 myReturnVal;

            if (TryConvertToInt64(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Int64.", myValue));
        }

        // Needed for compatibility with old code
        public static Int64 ConvertToInt64(string myValue)
        {
            Int64 myReturnVal;

            if (TryConvertToInt64(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to Int64.", myValue));
        }

        /// <summary>
        /// Tries the convert to int64.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        public static bool TryConvertToInt64(object myValue, out Int64 myReturnVal)
        {
            myReturnVal = 0;

            if (myValue == null)
            {
                return true;
            }

            Type t = myValue.GetType();

            if (t == typeof(long) || t == typeof(Int64))
            {
                myReturnVal = (Int64)myValue;
                return true;
            }

            if (t == typeof(bool))
            {
                if ((bool)myValue)
                {
                    myReturnVal = 1;
                }

                return true;
            }

            return TryConvertToInt64(myValue.ToString(), out myReturnVal);
        }

        /// <summary>
        /// Tries the convert to int64.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        private static bool TryConvertToInt64(string myValue, out Int64 myReturnVal)
        {
            myReturnVal = 0;

            myValue = myValue.Trim();
            if (String.IsNullOrEmpty(myValue))
            {
                return true;
            }

            // Try to parse the value normally
            if (Int64.TryParse(myValue, out myReturnVal))
            {
                return true;
            }

            // If that fails, try to parse any number format
            if (Int64.TryParse(myValue, NumberStyles.Any, new CultureInfo("en-US"), out myReturnVal))
            {
                return true;
            }

            // If that fails, try to parse as hex
            if (Int64.TryParse(myValue.TrimStart(_TrimHex), NumberStyles.HexNumber, new CultureInfo("en-US"), out myReturnVal))
            {
                return true;
            }

            return false;
        }

        #endregion ConvertToInt64

        #region ConvertToString
        /// <summary>
        /// Converts to a string. If null, returns String.Empty;
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <returns></returns>
        public static string ConvertToString(object myValue)
        {
            if (myValue == null)
            {
                return string.Empty;
            }

            Type t = myValue.GetType();

            if (t == typeof(string) || t == typeof(String))
            {
                return (string)myValue;
            }

            return Convert.ToString(myValue);
        }
        #endregion ConvertToString

        #region ConvertToUInt16
        /// <summary>
        /// Converts to u int16.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        public static UInt16 ConvertToUInt16(object myValue)
        {
            UInt16 myReturnVal;

            if (TryConvertToUInt16(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to UInt16.", myValue));
        }

        // Needed for compatibility with old code
        public static UInt16 ConvertToUInt16(string myValue)
        {
            UInt16 myReturnVal;

            if (TryConvertToUInt16(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to UInt16.", myValue));
        }

        /// <summary>
        /// Tries the convert to u int16.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        public static bool TryConvertToUInt16(object myValue, out UInt16 myReturnVal)
        {
            myReturnVal = 0;

            if (myValue == null)
            {
                return true;
            }

            Type t = myValue.GetType();

            if (t == typeof(ushort) || t == typeof(UInt16))
            {
                myReturnVal = (UInt16)myValue;
                return true;
            }

            if (t == typeof(bool))
            {
                if ((bool)myValue)
                {
                    myReturnVal = 1;
                }

                return true;
            }

            return TryConvertToUInt16(myValue.ToString(), out myReturnVal);
        }

        /// <summary>
        /// Tries the convert to u int16.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        private static bool TryConvertToUInt16(string myValue, out UInt16 myReturnVal)
        {
            myReturnVal = 0;

            myValue = myValue.Trim();
            if (String.IsNullOrEmpty(myValue))
            {
                return true;
            }

            // Try to parse the value normally
            if (UInt16.TryParse(myValue, out myReturnVal))
            {
                return true;
            }

            // If that fails, try to parse any number format
            if (UInt16.TryParse(myValue, NumberStyles.Any, new CultureInfo("en-US"), out myReturnVal))
            {
                return true;
            }

            // If that fails, try to parse as hex
            if (UInt16.TryParse(myValue.TrimStart(_TrimHex), NumberStyles.HexNumber, new CultureInfo("en-US"), out myReturnVal))
            {
                return true;
            }

            return false;
        }
        #endregion ConvertToUInt16

        #region ConvertToUInt32
        /// <summary>
        /// Converts to u int32.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        public static UInt32 ConvertToUInt32(object myValue)
        {
            UInt32 myReturnVal;

            if (TryConvertToUInt32(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to UInt32.", myValue));
        }

        // Needed for compatibility with old code
        public static UInt32 ConvertToUInt32(string myValue)
        {
            UInt32 myReturnVal;

            if (TryConvertToUInt32(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to UInt32.", myValue));
        }

        /// <summary>
        /// Tries the convert to u int32.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        public static bool TryConvertToUInt32(object myValue, out UInt32 myReturnVal)
        {
            myReturnVal = 0;

            if (myValue == null)
            {
                return true;
            }

            Type t = myValue.GetType();

            if (t == typeof(uint) || t == typeof(UInt32))
            {
                myReturnVal = (UInt32)myValue;
                return true;
            }

            if (t == typeof(bool))
            {
                if ((bool)myValue)
                {
                    myReturnVal = 1;
                }

                return true;
            }

            return TryConvertToUInt32(myValue.ToString(), out myReturnVal);
        }

        /// <summary>
        /// Tries the convert to u int32.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <param name="myReturnVal">My return value.</param>
        /// <returns></returns>
        private static bool TryConvertToUInt32(string myValue, out UInt32 myReturnVal)
        {
            myReturnVal = 0;

            myValue = myValue.Trim();
            if (String.IsNullOrEmpty(myValue))
            {
                return true;
            }

            // Try to parse the value normally
            if (UInt32.TryParse(myValue, out myReturnVal))
            {
                return true;
            }

            // If that fails, try to parse any number format
            if (UInt32.TryParse(myValue, NumberStyles.Any, new CultureInfo("en-US"), out myReturnVal))
            {
                return true;
            }

            // If that fails, try to parse as hex
            if (UInt32.TryParse(myValue.TrimStart(_TrimHex), NumberStyles.HexNumber, new CultureInfo("en-US"), out myReturnVal))
            {
                return true;
            }

            return false;
        }
        #endregion ConvertToUInt32

        #region ConvertToUInt64
        /// <summary>
        /// Converts to u int64.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        public static UInt64 ConvertToUInt64(object myValue)
        {
            UInt64 myReturnVal;

            if (TryConvertToUInt64(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to UInt64.", myValue));
        }

        // Needed for compatibility with old code
        public static UInt64 ConvertToUInt64(string myValue)
        {
            UInt64 myReturnVal;

            if (TryConvertToUInt64(myValue, out myReturnVal))
            {
                return myReturnVal;
            }

            // If that fails, throw the appropriate exception
            throw new FormatException(String.Format("{0} cannot be converted to UInt64.", myValue));
        }

        /// <summary>
        /// Converts to UInt64. If null, returns 0
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <returns></returns>
        public static bool TryConvertToUInt64(object myValue, out UInt64 myReturnVal)
        {
            myReturnVal = 0;

            if (myValue == null)
            {
                return true;
            }

            Type t = myValue.GetType();

            if (t == typeof(ulong) || t == typeof(UInt64))
            {
                myReturnVal = (UInt64)myValue;
                return true;
            }

            if (t == typeof(bool))
            {
                if ((bool)myValue)
                {
                    myReturnVal = 1;
                }

                return true;
            }

            return TryConvertToUInt64(myValue.ToString(), out myReturnVal);
        }

        /// <summary>
        /// Converts to UInt64.  If the value is NULL or Empty, it returns 0;
        /// </summary>
        /// <param name="myValue"> My value. </param>
        /// <returns></returns>
        private static bool TryConvertToUInt64(string myValue, out UInt64 myReturnVal)
        {
            myReturnVal = 0;

            myValue = myValue.Trim();
            if (String.IsNullOrEmpty(myValue))
            {
                return true;
            }

            // Try to parse the value normally
            if (UInt64.TryParse(myValue, out myReturnVal))
            {
                return true;
            }

            // If that fails, try to parse any number format
            if (UInt64.TryParse(myValue, NumberStyles.Any, new CultureInfo("en-US"), out myReturnVal))
            {
                return true;
            }

            // If that fails, try to parse as hex
            if (UInt64.TryParse(myValue.TrimStart(_TrimHex), NumberStyles.HexNumber, new CultureInfo("en-US"), out myReturnVal))
            {
                return true;
            }

            return false;
        }
        #endregion ConvertToUInt64
    }
}
