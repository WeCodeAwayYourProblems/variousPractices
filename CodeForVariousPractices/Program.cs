﻿using CodeForVariousPracices.BasicPractices;
using System.Diagnostics;
using System.Collections.Concurrent;
using CodeForVariousPracices.SolveSudokuPuzzle;
using System.Text;

namespace CodeForVariousPracices;
static class Program
{
   static void Main()
   {
      RecursionPractices recursion = new();
      bool returns = recursion.CheckForPrimeSimple_FutureINumberGeneric(565168463, 2, new List<int> { });

      // // Find a list of prime numbers for a very large integer
      // decimal num = 5954984651658495799; // 18 digit number

      // // decimal num = 999999;
      // string fileLocation = "C:\\Users\\ben.bowen_fox-pest\\CS_area\\practicing\\variousPractices\\CodeForVariousPractices\\BasicPractices\\RecordedInfoFiles\\PrimeList.txt";

      // Stopwatch watch = new();

      // watch.Start();
      // ConcurrentBag<int> primeList = recursion.ReturnPrimeList_FutureINumberGeneric(num, fileLocation, useLinq: true, new ConcurrentBag<int> { });
      // watch.Stop();
      // Console.WriteLine($"Input: {num}. Method: Parallel Linq. Time Elapsed: {watch.Elapsed}");
      // watch.Reset();

      // watch.Start();
      // ConcurrentBag<int> primeListing = recursion.ReturnPrimeList_FutureINumberGeneric(num, fileLocation, useLinq: false, new ConcurrentBag<int> { });
      // watch.Stop();
      // Console.WriteLine($"Input: {num}. Method: Foreach Loop. Time Elapsed: {watch.Elapsed}");
      // watch.Reset();

      // watch.Start();
      // List<int> newPrimeList = recursion.ReturnPrimeList_FutureINumberGeneric((long)num, fileLocation, new List<int> { });
      // watch.Stop();
      // Console.Write("{");
      // foreach (var item in newPrimeList)
      //    Console.Write($"{item}, ");
      // Console.Write("}" + $"\nInput: {num}. Method: {nameof(recursion.IsPrime)}. Time: elapsed: {watch.Elapsed}\n");
      // watch.Reset();

      // // New prime number finder
      // Int64 number = 8193;
      // Console.WriteLine($"Input: {number}. Result: {recursion.IsPrime(number)}");

      // Find the LCM GCD of two numbers
      int[] result = recursion.LcmAndGcdOfTwoNumbers(10, 15, 2, new int[2] { default, default });

      // Find the reversal of a given string
      string input = "w3resource";
      string expected = "ecruoser3w";
      string actual = recursion.ReverseInputString(input, "");

      Console.WriteLine($"Input: {input}. Expected output: {expected}. Actual output: {actual}");

      // Find the solution to Sudoku Puzzle
      string path = @"C:\Users\ben.bowen_fox-pest\CS_area\Portfolio\variousPractices\CodeForVariousPractices\SolveSudokuPuzzle\UnsolvedPuzzles\Puzzle1.csv";
      SudokuCsvReader reader = new SudokuCsvReader(path, emptyCell: "0", delimiter: ",");
      SudokuPuzzleSolver solver = new(reader.ReadBoard());


      // Place the solution in a csv file
      string solutionFile = @"C:\Users\ben.bowen_fox-pest\CS_area\Portfolio\variousPractices\CodeForVariousPractices\SolveSudokuPuzzle\SolvedPuzzles\SolutionToPuzzle1.csv";
      var array = solver.Solve();
      StringBuilder sb = new();
      foreach (var row in array)
      {
         for (var cell = 0; cell < row.Length; cell++)
         {
            sb.Append($"{row[cell].Value}");
            if (cell >= row.Length - 1)
               sb.Append(",");
         }
         sb.Append("\n");
      }
      File.WriteAllText(solutionFile, sb.ToString());
   }
}