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
   [Fact]
   public void MethodCorrectlyIdentifiesPrimeNumbers()
   {
      // Setup
      RecursionPractices recursion = new();
      // decimal input1 = 37;
      // decimal input2 = 13;
      // decimal input3 = 21;
      // decimal input4 = 8191;
      // decimal input5 = 8193;
      decimal input6 = 15498155494565515997;

      // Expected Outputs
      // bool expected1 = true;
      // bool expected2 = true;
      // bool expected3 = false;
      // bool expected4 = true;
      // bool expected5 = false;
      bool expected6 = false;

      // Actual outputs
      // bool actual1 = recursion.CheckForPrime(2, input1);
      // bool actual2 = recursion.CheckForPrime(2, input2);
      // bool actual3 = recursion.CheckForPrime(2, input3);
      // bool actual4 = recursion.CheckForPrime(2, input4);
      // bool actual5 = recursion.CheckForPrime(2, input5);
      bool actual6 = recursion.CheckForPrime(2, input6);

      // Assersions  
      // Assert.Equal(expected1, actual1);
      // Assert.Equal(expected2, actual2);
      // Assert.Equal(expected3, actual3);
      // Assert.Equal(expected4, actual4);
      // Assert.Equal(expected5, actual5);
      Assert.Equal(expected6, actual6);
   }

}