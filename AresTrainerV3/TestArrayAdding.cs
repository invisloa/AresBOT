using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3
{
    internal class TestArrayAdding
    {
        static void itemArrayPositionsInitialize()
        {

            int spaceMultiplyer = 0;
            int spaceBetweenRows = 0;

            for (int i = 0; i < 72; i++)
            {
                if(i<6)
                {
                    ExpBotMovePositions.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositions.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositions.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 12)
                {
                    if(spaceMultiplyer >6)
                    { 
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositions.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositions.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositions.firstRowInventory+ spaceBetweenRows);

                }
                else if (i < 18)
                {
                    if (spaceMultiplyer > 6)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositions.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositions.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositions.firstRowInventory + spaceBetweenRows);

                }
                else if (i < 24)
                {
                    if (spaceMultiplyer > 6)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositions.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositions.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositions.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 30)
                {
                    if (spaceMultiplyer > 6)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositions.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositions.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositions.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 36)
                {
                    if (spaceMultiplyer > 6)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositions.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositions.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositions.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 42)
                {
                    if (spaceMultiplyer > 6)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositions.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositions.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositions.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 48)
                {
                    if (spaceMultiplyer > 6)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositions.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositions.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositions.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 54)
                {
                    if (spaceMultiplyer > 6)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositions.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositions.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositions.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 60)
                {
                    if (spaceMultiplyer > 6)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositions.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositions.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositions.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 66)
                {
                    if (spaceMultiplyer > 6)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositions.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositions.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositions.firstRowInventory + spaceBetweenRows);
                }
                else if (i < 72)
                {
                    if (spaceMultiplyer > 6)
                    {
                        spaceMultiplyer = 0;
                        spaceBetweenRows += 35;

                    }
                    ExpBotMovePositions.itemSellPositions[i] = new Tuple<int, int>(ExpBotMovePositions.firstColumnInventory + spaceMultiplyer * 35, ExpBotMovePositions.firstRowInventory + spaceBetweenRows);
                }
                spaceMultiplyer++;
            }
        }
    }
}
