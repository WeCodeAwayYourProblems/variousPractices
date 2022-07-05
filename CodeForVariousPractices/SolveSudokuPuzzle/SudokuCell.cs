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
   public readonly bool Unchangeable;
   public bool Changeable
   { get => !Unchangeable; }

   public int Value { get; set; }

   public readonly int Row;
   public readonly int Column;

}