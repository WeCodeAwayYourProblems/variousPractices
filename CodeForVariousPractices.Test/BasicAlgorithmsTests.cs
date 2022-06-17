using System.Collections.Generic;
using CodeForVariousPracices.BasicPractices;
using Xunit;

namespace CodeForVariousPracices.Test;

public class TestAbsoluteDifference
{
   public BasicAlgorithms Algorithms { get; private set; }

   public TestAbsoluteDifference()
   { Algorithms = new(); }

   [
      Theory,
      InlineData(53, 6),
      InlineData(30, 21),
      InlineData(51, 0)
   ]
   public void BasicDifferenceMethod_ReturnAbsoluteDifference(int input, int expected)
   {
      // Actual Results
      int actual = Algorithms.ReturnAbsoluteDiffBetweenNand51(input);

      // Assertions
      Assert.Equal(expected, actual);
   }

   [
      Theory,
      InlineData(new string[] { "abc", "cdaef", "js", "php" }, new string[] { "bc", "cdef", "js", "php" }),
      InlineData(new string[] { "jack", "jackolantern", "beauty", "gilligan" }, new string[] { "jck", "jckolntern", "beuty", "gillign" })
   ]
   public void MethodRemovesAllAInEachStringOfInputList(string[] input, List<string> expected)
   {
      // Actual output
      IEnumerable<string> actual = Algorithms.RemoveAllAInEachString(input);

      // Assertions
      Assert.Equal(expected, actual);
   }

   [
      Theory,
      InlineData(30, 0, true),
      InlineData(25, 5, true),
      InlineData(20, 30, true),
      InlineData(20, 25, false)
   ]
   public void InputSumIs30_OrOneInputEquals30(int input1, int input2, bool expected)
   {
      // Actual Results
      bool actual = Algorithms.Input30OrSum30(input1, input2);

      // Assertions
      Assert.Equal(expected, actual);
   }

   [
      Theory,
      InlineData(1, 2, 3),
      InlineData(3, 2, 5),
      InlineData(2, 2, 12),
   ]
   public void BasicAdditionMethod_ReturnsSumOfTwoInts(int input1, int input2, int expected)
   {
      // Actual output
      int actual = Algorithms.ReturnSumOfTwoInts_ExceptIfTheTwoInputsAreEqual(input1, input2);

      // Assertions
      Assert.Equal(expected, actual);
   }
}