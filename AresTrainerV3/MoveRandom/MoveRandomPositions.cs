using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveRandom
{
    public class MoveRandomPositions
    {
		/*
	write program in c#
	character starts from x= 0, y = 0 point on a x/y axis platform;
	Tuple int,int centerpoint 960,520 - this is the mouse position that always points on the character which is always in the center of the screen,
	position of this point is not changing, its constant, character moves on x/y axis but on a different platform;
	every mouse move from centrepoint by +100 pixels makes move in platform in x axis +4;
	every mouse move from centrepoint by -100 pixels makes move in platform in x axis -4;
	every mouse move from centrepoint by +100 pixels makes move in platform in y axis +4;
	every mouse move from centrepoint by +100 pixels makes move in platform in y axis -4;
	mouse moves from centrepoint can vary from 100 pixels to 300 in any direction;
	move by +100 makes move in any axis  position by +4, +200 by +8, +300 by +12;
	moves can also be made like 1060,720 -this will me position by +8 in x axis and +8 in y axis
	minimum move radius is 100 pixels in any axis,
	maximum move radius is 300 pixels in any axis

	make a method that calculates the mouse moves sequence to reach destination point 

*/
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
