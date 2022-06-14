using System.Collections.Generic;
using CodeForVariousPracices.InterviewCodePractice;
using Xunit;

namespace CodeForVariousPractices.Test;

public class AlphabetSoupObjectTests
{
   public AlphabetSoupObjectTests()
   {
      soup = new();
   }
   public AlphabetSoup soup { get; }

   [Theory]
   [InlineData("hwpd", 2, "No error")]
   [InlineData("abcd", 6, "No error")]
   public void InputStringReturnAlphaPairsMethod_ReturnsTheCorrectNumberOfPairs(string input, int expected, string expectedMessage)
   {
      // Execution
      string actualMessage;
      int actual = soup.InputStringReturnAlphaPairs(input, out actualMessage);

      // Assertions
      Assert.Equal(expected, actual);
      Assert.Contains<string>(expectedMessage.ToLower(),
         new List<string>()
            { actualMessage, actualMessage.ToLower()});
   }
}