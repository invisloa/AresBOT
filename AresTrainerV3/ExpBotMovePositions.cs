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
                 //   new Tuple<int, int>(995, 375),  //mana pot (L)
                    new Tuple<int, int>(995, 305),  //mana pot (S)
                    new Tuple<int, int>(995, 450),  //red pot
                    new Tuple<int, int>(995, 415),  //white pot
                    new Tuple<int, int>(995, 185),  //hp pot Hysop

                    // new Tuple<int, int>(995, 225)   //hp yarrow pot
        };
        public static Tuple<int, int>[] mousePositionsForKharonBuying = new Tuple<int, int>[]
        {
                    new Tuple<int, int>(995, 305),  //mana pot
                    new Tuple<int, int>(995, 420),  //red pot
                    new Tuple<int, int>(995, 380),  //white pot
                    new Tuple<int, int>(995, 185)   //hp yarrow pot
        };
        public static Tuple<int, int>[] HershalRepotMovePositions = new Tuple<int, int>[]
        {
                    new Tuple<int, int>(523, 471),
                    new Tuple<int, int>(504, 677),
                    new Tuple<int, int>(654, 805),
                    new Tuple<int, int>(789, 748),
        };

        public static Tuple<int, int>[] KharonRepotMovePositions = new Tuple<int, int>[]
{
                    new Tuple<int, int>(1250, 170),
                    new Tuple<int, int>(1250, 170),
                    new Tuple<int, int>(920, 345),
};



        public static Tuple<int, int>[] UWCFirstFloorMovement = new  Tuple<int, int>[]
        {
                    new Tuple<int, int>(600, 520),
                    new Tuple<int, int>(960, 300),
                    new Tuple<int, int>(1250, 520),
                    new Tuple<int, int>(960, 620),
        };

        public const int firstColumnInventory  = 1260; // every next row is +35
        public const int firstRowInventory = 530; // every next column is +35;

        public static Tuple<int, int>[] itemSellPositions = new Tuple<int, int>[72];

    }
}
