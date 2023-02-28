using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.MovePositions;

namespace AresTrainerV3.ExpBotManager
{
    public abstract class ExpBotManagerAbstract : IStartExpBotThread, IMoveAttackCollect
	{
		public abstract void MoveAttackAndCollect();

		public static bool shutDownOnRepot = false;
        public void StartExpBotThread()
        {
            RequestStartExpBot();
			ProgramHandle.SetCameraForExpBot();
			Thread.Sleep(10);
            Thread ExpBotThread = new Thread(MoveAttackAndCollect);
            ExpBotThread.Start();  
        }
        protected static bool _isExpBotRunning = false;
		public abstract IDoWhileMoving WhatToDoWhileMoving
		{
			get;
		}
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
