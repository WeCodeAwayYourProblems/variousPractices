using CodeForVariousPracices.BasicPractices;
using Xunit;

namespace CodeForVariousPractices.Test;

public class ReturnBoolForSums
{
   [Fact]
   public void InputSumIs30_OrOneInputEquals30()
   {
      // Setup 
      BasicAlgorithms thirty = new();

      // Input pairs
      int first1 = 30;
      int first2 = 0;
      int second1 = 25;
      int second2 = 5;
      int third1 = 20;
      int third2 = 30;
      int fourth1 = 20;
      int fourth2 = 25;

      // Expected results
      bool firstExpected = true;
      bool secondExpected = true;
      bool thirdExpected = true;
      bool fourthExpected = false;

      // Actual Results
      bool firstActual = thirty.Input30OrSum30(first1, first2);
      bool secondActual = thirty.Input30OrSum30(second1, second2);
      bool thirdActual = thirty.Input30OrSum30(third1, third2);
      bool fourthActual = thirty.Input30OrSum30(fourth1, fourth2);

      // Assertions
      Assert.Equal(firstExpected, firstActual);
      Assert.Equal(secondExpected, secondActual);
      Assert.Equal(thirdExpected, thirdActual);
      Assert.Equal(fourthExpected, fourthActual);
   }
}