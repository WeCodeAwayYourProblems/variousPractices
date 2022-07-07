namespace CodeForVariousPracices.SolveSudokuPuzzle;

public class SudokuCsvReader : ISudokuBoardReader
{
   private readonly string PuzzleDoc;
   private readonly string EmptyCell;
   private readonly string Delimiter;

   public SudokuCsvReader(string fullLocationOfOriginalPuzzleDotCsv, string emptyCell, string delimiter)
   {
      // Assign Fields
      PuzzleDoc = fullLocationOfOriginalPuzzleDotCsv;
      Delimiter = delimiter;
      EmptyCell = emptyCell;
   }
   public SudokuCell[][] ReadBoard()
   {
      // Instantiate the nine rows of SudokuCell arrays
      SudokuCell[] row1 = new SudokuCell[9];
      SudokuCell[] row2 = new SudokuCell[9];
      SudokuCell[] row3 = new SudokuCell[9];
      SudokuCell[] row4 = new SudokuCell[9];
      SudokuCell[] row5 = new SudokuCell[9];
      SudokuCell[] row6 = new SudokuCell[9];
      SudokuCell[] row7 = new SudokuCell[9];
      SudokuCell[] row8 = new SudokuCell[9];
      SudokuCell[] row9 = new SudokuCell[9];
      SudokuCell[][] returnArray = new SudokuCell[][]
      {
         row1, row2, row3, row4, row5, row6, row7, row8, row9
      };

      // This exception is used more than once
      var ex = new ArgumentException($"The empty fields in the original puzzle file do not contain the correct value. Empty values must contain {EmptyCell} and nothing else. \"{EmptyCell}\" must be surrounded by the delimiter: {Delimiter}.");

      // Read original file
      string[] lines = File.ReadAllLines(PuzzleDoc);

      // Iterate through each row
      for (int row = 0; row < lines.Length; row++)
      {
         // All row items are now contained in a string array
         string[] line = lines[row].Split(Delimiter);

         // Convert all row items into integers
         for (int column = 0; column < line.Length; column++)
         {
            // Parse the row item into an integer
            int value;
            bool parsed = int.TryParse(line[column], out value);

            // If the value is an empty cell value, then it is considered valid automatically
            if (line[column] == EmptyCell)
               value = 0;

            // If the value is not parsed, and the value is not the empty cell value, then throw an error 
            // because the original puzzle was not written correctly
            if (!parsed && line[column] != EmptyCell)
               throw ex;

            // Assign values
            switch (row)
            {
               case 0:// First Row
                  row1[column] = new SudokuCell(value, row, column);
                  break;
               case 1:// 2 Row
                  row2[column] = new SudokuCell(value, row, column);
                  break;
               case 2:// 3 Row
                  row3[column] = new SudokuCell(value, row, column);
                  break;
               case 3:// 4 Row
                  row4[column] = new SudokuCell(value, row, column);
                  break;
               case 4:// 5 Row
                  row5[column] = new SudokuCell(value, row, column);
                  break;
               case 5:// 6 Row
                  row6[column] = new SudokuCell(value, row, column);
                  break;
               case 6:// 7 Row
                  row7[column] = new SudokuCell(value, row, column);
                  break;
               case 7:// 8 Row
                  row8[column] = new SudokuCell(value, row, column);
                  break;
               case 8:// 9 Row
                  row9[column] = new SudokuCell(value, row, column);
                  break;
               default:
                  throw ex;
            }
         }
      }

      return returnArray;
   }
}