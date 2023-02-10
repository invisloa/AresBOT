using AresTrainerV3.HealBot;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.MoveModels.MoveRandom;
using AresTrainerV3.Unstuck;
using System.Diagnostics;

namespace AresTrainerV3.AttackMob
{
	public static class AttackMobCollectSod
	{

		public static bool IsAttackingPixel = false;
		static int attackUnstackCounter = 0;
		static int unstackMax = 60;
		static void checkIfIsNowAttackingAnimation()
		{
			int waitTime = 20;
			Debug.WriteLine("check started");
			Thread.Sleep(waitTime);
			for (int i = 0; i < 10; i++)
			{
				Thread.Sleep(waitTime);
				if (ProgramHandle.isAttacking())
				{
					WaitForAttackEnd();
				}

			}
			Debug.WriteLine("check ended");

		}
		static void WaitForAttackEnd()
		{
			Thread.Sleep(100);
			IWhatToCollect _SodCollector;

			if (HealBotAbstract.SellItems == true)
			{
				_SodCollector = Factory.CreateAllItemsCollector(); // WHAT TO COLLECT WHEN ATTACKING 
			}
			else
			{
				_SodCollector = Factory.CreateSodCollector(); // WHAT TO COLLECT WHEN ATTACKING 
			}
			ICollectItems pixelSodCollect = new PixelItemCollector(_SodCollector);
			UnstuckFromAnywhere anywhereUnstucker = new UnstuckFromAnywhere();

			while (ProgramHandle.isAttacking())
			{
				attackUnstackCounter++;
				Debug.WriteLine(ProgramHandle.isWhatAnimationRunning);

				pixelSodCollect.ScanClickAndCollectItem();
				Thread.Sleep(100);
				Debug.WriteLine(attackUnstackCounter);
				if (attackUnstackCounter == unstackMax)
				{
					anywhereUnstucker.AttackUnstacker();
				}
			}
			checkIfIsNowAttackingAnimation();
			Debug.WriteLine("attacking stopped");
			Debug.WriteLine(ProgramHandle.isWhatAnimationRunning);

		}

		static bool isMobTargeted()
		{
			if (ProgramHandle.isMobSelected != 0 && ProgramHandle.isMobSelected < 8300000 && ProgramHandle.isInCity != 1)
			{
				return true;
			}
			else if (ProgramHandle.isMobSelected > 8300000)
			{
				AbstractWhatToCollect.MaxCollectWeight = 1;
				Debug.WriteLine($"Player Found");
				return false;
			}
			else
				return false;
		}
		static bool SkillAttack()
		{
			if (ProgramHandle.isMobSelected != 0)
			{
				MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
				Debug.WriteLine($"Mouse R Down");
				Thread.Sleep(300);
				if (ProgramHandle.isMouseClickedOnMob == 1)
				{
					IsAttackingPixel = true;
					attackUnstackCounter = 0;
					Debug.WriteLine($"Mouse Clicked On Mob==1");
					MoverRandom.AttackedOrCollected = true;
					WaitForAttackEnd();
					MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
					Debug.WriteLine($"Mouse R UP");
					IsAttackingPixel = false;
					return true;


				}
				else
				{
					Debug.WriteLine($"Mouse not Clicked On Mob");
					MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
					Debug.WriteLine($"Mouse R UP");
					IsAttackingPixel = false;
					return false;
				}
			}
			return false;
		}
		public static bool CheckIfSelectedAndAttackSkill()
		{
			if (isMobTargeted())
			{
				if (SkillAttack())
				{
					return true;
				}
				return false;
			}
			else
			{
				return false;
			}

		}
	}

}

