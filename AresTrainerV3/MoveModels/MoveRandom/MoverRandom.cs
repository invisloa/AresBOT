using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.MovePositions;
using AresTrainerV3.Unstuck;
using System.Diagnostics;

namespace AresTrainerV3.MoveModels.MoveRandom
{
	public abstract class MoverRandom : ExpBotManagerAbstract, IMoveAttackCollect
	{
		int sideMoveCount = 4;
		protected int _lastMouseMovePosition = 0;
		protected int _lastPositionAfterBounce = 0;
		protected bool tooLowDistance = false;
		protected Random randomizer = new Random();
		protected MoveRandomPositions positionsToMove = new MoveRandomPositions();
		bool movedMainMove = true;
		int bounceAntiRepeatCount = 0; public static bool AttackedOrCollected = false;
		DoScanAttackCollect _whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(new CollectSod()));

		void mainMoveSet()
		{
			movedMainMove = true;
			bounceAntiRepeatCount = 0;
		}
		bool isBounceable()
		{
			if (movedMainMove || bounceAntiRepeatCount > 6)
			{
				return true;
			}
			else
			{
				bounceAntiRepeatCount++;
				return false;
			}

		}

		protected abstract int moveOnlyOnMapX
		{
			get;
		}
		protected abstract Tuple<int, int, int, int> DirectionsLimts
		{
			get;
		}




		public override DoScanAttackCollect WhatToCollectWhileMoving
		{
			get
			{
				return _whatToCollectWhileMoving;

			}
			set
			{
				_whatToCollectWhileMoving = value;
			}
		}

		protected IUnstuckPosition unstuckPlace
		{
			get
			{
				return new UnstuckFromAnywhere();
			}
		}

		protected int MovePositionRandomizer(int i)
		{
			i = randomizer.Next(i - 1, i + 2); // not less then i-1 and not more then i+1
			if (i >= positionsToMove.MovePositionsArray.Length)  // transform if i> length of array
			{
				return i - positionsToMove.MovePositionsArray.Length;
			}
			else if (i < 0)
			{
				return positionsToMove.MovePositionsArray.Length + i; // +i because i is less then 0
			}
			else
			{
				return i;
			}
		}

		void MoveToPosition(int movePositionNr)
		{
			mouseClickToMove(movePositionNr);
		}
		void mouseClickToMove(int movePosNr)
		{
			Thread.Sleep(5);
			MouseOperations.SetCursorPosition(positionsToMove.MovePositionsArray[movePosNr].Item1, positionsToMove.MovePositionsArray[movePosNr].Item2);
			Thread.Sleep(5);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
			Thread.Sleep(50);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
			Thread.Sleep(50);
		}

		protected virtual void MoveToPosRandom()
		{
			if (ProgramHandle.isInCity != 1)
			{

				tooLowDistance = false;
				if (ProgramHandle.GetCurrentMap == moveOnlyOnMapX && isExpBotRunning)
				{

					if (!AttackedOrCollected)
					{
						if (ProgramHandle.isNowStandingOut())
						{
							tooLowDistance = true;
							Debug.WriteLine("TOO LOW DISTANCE");
							int a = randomizer.Next(3);
							if (a == 0)
							{
								_lastMouseMovePosition -= 8;
							}
							else if (a == 1)
							{
								_lastMouseMovePosition -= 16;
							}
							else
							{
								_lastMouseMovePosition -= 24;
							}
						}
						_lastMouseMovePosition = MovePositionRandomizer(_lastMouseMovePosition);
					}
					else
					{
						_lastMouseMovePosition = MovePositionRandomizer(_lastMouseMovePosition);
					}
					MoveToPosition(_lastMouseMovePosition);
					if (tooLowDistance)
					{
						Thread.Sleep(20);
					}
					AttackedOrCollected = false;
				}
				else
				{
					Thread.Sleep(15000);
					if (isExpBotRunning)
					{
						if (ProgramHandle.GetCurrentMap != moveOnlyOnMapX)
						{
							Thread.Sleep(5000);
							if (ProgramHandle.GetCurrentMap != moveOnlyOnMapX && isExpBotRunning)
							{
								RequestStopExpBot();
								HealBotAbstract.RequestStartStopHealBot();
								Process.Start("Shutdown", "-s -t 60");
							}
						}
					}
				}
			}
		}
		void MoveToPosRandom(int i)
		{
			_lastMouseMovePosition = i;
			MoveToPosRandom();
		}
		protected virtual void BorderLimitBounce(int mousePos, int firstBouncePos, int SecondBouncePos)
		{
			if (isBounceable())
			{
				if (_lastMouseMovePosition > mousePos)
				{
					_lastMouseMovePosition = MovePositionRandomizer(randomizer.Next(firstBouncePos, firstBouncePos + 6));
				}
				else
				{
					_lastMouseMovePosition = MovePositionRandomizer(randomizer.Next(SecondBouncePos, SecondBouncePos + 6));
				}
			}
			bounceAntiRepeatCount++;
		}
		protected virtual void leftLimitBounce()
		{
			BorderLimitBounce(16, 26, 2);
		}
		protected virtual void rightLimitBounce()
		{
			BorderLimitBounce(24, 18, 10);
		}
		protected virtual void upLimitBounce()
		{
			BorderLimitBounce(8, 18, 26);
		}
		protected virtual void downLimitBounce()
		{
			BorderLimitBounce(24, 2, 10);
		}

		public override void RunAndExp()
		{
			ProgramHandle.SetCameraForExpBot();
			RequestStartExpBot();

			while (isExpBotRunning)
			{
				if (ProgramHandle.isInCity == 1 && shutDownOnRepot)
				{
					Process.Start("Shutdown", "-s -t 10");
				}
				MoveAttackCollect();
			}
		}

		public bool MoveAttackCollect()
		{
			while (isExpBotRunning)
			{
				if (ProgramHandle.GetPositionX > DirectionsLimts.Item1 && ProgramHandle.GetPositionX < DirectionsLimts.Item3 && ProgramHandle.GetPositionY < DirectionsLimts.Item2 && ProgramHandle.GetPositionY > DirectionsLimts.Item4)
				{
					mainMoveSet();
					while (WhatToCollectWhileMoving.DoThisWhileMoving()) ;
					Debug.WriteLine("MainMoveClick");
					MoveToPosRandom();
				}
				else if (ProgramHandle.GetPositionX < DirectionsLimts.Item1)
				{
					Debug.WriteLine("maxLimitLeft");
					while (WhatToCollectWhileMoving.DoThisWhileMoving()) ;
					leftLimitBounce();
					MoveToPosRandom(_lastMouseMovePosition);
					movedMainMove = false;
				}
				else if (ProgramHandle.GetPositionX > DirectionsLimts.Item3)
				{
					Debug.WriteLine("maxRightLimit");
					while (WhatToCollectWhileMoving.DoThisWhileMoving()) ;
					rightLimitBounce();
					MoveToPosRandom(_lastMouseMovePosition);
					movedMainMove = false;
				}
				else if (ProgramHandle.GetPositionY < DirectionsLimts.Item4)
				{

					Debug.WriteLine("maxDownLimit");
					while (WhatToCollectWhileMoving.DoThisWhileMoving()) ;
					downLimitBounce();
					MoveToPosRandom(_lastMouseMovePosition);
					movedMainMove = false;
				}
				else if (ProgramHandle.GetPositionY > DirectionsLimts.Item2)
				{
					Debug.WriteLine("maxUpLimit");
					while (WhatToCollectWhileMoving.DoThisWhileMoving()) ;
					upLimitBounce();
					MoveToPosRandom(_lastMouseMovePosition);
					movedMainMove = false;
				}
				return true;
			}
			return false;
		}
	}
}
