using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MovePositions
{
    public static class TupleMousePos
    {
        public static Tuple<int, int> MoveDown
        {
            get { return new Tuple<int, int>(960, 525 + 235); }
        }
        public static Tuple<int, int> MoveUp
        {
            get { return new Tuple<int, int>(960, 525 - 270); }
        }
        public static Tuple<int, int> MoveLeft
        {
            get { return new Tuple<int, int>(960 - 270, 525); }
        }
        public static Tuple<int, int> MoveRight
        {
            get { return new Tuple<int, int>(960 + 270, 525); }
        }
        public static Tuple<int, int> SideMoveDown
        {
            get { return new Tuple<int, int>(960, 525 + 180); }
        }
        public static Tuple<int, int> SideMoveUp
        {
            get { return new Tuple<int, int>(960, 525 - 180); }
        }
        public static Tuple<int, int> SideMoveLeft
        {
            get { return new Tuple<int, int>(960 - 180, 525); }
        }
        public static Tuple<int, int> SideMoveRight
        {
            get { return new Tuple<int, int>(960 + 180, 525); }
        }

        /*            public Tuple<int, int> sideMoveDownGoLeft
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
        */
    }
}

