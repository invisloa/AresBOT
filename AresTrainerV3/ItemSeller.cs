using AresTrainerV3.Buyer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3
{
    public class ItemSeller
    {

        public static void itemArrayPositionsInitialize()
        {


            int spaceMultiplyer = 0;
            int spaceBetweenRows = 0;


            for (int i = 0; i < 72; i++)
            {
                if (i < 6)
                {
                    ExpBotMovePositionsValues.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositionsValues.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositionsValues.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 12)
                {
                    if (spaceMultiplyer > 5)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositionsValues.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositionsValues.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositionsValues.firstRowInventory + spaceBetweenRows);

                }
                else if (i < 18)
                {
                    if (spaceMultiplyer > 5)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositionsValues.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositionsValues.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositionsValues.firstRowInventory + spaceBetweenRows);

                }
                else if (i < 24)
                {
                    if (spaceMultiplyer > 5)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositionsValues.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositionsValues.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositionsValues.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 30)
                {
                    if (spaceMultiplyer > 5)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositionsValues.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositionsValues.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositionsValues.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 36)
                {
                    if (spaceMultiplyer > 5)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositionsValues.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositionsValues.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositionsValues.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 42)
                {
                    if (spaceMultiplyer > 5)
                    {
                        spaceBetweenRows = 0;   // 0 Because it starts from start again
                        spaceBetweenRows = 0;   // 0 Because it starts from start again
                        spaceMultiplyer = 0;


                    }
                    ExpBotMovePositionsValues.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositionsValues.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositionsValues.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 48)
                {
                    if (spaceMultiplyer > 5)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositionsValues.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositionsValues.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositionsValues.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 54)
                {
                    if (spaceMultiplyer > 5)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositionsValues.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositionsValues.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositionsValues.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 60)
                {
                    if (spaceMultiplyer > 5)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositionsValues.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositionsValues.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositionsValues.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 66)
                {
                    if (spaceMultiplyer > 5)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositionsValues.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositionsValues.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositionsValues.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 72)
                {
                    if (spaceMultiplyer > 5)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositionsValues.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositionsValues.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositionsValues.firstRowInventory + spaceBetweenRows);
                }
                spaceMultiplyer++;
            }
        }

        public static List<int> itemsForSaleList = new List<int>();



        public static bool isItemHighValue(int stat1, int stat2)
        {
            int magicAttack = 85;
            int magicWithHp = 40;
            int hightValueMainStats = 12;

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
            if (stat1 == 64)
            {
                Td += 5;
            }
            else if (stat1 == 65)
            {
                Td += 10;
            }
            else if (stat1 == 66)
            {
                Td += 15;
            }
            else if (stat1 == 67)
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
            else if(stat1 == 49)
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
            else if (Gedel > 14 && (Agi > 7 || Mp > 7 || Con > 7))
            {
                return true;
            }
            else if (Td > 30)
            {
                return true;
            }
            else if (Fire > magicAttack || Earth > magicAttack || Water > magicAttack || Air > magicAttack)
            {
                return true;
            }
            else if (Fire > magicWithHp || magicWithHp > magicAttack || Water > magicWithHp || Air > magicWithHp && Justus >15)
            {
                return true;
            }
            else if (Td > 10 && StrikingPower > 60)
            {
                return true;
            }
            else if (Justus > 15 && StrikingPower > 60)
            {
                return true;
            }
            else if (Justus > 10 && Td > 10)
            {
                return true;
            }
            else if (Sihon > 45)
            {
                return true;
            }
            else if (Sihon > 35 && Mp > 3 || Sihon > 35 && Agi > 3 || Sihon > 35 && Con > 3)
            {
                return true;
            }
            else if (Sihon > 30 && Mp > 6 || Sihon > 30 && Agi > 6 || Sihon > 30 && Con > 6)
            {
                return true;
            }
            else if (Luck > 25)
            {
                return true;
            }
            else if (Mizaph > 0 && (Mp > 3||Con>3||Agi>3))
            {
                return true;
            }
            else if (Mizaph>1)
            {
                return true;
            }
            else return false;
        }
        public static bool isItemSaleType(int typeAdress)
        {
            foreach (int item in PointersAndValues.ItemValuesSodSop)
            {
                if (typeAdress == item)
                { return false; }
            }
            if (typeAdress == 187)// arrows
            {
                return false;
            }
            public static readonly ItemEventSnowmanItems
            if (typeAdress == 3093) // LegacyPot
            {
                return false;
            }
            if (typeAdress == 9220) // EventBrew
            {
                return false;
            }
            if (typeAdress == 9261) // Eventscarf
            {
                return false;
            }
            if (typeAdress == 9262) // Eventscarf
            {
                return false;
            }
            if (typeAdress == 9263) // Eventscarf
            {
                return false;
            }
            if (typeAdress == 9264) // Eventscarf
            {
                return false;
            }
            if (typeAdress == 9265) // Eventscarf
            {
                return false;
            }
            if (typeAdress == 9266) // Eventhead
            {
                return false;
            }
            if (typeAdress == 9267) // Eventhead
            {
                return false;
            }

            else
            {
                return true;
            }
        }
        public static void ItemsForSaleListGenerate()
        {
            itemsForSaleList.Clear();
            for (int i = 0; i < 60; i++)
            {
                if (ProgramHandle.ReadSellItemsByteValue(i) != 0)
                {
                    if (!isItemHighValue(ProgramHandle.ReadSellItemsStat1(i),ProgramHandle.ReadSellItemsStat2(i)) && isItemSaleType(ProgramHandle.ReadSellItemsType(i)))
                    {
                        itemsForSaleList.Add(i);
                    } 
                }
            }
        }


        public static void MoveAndLeftClickToSellAll()
        {
            Debug.WriteLine("Check if selll window is open");
            Thread.Sleep(100);
            if (ProgramHandle.isSellWindowStillOpen == 1)
            {
                Thread.Sleep(50);
                Debug.WriteLine("window open sell item left click");
                MouseOperations.SetCursorPosition(560, 570);
                Thread.Sleep(50);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                Thread.Sleep(50);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                Thread.Sleep(100);

            }

            Debug.WriteLine("Check if high value");
            Thread.Sleep(200);
            if (ProgramHandle.isSellWindowStillOpen == 1)
            {
                Thread.Sleep(100);
                Debug.WriteLine("high value item click once more");
                MouseOperations.SetCursorPosition(560, 570);
                Thread.Sleep(50);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                Thread.Sleep(50);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                Thread.Sleep(100 );

            }
        }

        #region OldSellItems
        public static void SellItemsMouseMove()
        {
            ItemSeller.itemArrayPositionsInitialize();
            Thread.Sleep(50);
            ItemsForSaleListGenerate();
            Thread.Sleep(50);
            ProgramHandle.OpenShopWindow();
            Thread.Sleep(500);

            MouseOperations.MoveAndLeftClickOperation(1235, 570, 100);  // Open Inventory Tab 1
            Thread.Sleep(300);

            //  SELL ONLY FIRST ROW OF SECOND TAB  
            // for (int i = 12; i < ExpBotMovePositions.itemSellPositions.Length; i++) // START FROM 3 Row 1st Column - its 12
            foreach (var item in itemsForSaleList)
            {
                if (ProgramHandle.isShopWindowStillOpen() == 1)
                {
                    Debug.WriteLine($"sell item {item}");

                    int sellItemNumber = item + 12; // START FROM 3 Row 1st Column -its 12
                    if (sellItemNumber >= 36 && ProgramHandle.isCurrentInventoryTabOppened() == 0)
                    {
                        Thread.Sleep(150);
                        MouseOperations.MoveAndLeftClickOperation(1235, 670, 100); // Open Inventory Tab 2
                        Thread.Sleep(150);
                    }
                    ExpBotClass.MoveAndRightClickOperation(ExpBotMovePositionsValues.itemSellPositions[sellItemNumber].Item1, ExpBotMovePositionsValues.itemSellPositions[sellItemNumber].Item2);
                    MoveAndLeftClickToSellAll();
                }
            }
        }
        #endregion

/*        public static void NewSellItems()
        {
*//*            Thread.Sleep(500);
            ExpBotClass.MoveAndLeftClickOperation(1235, 570);
*//*    
            Thread.Sleep(500);
            ItemsForSaleListGenerate();
            ProgramHandle.OpenShopWindow();
            Thread.Sleep(1000);


            foreach (var item in itemsForSaleList)
            {
                Thread.Sleep(200);

                ProgramHandle.SetItemForSaleSelected(item);
                Thread.Sleep(200);
                ProgramHandle.OpenSellConfirmationUI();


                Thread.Sleep(200);
                MoveAndLeftClickToSellAll();
                Thread.Sleep(200);



            }
        }
*/    }
}
