using System;

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
        #region Round
        /// <summary>
        /// Rounds the specified m value.
        /// </summary>
        /// <param name="mValue">The m value.</param>
        /// <param name="nNumDigits">The num digits.</param>
        /// <returns></returns>
		public static decimal Round(decimal mValue, int nNumDigits)
		{
            return Math.Round(mValue, nNumDigits, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Rounds the specified value.
        /// </summary>
        /// <param name="dValue">The value.</param>
        /// <param name="nNumDigits">The number of digits.</param>
        /// <returns></returns>
        public static double Round(double dValue, int nNumDigits)
        {
            return Math.Round(dValue, nNumDigits, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Rounds the specified m value.
        /// </summary>
        /// <param name="mValue">The m value.</param>
        /// <param name="nNumDigits">The n num digits.</param>
        /// <returns></returns>
        public static decimal? Round(decimal? mValue, int nNumDigits)
        {
            if (mValue.HasValue)
            {
                return Round(mValue.Value, nNumDigits);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Rounds the specified d value.
        /// </summary>
        /// <param name="dValue">The d value.</param>
        /// <param name="nNumDigits">The n num digits.</param>
        /// <returns></returns>
        public static double? Round(double? dValue, int nNumDigits)
        {
            if (dValue.HasValue)
            {
                return Round(dValue.Value, nNumDigits);
            }
            else
            {
                return null;
            }
        }

        #endregion Round
    }
}
