namespace CodeForVariousPracices.SolveSudokuPuzzle;

public class SudokuPuzzleSolver
{
   public SudokuPuzzleSolver(string fullLocationOfOriginalPuzzleInTextFileForm, char delimiter, string emptyCell)
   {
      // Assign column, row, and blocks to new arrays
      Column1 = new SudokuCell[9];
      Column2 = new SudokuCell[9];
      Column3 = new SudokuCell[9];
      Column4 = new SudokuCell[9];
      Column5 = new SudokuCell[9];
      Column6 = new SudokuCell[9];
      Column7 = new SudokuCell[9];
      Column8 = new SudokuCell[9];
      Column9 = new SudokuCell[9];
      AllColumns = new SudokuCell[][] { Column9, Column8, Column7, Column6, Column5, Column4, Column3, Column2, Column1 };

      Row1 = new SudokuCell[9];
      Row2 = new SudokuCell[9];
      Row3 = new SudokuCell[9];
      Row4 = new SudokuCell[9];
      Row5 = new SudokuCell[9];
      Row6 = new SudokuCell[9];
      Row7 = new SudokuCell[9];
      Row8 = new SudokuCell[9];
      Row9 = new SudokuCell[9];
      AllRows = new SudokuCell[][] { Row1, Row2, Row3, Row4, Row5, Row6, Row7, Row8, Row9 };

      TopLeft = new SudokuCell[9];
      TopMiddle = new SudokuCell[9];
      TopRight = new SudokuCell[9];
      MiddleLeft = new SudokuCell[9];
      MiddleMiddle = new SudokuCell[9];
      MiddleRight = new SudokuCell[9];
      BottomLeft = new SudokuCell[9];
      BottomMiddle = new SudokuCell[9];
      BottomRight = new SudokuCell[9];
      AllBlocks = new SudokuCell[][] { TopLeft, TopMiddle, TopRight, MiddleLeft, MiddleMiddle, MiddleRight, BottomLeft, BottomMiddle, BottomRight };

      // This exception is used more than once
      var ex = new ArgumentException($"The empty fields in the original file do not contain the correct value. Empty values must contain {emptyCell}");

      // Read original file
      string[] lines = File.ReadAllLines(fullLocationOfOriginalPuzzleInTextFileForm);

      // Iterate through each line
      for (int column = 0; column < lines.Length; column++)
      {
         // All row items are now contained in a string array
         string[] segment = lines[column].Split(delimiter);

         // Convert all row items into integers
         for (int row = 0; row < segment.Length; row++)
         {
            int value;
            bool parsed = int.TryParse(segment[row], out value);
            if (!parsed && segment[row] == emptyCell) // If the value is an empty cell value, then it is considered valid, even if it's not an integer
               value = 0;
            if (!parsed && segment[row] != emptyCell)
               throw ex;

            // Assign column, row, and block values
            switch (row)
            {
               case 0: // First column
                  SudokuCell cell0 = new(value, row, column);
                  Column1[column] = cell0;
                  AssignRows(ex, column, row, cell0);
                  AssignBlocksSwitch(ex, column, row, cell0);
                  break;
               case 1: // Second column
                  SudokuCell cell1 = new(value, row, column);
                  Column1[column] = cell1;
                  AssignRows(ex, column, row, cell1);
                  AssignBlocksSwitch(ex, column, row, cell1);
                  break;
               case 2: // Third column
                  SudokuCell cell2 = new(value, row, column);
                  Column1[column] = cell2;
                  AssignRows(ex, column, row, cell2);
                  AssignBlocksSwitch(ex, column, row, cell2);
                  break;
               case 3: // Fourth column
                  SudokuCell cell3 = new(value, row, column);
                  Column1[column] = cell3;
                  AssignRows(ex, column, row, cell3);
                  AssignBlocksSwitch(ex, column, row, cell3);
                  break;
               case 4: // Fifth column
                  SudokuCell cell4 = new(value, row, column);
                  Column1[column] = cell4;
                  AssignRows(ex, column, row, cell4);
                  AssignBlocksSwitch(ex, column, row, cell4);
                  break;
               case 5: // Sixth column
                  SudokuCell cell5 = new(value, row, column);
                  Column1[column] = cell5;
                  AssignRows(ex, column, row, cell5);
                  AssignBlocksSwitch(ex, column, row, cell5);
                  break;
               case 6: // Seventh column
                  SudokuCell cell6 = new(value, row, column);
                  Column1[column] = cell6;
                  AssignRows(ex, column, row, cell6);
                  AssignBlocksSwitch(ex, column, row, cell6);
                  break;
               case 7: // Eighth column
                  SudokuCell cell7 = new(value, row, column);
                  Column1[column] = cell7;
                  AssignRows(ex, column, row, cell7);
                  AssignBlocksSwitch(ex, column, row, cell7);
                  break;
               case 8: // Ninth column
                  SudokuCell cell8 = new(value, row, column);
                  Column1[column] = cell8;
                  AssignRows(ex, column, row, cell8);
                  AssignBlocksSwitch(ex, column, row, cell8);
                  break;

               default:
                  throw ex;
            }
         }
      }

   }
   private void AssignRows(ArgumentException ex, int column, int row, SudokuCell cell)
   {
      // Assign row values
      switch (column)
      {
         case 0: // First Row
            Row1[row] = cell;
            break;
         case 1: // Second Row
            Row2[row] = cell;
            break;
         case 2: // Third Row
            Row3[row] = cell;
            break;
         case 3: // Fourth Row
            Row1[row] = cell;
            break;
         case 4: // Fifth Row
            Row1[row] = cell;
            break;
         case 5: // Sixth Row
            Row1[row] = cell;
            break;
         case 6: // Seventh Row
            Row1[row] = cell;
            break;
         case 7: // Eighth Row
            Row1[row] = cell;
            break;
         case 8: // Ninth Row
            Row1[row] = cell;
            break;
         default:
            throw ex;
      }
   }
   private void AssignBlocksCool(ArgumentException ex, int column, int row, SudokuCell cell)
   {
      // Notice that the min and max numbers for both top and left, middle, and bottom and right are the same
      int[] top_OR_left = { 0, 2 };
      int[] middle = { 3, 5 };
      int[] bottom_OR_right = { 6, 8 };

      // Min and max values are established for the six types of cell positions
      bool topRow = row >= 0 && row <= 2;
      bool middleRow = row >= 3 && row <= 5;
      bool bottomRow = row >= 6 && row <= 8;
      bool leftColumn = column >= 0 && column <= 2;
      bool middleColumn = column >= 3 && column <= 5;
      bool rightColumn = column >= 6 && column <= 8;

      // Booleans are assigned for each of the nine cells
      bool topLeft = leftColumn && topRow;
      bool topMiddle = middleColumn && topRow;
      bool topRight = rightColumn && topRow;

      bool middleLeft = leftColumn && middleRow;
      bool middleMiddle = middleColumn && middleRow;
      bool middleRight = rightColumn && middleRow;

      bool bottomLeft = leftColumn && bottomRow;
      bool bottomMiddle = middleColumn && bottomRow;
      bool bottomRight = rightColumn && bottomRow;

      // The proper array index is assigned the proper/corresponding cell object,
      // based on that cell object's position
      if (topLeft)
      {
         int minRow = top_OR_left[0];
         int maxRow = top_OR_left[1];
         int minCol = top_OR_left[0];
         int maxCol = top_OR_left[1];
         AssignArray(TopLeft, row, column, minRow, maxRow, minCol, maxCol, cell);
      }
      else if (topMiddle)
      {
         int minRow = top_OR_left[0];
         int maxRow = top_OR_left[1];
         int minCol = middle[0];
         int maxCol = middle[1];
         AssignArray(TopMiddle, row, column, minRow, maxRow, minCol, maxCol, cell);
      }
      else if (topRight)
      {
         int minRow = top_OR_left[0];
         int maxRow = top_OR_left[1];
         int minCol = bottom_OR_right[0];
         int maxCol = bottom_OR_right[1];
         AssignArray(TopMiddle, row, column, minRow, maxRow, minCol, maxCol, cell);
      }
      else if (middleLeft)
      {
         int minRow = middle[0];
         int maxRow = middle[1];
         int minCol = top_OR_left[0];
         int maxCol = top_OR_left[1];
         AssignArray(TopMiddle, row, column, minRow, maxRow, minCol, maxCol, cell);
      }
      else if (middleMiddle)
      {
         int minRow = middle[0];
         int minCol = middle[0];
         int maxRow = middle[1];
         int maxCol = middle[1];
         AssignArray(MiddleMiddle, row, column, minRow, maxRow, minCol, maxCol, cell);
      }
      else if (middleRight)
      {
         int minRow = middle[0];
         int maxRow = middle[1];
         int mincol = bottom_OR_right[0];
         int maxCol = bottom_OR_right[1];
         AssignArray(MiddleRight, row, column, minRow, maxRow, mincol, maxCol, cell);
      }
      else if (bottomLeft)
      {
         int minRow = bottom_OR_right[0];
         int maxRow = bottom_OR_right[1];
         int minCol = top_OR_left[0];
         int maxCol = top_OR_left[1];
         AssignArray(BottomLeft, row, column, minRow, maxRow, minCol, maxCol, cell);
      }
      else if (bottomMiddle)
      {
         int minRow = bottom_OR_right[0];
         int maxRow = bottom_OR_right[1];
         int minCol = middle[0];
         int maxCol = middle[1];
         AssignArray(BottomMiddle, row, column, minRow, maxRow, minCol, maxCol, cell);
      }
      else if (bottomRight)
      {
         int minRow = bottom_OR_right[0];
         int maxRow = bottom_OR_right[1];
         int minCol = bottom_OR_right[0];
         int maxCol = bottom_OR_right[1];
         AssignArray(BottomRight, row, column, minRow, maxRow, minCol, maxCol, cell);
      }
   }
   private void AssignArray(SudokuCell[] array, int row, int column, int minRow, int maxRow, int minCol, int maxCol, SudokuCell cell)
   {
      // Establish the six cell types
      bool topRow = row == minRow;
      bool midRow = row > minRow && row < maxRow;
      bool botRow = row == maxRow;

      bool leftCol = column == minCol;
      bool midCol = column > minCol && column < maxCol;
      bool rightCol = column == maxCol;

      // Assign the nine cells
      bool topLeft = topRow && leftCol;
      bool topMiddle = topRow && midCol;
      bool topRight = topRow && rightCol;

      bool midLeft = midRow && leftCol;
      bool midMid = midRow && midCol;
      bool midRight = midRow && rightCol;

      bool botLeft = botRow && leftCol;
      bool botMid = botRow && midCol;
      bool botRight = botRow && rightCol;

      if (topLeft) // Top 
         array[0] = cell;
      else if (topMiddle)
         array[1] = cell;
      else if (topRight)
         array[2] = cell;
      else if (midLeft) // Middle
         array[3] = cell;
      else if (midMid)
         array[4] = cell;
      else if (midRight)
         array[5] = cell;
      else if (botLeft) // Bottom
         array[6] = cell;
      else if (botMid)
         array[7] = cell;
      else if (botRight)
         array[8] = cell;
   }
   private void AssignBlocksSwitch(ArgumentException ex, int column, int row, SudokuCell cell)
   {
      switch ((row, column))
      {
         // TopLeft
         case (0, 0):
            TopLeft[0] = cell;
            break;
         case (0, 1):
            TopLeft[1] = cell;
            break;
         case (0, 2):
            TopLeft[2] = cell;
            break;

         case (1, 0):
            TopLeft[3] = cell;
            break;
         case (1, 1):
            TopLeft[4] = cell;
            break;
         case (1, 2):
            TopLeft[5] = cell;
            break;

         case (2, 0):
            TopLeft[6] = cell;
            break;
         case (2, 1):
            TopLeft[7] = cell;
            break;
         case (2, 2):
            TopLeft[8] = cell;
            break;

         // TopMiddle
         case (0, 3):
            TopMiddle[0] = cell;
            break;
         case (0, 4):
            TopMiddle[1] = cell;
            break;
         case (0, 5):
            TopMiddle[2] = cell;
            break;

         case (1, 3):
            TopMiddle[3] = cell;
            break;
         case (1, 4):
            TopMiddle[4] = cell;
            break;
         case (1, 5):
            TopMiddle[5] = cell;
            break;

         case (2, 3):
            TopMiddle[6] = cell;
            break;
         case (2, 4):
            TopMiddle[7] = cell;
            break;
         case (2, 5):
            TopMiddle[8] = cell;
            break;

         // TopRight
         case (0, 6):
            TopRight[0] = cell;
            break;
         case (0, 7):
            TopRight[1] = cell;
            break;
         case (0, 8):
            TopRight[2] = cell;
            break;

         case (1, 6):
            TopRight[3] = cell;
            break;
         case (1, 7):
            TopRight[4] = cell;
            break;
         case (1, 8):
            TopRight[5] = cell;
            break;

         case (2, 6):
            TopRight[6] = cell;
            break;
         case (2, 7):
            TopRight[7] = cell;
            break;
         case (2, 8):
            TopRight[8] = cell;
            break;

         // MiddleLeft
         case (3, 0):
            MiddleLeft[0] = cell;
            break;
         case (3, 1):
            MiddleLeft[1] = cell;
            break;
         case (3, 2):
            MiddleLeft[2] = cell;
            break;

         case (4, 0):
            MiddleLeft[3] = cell;
            break;
         case (4, 1):
            MiddleLeft[4] = cell;
            break;
         case (4, 2):
            MiddleLeft[5] = cell;
            break;

         case (5, 0):
            MiddleLeft[6] = cell;
            break;
         case (5, 1):
            MiddleLeft[7] = cell;
            break;
         case (5, 2):
            MiddleLeft[8] = cell;
            break;

         // MiddleMiddle
         case (3, 3):
            MiddleMiddle[0] = cell;
            break;
         case (3, 4):
            MiddleMiddle[1] = cell;
            break;
         case (3, 5):
            MiddleMiddle[2] = cell;
            break;

         case (4, 3):
            MiddleMiddle[3] = cell;
            break;
         case (4, 4):
            MiddleMiddle[4] = cell;
            break;
         case (4, 5):
            MiddleMiddle[5] = cell;
            break;

         case (5, 3):
            MiddleMiddle[6] = cell;
            break;
         case (5, 4):
            MiddleMiddle[7] = cell;
            break;
         case (5, 5):
            MiddleMiddle[8] = cell;
            break;


         // MiddleRight
         case (3, 6):
            MiddleRight[0] = cell;
            break;
         case (3, 7):
            MiddleRight[1] = cell;
            break;
         case (3, 8):
            MiddleRight[2] = cell;
            break;

         case (4, 6):
            MiddleRight[3] = cell;
            break;
         case (4, 7):
            MiddleRight[4] = cell;
            break;
         case (4, 8):
            MiddleRight[5] = cell;
            break;

         case (5, 6):
            MiddleRight[6] = cell;
            break;
         case (5, 7):
            MiddleRight[7] = cell;
            break;
         case (5, 8):
            MiddleRight[8] = cell;
            break;

         // Bottom Left
         case (6, 0):
            BottomLeft[0] = cell;
            break;
         case (6, 1):
            BottomLeft[1] = cell;
            break;
         case (6, 2):
            BottomLeft[2] = cell;
            break;

         case (7, 0):
            BottomLeft[3] = cell;
            break;
         case (7, 1):
            BottomLeft[4] = cell;
            break;
         case (7, 2):
            BottomLeft[5] = cell;
            break;

         case (8, 0):
            BottomLeft[6] = cell;
            break;
         case (8, 1):
            BottomLeft[7] = cell;
            break;
         case (8, 2):
            BottomLeft[8] = cell;
            break;

         // BottomMiddle
         case (6, 3):
            BottomMiddle[0] = cell;
            break;
         case (6, 4):
            BottomMiddle[1] = cell;
            break;
         case (6, 5):
            BottomMiddle[2] = cell;
            break;

         case (7, 3):
            BottomMiddle[3] = cell;
            break;
         case (7, 4):
            BottomMiddle[4] = cell;
            break;
         case (7, 5):
            BottomMiddle[5] = cell;
            break;

         case (8, 3):
            BottomMiddle[6] = cell;
            break;
         case (8, 4):
            BottomMiddle[7] = cell;
            break;
         case (8, 5):
            BottomMiddle[8] = cell;
            break;

         // BottomRight
         case (6, 6):
            BottomRight[0] = cell;
            break;
         case (6, 7):
            BottomRight[1] = cell;
            break;
         case (6, 8):
            BottomRight[2] = cell;
            break;

         case (7, 6):
            BottomRight[3] = cell;
            break;
         case (7, 7):
            BottomRight[4] = cell;
            break;
         case (7, 8):
            BottomRight[5] = cell;
            break;

         case (8, 6):
            BottomRight[6] = cell;
            break;
         case (8, 7):
            BottomRight[7] = cell;
            break;
         case (8, 8):
            BottomRight[8] = cell;
            break;

         default:
            throw ex;
      }
   }

   public void Solve()
   { }

   public int DuplicateFound(bool foundDuplicates, SudokuCell[] array)
   {
      foreach (var value in array)
      {
         IEnumerable<SudokuCell> duplicates =
            from cell in array
            where cell.Value == value.Value
            select cell;
         int duplicateCount = duplicates.Count();
         if (duplicateCount > 1)
         {
            foreach (var dup in duplicates)
               return dup.Value;
         }
      }
      return 0;
   }

   public bool FoundDuplicates(SudokuCell[] array)
   {
      foreach (var value in array)
      {
         int number =
         (
            from cell in array
            where cell.Value == value.Value
            select cell
         ).Count();
         if (number > 1)
            return true;
      }
      return false;

   }

   public SudokuCell[] RemoveDuplicates(int duplicatedNumber, SudokuCell[] array)
   {
      foreach (var cell in array)
      {
         if (cell.Value == duplicatedNumber && !cell.Unchangeable)
            cell.Value = 0;
      }
      return array;
   }
   public SudokuCell[] GuessNewNumbers(SudokuCell[] array)
   {
      List<int> validValues = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      foreach (var cell in array)
      {
         if (cell.Unchangeable)
         {
            validValues.Remove(cell.Value);
            continue;
         }
         else if (cell.Value == 0)
         {
            int newVal = validValues[0];
            cell.Value = newVal;
            validValues.Remove(newVal);
         }
      }
      return array;
   }
   private SudokuCell[][] AllColumns { get; set; }
   private SudokuCell[][] AllRows { get; set; }
   private SudokuCell[][] AllBlocks { get; set; }

   private static SudokuCell[]? Column1 { get; set; }
   private static SudokuCell[]? Column2 { get; set; }
   private static SudokuCell[]? Column3 { get; set; }
   private static SudokuCell[]? Column4 { get; set; }
   private static SudokuCell[]? Column5 { get; set; }
   private static SudokuCell[]? Column6 { get; set; }
   private static SudokuCell[]? Column7 { get; set; }
   private static SudokuCell[]? Column8 { get; set; }
   private static SudokuCell[]? Column9 { get; set; }
   private static SudokuCell[]? Row1 { get; set; }
   private static SudokuCell[]? Row2 { get; set; }
   private static SudokuCell[]? Row3 { get; set; }
   private static SudokuCell[]? Row4 { get; set; }
   private static SudokuCell[]? Row5 { get; set; }
   private static SudokuCell[]? Row6 { get; set; }
   private static SudokuCell[]? Row7 { get; set; }
   private static SudokuCell[]? Row8 { get; set; }
   private static SudokuCell[]? Row9 { get; set; }
   private static SudokuCell[]? TopLeft { get; set; }
   private static SudokuCell[]? TopMiddle { get; set; }
   private static SudokuCell[]? TopRight { get; set; }
   private static SudokuCell[]? MiddleLeft { get; set; }
   private static SudokuCell[]? MiddleMiddle { get; set; }
   private static SudokuCell[]? MiddleRight { get; set; }
   private static SudokuCell[]? BottomLeft { get; set; }
   private static SudokuCell[]? BottomMiddle { get; set; }
   private static SudokuCell[]? BottomRight { get; set; }

}