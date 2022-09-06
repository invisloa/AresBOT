using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MovePositions
{
    public struct TupleMousePos
    {
            public Tuple<int, int> MoveDown
            {
                get { return new Tuple<int, int>(960, 730); }
            }
            public Tuple<int, int> MoveUp
            {
                get { return new Tuple<int, int>(960, 310); }
            }
            public Tuple<int, int> MoveLeft
            {
                get { return new Tuple<int, int>(670, 520); }
            }
            public Tuple<int, int> MoveRight
            {
                get { return new Tuple<int, int>(1220, 520); }
            }

            public Tuple<int, int> sideMoveDownGoLeft
            {
                get { return new Tuple<int, int>(0, 0); }
            }
            public Tuple<int, int> sideMoveUpGoLeft
        {
                get { return new Tuple<int, int>(0, 0); }
            }
            public Tuple<int, int> sideMoveLeftGoUp
            {
                get { return new Tuple<int, int>(0, 0); }
            }
            public Tuple<int, int> sideMoveRightGoUp
            {
                get { return new Tuple<int, int>(0, 0); }
            }
            public Tuple<int, int> sideMoveDownGoRight
            {
                get { return new Tuple<int, int>(0, 0); }
            }
            public Tuple<int, int> sideMoveUpGoRight
            {
                get { return new Tuple<int, int>(0, 0); }
            }
            public Tuple<int, int> sideMoveLeftGoDown
            {
                get { return new Tuple<int, int>(0, 0); }
            }
            public Tuple<int, int> sideMoveRightGoDown
            {
                get { return new Tuple<int, int>(0, 0); }
            }

    }
}

