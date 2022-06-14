using System.Text;

namespace CodeForVariousPracices.BasicPractices;

public class RecursionPractices
{
   // 1. Write a program in C# Sharp to return a list of the first n natural numbers using recursion.
   public List<int> AllNaturalNumbersInAscendingOrder(int input, List<int> returnList, int constant = 1)
   {
      if (input < 1)
         return returnList;
      returnList.Add(constant);
      return AllNaturalNumbersInAscendingOrder(input - 1, returnList, constant + 1);
   }
   // 2. Write a program in C# Sharp to print numbers from n to 1 using recursion.
   public List<int> ReturnNaturalNumbersInDescendingOrder(int input, List<int> returnList)
   {
      if (input < 1)
         return returnList;
      returnList.Add(input);
      return ReturnNaturalNumbersInDescendingOrder(input - 1, returnList);
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
   public List<int> ReturnDigitsOfANumber(int input, List<int> returnList)
   {
      if (input < 10)
         return returnList;
      returnList.Add(input % 10);
      return ReturnDigitsOfANumber(input / 10, returnList);
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
   // 6. Write a program in C to return even or odd numbers in a given range using recursion.
   public List<int> ReturnEitherEvenOrOddNumbers(int incrementer, int input, List<int> returnList)
   {
      if (incrementer > input)
         return returnList;
      returnList.Add(incrementer);
      return ReturnEitherEvenOrOddNumbers(incrementer + 2, input, returnList);
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
      // Check whether the divisor is greater than half the input 
      // -- this saves time, as nothing greater than half of any number divides evenly into it
      if (divisor > input / 2)
         return true;

      // If Divisor is 2, increment it accordingly
      int newDivisor;
      if (divisor == 2)
         newDivisor = divisor + 1; // 3 is also a prime number
      else
         newDivisor = divisor + 2; // Although not all odd numbers are prime, all prime numbers are odd (except 2)
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
   // This method passes a list of used divisors so as not to use non-prime numbers in the division process
   public bool CheckForPrimeSimple_FutureINumberGeneric(int input, int divisor, List<int> divisorValues)
   {
      // Check to ensure the divisor is not less than 2
      if (divisor < 2)
         throw new ArgumentException($"{nameof(divisor)} cannot be less than 2");

      // Check for divisibility in input
      if (input % divisor == 0)
         return false;
      // Check whether the divisor is greater than half the input 
      // -- this is because no integer greater than half another integer can be multiplied ...
      // ... by another integer to evenly return the larger integer
      if (divisor < input / 2)
         return true;

      // If divisor is 2, increment it by 1
      int newDivisor;
      if (divisor == 2)
         newDivisor = divisor + 1;
      // Otherwise, increment accordingly
      else
      {
         // The new divisor has to be incremented by 2 before it's checked for validity
         newDivisor = divisor + 2;

         // Check to see whether the new divisor is divisible by any number in the divisor list
         // If the new divisor increments too large, we'll default to incrementing it by 2;
         while (divisorValues.Any(val => val % newDivisor == 0) && divisor < input / 2)
            newDivisor += 2;
      }
      divisorValues.Add(divisor);
      return CheckForPrimeSimple_FutureINumberGeneric(input, newDivisor, divisorValues);
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
      {
         newDivisor = divisor + 1;
         PrimeDivisors.Add(divisor);
         PrimeDivisors.Add(divisor + 1);
      }
      else
      {
         newDivisor = FindNextPrimeNumberForNextDivisor(divisor, input);
      }
      return CheckForPrimeComplex(newDivisor, input);

      // Local Function
      int FindNextPrimeNumberForNextDivisor(int divisor, decimal input)
      {
         int returnInt = default;
         // Find the next natural number n between (current divisor + 2) and (input / 2) that is prime ...
         // ... and make that the next divisor
         for (int div = divisor + 2; div > input / 2; div += 2) // increment by 2 so that we always have odd numbers
         {
            // Check whether the new divisor is evenly divisible by any of the PrimeDivisors numbers
            // If it is not, it is considered prime and made the new divisor
            if (!PrimeDivisors.Any(prime => prime % div == 0))
            {
               returnInt = div;

               // Only add the new divisor to the list of primes if it is not already contained therein. 
               if (!PrimeDivisors.Any(prime => prime == div))
                  PrimeDivisors.Add(div);
               break;
            }
            //    If the number IS divisible by one of the PrimeDivisorsNumbers,
            // then we continue the forLoop
         }

         //    If no such number could be found,
         // we assume that the PrimeDivisors number list is empty or incomplete,
         // and we assign newdivisor to divisor+2
         if (returnInt == default)
            returnInt = divisor + 2;
         return returnInt;
      }
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