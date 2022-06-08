using System.Collections.Generic;
using CodeForVariousPracices.InterviewCodePractice;
using Xunit;

namespace CodeForVariousPractices.Test;

public class AlphabetSoupObjectTests
{
   [Fact]
   public void InputStringReturnAlphaPairsMethod_ReturnsTheCorrectNumberOfPairs()
   {
      // Setup
      AlphabetSoup soup = new();
      // // Input strings
      string inputStr1 = "hwpd";
      string inputStr2 = "abcd";
      // // Expected outputs
      int expected1 = 2;
      int expected2 = 6;
      // // Expected out message
      string expectedMessage = "No error";

      // Execution
      string message1;
      string message2;
      int actual1 = soup.InputStringReturnAlphaPairs(inputStr1, out message1);
      int actual2 = soup.InputStringReturnAlphaPairs(inputStr2, out message2);

      // Assertions
      Assert.Equal(expected1, actual1);
      Assert.Equal(expected2, actual2);
      Assert.Contains<string>(expectedMessage.ToLower(),
         new List<string>()
            { message1, message1.ToLower(),
            message2, message2.ToLower() });

   }
}