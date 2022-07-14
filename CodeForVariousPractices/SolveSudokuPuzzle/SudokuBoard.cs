namespace CodeForVariousPracices.SolveSudokuPuzzle;

public record SetCellValue(int row, int column, int value);

public class SudokuBoard
{
   public SudokuBoard(SudokuCell[][] board)
   {
      // Assign each column, row, and block
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

   // Board Instantiation
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

      // Assign the block index to the cell so we don't have to go through this again
      int blockIndex = AllBlocks.ToList().IndexOf(array);
      cell.BlockIndex = blockIndex;
   }

   private IEnumerable<int> FindArrayValues(SudokuCell cell, bool column)
   {
      // Determine whether we're getting values from a row or column
      SudokuCell[] array;
      if (column)
         array = AllColumns[cell.Column];
      else
         array = AllRows[cell.Row];

      // Create a list of values from the sudoku cell array
      IEnumerable<int> arrayValues = array.Select(cell => cell.Value);
      return arrayValues;
   }


   // Board functionalities
   public SudokuCell FirstEmptyCell()
   {
      if (!HasEmptyCell())
         throw new Exception("Cannot find empty cell -- this board does not have empty cells.");

      foreach (var row in AllRows)
      {
         foreach (var cell in row)
         {
            if (cell.Value == 0)
               return cell;
         }
      }
      throw new Exception($"No empty cell could be found. Something is wrong with the {nameof(FirstEmptyCell)} method");
   }

   public List<SetCellValue> AllPossibleValues(SudokuCell cell)
   => new List<SetCellValue> {
      new SetCellValue(cell.Row, cell.Column, 1),
      new SetCellValue(cell.Row, cell.Column, 2),
      new SetCellValue(cell.Row, cell.Column, 3),
      new SetCellValue(cell.Row, cell.Column, 4),
      new SetCellValue(cell.Row, cell.Column, 5),
      new SetCellValue(cell.Row, cell.Column, 6),
      new SetCellValue(cell.Row, cell.Column, 7),
      new SetCellValue(cell.Row, cell.Column, 8),
      new SetCellValue(cell.Row, cell.Column, 9) };

   public bool HasEmptyCell()
   {
      foreach (var row in AllRows)
         if (row.Any((cell => cell.Value == 0)))
            return true;
      return false;
   }

   public bool IsValid()
   {
      if (HasEmptyCell() || HasRepeatedValues())
         return false;
      else
         return true;
   }

   public bool HasRepeatedValues()
   {
      foreach (var row in AllRows)
      {
         foreach (var cell in row)
         {
            // Find duplicates of the current cell value in the column
            var colDuplicates = AllColumns[cell.Column]
               .GroupBy(cell => cell.Value)
               .Where(g => g.Count() > 1)
               .Select(cell => cell.Key)
               .ToList();

            // Find duplicates of the current cell value in the block
            var blockDuplicates = AllBlocks[cell.BlockIndex]
               .GroupBy(cell => cell.Value)
               .Where(g => g.Count() > 1)
               .Select(cell => cell.Key)
               .ToList();

            if (colDuplicates.Count() > 0 || blockDuplicates.Count() > 0)
               return true;
         }
      }
      return false;
   }

   public SudokuBoard CloneBoard() => new SudokuBoard(AllRows);

   public void SetCellValue(SetCellValue value)
   => AllRows[value.row][value.column].Value = value.value;


   // Board values
   private IEnumerable<int> FindBlockValues(SudokuCell cell) => AllBlocks[cell.BlockIndex].Select(cell => cell.Value);
   public SudokuCell[][] AllColumns = new SudokuCell[][] { Column1!, Column2!, Column3!, Column4!, Column5!, Column6!, Column7!, Column8!, Column9! };
   public SudokuCell[][] AllRows = new SudokuCell[][] { Row1!, Row2!, Row3!, Row4!, Row5!, Row6!, Row7!, Row8!, Row9! };
   public SudokuCell[][] AllBlocks = new SudokuCell[][] { TopLeft!, TopMiddle!, TopRight!, MiddleLeft!, MiddleMiddle!, MiddleRight!, BottomLeft!, BottomMiddle!, BottomRight! };
   public static SudokuCell[]? Column1 = new SudokuCell[9];
   public static SudokuCell[]? Column2 = new SudokuCell[9];
   public static SudokuCell[]? Column3 = new SudokuCell[9];
   public static SudokuCell[]? Column4 = new SudokuCell[9];
   public static SudokuCell[]? Column5 = new SudokuCell[9];
   public static SudokuCell[]? Column6 = new SudokuCell[9];
   public static SudokuCell[]? Column7 = new SudokuCell[9];
   public static SudokuCell[]? Column8 = new SudokuCell[9];
   public static SudokuCell[]? Column9 = new SudokuCell[9];
   public static SudokuCell[]? Row1 = new SudokuCell[9];
   public static SudokuCell[]? Row2 = new SudokuCell[9];
   public static SudokuCell[]? Row3 = new SudokuCell[9];
   public static SudokuCell[]? Row4 = new SudokuCell[9];
   public static SudokuCell[]? Row5 = new SudokuCell[9];
   public static SudokuCell[]? Row6 = new SudokuCell[9];
   public static SudokuCell[]? Row7 = new SudokuCell[9];
   public static SudokuCell[]? Row8 = new SudokuCell[9];
   public static SudokuCell[]? Row9 = new SudokuCell[9];
   public static SudokuCell[]? TopLeft = new SudokuCell[9];
   public static SudokuCell[]? TopMiddle = new SudokuCell[9];
   public static SudokuCell[]? TopRight = new SudokuCell[9];
   public static SudokuCell[]? MiddleLeft = new SudokuCell[9];
   public static SudokuCell[]? MiddleMiddle = new SudokuCell[9];
   public static SudokuCell[]? MiddleRight = new SudokuCell[9];
   public static SudokuCell[]? BottomLeft = new SudokuCell[9];
   public static SudokuCell[]? BottomMiddle = new SudokuCell[9];
   public static SudokuCell[]? BottomRight = new SudokuCell[9];
}