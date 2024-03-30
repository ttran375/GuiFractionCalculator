using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiFractionCalculator
{
    /**
 * Fraction class supplies the underlying logic to drive this application. A better design might be to have this in a separate file or as a library.
 */
    public class Fraction
    {
        public int Top { get; }
        public int Bottom { get; }

        /**
         * This constructor takes two optional int arguments and assigns them to the appropriate properties.
         */
        public Fraction(int top = 0, int bottom = 1) => (Top, Bottom) = (top, bottom);

        /**
         * Add another constructor that takes two optional string arguments and assigns them to the appropriate properties (of course after conversion).
         */
        public Fraction(string top = "0", string bottom = "1") : this(int.Parse(top), int.Parse(bottom)) { }

        public static Fraction operator +(Fraction lhs, Fraction rhs) => new Fraction(lhs.Top * rhs.Bottom + rhs.Top * lhs.Bottom, lhs.Bottom * rhs.Bottom);
        public static Fraction operator -(Fraction lhs, Fraction rhs) => new Fraction(lhs.Top * rhs.Bottom - rhs.Top * lhs.Bottom, lhs.Bottom * rhs.Bottom);

        /**
         * Add two more methods that overloads the arithmetic operators multiply and divide arithmetic.
         */
        public static Fraction operator *(Fraction lhs, Fraction rhs) => new Fraction(lhs.Top * rhs.Top, lhs.Bottom * rhs.Bottom);
        public static Fraction operator /(Fraction lhs, Fraction rhs) => new Fraction(lhs.Top * rhs.Bottom, lhs.Bottom * rhs.Top);

        public override string ToString() => $"[{Top}, {Bottom}]";

        /**
         * This Deconstructor allows you to get both properties with a single statement.
         */
        public void Deconstruct(out string top, out string bottom) => (top, bottom) = ($"{Top}", $"{Bottom}");
    }
}
