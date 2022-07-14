namespace CodeForVariousPracices.SolveSudokuPuzzle;

public class SudokuPuzzleSolver
{
   public SudokuBoard Solve(SudokuBoard board)
   {
      Queue<SudokuBoard> allPossibleBoards = new();
      allPossibleBoards.Enqueue(board);

      // Find solution
      bool solved = false;
      while (!solved)
      {
         SudokuBoard currentBoard;
         bool notEmpty = allPossibleBoards.TryDequeue(out currentBoard!);
         if (!notEmpty)
            break;
         if (currentBoard.HasEmptyCell())
         {
            List<SetCellValue> possibleValues = currentBoard.AllPossibleValues(currentBoard.FirstEmptyCell());
            foreach (var option in possibleValues)
            {
               SudokuBoard newBoard = currentBoard.CloneBoard();
               newBoard.SetCellValue(option);
               allPossibleBoards.Enqueue(newBoard);
            }
            continue;
         }
         if (currentBoard.IsValid())
            return currentBoard;
      }
      throw new Exception($"{nameof(Solve)} didn't work. Solution could not be found.");
   }
}