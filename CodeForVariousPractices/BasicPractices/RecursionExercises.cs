using System.Text;

namespace CodeForVariousPracices.BasicPractices;

public class RecursionPractices
{
   // 1. Write a program in C# Sharp to print the first n natural number using recursion.
   public void PrintAllNaturalNumbersInAscendingOrder(int input, int constant = 1)
   {
      if (input == 1)
      {
         Console.Write($"{constant}");
         return;
      }
      Console.Write($"{constant}, ");
      PrintAllNaturalNumbersInAscendingOrder(input - 1, constant + 1);
   }
   // 2. Write a program in C# Sharp to print numbers from n to 1 using recursion.
   public void PrintNaturalNumbersInDescendingOrder(int input)
   {
      if (input == 1)
      {
         Console.Write($"{input}");
         return;
      }
      Console.Write($"{input}, ");
      PrintNaturalNumbersInDescendingOrder(input - 1);
   }
   // 3. Write a program in C# Sharp to find the sum of first n natural numbers using recursion.
   public int ReturnTheSumOfNNaturalNumbers(int input)
   {
      if (input == 1)
         return input;
      else
         return input + ReturnTheSumOfNNaturalNumbers(input - 1);
   }
   // 4. Write a program in C# Sharp to display the individual digits of a given number using recursion.
   public void DisplayDigitsOfANumber(int input)
   {
      if (input < 10)
      {
         Console.Write($"{input}");
         return;
      }
      DisplayDigitsOfANumber(input / 10);
      Console.Write($"{input % 10}, ");
   }
   // 5. Write a program in C# Sharp to count the number of digits in a number using recursion.
   public int ReturnNumberOfDigitsWithoutRecursion(int input)
   {
      // Convert input to string and return its length
      string inputstring = $"{input}";
      return inputstring.Length;
   }
   public void ReturnNumberOfDigitsWithRecursion(int input)
   {
      if (input < 10)
      {
         Console.WriteLine($"{input} ");
         return;
      }
      ReturnNumberOfDigitsWithRecursion(input / 10);
      Console.WriteLine($" {input % 10} ");
   }
   // 6. Write a program in C to print even or odd numbers in a given range using recursion.
   public void PrintBothEvenAndOddNumbers(int incrementer, int input)
   {
      if (incrementer > input)
         return;
      Console.Write($"{incrementer}, ");
      PrintBothEvenAndOddNumbers(incrementer + 2, input);
   }
}