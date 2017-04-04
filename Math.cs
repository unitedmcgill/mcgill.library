using System;

namespace McGill.Library
{
    /// <summary>
    /// Namespace:   McGill.Library
    /// Class:       UMCLib
    /// Created By:  JMoody
    /// Created On:  6/15/2011
    /// Description: The UMCLib class is used to allow decimals in Math functions.
    /// </summary>
    public partial class UMCLib
    {
        #region RadiansToDegrees
        /// <summary>
        /// Converts Radians to degrees.
        /// </summary>
        /// <param name="myRadians">The angle in radians.</param>
        /// <returns></returns>
        public static double RadiansToDegrees(double myRadians)
        {
            return myRadians * 180.0 / Math.PI;
        }
        /// <summary>
        /// Converts Radians to degrees.
        /// </summary>
        /// <param name="myRadians">The angle in radians.</param>
        /// <returns></returns>
        public static decimal RadiansToDegrees(decimal myRadians)
        {
            return myRadians * 180.0M / ConvertToDecimal(Math.PI);
        }
        #endregion RadiansToDegrees

        #region DegreesToRadians
        /// <summary>
        /// Converts Degrees to radians.
        /// </summary>
        /// <param name="myDegrees">The angle in degrees.</param>
        /// <returns></returns>
        public static double DegreesToRadians(double myDegrees)
        {
            return myDegrees * Math.PI / 180.0;
        }
        /// <summary>
        /// Converts Degrees to radians.
        /// </summary>
        /// <param name="myDegrees">The angle in degrees.</param>
        /// <returns></returns>
        public static decimal DegreesToRadians(decimal myDegrees)
        {
            return myDegrees * ConvertToDecimal(Math.PI) / 180.0M;
        }
        #endregion DegreesToRadians

        #region Trigonometry
        #region Acos
        /// <summary>
        /// Returns the angle in degrees whose cosine is the specified number.
        /// </summary>
        /// <param name="dCosineValue">The d cosine value.</param>
        /// <returns></returns>
        public static decimal Acos(decimal dCosineValue)
        {
            return ConvertToDecimal(RadiansToDegrees(Math.Acos(ConvertToDouble(dCosineValue))));
        }
        #endregion Acos

        #region Asin
        /// <summary>
        /// Returns the angle in degrees whose sine is the specified number.
        /// </summary>
        /// <param name="dSineValue">The d sine value.</param>
        /// <returns></returns>
        public static decimal Asin(decimal dSineValue)
        {
            return ConvertToDecimal(RadiansToDegrees(Math.Asin(ConvertToDouble(dSineValue))));
        }
        #endregion Asin

        #region Atan
        /// <summary>
        /// Returns the angle in degrees whose tangent is the specified number.
        /// </summary>
        /// <param name="dTangentValue">The d tangent value.</param>
        /// <returns></returns>
        public static decimal Atan(decimal mTangentValue)
        {
            return ConvertToDecimal(RadiansToDegrees(Math.Atan(ConvertToDouble(mTangentValue))));
        }
        #endregion Atan

        #region Atan2
        /// <summary>
        /// Returns the angle in degrees whose tangent is the quotient of the two specified numbers.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        public static decimal Atan2(decimal y, decimal x)
        {
            return ConvertToDecimal(RadiansToDegrees(Math.Atan2(ConvertToDouble(y), ConvertToDouble(x))));
        }
        #endregion Atan2

        #region Cos
        /// <summary>
        /// Calculates the cosine of the angle, when the angle is in degrees.
        /// </summary>
        /// <param name="myAngleInDegrees">My angle in degrees.</param>
        /// <returns></returns>
        public static decimal Cos(decimal myAngleInDegrees)
        {
            return ConvertToDecimal(Math.Cos(DegreesToRadians(ConvertToDouble(myAngleInDegrees))));
        }
        #endregion Cos

        #region Sin
        /// <summary>
        /// Calculates the sine of the angle, when the angle is in degrees.
        /// </summary>
        /// <param name="myAngleInDegrees">My angle in degrees.</param>
        /// <returns></returns>
        public static decimal Sin(decimal myAngleInDegrees)
        {
            return ConvertToDecimal(Math.Sin(DegreesToRadians(ConvertToDouble(myAngleInDegrees))));
        }
        #endregion Sin

        #region Tan
        /// <summary>
        /// Calculates the tangent of the angle, when the angle is in degrees.
        /// </summary>
        /// <param name="myAngleInDegrees">My angle in degrees.</param>
        /// <returns></returns>
        public static decimal Tan(decimal myAngleInDegrees)
        {
            return ConvertToDecimal(Math.Tan(DegreesToRadians(ConvertToDouble(myAngleInDegrees))));
        }
        #endregion Tan
        #endregion Trigonometry

        #region Common Math Functions
        #region Exp
        /// <summary>
        /// Returns e raised to the specified power.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        public static decimal Exp(Decimal x)
        {
            return ConvertToDecimal(Math.Exp(ConvertToDouble(x)));
        }
        #endregion Exp

        #region Log
        /// <summary>
        /// Returns the natural (base e) logarithm of a specified number.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        public static decimal Log(Decimal x)
        {
            return ConvertToDecimal(Math.Log(ConvertToDouble(x)));
        }
        /// <summary>
        /// Returns the logarithm of a specified number in a spcified base.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public static decimal Log(Decimal x, Decimal y)
        {
            return ConvertToDecimal(Math.Log(ConvertToDouble(x), ConvertToDouble(y)));
        }
        #endregion Log

        #region PI
        /// <summary>
        /// Gets the pi.
        /// </summary>
        /// <value>
        /// The pi.
        /// </value>
        public static decimal PI
        {
            get { return ConvertToDecimal(Math.PI); }
        }
        #endregion PI

        #region Pow
        /// <summary>
        /// Returns a specified number raised to the specified power.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public static decimal Pow(decimal x, decimal y)
        {
            return ConvertToDecimal(Math.Pow(ConvertToDouble(x), ConvertToDouble(y)));
        }
        #endregion Pow

        #region Sqrt
        /// <summary>
        /// Calculates the square root of the specified value.
        /// </summary>
        /// <param name="myValue">My value.</param>
        /// <returns></returns>
        public static decimal Sqrt(decimal myValue)
        {
            return ConvertToDecimal(Math.Sqrt(ConvertToDouble(myValue)));
        }
        #endregion Sqrt
        #endregion Common Math Functions

        #region Physical Unit Conversions
        #region Constants
        public const decimal StdPressurePsi = 14.696M;
        public const int StdTemperatureFahr = 70;
        public const int NormalTemperatureFahr = 68;
        public const decimal H2SO4MolecularWeight = 98.8M;
        public const decimal NH3MolecularWeight = 17.03M;
        public const decimal SOxMolecularWeight = 64.06M;
        public const decimal NOxMolecularWeight = 46.01M;
        public const decimal N2MolecularWeight = 28.01M;
        public const decimal HClMolecularWeight = 36.46M;
        public const decimal CO2MolecularWeight = 44.01M;
        #endregion Constants

        #region AirClean Concentrations
        /// <summary>
        /// PPMDVs to LBS per hour.
        /// </summary>
        /// <param name="mPPMDV">The m PPMDV.</param>
        /// <param name="mMolecularWeight">The m molecular weight.</param>
        /// <param name="mGasFlowSCFMD">The m gas flow SCFMD.</param>
        /// <returns></returns>
        public static decimal PPMDVToLbsPerHour(decimal mPPMDV, decimal mMolecularWeight, decimal mGasFlowSCFMD)
        {
            return mPPMDV * mMolecularWeight * mGasFlowSCFMD * 60 / 386500000;
        }

        /// <summary>
        /// Mgs the per N m3 to LBS per hour.
        /// </summary>
        /// <param name="mMgPerNM3">The m mg per N m3.</param>
        /// <param name="mGasFlowSCFMD">The m gas flow SCFMD.</param>
        /// <param name="mStdTemp">The m STD temp.</param>
        /// <param name="mNormalTemp">The m normal temp.</param>
        /// <param name="mElevationFt">The m elevation ft.</param>
        /// <returns></returns>
        public static decimal MgPerNM3ToLbsPerHour(decimal mMgPerNM3, decimal mGasFlowSCFMD, decimal mStdTemp, decimal mNormalTemp,
            decimal mElevationFt)
        {
            return mMgPerNM3 * 0.0283168M * 60 * mGasFlowSCFMD * (460 + mNormalTemp) * PsiAtElevation(mElevationFt, mStdTemp, 1) / (453600 *
                (460 + mStdTemp));
        }

        /// <summary>
        /// Mgs the per n m3 to mm btu per hour.
        /// </summary>
        /// <param name="mMgPerNM3">The m mg per n m3.</param>
        /// <param name="mGasFlowSCFMD">The m gas flow SCFMD.</param>
        /// <param name="mStdTemp">The m standard temporary.</param>
        /// <param name="mNormalTemp">The m normal temporary.</param>
        /// <param name="mElevationFt">The m elevation ft.</param>
        /// <param name="mProduction">The m production.</param>
        /// <returns></returns>
        public static decimal MgPerNM3ToMmBtuPerHour(decimal mMgPerNM3, decimal mGasFlowSCFMD, decimal mStdTemp, decimal mNormalTemp,
            decimal mElevationFt, decimal mProduction)
        {
            if (mProduction == 0)
            {
                return 0;
            }

            return (mMgPerNM3 * 0.0283168M * 60 * mGasFlowSCFMD * (460 + mNormalTemp) * PsiAtElevation(mElevationFt, mStdTemp, 1) / (453600 *
                (460 + mStdTemp))) / mProduction;
        }

        /// <summary>
        /// Grainses the per DSCF to LBS per hour.
        /// </summary>
        /// <param name="mGrainsPerDSCF">The m grains per DSCF.</param>
        /// <param name="mGasFlowSCFMD">The m gas flow SCFMD.</param>
        /// <returns></returns>
        public static decimal GrainsPerDSCFToLbsPerHour(decimal mGrainsPerDSCF, decimal mGasFlowSCFMD)
        {
            return mGrainsPerDSCF * mGasFlowSCFMD * 60 / 7000;
        }

        /// <summary>
        /// Grainses the per DSCF to mm btu per hour.
        /// </summary>
        /// <param name="mGrainsPerDSCF">The m grains per DSCF.</param>
        /// <param name="mGasFlowSCFMD">The m gas flow SCFMD.</param>
        /// <param name="mProduction">The m production.</param>
        /// <returns></returns>
        public static decimal GrainsPerDSCFToMmBtuPerHour(decimal mGrainsPerDSCF, decimal mGasFlowSCFMD, decimal mProduction)
        {
            if (mProduction == 0)
            {
                return 0;
            }

            return (mGrainsPerDSCF * mGasFlowSCFMD * 60M / 7000M) / mProduction;
        }

        /// <summary>
        /// PPMDVs to mg per N m3.
        /// </summary>
        /// <param name="mPPMDV">The m PPMDV.</param>
        /// <param name="mMolecularWeight">The m molecular weight.</param>
        /// <param name="mStdTemp">The m STD temp.</param>
        /// <param name="mNormalTemp">The m normal temp.</param>
        /// <param name="mElevationFt">The m elevation ft.</param>
        /// <returns></returns>
        public static decimal PPMDVToMgPerNM3(decimal mPPMDV, decimal mMolecularWeight, decimal mStdTemp, decimal mNormalTemp,
            decimal mElevationFt)
        {
            return mPPMDV * mMolecularWeight * 0.04144M * (460 + mStdTemp) / ((460 + mNormalTemp) * PsiAtElevation(mElevationFt, mStdTemp, 1));
        }

        /// <summary>
        /// LBSs the per hour to mg per N m3.
        /// </summary>
        /// <param name="mLbsPerHour">The m LBS per hour.</param>
        /// <param name="mGasFlowSCFMD">The m gas flow SCFMD.</param>
        /// <param name="mStdTemp">The m STD temp.</param>
        /// <param name="mNormalTemp">The m normal temp.</param>
        /// <param name="mElevationFt">The m elevation ft.</param>
        /// <returns></returns>
        public static decimal LbsPerHourToMgPerNM3(decimal mLbsPerHour, decimal mGasFlowSCFMD, decimal mStdTemp, decimal mNormalTemp,
            decimal mElevationFt)
        {
            return mLbsPerHour * 453600 * (460 + mStdTemp) / (0.0283168M * 60 * mGasFlowSCFMD * (460 + mNormalTemp)
                * PsiAtElevation(mElevationFt, mStdTemp, 1));
        }

        /// <summary>
        /// Grainses the per DSCF to mg per N m3.
        /// </summary>
        /// <param name="mGrainsPerDSCF">The m grains per DSCF.</param>
        /// <param name="mStdTemp">The m STD temp.</param>
        /// <param name="mNormalTemp">The m normal temp.</param>
        /// <param name="mElevationFt">The m elevation ft.</param>
        /// <returns></returns>
        public static decimal GrainsPerDSCFToMgPerNM3(decimal mGrainsPerDSCF, decimal mStdTemp, decimal mNormalTemp, decimal mElevationFt)
        {
            return mGrainsPerDSCF * 64.79891M * (460 + mStdTemp) / (0.0283168M * (460 + mNormalTemp)
                * PsiAtElevation(mElevationFt, mStdTemp, 1));
        }

        /// <summary>
        /// LBSs the per hour to grains per DSCF.
        /// </summary>
        /// <param name="mLbsPerHour">The m LBS per hour.</param>
        /// <param name="mGasFlowSCFMD">The m gas flow SCFMD.</param>
        /// <returns></returns>
        public static decimal LbsPerHourToGrainsPerDSCF(decimal mLbsPerHour, decimal mGasFlowSCFMD)
        {
            return mLbsPerHour * 7000 / (mGasFlowSCFMD * 60);
        }

        /// <summary>
        /// LBSs the per hour to mm btu per hour.
        /// </summary>
        /// <param name="mLbsPerHour">The m LBS per hour.</param>
        /// <param name="mProduction">The m production.</param>
        /// <returns></returns>
        public static decimal LbsPerHourToMmBtuPerHour(decimal mLbsPerHour, decimal mProduction)
        {
            if (mProduction == 0)
            {
                return 0;
            }

            return mLbsPerHour / mProduction;
        }

        /// <summary>
        /// Mgs the per N m3 to grains per DSCF.
        /// </summary>
        /// <param name="mMgPerNM3">The m mg per N m3.</param>
        /// <param name="mStdTemp">The m STD temp.</param>
        /// <param name="mNormalTemp">The m normal temp.</param>
        /// <param name="mElevationFt">The m elevation ft.</param>
        /// <returns></returns>
        public static decimal MgPerNM3ToGrainsPerDSCF(decimal mMgPerNM3, decimal mStdTemp, decimal mNormalTemp, decimal mElevationFt)
        {
            return mMgPerNM3 * 0.0283168M * (460 + mNormalTemp) * PsiAtElevation(mElevationFt, mStdTemp, 1) / (64.79891M * (460 + mStdTemp));
        }

        /// <summary>
        /// LBSs the per hour to PPMDV.
        /// </summary>
        /// <param name="mLbsPerHour">The m LBS per hour.</param>
        /// <param name="mMolecularWeight">The m molecular weight.</param>
        /// <param name="mGasFlowSCFMD">The m gas flow SCFMD.</param>
        /// <returns></returns>
        public static decimal LbsPerHourToPPMDV(decimal mLbsPerHour, decimal mMolecularWeight, decimal mGasFlowSCFMD)
        {
            return mLbsPerHour * 386500000 / (mMolecularWeight * mGasFlowSCFMD * 60);
        }

        /// <summary>
        /// Mgs the per N m3 to PPMDV.
        /// </summary>
        /// <param name="mMgPerNM3">The m mg per N m3.</param>
        /// <param name="nMolecularWeight">The n molecular weight.</param>
        /// <param name="mStdTemp">The m STD temp.</param>
        /// <param name="mNormalTemp">The m normal temp.</param>
        /// <param name="mElevationFt">The m elevation ft.</param>
        /// <returns></returns>
        public static decimal MgPerNM3ToPPMDV(decimal mMgPerNM3, decimal nMolecularWeight, decimal mStdTemp, decimal mNormalTemp,
            decimal mElevationFt)
        {
            return mMgPerNM3 * (460 + mNormalTemp) * PsiAtElevation(mElevationFt, mStdTemp, 1) / (nMolecularWeight * 0.04144M
                * (460 + mStdTemp));
        }
        #endregion AirClean Concentrations

        #region Pressure
        /// <summary>
        /// Psis at elevation.
        /// </summary>
        /// <param name="mElevation">The m elevation.</param>
        /// <param name="mStdTemp">The m STD temp.</param>
        /// <param name="mStdPressure">The m STD pressure.</param>
        /// <returns></returns>
        public static decimal PsiAtElevation(decimal mElevation, decimal mStdTemp, decimal mStdPressure)
        {
            return mStdPressure * UMCLib.ConvertToDecimal(Math.Exp((double)(-32.17405M * 28.9644M * mElevation / (89494.596M *
                ((mStdTemp - 32) * 5 / 9 + 273)))));
        }
        #endregion Pressure
        #endregion Physical Unit Conversions

        #region C Functions
        /// <summary>
        /// Highes the word.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int HighWord(long value)
        {
            return unchecked((short)(value >> 16));
        }

        /// <summary>
        /// Highes the word.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int HighWord(IntPtr value)
        {
            // Instead of checking the IntPrt length for 32 or 64 bit length, just cast to long (64-bit)
            return HighWord((long)value);
        }

        /// <summary>
        /// Lows the word.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int LowWord(long value)
        {
            return unchecked((short)value);
        }

        /// <summary>
        /// Lows the word.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int LowWord(IntPtr value)
        {
            // Instead of checking the IntPrt length for 32 or 64 bit length, just cast to long (64-bit)
            return LowWord((long)value);
        }
        #endregion C Functions
    }
}
