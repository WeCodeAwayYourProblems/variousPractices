using System.Collections.Generic;
using Xunit;

namespace CodeForVariousPractices.Test;

public class BasicStringProofs
{
   [
      Theory,
      InlineData("This Is An Input String", "this is an input string")
   ]
   public void ReassignedStringsContainNewValues(string input, string expected)
   {
      // Actual Values
      input = input.ToLower();

      // Assertions
      Assert.Equal(expected, input);
   }
   [
      Theory,
      InlineData(new char[] { 't', 'h', 'i', 's', ' ', 'i', 's', ' ', 'a', ' ', 's', 't', 'r', 'i', 'n', 'g' }, "this is a string")
   ]
   public void CharacterCollectionsConvertedToStringContainExpectedValues(char[] input, string expected)
   {
      // Actual
      string actual1 = string.Concat(input);
      string actual2 = new string(input);

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
      bool notEqual2 = bb != aa;
      bool notEqual3 = bb != a;
      bool notEqual4 = b != aa;

      // Then
      Assert.True(equalA);
      Assert.True(equalB);
      Assert.True(notEqual);
      Assert.True(notEqual2);
      Assert.True(notEqual3);
      Assert.True(notEqual4);
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