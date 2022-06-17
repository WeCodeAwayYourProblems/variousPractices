using System;
using System.Collections.Generic;
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
   [
      Theory,
      InlineData(10, 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10),
      InlineData(20, 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10 + 11 + 12 + 13 + 14 + 15 + 16 + 17 + 18 + 19 + 20)
   ]
   public void AddsEachNaturalNumberOfNumberN(int input, int expected)
   {
      // Actual output
      int actual = recursion.ReturnTheSumOfNNaturalNumbers(input);

      // Assersions
      Assert.Equal(expected, actual);
   }

   [
      Theory,
      InlineData(37, true),
      InlineData(13, true),
      InlineData(21, false),
      InlineData(8191, true),
      InlineData(8193, false),
      InlineData(565168463, false)
   ]
   public void MethodCorrectlyIdentifiesPrimeNumbers_Int(int input, bool expected)
   {
      // Actual output
      bool actual = recursion.CheckForPrime(2, input);

      // Assersions  
      Assert.Equal(expected, actual);
   }
   [
      Theory,
      InlineData(37, true),
      InlineData(13, true),
      InlineData(21, false),
      InlineData(8191, true),
      InlineData(8193, false),
      InlineData(15498155494565515997, false)
   ]
   public void MethodCorrectlyIdentifiesPrimeNumbers_Decimal(decimal input, bool expected)
   {
      // Actual output
      bool actual = recursion.CheckForPrime(2, input);

      // Assersions  
      Assert.Equal(expected, actual);
   }
   [
      Theory,
      InlineData(37, true),
      InlineData(13, true),
      InlineData(21, false),
      InlineData(8191, true),
      InlineData(8193, false),
      InlineData(565168463, false)
   ]
   public void MethodCorrectlyIdentifiesPrimeNumbers_SimpleMethod_FutureINumberGeneric(int input, bool expected)
   {
      // Actual output
      bool actual = recursion.CheckForPrimeSimple_FutureINumberGeneric(input, 2, new List<int> { });

      // Assersions  
      Assert.Equal(expected, actual);
   }
   [
      Theory,
      InlineData(37, true),
      InlineData(13, true),
      InlineData(21, false),
      InlineData(8191, true),
      InlineData(8193, false),
      InlineData(565168463, false)
   ]
   public void ReturnsPrimeNumbersList_FutureINumberGeneric(int input, bool expected)
   {
      // Actual output
      bool actual = recursion.CheckForPrimeSimple_FutureINumberGeneric(input, 2, new List<int> { });

      // Assersions  
      Assert.Equal(expected, actual);
   }
   [
      Theory,
      InlineData("radar", true),
      InlineData("racecar", true),
      InlineData("Ben", false),
      InlineData("Supercalifragilisticexpialidocious", false),
      InlineData("Tattarrattat", true)
   ]
   public void MethodCorrectlyIdentifiesPalindromeStrings(string input, bool expected)
   {
      // Actual output
      bool actual = recursion.CheckStringForPalindrome(input);

      // Assertions
      Assert.Equal(expected, actual);
   }
   [
      Theory,
      InlineData("radar", "ada"),
      InlineData("racecar", "aceca"),
      InlineData("ben", "e")
   ]
   public void RemoveStringMethod_RemovesTheFirstAndLastCharacterOfAStringAndReturnsTheResult(string input, string expected)
   {
      // Actual output
      string actual = recursion.RemoveFirstAndLastLetter(input);

      // Assertions
      Assert.Equal(expected, actual);
   }
   [
      Theory,
      InlineData(10, 3628800),
      InlineData(5, 120),
      InlineData(11, 39916800)
   ]
   public void FactorialMethodReturnsFactorial(int input, int expected)
   {
      // Actual output
      int actual = recursion.Factorial(input, 3, 2);

      // Assertions
      Assert.Equal(expected, actual);
   }
   [
      Theory,
      InlineData(37, true), InlineData(13, true), InlineData(21, false),
      InlineData(8191, true), InlineData(8193, false), InlineData(565168463, false), InlineData(1231654684561321379, false), InlineData(1231654684561, false)
   ]
   public void IsPrimeMethod_ReturnsProperBoolean(Int64 input, bool expected)
   {
      // Actual output
      bool actual = recursion.IsPrime(input);

      // Assertions
      Assert.Equal(expected, actual);
   }
   [
      Theory,
      InlineData(10, 15, new int[2] { 5, 30 }),
      InlineData(6, 15, new int[2] { 3, 30 })
   ]
   public void FindsTheGCDandLCMOfTwoNumbers(int input1, int input2, int[] expected)
   {
      // Actual
      int[] actual = recursion.LcmAndGcdOfTwoNumbers(input1, input2, incrementer: 2, new int[2] { default, default });

      // Assertions
      Assert.Equal(expected, actual);
   }
}