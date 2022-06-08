using System.Collections.Generic;
using CodeForVariousPracices.BasicPractices;
using Xunit;

namespace CodeForVariousPractices.Test;

public class RemovesAllAInEachString
{
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
}