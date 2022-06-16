using System.Collections.Concurrent;
using CodeForVariousPracices.BasicPractices;

namespace CodeForVariousPracices;
static class Program
{
   static void Main()
   {
      RecursionPractices recursion = new();
      bool returns = recursion.CheckForPrimeSimple_FutureINumberGeneric(565168463, 2, new List<int> { });

      // Find a list of prime numbers for a very large integer
      decimal num = 5954984651658495799; // 18 digit number
      ConcurrentBag<int> primeList = recursion.ReturnPrimeList_FutureINumberGeneric(num, "C:\\Users\\ben.bowen_fox-pest\\CS_area\\practicing\\variousPractices\\CodeForVariousPractices\\BasicPractices\\RecordedInfoFiles\\PrimeList.txt", new ConcurrentBag<int> { });
   }
}