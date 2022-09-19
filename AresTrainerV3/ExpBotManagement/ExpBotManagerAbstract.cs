using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.MovePositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ExpBotManager
{
    public abstract class ExpBotManagerAbstract : IStartExpBotThread
    {
        public abstract MoveToPositionAbstract MoveToPosPlace { get;}
        public abstract void RunAndExpSquare();

        public void StartExpBotThread()
        {
            RequestStartStopExpBot();
            if (isExpBotRunning)
            {
                Thread ExpBotThread = new Thread(RunAndExpSquare);
                ExpBotThread.Start();
            }
        }



        protected static bool _isExpBotRunning = false;
        public static bool isExpBotRunning
        {
            get { return _isExpBotRunning; }
        }
        public static void RequestStartStopExpBot()
        {
            if (_isExpBotRunning)
            {
                _isExpBotRunning = false;
            }
            else
            {
                _isExpBotRunning = true;
            }
        }



    }
}
