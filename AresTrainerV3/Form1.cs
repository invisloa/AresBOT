using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot;
using AresTrainerV3.HealBot.Repoter;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.ItemCollect.ItemBlessing;
using AresTrainerV3.ItemInventory;
using AresTrainerV3.ItemInventory.Buyer;
using AresTrainerV3.MoveModels;
using AresTrainerV3.MoveModels.MoveToPoint;
using AresTrainerV3.MoveModels.MoveToPoint.DestinationsCoords;
using AresTrainerV3.MoveModels.MoveToPoint.MouseToPosModel;
using AresTrainerV3.SkillSelection;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using Utilities;







namespace AresTrainerV3
{

	public partial class Form1 : Form
	{
		static Thread animbotThread;
		static Thread expbotThread = new Thread(ProgramHandle.StartAttackWhenMobSelectedBot);
		public SkillSelector CurrentlySelectedClass = SkillSelector.SelectPropperClass();
		globalKeyboardHook gkh = new globalKeyboardHook();
		Random randomizer = new Random();
		public ItemSeller Seller = new ItemSeller();

		public Form1()
		{
			InitializeComponent();
			ProgramHandle.InitializeProgram();
			Factory.HealbotToRun.setHealbotValues();
			HPValueTextBox.Text = HealBot.HealBotA.HpHealValue.ToString();
			MannaValueTextBox.Text = HealBot.HealBotA.MpRestoreValue.ToString();
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			gkh.HookedKeys.Add(Keys.F2);
			gkh.HookedKeys.Add(Keys.F3);
			gkh.HookedKeys.Add(Keys.F4);
			gkh.HookedKeys.Add(Keys.F5);
			gkh.HookedKeys.Add(Keys.F6);
			gkh.HookedKeys.Add(Keys.F8);
			gkh.HookedKeys.Add(Keys.F9);
			//
			//SUBSCRIBE globalKeyboardHook.
			//
			gkh.KeyF2Down += StartOnlyHealbotThread;
			gkh.KeyF2Down += ShowIfOnOrOff;
			//       gkh.KeyF3Down += ;
			gkh.KeyF3Down += StopAllBots;
			gkh.KeyF3Down += ShowIfOnOrOff;
			gkh.KeyF4Down += Start1HitKoThread;
			gkh.KeyF4Down += ShowIfOnOrOff;
			gkh.KeyF5Down += ProgramHandle.TeleportingPlace;
			gkh.KeyF6Down += AttackWhenMobSelectedThread;
			gkh.KeyF6Down += ShowIfOnOrOff;
			gkh.KeyF9Down += ShowIfOnOrOff;
		}

		void StartOnlyHealbotThread()
		{
			Factory.HealbotToRun.StartHealBotThread();
		}
		void StopAllBots()
		{
			ExpBotManagerAbstract.RequestStopExpBot();
			HealBot.HealBotA.RequestStartStopHealBot();
		}
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				HealBot.HealBotA.SelfSetHealValue = true;
			}
			else
			{
				HealBot.HealBotA.SelfSetHealValue = false;

			}
		}

		static void AttackWhenMobSelectedThread()
		{

			ProgramHandle.SetCameraForExpBot();

			Thread.Sleep(50);
			ProgramHandle.RequestStopExpBot();
			Thread.Sleep(50);


			if (expbotThread == null)
			{
				expbotThread = new Thread(ProgramHandle.StartAttackWhenMobSelectedBot);
			}
			if (!expbotThread.IsAlive)
			{
				expbotThread = new Thread(ProgramHandle.StartAttackWhenMobSelectedBot);
				expbotThread.Start();
			}

		}
		public void SetCollectEnums()
		{
			if (CollectorComboBox.Text == "+Event")
			{
				Factory.WhatToCollect = Enums.EnumsList.WhatToCollectEnums.Event;
			}
			else if (CollectorComboBox.Text == "+Jewelery")
			{
				Factory.WhatToCollect = Enums.EnumsList.WhatToCollectEnums.Jewelery;
			}
			else if (CollectorComboBox.Text == "+Stones")
			{
				Factory.WhatToCollect = Enums.EnumsList.WhatToCollectEnums.Stones;
			}
			else if (CollectorComboBox.Text == "+Stones+Jewelery")
			{
				Factory.WhatToCollect = Enums.EnumsList.WhatToCollectEnums.StonesAndJewelery;
			}
			else if (CollectorComboBox.Text == "+Seller")
			{
				Factory.WhatToCollect = Enums.EnumsList.WhatToCollectEnums.SellWeapons;
			}
			else if (CollectorComboBox.Text == "AllItems")
			{
				Factory.WhatToCollect = Enums.EnumsList.WhatToCollectEnums.SellAll;
			}

		}
		void SetBotEnums()
		{
			Seller.AssignWeight();

			if (ExpBotComboBox.Text == "EtanaBuckerty")
			{
				Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.EtanaBuckerty;
			}
			else if (ExpBotComboBox.Text == "SacredGiko")
			{
				Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.NoRepot;
			}
			else if (ExpBotComboBox.Text == "SacredThieves")
			{
				Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.NoRepot;
			}
			else if (ExpBotComboBox.Text == "SacredThievesSOD")
			{
				//Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.NoRepot;

				Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.SacredThievesSOD;
			}
			else if (ExpBotComboBox.Text == "HolinaGoblins")
			{
				Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.HolinaGoblins;
			}
			else if (ExpBotComboBox.Text == "BucksLowLVL")
			{
				Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.BucksLowLVL;
			}
			else if (ExpBotComboBox.Text == "HershalLowLvl")
			{
				Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.HershalLowLvl;
			}
			else if (ExpBotComboBox.Text == "HershalLeafMages")
			{
				Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.HershalLeafMages;
			}
			else if (ExpBotComboBox.Text == "HershalUWC1stFloor")
			{
				Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.HershalUWC1stFloor;
			}
			else if (ExpBotComboBox.Text == "KharonWolves")
			{
				Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.KharonWolves;
			}
			else if (ExpBotComboBox.Text == "KharonBigWolves")
			{
				Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.KharonBigWolves;
			}
			else if (ExpBotComboBox.Text == "Sloth1stFloor")
			{
				Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.Sloth1stFloor;
			}
			else if (ExpBotComboBox.Text == "SlothNoIcebergs")
			{
				Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.SlothNoIcebergs;
			}
			else if (ExpBotComboBox.Text == "SlothHorseFarm")
			{
				Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.SlothHorseFarm;
			}
			else if (ExpBotComboBox.Text == "SlothAoe")
			{
				Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.SlothAoe;
			}
			else if (ExpBotComboBox.Text == "SlothAoe2spot")
			{
				Factory.WhichBotThreadToStart = Enums.EnumsList.MoverBotEnums.SlothAoe2Spot;
			}

		}
		void AssignBot()
		{
			SetBotEnums();
			SetCollectEnums();
			Factory.ExpPlaceRepoterBotToStartSetter();
		}


		private void ClassChangeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{

			if (ClassChangeComboBox.SelectedIndex == 0)
			{
				PointersAndValues.skill1AnimValue = PointersAndValues.arcerAnim1;
				PointersAndValues.skill2AnimValue = PointersAndValues.arcerAnim2;
				PointersAndValues.skillValue = PointersAndValues.arcerFirstSkill;
				PointersAndValues.normal1AnimValue = PointersAndValues.arcerAnim1;
				PointersAndValues.normal2AnimValue = PointersAndValues.arcerAnim2;

			}

			if (ClassChangeComboBox.SelectedIndex == 1)
			{
				PointersAndValues.skill1AnimValue = PointersAndValues.spearSkillAnim1FirstSkill;
				PointersAndValues.skill2AnimValue = PointersAndValues.spearSkillAnim2;
				PointersAndValues.skillValue = PointersAndValues.spearFirstSkill;
			}
			if (ClassChangeComboBox.SelectedIndex == 2)
			{
				PointersAndValues.skill1AnimValue = PointersAndValues.mageAnim1;
				PointersAndValues.skill2AnimValue = PointersAndValues.mageAnim2;
			}
			if (ClassChangeComboBox.SelectedIndex == 3)
			{
				PointersAndValues.skill1AnimValue = PointersAndValues.knightskilllAnim1;
				PointersAndValues.skill2AnimValue = PointersAndValues.knightskilllAnim2;
				PointersAndValues.skillValue = PointersAndValues.knightFirstBlunt;
				PointersAndValues.normal1AnimValue = PointersAndValues.knightNormalAnim1;
				PointersAndValues.normal2AnimValue = PointersAndValues.knightskilllAnim2;

			}


		}

		private void StartSkillBtn_Click(object sender, EventArgs e)
		{
			Start1HitKoThread();
		}
		void Start1HitKoThread()
		{
			ProgramHandle.SetCameraLong();
			/*            CurrentlySelectedClass = SkillSelector.SelectPropperClass();
            */
			Thread.Sleep(50);
			ProgramHandle.RequestStopAnim();
			Thread.Sleep(50);


			if (animbotThread == null)
			{
				animbotThread = new Thread(() => ProgramHandle.Start1HitKO());
			}
			if (!animbotThread.IsAlive)
			{
				animbotThread = new Thread(() => ProgramHandle.Start1HitKO());
				animbotThread.Start();
			}
		}



		private void HpToBuy_TextChanged(object sender, EventArgs e)
		{
			if (HpToBuy.Text != "0")
			{
				BuyerPotionsAbstract.BuyFromForm = true;
			}
			int i = 0;
			int.TryParse(HpToBuy.Text, out i);
			BuyerPotionsAbstract.HpPotionsToBuy = i;
		}

		private void MpToBuy_TextChanged(object sender, EventArgs e)
		{
			{
				int i = 0;
				int.TryParse(MpToBuy.Text, out i);
				BuyerPotionsAbstract.MpPotionsToBuy = i;

			}
		}

		private void SpeedPot_TextChanged(object sender, EventArgs e)
		{
			int i = 0;
			int.TryParse(SpeedPot.Text, out i);
			BuyerPotionsAbstract.SpeedPotionsToBuy = i;

		}

		private void BuyMaxHp_CheckedChanged(object sender, EventArgs e)
		{
			if (BuyMaxHp.Checked)
			{
				BuyerPotionsAbstract.BuyMaxPotions = true;
			}
			else
			{
				BuyerPotionsAbstract.BuyMaxPotions = false;
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		private void AddAnimValue_Click(object sender, EventArgs e)
		{
		}

		private void SubstractAnimValue_Click(object sender, EventArgs e)
		{

		}

		void ShowIfOnOrOff()

		{

			if (!ProgramHandle.isStopAnim)
			{
				BtnHitKO.Text = "OFF";
				BtnHitKO.BackColor = Color.Gray;
			}
			else
			{
				BtnHitKO.Text = "ON";
				BtnHitKO.BackColor = Color.Yellow;
			}

			if (!ProgramHandle.isStopBot)
			{
				button1.Text = "OFF";
				button1.BackColor = Color.Gray;
			}
			else
			{
				button1.Text = "ON";
				button1.BackColor = Color.Yellow;

			}

			/*            if (!BitmapCreator.isStopPixelAttack)
                        {
                            button2.Text = "OFF";
                            button2.BackColor = Color.Gray;
                        }
                        else
                        {
                            button2.Text = "ON";
                            button2.BackColor = Color.Yellow;

                        }
            */
			if (!ExpBotClass.isStopMoveExpBot)
			{
				button3.Text = "OFF";
				button3.BackColor = Color.Gray;
			}
			else
			{
				button3.Text = "ON";
				button3.BackColor = Color.Yellow;

			}
			if (!ProgramHandle.isStopHeal)
			{
				BtnHealbotOnOff.Text = "OFF";
				BtnHealbotOnOff.BackColor = Color.Gray;
			}
			else
			{
				BtnHealbotOnOff.Text = "ON";
				BtnHealbotOnOff.BackColor = Color.Yellow;
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			System.Environment.Exit(1);
		}


		#region OLD NORMAL ATTACK THREAD and Functuiobn
		// static Thread normalAttackThread = new Thread(ProgramHandle.StartNormalAttack);

		/*        static void StartNormalAttack()
        {
            ProgramHandle.SetAnim1Value = PointersAndValues.skill1AnimValue;
            ProgramHandle.SetAnim2Value = PointersAndValues.skill2AnimValue;
            ProgramHandle.SetSkillValue = PointersAndValues.skillValue;


            if (animbotThread.IsAlive)
            {
                ProgramHandle.RequestStopAnim();
            }
            Thread.Sleep(50);
            ProgramHandle.RequestStopAnim();
            Thread.Sleep(50);
            if (!normalAttackThread.IsAlive)
            {
                normalAttackThread = new Thread(ProgramHandle.StartNormalAttack);
                normalAttackThread.Start();
            }
        }

*/
		#endregion

		private void Tester_Click(object sender, EventArgs e)
		{

			TextBoxLog.Text = ExpBotClass.ExpBotLog;
		}

		private void SellItems_Click(object sender, EventArgs e)
		{
			ProgramHandle.SetGameAsMainWindow();
			//ProgramHandle.OpenShopWindow();
			Thread.Sleep(1000);

			Seller.SellItemsByMouseMove();
		}


		private void OpenStorageBTN_Click(object sender, EventArgs e)
		{
			ProgramHandle.OpenStorageWindow();
		}

		private void teleport_Click(object sender, EventArgs e)
		{
			ProgramHandle.TeleportToPositionTuple(TeleportValues.PosSlothFloor1NoIceBergs);

		}

		private void ShowPositionsBtn_Click(object sender, EventArgs e)
		{
			PositionX.Text = ProgramHandle.GetPositionX.ToString();
			PositionY.Text = ProgramHandle.GetPositionY.ToString();
			PositionZ.Text = ProgramHandle.GetPositionZ.ToString();
		}
		private void ShowPosShort_Click(object sender, EventArgs e)
		{
			PositionX.Text = ProgramHandle.GetPositionShortX.ToString();
			PositionY.Text = ProgramHandle.GetPositionShortY.ToString();
			PositionZ.Text = ProgramHandle.GetPositionShortZ.ToString();
		}


		private void GoToPos_Click(object sender, EventArgs e)
		{
			ProgramHandle.TeleportToPosition(Int32.Parse(PositionX.Text), Int32.Parse(PositionY.Text), 0);
		}

		private void SellItemsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (SellItemsCheckBox.Checked)
			{
				HealBot.HealBotA.SellItems = true;
				checkBox1.Checked = false;
			}
			else
			{
				HealBot.HealBotA.SellItems = false;
			}
		}

		private void NumberOfCollectScans_TextChanged(object sender, EventArgs e)
		{
			int i = 1;
			int.TryParse(NumberOfCollectScans.Text, out i);
			DoScanAttackCollect.NumberOfCollectScans = i;
		}

		private void RunSellerCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			BuyerPotionsAbstract.SpeedPotionsToBuy = 3;

			BuyerPotionsAbstract.BuyFromForm = true;
			if (ProgramHandle.isCurrentClassSelected == PointersAndValues.ClassSorcerer)
			{
				BuyerPotionsAbstract.HpPotionsToBuy = 311;
				BuyerPotionsAbstract.MpPotionsToBuy = 25;
			}
			else if (ProgramHandle.isCurrentClassSelected == PointersAndValues.ClassKnight)
			{
				BuyerPotionsAbstract.HpPotionsToBuy = 333;
				BuyerPotionsAbstract.MpPotionsToBuy = 35;
				ExpBotComboBox.Text = "SlothAoe2spot";
			}
			else if (ProgramHandle.isCurrentClassSelected == PointersAndValues.ClassSpear)
			{
				BuyerPotionsAbstract.HpPotionsToBuy = 250;
				BuyerPotionsAbstract.MpPotionsToBuy = 45;
			}
			else if (ProgramHandle.isCurrentClassSelected == PointersAndValues.ClassArcher)
			{
				BuyerPotionsAbstract.HpPotionsToBuy = 333;
				BuyerPotionsAbstract.MpPotionsToBuy = 55;
			}

			HpToBuy.Text = BuyerPotionsAbstract.HpPotionsToBuy.ToString();
			MpToBuy.Text = BuyerPotionsAbstract.MpPotionsToBuy.ToString();
			SpeedPot.Text = BuyerPotionsAbstract.SpeedPotionsToBuy.ToString();
			HealBot.HealBotA.SellItems = true;
			SellItemsCheckBox.Checked = true;
			DoScanAttackCollect.NumberOfCollectScans = 1;
			NumberOfCollectScans.Text = DoScanAttackCollect.NumberOfCollectScans.ToString();
			this.CollectorComboBox.Text = "AllItems";
		}

		private void ExpBotComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			AssignBot();
		}

		private void CollectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			AssignBot();
		}

		private void ShutDownWhenInCity_CheckedChanged(object sender, EventArgs e)
		{
			if (ShutDownWhenInCity.Checked)
			{
				ExpBotManagerAbstract.shutDownOnRepot = true;
			}
			else
			{
				ExpBotManagerAbstract.shutDownOnRepot = false;
			}
		}

		private void CollectItemsBox_CheckedChanged(object sender, EventArgs e)
		{
			if (CollectItemsBox.Checked)
			{
				DoScanAttackCollect.CollectItems = true;
			}
			else
			{
				DoScanAttackCollect.CollectItems = false;
			}
		}

		private void RunExpBot_Click(object sender, EventArgs e)
		{
			AssignBot();
			Factory.HealbotToRun.StartHealBotThread();
			ProgramHandle.SetCameraForExpBot();
			if (Factory.GoRepotFirst)
			{
				Factory.HealbotToRun.RepotAndStartExpBot();
			}
			else
			{
				Factory.ExpBotToStart.StartExpBotThread();
			}
		}



		public void BlessItem()
		{
			ExpBotManagerAbstract.RequestStartExpBot();
			ItemBlesser Blesser = new ItemBlesser();
			Blesser.BlessItem(10);
		}
		public void StartBlessThread()
		{
			ExpBotManagerAbstract.RequestStartExpBot();
			Thread.Sleep(10);
			Thread ExpBotThread = new Thread(BlessItem);
			ExpBotThread.Start();
		}

		private void GoToPos_Click_1(object sender, EventArgs e)
		{
			int x = 0;
			int y = 0;
			Int32.TryParse(PositionX.Text, out x);
			Int32.TryParse(PositionY.Text, out y);
			ProgramHandle.TeleportToPosition(x, y, 0);
		}

		private void ItemBlesserBtn_Click(object sender, EventArgs e)
		{
			int blessValue;
			Int32.TryParse(HpToBuy.Text, out blessValue);
			MessageBox.Show($"You are going to try bless item to {blessValue}");

			ItemBlesser itemBlesser = new ItemBlesser();
			itemBlesser.BlessItem(blessValue);
		}

		private void HPValueTextBox_TextChanged_1(object sender, EventArgs e)
		{

			int i = 100;
			int.TryParse(HPValueTextBox.Text, out i);
			HealBot.HealBotA.HpHealValue = i;

		}

		private void MannaValueTextBox_TextChanged(object sender, EventArgs e)
		{
			int i = 100;
			int.TryParse(MannaValueTextBox.Text, out i);
			HealBot.HealBotA.MpRestoreValue = i;
		}

		private void RunExpcheckBox_CheckedChanged(object sender, EventArgs e)
		{
			BuyerPotionsAbstract.SpeedPotionsToBuy = 6;

			BuyerPotionsAbstract.BuyFromForm = true;
			if (ProgramHandle.isCurrentClassSelected == PointersAndValues.ClassSorcerer)
			{
				BuyerPotionsAbstract.HpPotionsToBuy = 333;
				BuyerPotionsAbstract.MpPotionsToBuy = 99;
				ExpBotComboBox.Text = "KharonBigWolves";

			}
			else if (ProgramHandle.isCurrentClassSelected == PointersAndValues.ClassKnight)
			{
				BuyerPotionsAbstract.HpPotionsToBuy = 333;
				BuyerPotionsAbstract.MpPotionsToBuy = 70;
				ExpBotComboBox.Text = "KharonBigWolves";
			}
			else if (ProgramHandle.isCurrentClassSelected == PointersAndValues.ClassSpear)
			{
				BuyerPotionsAbstract.HpPotionsToBuy = 250;
				BuyerPotionsAbstract.MpPotionsToBuy = 45;
			}
			else if (ProgramHandle.isCurrentClassSelected == PointersAndValues.ClassArcher)
			{
				BuyerPotionsAbstract.HpPotionsToBuy = 333;
				BuyerPotionsAbstract.MpPotionsToBuy = 55;
			}
			HpToBuy.Text = BuyerPotionsAbstract.HpPotionsToBuy.ToString();
			MpToBuy.Text = BuyerPotionsAbstract.MpPotionsToBuy.ToString();
			SpeedPot.Text = BuyerPotionsAbstract.SpeedPotionsToBuy.ToString();
			BuyMaxHp.Checked = true;
			DoScanAttackCollect.NumberOfCollectScans = 1;
			NumberOfCollectScans.Text = DoScanAttackCollect.NumberOfCollectScans.ToString();
			this.CollectorComboBox.Text = "AllItems";
		}
		private void GoRepotFirst_CheckedChanged(object sender, EventArgs e)
		{
			if (GoRepotFirst.Checked == true)
			{
				Factory.GoRepotFirst = true;
			}
			else
			{
				Factory.GoRepotFirst = false;
			}
		}

		private void fasttest_Click(object sender, EventArgs e)
		{
			AbstractWhatToCollect.MaxCollectWeight = ProgramHandle.getMaxWeight - 150;
			ExpBotManagerAbstract.RequestStartExpBot();
			// HealBotAbstract.RequestStartStopHealBot();
			//HealbotToRun.StartHealBotThread();

			ProgramHandle.SetCameraForExpBot();
			MoveToPointRepoter moverToPoint = new MoveToPointRepoter(DestinationsCoordinator.HershalRepot);
			moverToPoint.MoveToRepotDestination();

			/*		ReadOnlyCollection<CoordsPoint> tester = new ReadOnlyCollection<CoordsPoint>(new[]
					{
					new CoordsPoint(235,204,1),
					new CoordsPoint(225,197,1),
					new CoordsPoint(215,193,1),
				});

					MoveToPointRepoter moverToPoint = new MoveToPointRepoter(tester);
					moverToPoint.MoveToRepotDestination();

				}*/

		}


	}
}
