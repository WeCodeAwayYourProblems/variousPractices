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
   // 7. Write a program in C# Sharp to check whether a number is prime or not using recursion.
   public bool CheckForPrime(int divisor, decimal input)
   {
      // Check to ensure the divisor is not less than 2
      if (divisor < 2)
         throw new ArgumentException($"{nameof(divisor)} cannot be less than 2");

      // Check for divisibility in input
      if (input % divisor == 0)
         return false;
      // Check whether the divisor is greater than half the input -- this saves time
      if (divisor > input / 2)
         return true;

      // If Divisor is 2, increment it accordingly
      int newDivisor;
      if (divisor == 2)
         newDivisor = divisor + 1; // 3 is also a prime number
      else
         newDivisor = divisor + 2; // Although not all odd numbers are prime, all prime numbers are odd (except 2, I guess?)
      return CheckForPrime(newDivisor, input);
   }
   public bool CheckForPrime(int divisor, int input)
   {
      // Check to ensure the divisor is not less than 2
      if (divisor < 2)
         throw new ArgumentException($"{nameof(divisor)} cannot be less than 2");

      // Check for divisibility in input
      if (input % divisor == 0)
         return false;
      // Check whether the divisor is greater than half the input -- this saves time
      if (divisor > input / 2)
         return true;

      // If Divisor is 2, increment it accordingly
      int newDivisor;
      if (divisor == 2)
         newDivisor = divisor + 1; // 3 is also a prime number
      else
         newDivisor = divisor + 2; // Although not all odd numbers are prime, all prime numbers are odd (except 2, I guess?)
      return CheckForPrime(newDivisor, input);
   }
   private List<int> PrimeDivisors = new();
   public bool CheckForPrimeComplex(int divisor, decimal input)
   {
      // Check whether the divisor is less than 2
      if (divisor < 2)
         throw new ArgumentException($"{nameof(divisor)} cannot be less than 2");

      // Check whether the divisor is already contained in the PrimeDivisorsList
      // Use case: the PrimeDivisors list is already populated with prime numbers and this method is being called again
      if (!PrimeDivisors.Any(div => div == divisor))
      {
         // Check whether the current divisor is divisible by any of the Prime divisors
         // The new Divisor will definitely be prime. Probably.
         divisor = CheckForPrimeDivisibility(divisor, input);
      }

      if (divisor > input / 2)
         return true;
      if (input % divisor == 0)
         return false;

      // If the divisor is 2, increment the divisor accordingly
      int newDivisor;
      if (divisor == 2)
         newDivisor = divisor++;
      else
         newDivisor = divisor + 2;
      return CheckForPrimeComplex(newDivisor, input);
   }
   public bool CheckForPrimeComplex(int divisor, int input)
   {
      // Check whether the divisor is less than 2
      if (divisor < 2)
         throw new ArgumentException($"{nameof(divisor)} cannot be less than 2");

      // Check whether the divisor is already contained in the PrimeDivisorsList
      // Use case: the PrimeDivisors list is already populated with prime numbers and this method is being called again
      bool isContainedInPrimeList = PrimeDivisors.Any(div => div == divisor);

      if (!isContainedInPrimeList)
      {
         // Check whether the current divisor is divisible by any of the Prime divisors
         // The new Divisor will definitely be prime. Probably.
         divisor = CheckForPrimeDivisibility(divisor, input);
      }

      if (divisor > input / 2)
         return true;
      if (input % divisor == 0)
         return false;

      // If the divisor is 2, increment the divisor accordingly
      int newDivisor;
      if (divisor == 2)
         newDivisor = divisor++;
      else
         newDivisor = divisor + 2;
      return CheckForPrimeComplex(newDivisor, input);
   }

   private int CheckForPrimeDivisibility(int divisor, decimal input)
   {
      for (int div = divisor; div > input / 2; div += 2)
      {
         bool[] isPrime = new bool[1] { true };
         foreach (var prime in PrimeDivisors)
         {
            if (div % prime == 0)
            {
               isPrime[0] = false;
               break;
            }
            else
               continue;
         }
         // Change the value of the divisor
         divisor = div;
         if (isPrime[0])
         {
            PrimeDivisors.Add(divisor);
            break;
         }
         else
            continue;
      }
      return divisor;
   }

   private int CheckForPrimeDivisibility(int divisor, int input)
   {
      for (int div = divisor; div > input / 2; div += 2)
      {
         bool[] isPrime = new bool[1] { true };
         foreach (var prime in PrimeDivisors)
         {
            if (div % prime == 0)
            {
               isPrime[0] = false;
               break;
            }
            else
               continue;
         }
         // Change the value of the divisor
         divisor = div;
         if (isPrime[0])
         {
            PrimeDivisors.Add(divisor);
            break;
         }
         else
            continue;
      }
      return divisor;
   }


   // 8. Write a program in C# Sharp to check whether a given string is Palindrome or not using recursion.
   public bool CheckStringForPalindrome(string input)
   {
      // Make the entire word lower case
      input = input.ToLower();

      // Return false if the first and last letters are not the same
      if (input[0] != input[input.Length - 1])
         return false;

      // If the string does not have one or two letters left, remove the first and last letters from the string
      bool lastTwo = input.Length <= 2;
      List<string> newInput = new();
      if (!lastTwo)
         newInput.Add(RemoveFirstAndLastLetter(input));

      // Check whether the last two remaining letters are the same
      bool sameLetters = input[0].Equals(input[input.Length - 1]);
      if (sameLetters && lastTwo)
         return true;
      else if (!sameLetters && lastTwo)
         return false;
      else
         return CheckStringForPalindrome(newInput[0]);
   }
   public string RemoveFirstAndLastLetter(string input)
   {
      StringBuilder sb = new();
      for (int index = 1; index < input.Length - 1; index++)
      { sb.Append(input[index]); }
      return sb.ToString();
   }
   // 9. Write a program in C# Sharp to find the factorial of a given number using recursion.
   public int Factorial(int input, int incrementer, int product)
   {
      product = product * incrementer;
      incrementer++;
      if (incrementer > input)
         return product;
      return Factorial(input, incrementer, product);
   }
   // 10. Write a program in C# Sharp to find the Fibonacci numbers for a n numbers of series using recursion.
   public void PrintNNumbersOfFibonacci(int input, int previousF, int currentF)
   {
      int nextF = currentF + previousF;
      previousF = currentF;
      if (currentF == 0)
         nextF = 1;
      Console.Write($"{currentF} ");
      input--;
      if (input < 1)
         return;
      PrintNNumbersOfFibonacci(input, currentF, nextF);
   }
}