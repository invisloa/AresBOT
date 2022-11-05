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
       // public abstract MoveToPositionAbstract MoveToPosPlace { get; }
        public abstract void RunAndExp();
        public static bool shutDownOnRepot = false;
        public void StartExpBotThread()
        {
            RequestStartExpBot();
            Thread.Sleep(10);
            if (isExpBotRunning)
            {
                Thread ExpBotThread = new Thread(RunAndExp);
                ExpBotThread.Start();
            }
        }


        protected static bool _isExpBotRunning = false;
        public static bool isExpBotRunning
        {
            get { return _isExpBotRunning; }
        }
        public static void RequestStopExpBot()
        {
            if (_isExpBotRunning)
            {
                _isExpBotRunning = false;
            }
        }
        public static void RequestStartExpBot()
        {
            if (!_isExpBotRunning)
            {
                _isExpBotRunning = true;
            }
        }

    }
}
