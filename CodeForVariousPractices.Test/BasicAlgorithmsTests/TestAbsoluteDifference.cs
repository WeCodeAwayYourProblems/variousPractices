using CodeForVariousPracices.BasicPractices;
using Xunit;

namespace CodeForVariousPracices.Test;

public class TestAbsoluteDifference
{
   [Fact]
   public void BasicDifferenceMethod_ReturnAbsoluteDifference()
   {
      // Setup
      BasicAlgorithms Algorithms = new();
      // Inputs
      int first = 53;
      int second = 30;
      int third = 51;

      // Expected results
      int firstExpected = 6;
      int secondExpected = 21;
      int thirdExpected = 0;

      // Actual Results
      int firstActual = Algorithms.ReturnAbsoluteDiffBetweenNand51(first);
      int secondActual = Algorithms.ReturnAbsoluteDiffBetweenNand51(second);
      int thirdActual = Algorithms.ReturnAbsoluteDiffBetweenNand51(third);

      // Assertions
      Assert.Equal(firstExpected, firstActual);
      Assert.Equal(secondExpected, secondActual);
      Assert.Equal(thirdExpected, thirdActual);
   }
}