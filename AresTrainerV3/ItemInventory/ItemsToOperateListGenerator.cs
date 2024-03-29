﻿using static AresTrainerV3.Enums.EnumsList;

namespace AresTrainerV3.ItemInventory
{
	internal class ItemsToOperateListGenerator : IItemsOperationsGenerator
	{
		InventoryType inventoryTypeOperation;

		public bool isItemHighValue(int itemAdressVector, InventoryType invType)
		{
			inventoryTypeOperation = invType;
			return isItemHighValue(itemAdressVector);
		}

		public List<int> ItemsOperationsListGenerate(Func<int, bool> delegateIsItemFitToAdd, InventoryType invTypeOperation)
		{
			List<int> imtemsToOperate = new List<int>();

			inventoryTypeOperation = invTypeOperation;
			int inventoryCount;
			if (inventoryTypeOperation == InventoryType.Inventory) inventoryCount = 60;
			else inventoryCount = 98;
			imtemsToOperate.Clear();
			for (int i = 0; i < inventoryCount; i++)
			{
				if (delegateIsItemFitToAdd(i))
				{
					imtemsToOperate.Add(i);
				}
			}
			return imtemsToOperate;
		}
		public List<int> ItemsForSaleListGenerate()
		{
			return ItemsOperationsListGenerate(isItemForSaleCheck, InventoryType.Inventory);
		}
		public List<int> ItemsFromStorageListGenerate()
		{
			return ItemsOperationsListGenerate(isItemForSaleCheck, InventoryType.Storage);
		}

		 bool isItemSaleType(int itemTypeVector)
		{
			int itemTypeValue;
			if (inventoryTypeOperation == InventoryType.Inventory)
			{
				itemTypeValue = ProgramHandle.ReadInventoryItemsType(itemTypeVector);
			}
			else
			{
				itemTypeValue = ProgramHandle.ReadStorageItemsType(itemTypeVector);
			}
			if (PointersAndValues.ItemsNotForSaleValues.Contains(itemTypeValue) ||
				PointersAndValues.ItemValuesEventSnowman.Contains(itemTypeValue))
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public List<int> ItemsToStorageMoveListGenerate()
		{
			return ItemsOperationsListGenerate(isItemForToStorageMoveCheck, InventoryType.Inventory);
		}
		 bool isItemForToStorageMoveCheck(int itemVector)
		{
			if (ProgramHandle.ReadInvItmsCount(itemVector) != 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		 bool isItemHighValue(int itemAdressVector)
		{
			int stat1, stat2;

			int hightValueMainStats = 14;

			int SihonValue = 40;
			int SihonWithStats = 35;
			int magicAttackLimit = 85;
			int magicJustusLimit = 40;
			int magicJustus25Limit = 30;



			if (inventoryTypeOperation == InventoryType.Inventory)
			{
				stat1 = ProgramHandle.ReadSellItemsStat1(itemAdressVector);
				stat2 = ProgramHandle.ReadSellItemsStat2(itemAdressVector);
			}
			else
			{
				stat1 = ProgramHandle.ReadStorageItemsStat1(itemAdressVector);
				stat2 = ProgramHandle.ReadStorageItemsStat2(itemAdressVector);
			}
			int Mp = 0;
			int Agi = 0;
			int Con = 0;
			int Td = 0;
			int Fire = 0;
			int Earth = 0;
			int Air = 0;
			int Water = 0;
			int Sihon = 0;
			int Kislon = 0;
			int Luck = 0;
			int StrikingPower = 0;
			int Justus = 0;
			int MageEmpPower = 0;
			int MageAlliPower = 0;
			int Gedel = 0;
			int Mizaph = 0;
			#region Mizaph++
			if (stat1 == 120)
			{
				Mizaph += 1;
			}
			else if (stat1 == 121)
			{
				Mizaph += 2;
			}
			#endregion
			#region Agility++
			// Bilhan
			if (stat1 == 17)
			{
				Agi += 1;
			}
			else if (stat1 == 18)
			{
				Agi += 3;
			}
			else if (stat1 == 19)
			{
				Agi += 5;
			}
			else if (stat1 == 20)
			{
				Agi += 7;
			}
			else if (stat1 == 21)
			{
				Agi += 9;
			}
			// Idbash
			if (stat2 == 15)
			{
				Agi += 2;
			}
			else if (stat2 == 16)
			{
				Agi += 4;
			}
			else if (stat2 == 17)
			{
				Agi += 6;
			}
			else if (stat2 == 18)
			{
				Agi += 8;
			}
			else if (stat2 == 19)
			{
				Agi += 10;
			}
			#endregion
			#region Mouscle Power
			// Baruch
			if (stat1 == 1)
			{
				Mp += 1;
			}
			else if (stat1 == 2)
			{
				Mp += 3;
			}
			else if (stat1 == 3)
			{
				Mp += 5;
			}
			else if (stat1 == 4)
			{
				Mp += 7;
			}
			else if (stat1 == 5)
			{
				Mp += 9;
			}
			// Keluchi
			if (stat2 == 1)
			{
				Mp += 2;
			}
			else if (stat2 == 2)
			{
				Mp += 4;
			}
			else if (stat2 == 3)
			{
				Mp += 6;
			}
			else if (stat2 == 4)
			{
				Mp += 8;
			}
			else if (stat2 == 5)
			{
				Mp += 10;
			}
			#endregion
			#region Concentration
			// Lhasha
			if (stat1 == 12)
			{
				Con += 1;
			}
			else if (stat1 == 13)
			{
				Con += 3;
			}
			else if (stat1 == 14)
			{
				Con += 5;
			}
			else if (stat1 == 15)
			{
				Con += 7;
			}
			else if (stat1 == 16)
			{
				Con += 9;
			}
			// Dalphon
			if (stat2 == 10)
			{
				Con += 2;
			}
			else if (stat2 == 11)
			{
				Con += 4;
			}
			else if (stat2 == 12)
			{
				Con += 6;
			}
			else if (stat2 == 13)
			{
				Con += 8;
			}
			else if (stat2 == 14)
			{
				Con += 10;
			}
			#endregion
			#region TotalDamage++
			// Amos
			if (stat1 == 75)
			{
				Td += 5;
			}
			else if (stat1 == 76)
			{
				Td += 10;
			}
			else if (stat1 == 77)
			{
				Td += 15;
			}
			else if (stat1 == 78)
			{
				Td += 20;
			}
			// Magbisch
			if (stat2 == 64)
			{
				Td += 5;
			}
			else if (stat2 == 65)
			{
				Td += 10;
			}
			else if (stat2 == 66)
			{
				Td += 15;
			}
			else if (stat2 == 67)
			{
				Td += 20;
			}
			#endregion
			#region Sihon
			// Sihon
			if (stat1 == 186)
			{
				Sihon += 40;
			}
			else if (stat1 == 187)
			{
				Sihon += 45;
			}
			else if (stat1 == 188)
			{
				Sihon += 50;
			}
			#endregion
			#region StrikingPower
			// Kazen /  Doriat
			if (stat2 == 123 || stat2 == 118)
			{
				StrikingPower += 60;
			}
			else if (stat2 == 124 || stat2 == 119)
			{
				StrikingPower += 80;
			}
			else if (stat2 == 125 || stat2 == 120)
			{
				StrikingPower += 100;
			}
			else if (stat2 == 126 || stat2 == 121)
			{
				StrikingPower += 120;
			}
			#endregion
			#region Mage

			// Air 
			if (stat2 == 50)
			{
				MageEmpPower += 5;
			}
			else if (stat2 == 51)
			{
				MageEmpPower += 15;
			}
			else if (stat2 == 52)
			{
				MageEmpPower += 25;
			}
			else if (stat2 == 53)
			{
				MageEmpPower += 35;
			}
			else if (stat2 == 54)
			{
				MageEmpPower += 45;
			}
			else if (stat2 == 55)
			{
				MageEmpPower += 55;
			}
			//  Earth
			if (stat2 == 44)
			{
				MageAlliPower += 5;
			}
			else if (stat2 == 45)
			{
				MageAlliPower += 15;
			}
			else if (stat2 == 46)
			{
				MageAlliPower += 25;
			}
			else if (stat2 == 47)
			{
				MageAlliPower += 35;
			}
			else if (stat2 == 48)
			{
				MageAlliPower += 45;
			}
			else if (stat2 == 49)
			{
				MageAlliPower += 55;
			}
			// Water
			if (stat1 == 41 || stat1 == 35)
			{
				MageEmpPower += 10;
			}
			else if (stat1 == 41 || stat1 == 36)
			{
				MageEmpPower += 20;
			}
			else if (stat1 == 42 || stat1 == 37)
			{
				MageEmpPower += 30;
			}
			else if (stat1 == 43 || stat1 == 38)
			{
				MageEmpPower += 40;
			}
			else if (stat1 == 44 || stat1 == 39)
			{
				MageEmpPower += 50;
			}
			else if (stat1 == 45 || stat1 == 40)
			{
				MageEmpPower += 60;
			}
			// Fire
			if (stat1 == 35)
			{
				MageAlliPower += 10;
			}
			else if (stat1 == 36)
			{
				MageAlliPower += 20;
			}
			else if (stat1 == 37)
			{
				MageAlliPower += 30;
			}
			else if (stat1 == 38)
			{
				MageAlliPower += 40;
			}
			else if (stat1 == 39)
			{
				MageAlliPower += 50;
			}
			else if (stat1 == 40)
			{
				MageAlliPower += 60;
			}

			#endregion
			#region Justus
			// Justus
			if (stat1 == 189)
			{
				Justus += 10;
			}
			else if (stat1 == 190)
			{
				Justus += 15;
			}
			else if (stat1 == 191)
			{
				Justus += 20;
			}
			else if (stat1 == 192)
			{
				Justus += 25;
			}
			else if (stat1 == 193)
			{
				Justus += 30;
			}
			#endregion
			#region Gedel
			// Gedel
			if (stat1 == 81)
			{
				Gedel += 8;
			}
			else if (stat1 == 82)
			{
				Gedel += 10;
			}
			else if (stat1 == 83)
			{
				Gedel += 15;
			}
			else if (stat1 == 84)
			{
				Gedel += 20;
			}
			#endregion
			#region Luck
			// Luck
			if (stat2 == 97)
			{
				Luck += 10;
			}
			else if (stat2 == 98)
			{
				Luck += 20;
			}
			else if (stat2 == 99)
			{
				Luck += 30;
			}
			else if (stat1 == 126)
			{
				Luck += 5;
			}
			else if (stat1 == 127)
			{
				Luck += 15;
			}
			else if (stat1 == 128)
			{
				Luck += 25;
			}
			#endregion
			#region Fire
			if (stat1 == 35)
			{
				Fire += 10;
			}
			else if (stat1 == 36)
			{
				Fire += 20;
			}
			else if (stat1 == 37)
			{
				Fire += 30;
			}
			else if (stat1 == 38)
			{
				Fire += 40;
			}
			else if (stat1 == 39)
			{
				Fire += 50;
			}
			else if (stat1 == 40)
			{
				Fire += 60;
			}
			//stat2
			if (stat2 == 32)
			{
				Water += 5;
			}
			else if (stat2 == 33)
			{
				Fire += 15;
			}
			else if (stat2 == 34)
			{
				Fire += 25;
			}
			else if (stat2 == 35)
			{
				Fire += 35;
			}
			else if (stat2 == 36)
			{
				Fire += 45;
			}
			else if (stat2 == 37)
			{
				Fire += 55;
			}
			#endregion
			#region Water

			//stats 1
			if (stat1 == 41)
			{
				Water += 5;
			}
			else if (stat1 == 42)
			{
				Water += 10;
			}
			else if (stat1 == 43)
			{
				Water += 20;
			}
			else if (stat1 == 44)
			{
				Water += 30;
			}
			else if (stat1 == 45)
			{
				Water += 40;
			}
			else if (stat1 == 46)
			{
				Water += 50;
			}
			else if (stat1 == 47)
			{
				Water += 60;
			}
			//stats 2
			if (stat2 == 38)
			{
				Water += 5;
			}
			else if (stat2 == 39)
			{
				Water += 15;
			}
			else if (stat2 == 40)
			{
				Water += 25;
			}
			else if (stat2 == 41)
			{
				Water += 35;
			}
			else if (stat2 == 42)
			{
				Water += 45;
			}
			else if (stat2 == 43)
			{
				Water += 55;
			}
			#endregion
			#region Earth
			// stats 1
			if (stat1 == 48)
			{
				Earth += 5;
			}
			else if (stat1 == 49)
			{
				Earth += 10;
			}
			else if (stat1 == 50)
			{
				Earth += 20;
			}
			else if (stat1 == 51)
			{
				Earth += 30;
			}
			else if (stat1 == 52)
			{
				Earth += 40;
			}
			else if (stat1 == 53)
			{
				Earth += 50;
			}
			else if (stat1 == 54)
			{
				Earth += 60;
			}
			// stats 2
			if (stat2 == 44)
			{
				Earth += 5;
			}
			else if (stat2 == 45)
			{
				Earth += 15;
			}
			else if (stat2 == 46)
			{
				Earth += 25;
			}
			else if (stat2 == 47)
			{
				Earth += 35;
			}
			else if (stat2 == 48)
			{
				Earth += 45;
			}
			else if (stat2 == 49)
			{
				Earth += 55;
			}
			#endregion
			#region Air

			// stats 1
			if (stat1 == 55)
			{
				Air += 5;
			}
			else if (stat1 == 56)
			{
				Air += 10;
			}
			else if (stat1 == 57)
			{
				Air += 20;
			}
			else if (stat1 == 58)
			{
				Air += 30;
			}
			else if (stat1 == 59)
			{
				Air += 40;
			}
			else if (stat1 == 60)
			{
				Air += 50;
			}
			else if (stat1 == 61)
			{
				Air += 60;
			}

			if (stat2 == 50)
			{
				Air += 5;
			}
			else if (stat2 == 51)
			{
				Air += 15;
			}
			else if (stat2 == 52)
			{
				Air += 25;
			}
			else if (stat2 == 53)
			{
				Air += 35;
			}
			else if (stat2 == 54)
			{
				Air += 45;
			}
			else if (stat2 == 55)
			{
				Air += 55;
			}
			#endregion

			// Check IF stats Are Higher
			if (Agi > hightValueMainStats)
			{
				return true;
			}
			else if (Mp > hightValueMainStats)
			{
				return true;
			}
			else if (Con > hightValueMainStats)
			{
				return true;
			}
			else if (Gedel > 15 && (Agi > 7 || Mp > 7 || Con > 7))
			{
				return true;
			}
			else if (Td > 30)
			{
				return true;
			}
			else if (Fire > magicAttackLimit || Earth > magicAttackLimit || Water > magicAttackLimit || Air > magicAttackLimit)
			{
				return true;
			}
			else if ((Fire > magicJustusLimit || magicJustusLimit > magicAttackLimit || Water > magicJustusLimit || Air > magicJustusLimit) && Justus > 15)
			{
				return true;
			}
			else if ((Fire > magicJustus25Limit || Earth > magicJustus25Limit || Water > magicJustus25Limit || Air > magicJustus25Limit) && Justus > 20)
			{
				return true;
			}
			else if (Td > 15 && StrikingPower > 80)
			{
				return true;
			}
			else if (Justus > 20 && StrikingPower > 100)
			{
				return true;
			}
			else if (Justus > 20 && Td > 10)
			{
				return true;
			}
			else if (Sihon > SihonValue)
			{
				return true;
			}
			else if (Sihon > SihonWithStats && Mp > 4 || Sihon > SihonWithStats && Agi > 4 || Sihon > SihonWithStats && Con > 4)
			{
				return true;
			}
			else if (Luck > 25)
			{
				return true;
			}
			else if (Mizaph > 1 && (Mp > 6 || Con > 6 || Agi > 6))
			{
				return true;
			}
			else return false;
		}
		 bool isItemForSaleCheck(int itemVector)
		{
			if (!isItemHighValue(itemVector) && isItemSaleType(itemVector))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
			}
}
