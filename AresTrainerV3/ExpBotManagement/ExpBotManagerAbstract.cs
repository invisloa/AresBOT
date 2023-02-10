using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.MovePositions;

namespace AresTrainerV3.ExpBotManager
{
    public abstract class ExpBotManagerAbstract : IStartExpBotThread, IMoveAttackCollect
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

		public abstract DoScanAttackCollect WhatToCollectWhileMoving
		{
			get;
			set;
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

		public bool MoveAttackCollect()
		{
			throw new NotImplementedException();
		}
	}
}
