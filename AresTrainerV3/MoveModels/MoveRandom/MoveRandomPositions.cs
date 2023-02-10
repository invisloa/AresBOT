using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveRandom
{
    public class MoveRandomPositions
    {
        //
        // method route calculator to calculate distance needed to travel
        // method to transform distance into best route by goClickMethod
        // check what moves need to be made to go there
        // contains 1 main go to point
        // contains 1 point for set sub route which is generated when obstacle on road is met
        // check if obstacle will be on the road fo 4 moves forward
        // if obstacle is in those 4 moves forward set new move around route
        //


        public Tuple<int, int>[] MovePositionsArray =
        {
            new Tuple<int, int>(1290, 520),
            new Tuple<int, int>(1290, 460),
            new Tuple<int, int>(1260, 400),
            new Tuple<int, int>(1240, 350),
            new Tuple<int, int>(1210, 310),
            new Tuple<int, int>(1160, 260),
            new Tuple<int, int>(1110, 230),
            new Tuple<int, int>(1040, 210),
            new Tuple<int, int>(970, 200),
            new Tuple<int, int>(900, 205),
            new Tuple<int, int>(830, 230),
            new Tuple<int, int>(760, 260),
            new Tuple<int, int>(710, 300),
            new Tuple<int, int>(680, 350),
            new Tuple<int, int>(650, 400),
            new Tuple<int, int>(640, 450),
            new Tuple<int, int>(630, 520),
            new Tuple<int, int>(640, 580),
            new Tuple<int, int>(660, 640),
            new Tuple<int, int>(680, 690),
            new Tuple<int, int>(720, 730),
            new Tuple<int, int>(770, 770),
            new Tuple<int, int>(820, 800),
            new Tuple<int, int>(890, 820),
            new Tuple<int, int>(950, 830),
            new Tuple<int, int>(1020, 820),
            new Tuple<int, int>(1100, 800),
            new Tuple<int, int>(1150, 770),
            new Tuple<int, int>(1260, 640),
            new Tuple<int, int>(1240, 690),
            new Tuple<int, int>(1200, 730),
            new Tuple<int, int>(1280, 590),

        };

    }
}
