using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3
{
    public static class ExpBotMovePositions
    {
        public static Tuple<int, int>[] mousePositionsForHershalBuying = new Tuple<int, int>[]
        {
                    new Tuple<int, int>(995, 375),  //mana pot
                    new Tuple<int, int>(995, 450),  //red pot
                    new Tuple<int, int>(995, 415),  //white pot
                    new Tuple<int, int>(995, 225)   //hp yarrow pot
        };
                public static Tuple<int, int>[] HershalMovePositions = new Tuple<int, int>[]
        {
                    new Tuple<int, int>(523, 471),
                    new Tuple<int, int>(504, 677),
                    new Tuple<int, int>(654, 805),
                    new Tuple<int, int>(789, 748),
        };

        public static Tuple<int, int>[] UWCFirstFloorMovement = new  Tuple<int, int>[]
        {
                    new Tuple<int, int>(600, 520),
                    new Tuple<int, int>(960, 300),
                    new Tuple<int, int>(1250, 520),
                    new Tuple<int, int>(960, 620),
        };


}
}
