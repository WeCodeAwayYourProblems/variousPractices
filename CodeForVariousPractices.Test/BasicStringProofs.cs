using System.Collections.Generic;
using Xunit;

namespace CodeForVariousPractices.Test;

public class BasicStringProofs
{
   [Fact]
   public void ReassignedStringsContainNewValues()
   {
      // Setup
      string input = "This Is An Input String";

      // Expected Values
      string expected = "this is an input string";

      // Actual Values
      input = input.ToLower();

      // Assertions
      Assert.Equal(expected, input);
   }
   [Fact]
   public void CharacterCollectionsConvertedToStringContainExpectedValues()
   {
      // Setup
      char[] input = new char[] { 't', 'h', 'i', 's', ' ', 'i', 's', ' ', 'a', ' ', 's', 't', 'r', 'i', 'n', 'g' };
      List<char> input2 = new() { 't', 'h', 'i', 's', ' ', 'i', 's', ' ', 'a', ' ', 's', 't', 'r', 'i', 'n', 'g' };

      // Expected
      string expected = "this is a string";

      // Actual
      string actual1 = string.Concat(input);
      string actual2 = new string(input2.ToArray());

      // Assertions
      Assert.Equal(expected, actual1);
      Assert.Equal(expected, actual2);
   }
   [Fact]
   public void ComparisonOperatorsWorkForIndividualCharacters()
   {
      // Given
      char a = 'a';
      char aa = 'a';
      char b = 'b';
      char bb = 'b';

      // When
      bool equalA = a == aa;
      bool equalB = b == bb;
      bool notEqual = b != a;

      // Then
      Assert.True(equalA);
      Assert.True(equalB);
      Assert.True(notEqual);
   }
   [Fact]
   public void IndexedStringsReturnAChar()
   {
      // Given
      string letters = "letters";
      char t = 't';

      // When
      var character = letters[3];

      // Then
      Assert.Equal(t, character);
   }
}