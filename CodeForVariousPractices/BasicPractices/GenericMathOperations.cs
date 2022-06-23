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
   // Alternative
   public int ReturnThePowerOfTwoNumbers(int input, int power) => input ^ power;

   // 4. Write a C# Sharp program to calculate true mean value, mean with rounding away from zero and mean with rounding to nearest of some specified decimal values.
   public Dictionary<string, decimal> CalculateMeanValue_True_AwayFromZero_ToNearest(decimal[] inputValues)
   {
      Dictionary<string, decimal> returnDict = new();

      // Calculate The True mean
      decimal trueMeanSum = 0;
      foreach (decimal val in inputValues)
      {
         trueMeanSum += val;
      }
      returnDict.Add("The true mean of the given inputs is: ", trueMeanSum / inputValues.Length);

      // Calculate the mean away from zero
      decimal awayMeanSum = 0;
      foreach (decimal val in inputValues)
      {
         awayMeanSum += Math.Round(val, 1, MidpointRounding.AwayFromZero);
      }
      returnDict.Add("The mean rounded away from zero of the given inputs is: ", awayMeanSum / inputValues.Length);

      // Calculate the mean to nearest
      decimal nearMeanSum = 0;
      foreach (decimal val in inputValues)
      {
         nearMeanSum += Math.Round(val, 1, MidpointRounding.ToEven);
      }
      returnDict.Add("The mean rounded to the nearest value of the given inputs is: ", nearMeanSum / inputValues.Length);

      return returnDict;
   }

   // 5. Write a C# Sharp program to return the sign of a single value
   public string ReturnWhetherAGivenValueIsGreaterOrLessThanZero(int input)
   {
      if (input < 0)
         return $"{input} is less than zero";
      else if (input > 0)
         return $"{input} is greater than zero";
      else
         return $"{input} is equal to zero";
   }

   // 6. Return the N root of any number
   public double ReturnTheNRootOfAnyNumber(double input, int power) => Math.Pow(input, 1.0 / power);

   // 7. Write a C# Sharp program to find the whole number and fractional part from a positive and a negative Decimal number
   public Dictionary<string, decimal> ReturnWholeAndPartOfAnyGivenNumber(decimal input)
   {
      Dictionary<string, decimal> returnDict = new();
      decimal absolute = Math.Abs(input);

      decimal integral = Math.Floor(absolute);
      decimal remainder = absolute - integral;
      if (input > 0)
      {
         returnDict.Add($"The integral of {input} is: ", integral);
         returnDict.Add($"The remainder of {input} is: ", remainder);
      }
      else
      {
         returnDict.Add($"The integral of {input} is: ", integral * -1);
         returnDict.Add($"The remainder of {input} is: ", remainder * -1);
      }
      return returnDict;
   }
}