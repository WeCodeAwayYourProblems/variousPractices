using Xunit;

namespace CodeForVariousPracices.SolveSudokuPuzzle.Test;

public class SudokuPuzzleTests
{
   private SudokuCell[][] Board;
   private SudokuPuzzleSolver Solver;
   private SudokuCell[] Row1;
   private SudokuCell[] Row2;
   private SudokuCell[] Row3;
   private SudokuCell[] Row4;
   private SudokuCell[] Row5;
   private SudokuCell[] Row6;
   private SudokuCell[] Row7;
   private SudokuCell[] Row8;
   private SudokuCell[] Row9;
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
      Solver = new(Board);
   }

   [
      Theory,
      InlineData(new int[9] { 9, 9, 4, 5, 7, 7, 8, 0, 0 }, new int[] { 9, 7 }, new int[9] { 0, 0, 4, 5, 0, 0, 8, 0, 0 })
   ]
   public void RemoveDuplicatesMethod_ReturnsAnArrayWithoutDuplicates(int[] input, int[] duplicates, int[] expected)
   {
      SudokuCell[] sudokuCellsArray = ConvertIntegerArrayIntoSudokuCellArray(input);

      // Remove Duplicates
      SudokuCell[] withoutDuplicates = Solver.RemoveDuplicates(duplicates, sudokuCellsArray);

      // Convert the duplicates to an integer array
      List<int> values = ConvertSudokuCellArrayToListOfInt(withoutDuplicates);

      int[] actual = values.ToArray();

      // Assertions
      Assert.Equal(expected, actual);
   }
   [
      Theory,
      InlineData(new int[9] { 9, 9, 4, 5, 7, 7, 8, 0, 0 }, new int[9] { 0, 0, 4, 5, 0, 0, 8, 0, 0 })
   ]
   public void RemoveDuplicatesMethodOverload_ReturnsAnArrayWithoutDuplicates(int[] input, int[] expected)
   {
      var cellsArray = ConvertIntegerArrayIntoSudokuCellArray(input);

      // remove Duplicates
      var noDuplicates = Solver.RemoveDuplicates(cellsArray);

      // Convert duplicates to integer array
      int[] actual = ConvertSudokuCellArrayToListOfInt(noDuplicates).ToArray();

      // Assertions
      Assert.Equal(expected, actual);
   }


   [
      Theory,
      InlineData(new int[9] { 0, 0, 0, 7, 8, 7, 9, 9, 9 }, new int[2] { 7, 9 })
   ]
   public void FindDuplicatesMethod_ReturnsArray(int[] input, int[] expected)
   {
      // Convert input to an array of sudoku cells
      SudokuCell[] sudokuCellArray = ConvertIntegerArrayIntoSudokuCellArray(input);

      // Find duplicates
      int[] actual = Solver.DuplicateFound(sudokuCellArray);

      // Assertions
      Assert.Equal(expected, actual);
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