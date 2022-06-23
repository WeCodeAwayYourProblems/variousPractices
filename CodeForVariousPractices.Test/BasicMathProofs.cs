using System;
using Xunit;

namespace CodeForVariousPractices.Test;

public class BasicMathProofs
{
   [
      Theory,
      InlineData(1239, 123),
      InlineData(1234, 123)
   ]
   public void IntegerDivisionsReturnWholeNumbers(int input, int expected)
   {
      // Actual values
      int actual = input / 10;

      // Assert how the number is rounded -- either up or down
      Assert.Equal(expected, actual);
   }

   [
      Theory,
      InlineData(1239, 9),
      InlineData(1234, 4)
   ]
   public void IntegerMod10ReturnsTheLastDigitOfLargeNumbers(int input, int expected)
   {
      // Actual values
      int actual = input % 10;

      // Assert
      Assert.Equal(expected, actual);
   }

   [
      Theory(Skip = "There's a bug with finding the exact remainder."),
      InlineData(5.5, 5.0, 0.5),
      InlineData(-25.56, -25.0, -0.56)
   ]
   public void AnyNonWholeNumberFlooredReturnsTheIntegral(double input, double expectedIntegral, double expectedRemainder)
   {
      // Find the absolute value of the input
      double absolute = Math.Abs(input);

      // Find the floor of the absolute input value
      double integer = Math.Floor(absolute);

      // Find the remainder
      double remainder = absolute - integer;

      // Adjust the integer and remainder based on the sign of the input
      if (input < 0)
      {
         remainder *= -1;
         integer *= -1;
      }

      // Assertions
      Assert.Equal(expectedIntegral, integer);
      Assert.Equal(expectedRemainder, remainder);
   }
}