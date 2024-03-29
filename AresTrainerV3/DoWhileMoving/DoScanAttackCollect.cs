﻿using AresTrainerV3.AttackMob;
using AresTrainerV3.HealBot;
using AresTrainerV3.ItemCollect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.DoWhileMoving
{
    public class DoScanAttackCollect : IDoWhileMoving
    {
        IScanAndCollect ICollector = Factory.CreateScanAndCollectMethod();
        public static int NumberOfCollectScans = 1;
        public static bool CollectItems = true;

        public DoScanAttackCollect(IScanAndCollect iCollector)
        {
            ICollector = iCollector;
        }

        bool ScanAttackCollect()
        {
            if (HealBot.HealBotA.SellItems == true)
            {
                    for (int i = 0; i < NumberOfCollectScans; i++)
                    {
                        if (ICollector.ScanClickAndCollectItem())
                        {
                            return true;
                        }
                    }

                if (PixelMobAttack.AttackSkillMobWhenSelected())
                {
                    return true;
                }
                return false;
            }
            else
            {
                    if (PixelMobAttack.AttackSkillMobWhenSelected())
                    {
                        return true;
                    }
                    if (CollectItems)
                    {
                        for (int i = 0; i < NumberOfCollectScans; i++)
                        {
                            if (ICollector.ScanClickAndCollectItem())
                            {
                                return true;
                            }
                        }
                    }
                    return false;
            }
        }


        public bool DoThisWhileMoving()
        {
           return ScanAttackCollect();
        }
    }
}
