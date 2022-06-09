using CodeForVariousPracices.BasicPractices;

namespace CodeForVariousPracices;
static class Program
{
   static void Main()
   {
      // Test Printed Recursion methods
      RecursionPractices recursion = new();
      int input1 = 10;
      int input2 = 20;
      string expected1 = "10, 9, 8, 7, 6, 5, 4, 3, 2, 1";
      string expected2 = "20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1";
      Dictionary<int, string> values = new()
      {
         { input1, expected1 },
         { input2, expected2 }
      };
      Test_PrintedRecursionPrintMethods(values, recursion);
   }

   private static void Test_PrintedRecursionPrintMethods(Dictionary<int, string> values, RecursionPractices recursion)
   {
      int index = 0;
      foreach (var input in values.Keys)
      {
         // Test PrintNaturalNumbersInDescendingOrder method
         PrintInputAndExpectedValues(values, index, input, $"{nameof(recursion.PrintNaturalNumbersInDescendingOrder)}");
         recursion.PrintNaturalNumbersInDescendingOrder(input);

         // Test PrintBothEvenAndOddNumbers
         PrintInputAndExpectedValues(values, index, input, $"{nameof(recursion.PrintBothEvenAndOddNumbers)}");
         recursion.PrintBothEvenAndOddNumbers(1, input);

         // increment the index
         index++;
      }
   }

   private static void PrintInputAndExpectedValues(Dictionary<int, string> values, int index, int input, string methodName)
   {
      Console.WriteLine($"\n\nTest {methodName} method\nInput {index + 1}:\n\t{input}\nExpected Output {index + 1}:\n\t{values[input]}\nActual {index + 1}:");
   }
}
