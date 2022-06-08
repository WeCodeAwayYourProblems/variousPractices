using System.Text;

namespace CodeForVariousPracices.BasicPractices;
public class BasicAlgorithms
{
   public int ReturnSumOfTwoInts(int a, int b)
   {
      int results = 0;

      // Per parameters, if both inputs are equal, return triple their sum
      if (a == b)
      { results = (a + b) * 3; }
      // Per parameters, return the sum of the integers 
      else
      { results = a + b; }

      return results;
   }

   public int ReturnAbsoluteDiffBetweenNand51(int n)
   {
      int results = 0;
      // Per parameters, return triple the absolute difference if n is greater than 51
      if (n > 51)
         results = (n - 51) * 3;
      // Per parameters, return the absolute difference between n and 51;
      else
         results = 51 - n;
      return results;
   }

   public bool Input30OrSum30(int a, int b)
   {
      if (a == 30 || b == 30)
         return true;
      else if (a + b == 30)
         return true;
      else
         return false;
   }

   // Write a C# Sharp program to remove all "a" in each string in given list of strings and return the new string.
   public List<string> RemoveAllAInEachString(IEnumerable<string> stringArray)
   {
      // Create the list that will return the final product
      List<string> returnList = new();

      // Loop through each of the items in the array
      foreach (var item in stringArray)
      {
         // Create a mutable list that will contain the valid characters from each string
         List<char> aRemoved = new();

         // Find all valid characters in the string
         foreach (char character in item)
         {
            // If the character is not 'a', then add it to the list of characters
            if (!character.Equals('a'))
            { aRemoved.Add(character); }
         }

         // Convert the list of characters to a string using stringbuilder
         StringBuilder builder = new();
         foreach (var character in aRemoved)
         {
            builder.Append(character);
         }

         // Add the final string to the list that will be returned
         returnList.Add(builder.ToString());
      }

      return returnList;
   }
}