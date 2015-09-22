using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace FractionCalculator.Structs
{
    struct Fraction
    {
        private BigInteger numerator;
        private BigInteger denominator;

        public Fraction(BigInteger numerator, BigInteger denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public BigInteger Numerator
        {
            get
            {
                return this.numerator;
            }
            set
            {
                if (value < -9223372036854775808 || value > 9223372036854775807)
                {
                    throw new ArgumentOutOfRangeException("Numerator must be in the range [-9223372036854775808...9223372036854775807].");
                }
                this.numerator = value;
            }
        }
        public BigInteger Denominator
        {
            get
            {
                return this.denominator;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Denominator can't be 0.");
                }
                this.denominator = value;
            }
        }
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            BigInteger newNumerator = 0;
            BigInteger newDenominator = 0;
            if (f1.denominator == f2.denominator)
            {
                newNumerator = f1.numerator + f2.numerator;
                newDenominator = f1.denominator;
            }
            else
            {
                if (f1.denominator % f2.denominator == 0 || f2.denominator % f1.denominator == 0)
                {
                    if (f1.denominator > f2.denominator)
                    {
                        newNumerator = f1.numerator + (f1.denominator / f2.denominator) * f2.numerator;
                        newDenominator = f1.denominator;
                    }
                    else
                    {
                        newNumerator = f1.numerator * (f2.denominator / f1.denominator) + f2.numerator;
                        newDenominator = f2.denominator;
                    }
                }
                else
                {
                    newNumerator = (f1.denominator * f2.numerator) + (f1.numerator * f2.denominator);
                    newDenominator = f1.denominator * f2.denominator;
                }
            }

            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            BigInteger newNumerator = 0;
            BigInteger newDenominator = 0;
            if (f1.denominator == f2.denominator)
            {
                newNumerator = f1.numerator - f2.numerator;
                newDenominator = f1.denominator;
            }
            else
            {
                if (f1.denominator % f2.denominator == 0 || f2.denominator % f1.denominator == 0)
                {
                    if (f1.denominator > f2.denominator)
                    {
                        newNumerator = f1.numerator - (f1.denominator / f2.denominator) * f2.numerator;
                        newDenominator = f1.denominator;
                    }
                    else
                    {
                        newNumerator = f1.numerator * (f2.denominator / f1.denominator) - f2.numerator;
                        newDenominator = f2.denominator;
                    }
                }
                else
                {
                    newNumerator = (f1.denominator * f2.numerator) - (f1.numerator * f2.denominator);
                    newDenominator = f1.denominator * f2.denominator;
                }
            }

            return new Fraction(newNumerator, newDenominator);
        }

        public override string ToString()
        {
            return String.Format("{0}", ((decimal)this.numerator / (decimal)this.denominator));
        }
    }
}
