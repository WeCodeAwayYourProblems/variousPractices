namespace CodeForVariousPracices.SolveSudokuPuzzle;

public class SudokuCell
{
   public SudokuCell(int value, int row, int column)
   {
      if (value < 0 || value > 9)
         throw new ArgumentException("Original puzzle contains invalid numbers.");

      if (value > 0)
         Unchangeable = true;
      else
         Unchangeable = false;

      Value = value;

      Row = row;
      Column = column;
   }
   public SudokuCell(int value, int row, int column, bool changeable)
   {
      if (value < 0 || value > 9)
         throw new ArgumentNullException("Original puzzle contains invalid numbers.");

      Value = value;
      Row = row;
      Column = column;
      Unchangeable = !changeable;
   }
   public readonly bool Unchangeable;
   public bool Changeable
   { get => !Unchangeable; }

   public int Value { get; set; }

   public readonly int Row;
   public readonly int Column;

}