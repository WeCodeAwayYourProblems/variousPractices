using System;
using System.Collections.Generic;
using CodeForVariousPracices.BasicPractices;
using Xunit;

namespace CodeForVariousPractices.Test;
public class RecursionTests
{
   RecursionPractices Recursion { get; }
   public RecursionTests()
   { Recursion = new(); }

   [
      Theory,
      InlineData(10, 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10),
      InlineData(11, 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10 + 11),
      InlineData(15, 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10 + 11 + 12 + 13 + 14 + 15),
      InlineData(20, 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10 + 11 + 12 + 13 + 14 + 15 + 16 + 17 + 18 + 19 + 20)
   ]
   public void AddsEachNaturalNumberOfNumberN(int input, int expected)
   {
      // Actual output
      int actual = Recursion.ReturnTheSumOfNNaturalNumbers(input);

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
      bool actual = Recursion.CheckForPrime(2, input);

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
      bool actual = Recursion.CheckForPrime(2, input);

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
      bool actual = Recursion.CheckForPrimeSimple_FutureINumberGeneric(input, 2, new List<int> { });

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
      bool actual = Recursion.CheckForPrimeSimple_FutureINumberGeneric(input, 2, new List<int> { });

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
      bool actual = Recursion.CheckStringForPalindrome(input);

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
      string actual = Recursion.RemoveFirstAndLastLetter(input);

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
      int actual = Recursion.Factorial(input, 3, 2);

      // Assertions
      Assert.Equal(expected, actual);
   }

   [
      Theory,
      InlineData(37, true),
      InlineData(13, true),
      InlineData(21, false),
      InlineData(8191, true),
      InlineData(8193, false),
   // InlineData(565168463, false),
   // InlineData(1231654684561321379, false),
   // InlineData(1231654684561, false)
   ]
   public void IsPrimeMethod_ReturnsProperBoolean(long input, bool expected)
   {
      // Actual output
      bool actual = Recursion.IsPrime(input);

      // Assertions
      Assert.Equal(expected, actual);
   }

   [
      Theory,
      InlineData(10, 15, new int[2] { 5, 30 }),
      InlineData(10, 25, new int[2] { 5, 50 }),
      InlineData(8, 21, new int[2] { 1, 168 }),
      InlineData(6, 15, new int[2] { 3, 30 })
   ]
   public void FindsTheGCDandLCMOfTwoNumbers(int input1, int input2, int[] expected)
   {
      // Actual
      int[] actual = Recursion.LcmAndGcdOfTwoNumbers(input1, input2, incrementer: 2, new int[2] { default, default });

      // Assertions
      Assert.Equal(expected, actual);
   }
   [
      Theory,
      InlineData("w3resource", "ecruoser3w"),
      InlineData("Benjamin Wallace Bowen", "newoB ecallaW nimajneB")
   ]
   public void ReturnsInputStringReversed(string input, string expected)
   {
      // Actual
      string actual = Recursion.ReverseInputString(input, "");

      // Assertions
      Assert.Equal(expected, actual);
   }

   [
      Theory,
      InlineData(5, 3, 5 * 5 * 5),
      InlineData(10, 3, 10 * 10 * 10),
      InlineData(10, 6, 10 * 10 * 10 * 10 * 10 * 10),
      InlineData(3, 5, 3 * 3 * 3 * 3 * 3)
   ]
   public void FindThePowerOfANumberRecursively(int baseValue, int exponent, int expected)
   {
      // Actual
      int actual = Recursion.ReturnPowerOfANumber(baseValue, exponent, 1);

      // Assertions
      Assert.Equal(expected, actual);
   }
}