using Xunit;

namespace CodeForVariousPractices.Test;

public class BasicMathProofs
{
   [Fact]
   public void IntegerDivisionsReturnWholeNumbers()
   {
      // Integers to be divided by 10
      int num1 = 1239;
      int num2 = 1234;

      // Expected values
      int expected1 = 123;
      int expected2 = 123;

      // Actual values
      int actual1 = num1 / 10;
      int actual2 = num2 / 10;

      // Assert how the number is rounded -- either up or down
      Assert.Equal(expected1, actual1);
      Assert.Equal(expected2, actual2);
   }

   [Fact]
   public void IntegerMod10ReturnsTheLastDigitOfLargeNumbers()
   {
      // Integers to be mod by 10
      int num1 = 1239;
      int num2 = 1234;

      // Expected Values
      int expected1 = 9;
      int expected2 = 4;

      // Actual values
      int actual1 = num1 % 10;
      int actual2 = num2 % 10;

      // Assert
      Assert.Equal(expected1, actual1);
      Assert.Equal(expected2, actual2);
   }
}