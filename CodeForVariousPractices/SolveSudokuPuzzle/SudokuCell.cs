namespace CodeForVariousPracices.SolveSudokuPuzzle;

public class SudokuCell
{
   public SudokuCell(int value, int row, int column)
   {
      if (value < 0 || value > 9)
         throw new ArgumentException("Original puzzle contains invalid numbers.");

      if (value > 0)
      {
         Unchangeable = true;
         Changeable = false;
      }
      else
      {
         Unchangeable = false;
         Changeable = true;
      }

      Value = value;

      Row = row;
      Column = column;
   }
   public readonly bool Unchangeable;
   public readonly bool Changeable;
   public int Value { get; set; }

   public readonly int Row;
   public readonly int Column;

}