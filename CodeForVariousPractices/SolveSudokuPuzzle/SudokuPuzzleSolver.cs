namespace CodeForVariousPracices.SolveSudokuPuzzle;

public class SudokuPuzzleSolver
{
   public SudokuPuzzleSolver(SudokuCell[][] board)
   {
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
            GuessNewNumbers(array);

         // Check for duplicates in all the columns
         bool duplicates = false;
         foreach (var array in AllColumns)
            duplicates = DuplicatesWereFoundAndRemoved(duplicates, array);

         // Check for duplicates in all the blocks
         foreach (var array in AllBlocks)
            duplicates = DuplicatesWereFoundAndRemoved(duplicates, array);
         if (duplicates)
            continue;

         // If we've reached this point, no duplicates have been found
         solved = true;
      }
      return AllRows;

      bool DuplicatesWereFoundAndRemoved(bool duplicates, SudokuCell[] array)
      {
         if (FoundDuplicates(array))
         {
            RemoveDuplicates(array);
            duplicates = true;
         }

         return duplicates;
      }
   }

   public int[] DuplicateFound(SudokuCell[] array)
   {
      // Find all duplicates
      List<int> cellList = array.GroupBy(x => x.Value)
         .Where(g => g.Count() > 1)
         .Select(y => y.Key)
         .ToList();

      // Remove 0 from the list
      if (cellList.Contains(0))
         cellList.Remove(0);

      return cellList.ToArray();
   }
   public bool FoundDuplicates(SudokuCell[] array)
   {
      // Find all duplicates
      int[] duplicates = DuplicateFound(array);

      // If there are any duplicates, return true
      if (duplicates.Length > 0)
         return true;
      return false;
   }

   public SudokuCell[] RemoveDuplicates(int[] duplicatedNumber, SudokuCell[] array)
   {
      foreach (var duplicate in duplicatedNumber)
         foreach (var cell in array)
            if (cell.Value == duplicate && cell.Changeable)
               cell.Value = 0;
      return array;
   }

   public SudokuCell[] RemoveDuplicates(SudokuCell[] array) =>
      RemoveDuplicates(DuplicateFound(array), array);
   public SudokuCell[] GuessNewNumbers(SudokuCell[] array)
   {
      List<int> validValues = new(9) { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

      // Remove any permanent values from the list of valid values
      foreach (var cell in array)
         if (cell.Unchangeable)
            validValues.Remove(cell.Value);

      // Assign new values for any empty cells
      // ... without duplicating values in columns or blocks
      foreach (var cell in array)
      {
         IEnumerable<int> columnValues = FindColumnValues(cell);
         IEnumerable<int> blockValues = FindBlockValues(cell);

         // Add the new value to the current cell
         if (cell.Value == 0)
         {
            // Set the new value for the cell
            int newVal = validValues[0];

            // Prevent cell value duplication
            // ... by checking the columns and blocks for the new value
            foreach (var value in validValues)
            {
               if (columnValues.Contains(value) || blockValues.Contains(value))
                  continue;

               newVal = value;
               break;
            }
            cell.Value = newVal;
            validValues.Remove(newVal);
         }
      }

      return array;
   }

   private List<int> FindColumnValues(SudokuCell cell)
   {
      var columnArray = AllColumns[cell.Column];
      List<int> columnArrayValues = new();
      foreach (var item in columnArray)
         columnArrayValues.Add(item.Value);
      return columnArrayValues;
   }

   private List<int> FindBlockValues(SudokuCell cell)
   {
      // Determine which block the current cell is in
      int index = -1;
      for (var i = 0; i < AllBlocks.Length; i++)
      {
         if (AllBlocks[i].Contains(cell))
         {
            index = i;
            break;
         }
      }
      // Convert the cell array to an int array
      List<int> returnArray = new();
      foreach (var item in AllBlocks[index])
         returnArray.Add(item.Value);

      return returnArray;
   }

   private SudokuCell[][] AllColumns = new SudokuCell[][] { Column1!, Column2!, Column3!, Column4!, Column5!, Column6!, Column7!, Column8!, Column9! };
   private SudokuCell[][] AllRows = new SudokuCell[][] { Row1!, Row2!, Row3!, Row4!, Row5!, Row6!, Row7!, Row8!, Row9! };
   private SudokuCell[][] AllBlocks = new SudokuCell[][] { TopLeft!, TopMiddle!, TopRight!, MiddleLeft!, MiddleMiddle!, MiddleRight!, BottomLeft!, BottomMiddle!, BottomRight! };

   private static SudokuCell[]? Column1 = new SudokuCell[9];
   private static SudokuCell[]? Column2 = new SudokuCell[9];
   private static SudokuCell[]? Column3 = new SudokuCell[9];
   private static SudokuCell[]? Column4 = new SudokuCell[9];
   private static SudokuCell[]? Column5 = new SudokuCell[9];
   private static SudokuCell[]? Column6 = new SudokuCell[9];
   private static SudokuCell[]? Column7 = new SudokuCell[9];
   private static SudokuCell[]? Column8 = new SudokuCell[9];
   private static SudokuCell[]? Column9 = new SudokuCell[9];
   private static SudokuCell[]? Row1 = new SudokuCell[9];
   private static SudokuCell[]? Row2 = new SudokuCell[9];
   private static SudokuCell[]? Row3 = new SudokuCell[9];
   private static SudokuCell[]? Row4 = new SudokuCell[9];
   private static SudokuCell[]? Row5 = new SudokuCell[9];
   private static SudokuCell[]? Row6 = new SudokuCell[9];
   private static SudokuCell[]? Row7 = new SudokuCell[9];
   private static SudokuCell[]? Row8 = new SudokuCell[9];
   private static SudokuCell[]? Row9 = new SudokuCell[9];
   private static SudokuCell[]? TopLeft = new SudokuCell[9];
   private static SudokuCell[]? TopMiddle = new SudokuCell[9];
   private static SudokuCell[]? TopRight = new SudokuCell[9];
   private static SudokuCell[]? MiddleLeft = new SudokuCell[9];
   private static SudokuCell[]? MiddleMiddle = new SudokuCell[9];
   private static SudokuCell[]? MiddleRight = new SudokuCell[9];
   private static SudokuCell[]? BottomLeft = new SudokuCell[9];
   private static SudokuCell[]? BottomMiddle = new SudokuCell[9];
   private static SudokuCell[]? BottomRight = new SudokuCell[9];

}