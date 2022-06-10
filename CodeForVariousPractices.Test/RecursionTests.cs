using System;
using CodeForVariousPracices.BasicPractices;
using Xunit;

namespace CodeForVariousPractices.Test;
public class RecursionTests
{
   RecursionPractices recursion { get; }
   public RecursionTests()
   {
      recursion = new();
   }
   [Fact]
   public void AddsEachNaturalNumberOfNumberN()
   {
      // Setup
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
      int input1 = 37;
      decimal input2 = 13;
      int input3 = 21;
      decimal input4 = 8191;
      int input5 = 8193;
      decimal input6 = 15498155494565515997;
      // decimal input7 = decimal.MaxValue;
      // int input8 = int.MaxValue;

      // Expected Outputs
      bool expected1 = true;
      bool expected2 = true;
      bool expected3 = false;
      bool expected4 = true;
      bool expected5 = false;
      bool expected6 = false;
      // bool expected7 = false;
      // bool expected8 = false;

      // Actual outputs
      bool actual1 = recursion.CheckForPrime(2, input1);
      bool actual2 = recursion.CheckForPrime(2, input2);
      bool actual3 = recursion.CheckForPrime(2, input3);
      bool actual4 = recursion.CheckForPrime(2, input4);
      bool actual5 = recursion.CheckForPrime(2, input5);
      bool actual6 = recursion.CheckForPrime(2, input6);
      // bool actual7 = recursion.CheckForPrime(2, input7);
      // bool actual8 = recursion.CheckForPrime(2, input8);

      // Assersions  
      Assert.Equal(expected1, actual1);
      Assert.Equal(expected2, actual2);
      Assert.Equal(expected3, actual3);
      Assert.Equal(expected4, actual4);
      Assert.Equal(expected5, actual5);
      Assert.Equal(expected6, actual6);
      // Assert.Equal(expected7, actual7);
      // Assert.Equal(expected8, actual8);
   }
   [Fact]
   public void MethodCorrectlyIdentifiesPalindromeStrings()
   {
      // Setup 
      string input1 = "radar";
      string input2 = "racecar";
      string input3 = "Ben";
      string input4 = "Supercalifragilisticexpialidocious";
      string input5 = "Tattarrattat";

      // Expected Values
      bool expected1 = true;
      bool expected2 = true;
      bool expected3 = false;
      bool expected4 = false;
      bool expected5 = true;

      // Actual Values
      bool actual1 = recursion.CheckStringForPalindrome(input1);
      bool actual2 = recursion.CheckStringForPalindrome(input2);
      bool actual3 = recursion.CheckStringForPalindrome(input3);
      bool actual4 = recursion.CheckStringForPalindrome(input4);
      bool actual5 = recursion.CheckStringForPalindrome(input5);

      // Assertions
      Assert.Equal(expected1, actual1);
      Assert.Equal(expected2, actual2);
      Assert.Equal(expected3, actual3);
      Assert.Equal(expected4, actual4);
      Assert.Equal(expected5, actual5);
   }
   [Fact]
   public void RemoveStringMethod_RemovesTheFirstAndLastCharacterOfAStringAndReturnsTheResult()
   {
      // Setup
      string input1 = "radar";
      string input2 = "racecar";
      string input3 = "ben";

      // Expected values
      string expected1 = "ada";
      string expected2 = "aceca";
      string expected3 = "e";

      // Actual
      string actual1 = recursion.RemoveFirstAndLastLetter(input1);
      string actual2 = recursion.RemoveFirstAndLastLetter(input2);
      string actual3 = recursion.RemoveFirstAndLastLetter(input3);

      // Assertions
      Assert.Equal(expected1, actual1);
      Assert.Equal(expected2, actual2);
      Assert.Equal(expected3, actual3);
   }
   [Fact]
   public void FactorialMethodReturnsFactorial()
   {
      // Setup
      int input1 = 10;
      int input2 = 5;
      int input3 = 11;

      // Expected results
      int expected1 = 3628800;
      int expected2 = 120;
      int expected3 = 39916800;

      // Actual results
      int actual1 = recursion.Factorial(input1, 3, 2);
      int actual2 = recursion.Factorial(input2, 3, 2);
      int actual3 = recursion.Factorial(input3, 3, 2);

      // Assertions
      Assert.Equal(expected1, actual1);
      Assert.Equal(expected2, actual2);
      Assert.Equal(expected3, actual3);
   }

}