using System.Collections.Generic;
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
   [Fact]
   public void MethodRemovesAllAInEachStringOfInputList()
   {
      // Setup
      BasicAlgorithms stringReturned = new();

      // Input
      string[] inputValues = new string[] { "abc", "cdaef", "js", "php" };

      // Expected output
      List<string> expected = new() { "bc", "cdef", "js", "php" };

      // Actual output
      List<string> actual = stringReturned.RemoveAllAInEachString(inputValues);

      // Assertions
      Assert.Equal(expected, actual);
   }
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