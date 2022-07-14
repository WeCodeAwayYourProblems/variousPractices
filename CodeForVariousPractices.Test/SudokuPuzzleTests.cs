using Xunit;

namespace CodeForVariousPracices.SolveSudokuPuzzle.Test;

public class SudokuPuzzleTests
{
   private readonly SudokuCell[][] Board;
   private readonly SudokuPuzzleSolver Solver;
   private readonly SudokuCell[] Row1;
   private readonly SudokuCell[] Row2;
   private readonly SudokuCell[] Row3;
   private readonly SudokuCell[] Row4;
   private readonly SudokuCell[] Row5;
   private readonly SudokuCell[] Row6;
   private readonly SudokuCell[] Row7;
   private readonly SudokuCell[] Row8;
   private readonly SudokuCell[] Row9;
   public SudokuPuzzleTests()
   {
      // Instantiate rows
      Row1 = new SudokuCell[9];
      Row2 = new SudokuCell[9];
      Row3 = new SudokuCell[9];
      Row4 = new SudokuCell[9];
      Row5 = new SudokuCell[9];
      Row6 = new SudokuCell[9];
      Row7 = new SudokuCell[9];
      Row8 = new SudokuCell[9];
      Row9 = new SudokuCell[9];

      // Generate random values for the board
      List<SudokuCell> sudokulist = new();
      Random rand = new();
      for (int row = 0; row < 9; row++)
         for (int column = 0; column < 9; column++)
            sudokulist.Add(new SudokuCell(rand.Next(0, 10), row, column, changeable: true));

      // Instantiate the board
      Board = new SudokuCell[][]
      {
         Row1,Row2,Row3,Row4,Row5,Row6,Row7,Row8,Row9
      };

      // Assign values to the baord
      foreach (var cell in sudokulist)
         Board[cell.Row][cell.Column] = cell;

      // Instantiate the solver
      Solver = new();
   }

   // Reusable code
   private SudokuCell[] ConvertIntegerArrayIntoSudokuCellArray(int[] input)
   {
      // Convert the input array into a sudoku cell array
      List<SudokuCell> sudokucellsList = new();
      int row = 0;
      int column = 0;
      foreach (var integer in input)
      {
         sudokucellsList.Add(new SudokuCell(integer, row, column, changeable: true));
         column++;
      }

      // Convert the sudoku cell list into an array
      SudokuCell[] sudokuCellsArray = sudokucellsList.ToArray();
      return sudokuCellsArray;
   }
   private static List<int> ConvertSudokuCellArrayToListOfInt(SudokuCell[] withoutDuplicates)
   {
      List<int> values = new();
      foreach (var cell in withoutDuplicates)
         values.Add(cell.Value);
      return values;
   }
}