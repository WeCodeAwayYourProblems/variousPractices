using CodeForVariousPracices.BasicPractices;
using Xunit;

namespace CodeForVariousPractices.Test;

public class ReturnSumOfTwoInts
{
   [Fact]
   public void BasicAdditionMethod_ReturnsSumOfTwoInts()
   {
      // Setup
      BasicAlgorithms Algorithms = new();

      // Input pairs
      int first1 = 1;
      int first2 = 2;
      int second1 = 3;
      int second2 = 2;
      int third1 = 2;
      int third2 = 2;

      // Expected output per pairs
      int firstExpected = 3;
      int secondExpected = 5;
      int thirdExpected = 12;

      // Actual output
      int firstActual = Algorithms.ReturnSumOfTwoInts(first1, first2);
      int secondActual = Algorithms.ReturnSumOfTwoInts(second1, second2);
      int thirdActual = Algorithms.ReturnSumOfTwoInts(third1, third2);

      // Assertions
      Assert.Equal(firstExpected, firstActual);
      Assert.Equal(secondExpected, secondActual);
      Assert.Equal(thirdExpected, thirdActual);
   }
}