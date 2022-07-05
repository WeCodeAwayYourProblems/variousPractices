namespace CodeForVariousPracices.SolveSudokuPuzzle;

public class SudokuPuzzleSolver
{
   public SudokuPuzzleSolver(SudokuCell[][] board)
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
      AllColumns = new SudokuCell[][] { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9 };

      Row1 = new SudokuCell[9];
      Row2 = new SudokuCell[9];
      Row3 = new SudokuCell[9];
      Row4 = new SudokuCell[9];
      Row5 = new SudokuCell[9];
      Row6 = new SudokuCell[9];
      Row7 = new SudokuCell[9];
      Row8 = new SudokuCell[9];
      Row9 = new SudokuCell[9];
      AllRows = new SudokuCell[][]
      {
         Row1, Row2, Row3, Row4, Row5, Row6, Row7, Row8, Row9
      };

      TopLeft = new SudokuCell[9];
      TopMiddle = new SudokuCell[9];
      TopRight = new SudokuCell[9];
      MiddleLeft = new SudokuCell[9];
      MiddleMiddle = new SudokuCell[9];
      MiddleRight = new SudokuCell[9];
      BottomLeft = new SudokuCell[9];
      BottomMiddle = new SudokuCell[9];
      BottomRight = new SudokuCell[9];
      AllBlocks = new SudokuCell[][]
      {
         TopLeft, TopMiddle, TopRight, MiddleLeft, MiddleMiddle, MiddleRight, BottomLeft, BottomMiddle, BottomRight
      };

      // // Iterate through the puzzle board
      // for (var row = 0; row < board.Length; row++)
      //    AllRows[row] = board[row];

      // Assign each column 
      foreach (var array in board)
      {
         foreach (var cell in array)
         {
            // Assign columns
            AllColumns[cell.Column][cell.Row] = cell;

            // Assign Rows
            AllRows[cell.Row][cell.Column] = cell;

            // Assign blocks
            AssignBlocks(cell);
         }
      }
   }
   private void AssignBlocks(SudokuCell cell)
   {
      // Determine which block this cell belongs in, based on its row and column

      // Min and max values of a single block are established for the six types of cell positions
      bool topRow = cell.Row >= 0 && cell.Row <= 2;
      bool middleRow = cell.Row >= 3 && cell.Row <= 5;
      bool bottomRow = cell.Row >= 6 && cell.Row <= 8;
      bool leftColumn = cell.Column >= 0 && cell.Column <= 2;
      bool middleColumn = cell.Column >= 3 && cell.Column <= 5;
      bool rightColumn = cell.Column >= 6 && cell.Column <= 8;

      // Notice that the min and max numbers for top and left, middle, and bottom and right are the same
      int[] top_OR_left = { 0, 2 };
      int[] middle = { 3, 5 };
      int[] bottom_OR_right = { 6, 8 };

      // Booleans are assigned for each of the nine cells in a block
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
         AssignArray(TopLeft!, minRow, maxRow, minCol, maxCol, cell);
      }
      else if (topMiddle)
      {
         int minRow = top_OR_left[0];
         int maxRow = top_OR_left[1];
         int minCol = middle[0];
         int maxCol = middle[1];
         AssignArray(TopMiddle!, minRow, maxRow, minCol, maxCol, cell);
      }
      else if (topRight)
      {
         int minRow = top_OR_left[0];
         int maxRow = top_OR_left[1];
         int minCol = bottom_OR_right[0];
         int maxCol = bottom_OR_right[1];
         AssignArray(TopRight!, minRow, maxRow, minCol, maxCol, cell);
      }
      else if (middleLeft)
      {
         int minRow = middle[0];
         int maxRow = middle[1];
         int minCol = top_OR_left[0];
         int maxCol = top_OR_left[1];
         AssignArray(MiddleLeft!, minRow, maxRow, minCol, maxCol, cell);
      }
      else if (middleMiddle)
      {
         int minRow = middle[0];
         int minCol = middle[0];
         int maxRow = middle[1];
         int maxCol = middle[1];
         AssignArray(MiddleMiddle!, minRow, maxRow, minCol, maxCol, cell);
      }
      else if (middleRight)
      {
         int minRow = middle[0];
         int maxRow = middle[1];
         int mincol = bottom_OR_right[0];
         int maxCol = bottom_OR_right[1];
         AssignArray(MiddleRight!, minRow, maxRow, mincol, maxCol, cell);
      }
      else if (bottomLeft)
      {
         int minRow = bottom_OR_right[0];
         int maxRow = bottom_OR_right[1];
         int minCol = top_OR_left[0];
         int maxCol = top_OR_left[1];
         AssignArray(BottomLeft!, minRow, maxRow, minCol, maxCol, cell);
      }
      else if (bottomMiddle)
      {
         int minRow = bottom_OR_right[0];
         int maxRow = bottom_OR_right[1];
         int minCol = middle[0];
         int maxCol = middle[1];
         AssignArray(BottomMiddle!, minRow, maxRow, minCol, maxCol, cell);
      }
      else if (bottomRight)
      {
         int minRow = bottom_OR_right[0];
         int maxRow = bottom_OR_right[1];
         int minCol = bottom_OR_right[0];
         int maxCol = bottom_OR_right[1];
         AssignArray(BottomRight!, minRow, maxRow, minCol, maxCol, cell);
      }
   }
   private void AssignArray(SudokuCell[] array, int minRow, int maxRow, int minCol, int maxCol, SudokuCell cell)
   {
      // Establish the six cell types
      bool topRow = cell.Row == minRow;
      bool midRow = cell.Row > minRow && cell.Row < maxRow;
      bool botRow = cell.Row == maxRow;

      bool leftCol = cell.Column == minCol;
      bool midCol = cell.Column > minCol && cell.Column < maxCol;
      bool rightCol = cell.Column == maxCol;

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

      List<bool> position = new()
      {
         topLeft,topMiddle,topRight,midLeft,midMid,midRight,botLeft,botMid,botRight
      };
      int index = position.FindIndex(boolean => boolean);

      array[index] = cell;
   }


   public SudokuCell[][] Solve()
   {
      bool solved = false;
      while (!solved)
      {
         // Guess numbers for all rows of sudoku table
         foreach (var array in AllRows)
         { GuessNewNumbers(array); }

         // Check for duplicates in all the columns
         bool duplicates = false;
         foreach (var array in AllColumns)
         {
            int[] value = DuplicateFound(array);
            if (value.Length > 0)
            {
               RemoveDuplicates(value, array);
               duplicates = true;
            }
         }

         // Check for duplicates in all the blocks
         foreach (var array in AllBlocks)
         {
            int[] value = DuplicateFound(array);
            if (value.Length > 1)
            {
               RemoveDuplicates(value, array);
               duplicates = true;
            }
         }
         if (duplicates)
            continue;

         // If we've reached this point, no duplicates have been found
         solved = true;
      }
      return AllRows;
   }

   public int[] DuplicateFound(SudokuCell[] array)
   {
      int[] cellArray = array.GroupBy(x => x.Value)
         .Where(g => g.Count() > 1)
         .Select(y => y.Key)
         .ToArray();
      return cellArray;
   }

   public SudokuCell[] RemoveDuplicates(int[] duplicatedNumber, SudokuCell[] array)
   {
      foreach (var duplicate in duplicatedNumber)
      {
         int found = 0;
         foreach (var cell in array)
         {
            if (duplicate == cell.Value && found == 0)
            {
               found++;
               continue;
            }
            // Revert every cell that is contained in
            if (duplicatedNumber.Contains(cell.Value) && cell.Changeable)
               cell.Value = 0;
         }
      }
      return array;
   }
   public SudokuCell[] GuessNewNumbers(SudokuCell[] array)
   {
      List<int> validValues = new(9) { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      foreach (var cell in array)
      {
         if (cell.Unchangeable)
         {
            validValues.Remove(cell.Value);
            continue;
         }
      }
      foreach (var cell in array)
      {
         if (cell.Value == 0)
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