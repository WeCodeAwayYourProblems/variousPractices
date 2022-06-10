namespace CodeForVariousPracices.BasicPractices;

public class GenericMathOperations
{
   // 1. Write a C# Sharp program to get the absolute value of a number of Decimal values, Double values, Int16 values, Int32 values: and Int64 values.
   public decimal ReturnAbsoluteValueOfAnyNumber(decimal input) => Math.Abs(input);
   public double ReturnAbsoluteValueOfAnyNumber(double input) => Math.Abs(input);
   public short ReturnAbsoluteValueOfAnyNumber(short input) => Math.Abs(input);
   public int ReturnAbsoluteValueOfAnyNumber(int input) => Math.Abs(input);
   public long ReturnAbsoluteValueOfAnyNumber(long input) => Math.Abs(input);
   public nint ReturnAbsoluteValueOfAnyNumber(nint input) => Math.Abs(input);
   public sbyte ReturnAbsoluteValueOfAnyNumber(sbyte input) => Math.Abs(input);
   public float ReturnAbsoluteValueOfAnyNumber(float input) => Math.Abs(input);
   // 2. Write a C# Sharp program to find the greater and smaller value of two variables.
   public string ReturnGreaterAndLesserOfTwoValues(decimal input1, decimal input2)
   {
      bool isGreater = input1 > input2;
      string baseMessage = $" of the two numbers {input1} and {input2}";
      string greaterMessage;
      string lessMessage;
      if (isGreater)
      {
         greaterMessage = $"{input1} is larger" + baseMessage;
         lessMessage = $"{input2} is the smaller" + baseMessage;
      }
      else
      {
         greaterMessage = $"{input2} is larger" + baseMessage;
         lessMessage = $"{input1} is the smaller" + baseMessage;
      }
      return greaterMessage + "\n" + lessMessage;
   }
   public string ReturnGreaterAndLesserOfTwoValues(double input1, double input2)
   {
      bool isGreater = input1 > input2;
      string baseMessage = $" of the two numbers {input1} and {input2}";
      string greaterMessage;
      string lessMessage;
      if (isGreater)
      {
         greaterMessage = $"{input1} is larger" + baseMessage;
         lessMessage = $"{input2} is the smaller" + baseMessage;
      }
      else
      {
         greaterMessage = $"{input2} is larger" + baseMessage;
         lessMessage = $"{input1} is the smaller" + baseMessage;
      }
      return greaterMessage + "\n" + lessMessage;
   }
   public string ReturnGreaterAndLesserOfTwoValues(short input1, short input2)
   {
      bool isGreater = input1 > input2;
      string baseMessage = $" of the two numbers {input1} and {input2}";
      string greaterMessage;
      string lessMessage;
      if (isGreater)
      {
         greaterMessage = $"{input1} is larger" + baseMessage;
         lessMessage = $"{input2} is the smaller" + baseMessage;
      }
      else
      {
         greaterMessage = $"{input2} is larger" + baseMessage;
         lessMessage = $"{input1} is the smaller" + baseMessage;
      }
      return greaterMessage + "\n" + lessMessage;
   }
   public string ReturnGreaterAndLesserOfTwoValues(int input1, int input2)
   {
      bool isGreater = input1 > input2;
      string baseMessage = $" of the two numbers {input1} and {input2}";
      string greaterMessage;
      string lessMessage;
      if (isGreater)
      {
         greaterMessage = $"{input1} is larger" + baseMessage;
         lessMessage = $"{input2} is the smaller" + baseMessage;
      }
      else
      {
         greaterMessage = $"{input2} is larger" + baseMessage;
         lessMessage = $"{input1} is the smaller" + baseMessage;
      }
      return greaterMessage + "\n" + lessMessage;
   }
   public string ReturnGreaterAndLesserOfTwoValues(long input1, long input2)
   {
      bool isGreater = input1 > input2;
      string baseMessage = $" of the two numbers {input1} and {input2}";
      string greaterMessage;
      string lessMessage;
      if (isGreater)
      {
         greaterMessage = $"{input1} is larger" + baseMessage;
         lessMessage = $"{input2} is the smaller" + baseMessage;
      }
      else
      {
         greaterMessage = $"{input2} is larger" + baseMessage;
         lessMessage = $"{input1} is the smaller" + baseMessage;
      }
      return greaterMessage + "\n" + lessMessage;
   }
   public string ReturnGreaterAndLesserOfTwoValues(nint input1, nint input2)
   {
      bool isGreater = input1 > input2;
      string baseMessage = $" of the two numbers {input1} and {input2}";
      string greaterMessage;
      string lessMessage;
      if (isGreater)
      {
         greaterMessage = $"{input1} is larger" + baseMessage;
         lessMessage = $"{input2} is the smaller" + baseMessage;
      }
      else
      {
         greaterMessage = $"{input2} is larger" + baseMessage;
         lessMessage = $"{input1} is the smaller" + baseMessage;
      }
      return greaterMessage + "\n" + lessMessage;
   }
   public string ReturnGreaterAndLesserOfTwoValues(sbyte input1, sbyte input2)
   {
      bool isGreater = input1 > input2;
      string baseMessage = $" of the two numbers {input1} and {input2}";
      string greaterMessage;
      string lessMessage;
      if (isGreater)
      {
         greaterMessage = $"{input1} is larger" + baseMessage;
         lessMessage = $"{input2} is the smaller" + baseMessage;
      }
      else
      {
         greaterMessage = $"{input2} is larger" + baseMessage;
         lessMessage = $"{input1} is the smaller" + baseMessage;
      }
      return greaterMessage + "\n" + lessMessage;
   }
   public string ReturnGreaterAndLesserOfTwoValues(float input1, float input2)
   {
      bool isGreater = input1 > input2;
      string baseMessage = $" of the two numbers {input1} and {input2}";
      string greaterMessage;
      string lessMessage;
      if (isGreater)
      {
         greaterMessage = $"{input1} is larger" + baseMessage;
         lessMessage = $"{input2} is the smaller" + baseMessage;
      }
      else
      {
         greaterMessage = $"{input2} is larger" + baseMessage;
         lessMessage = $"{input1} is the smaller" + baseMessage;
      }
      return greaterMessage + "\n" + lessMessage;
   }
   // 3. Write a C# Sharp program to calculate the value that results from raising 3 to a power ranging from 0 to 32
   public void PrintAllValuesOfNRaisedToAllNumbers0ToY_Recursive(int n, int y, int incrementer)
   {
      if (incrementer < 0)
         throw new ArgumentException($"{nameof(incrementer)} parameter must be equal to 0 by the initial caller.");

      if (incrementer >= y)
         return;
      Console.Write($"{n ^ incrementer}");
      incrementer++;
      PrintAllValuesOfNRaisedToAllNumbers0ToY_Recursive(n, y, incrementer);
   }
}