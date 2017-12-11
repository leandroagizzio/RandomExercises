using System;
using System.Linq;

namespace Classes {

    //check common numbers in sorted and distinct arrays

    class CheckCommon {

        static int getCommon(int[] first, int[] second) {
            int total = 0;
            // 3 arrays to use, the active is the current one
            // passive is the one to be iterated, trocador to help swap
                                // get the size of the bigger array
            int[] active = new int[ first.Length > second.Length ? first.Length : second.Length];
            int[] passive = new int[active.Length];
            int[] auxiliar = new int[active.Length];
            // actual position on the original arrays
            int positionFirst = 0;
            int positionSecond = 0;
            // position in arrays that will be used
            int positionActive = 0;
            int positionPassive = 0;
            int positionAuxiliar = 0;
            // initializing with first as active
            active = first;
            passive = second;
            // if the active is the first
            bool isFirst = true;
            // while still inside both arrays
            while ((positionFirst < first.Length) && (positionSecond < second.Length)) {
                //Console.WriteLine(active[positionActive] +" - "+ passive[positionPassive]
                //     + " - " + positionFirst + " - " + positionSecond +" - " + positionActive +" - " + positionPassive +" - "  );
                
                // if active bigger or equal passive                
                if (active[positionActive] >= passive[positionPassive]) {
                    // if first is the active, the second will move to next element
                    if (isFirst)
                        positionSecond++;
                    else
                        positionFirst++;
                    // if they are equal we have a common
                    if (active[positionActive] == passive[positionPassive])
                        total++;
                    // points to next passive
                    positionPassive++;
                    continue;
                }

                // active smaller than passive
                // need to swap

                //swap arrays
                auxiliar = active;
                active = passive;
                passive = auxiliar;

                //swap positions and the active will be moved forward and become passive
                positionAuxiliar = positionActive + 1;
                positionActive = positionPassive;
                positionPassive = positionAuxiliar;

                // as arrays swapped, if first now is second, if second now is first
                isFirst = !isFirst;

                // move to next real element
                if (isFirst)
                    positionSecond++;
                else
                    positionFirst++;
            }
            return total;
        }

        static void Main(String[] args) {
            //string[] firstArray = "1 5 15 20 30 37".Split(' ');
            //string[] secondArray = "2 5 13 30 32 35 37 42".Split(' ');
            string[] firstArray = Console.ReadLine().Split(' ');
            string[] secondArray = Console.ReadLine().Split(' ');
            int[] first = Array.ConvertAll(firstArray, Int32.Parse);
            int[] second = Array.ConvertAll(secondArray, Int32.Parse);
            Console.WriteLine(getCommon(first.OrderBy(x => x).Distinct().ToArray(), 
                second.OrderBy(x => x).Distinct().ToArray()));
        }

    }
}
