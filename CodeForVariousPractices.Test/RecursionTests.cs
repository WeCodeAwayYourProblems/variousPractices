using CodeForVariousPracices.BasicPractices;
using Xunit;

namespace CodeForVariousPractices.Test;
public class RecursionTests
{
   [Fact]
   public void AddsEachNaturalNumberOfNumberN()
   {
      // Setup
      RecursionPractices recursion = new();
      int input1 = 10;
      int input2 = 20;

      // Expected values
      int expected1 = 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10;
      int expected2 = 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10 + 11 + 12 + 13 + 14 + 15 + 16 + 17 + 18 + 19 + 20;

      // Actual output
      int actual1 = recursion.ReturnTheSumOfNNaturalNumbers(input1);
      int actual2 = recursion.ReturnTheSumOfNNaturalNumbers(input2);

      // Assersions
      Assert.Equal(expected1, actual1);
      Assert.Equal(expected2, actual2);
   }
}