namespace CodeForVariousPracices.InterviewCodePractice;

public class AlphabetSoup
{
   public int InputStringReturnAlphaPairs(string input, out string errorMessage)
   {
      int pairs = 0;
      List<int> alphaNumerics = new();
      char[] alphabet = new char[]
         { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
         'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

      // Set dictionary values to <character, int>
      // This gives each letter of the alphabet a numerical value
      Dictionary<char, int> alphaDict = new();
      for (var i = 0; i < alphabet.Length; i++)
      { alphaDict.Add(alphabet[i], i + 1); }

      // Assign each character in the input string a value, based on the dictionary
      // Save int value in list
      foreach (var character in input)
      { alphaNumerics.Add(alphaDict[character]); }

      // The list.count should be the same as input.length
      if (!alphaNumerics.Count.Equals(input.Length))
      { errorMessage = "Something is wrong with the program's ability to loop through the input string."; }
      else
      { errorMessage = "No error"; }

      // Loop through alphanumeric values as assigned
      for (var i = 0; i < alphaNumerics.Count; i++)
      {
         for (var index = i + 1; index < alphaNumerics.Count; index++)
         {
            if (alphaNumerics[i] < alphaNumerics[index])
            { pairs++; }
         }
      }
      return pairs;
   }
}