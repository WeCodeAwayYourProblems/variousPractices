using CodeForVariousPracices.BasicPractices;

namespace CodeForVariousPracices;
static class Program
{
   static void Main()
   {
      RecursionPractices recursion = new();
      bool returns = recursion.CheckForPrimeSimple_FutureINumberGeneric(565168463, 2, new List<int> { });
   }
}