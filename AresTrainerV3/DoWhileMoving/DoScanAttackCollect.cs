using AresTrainerV3.AttackMob;
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
        ICollectItems ICollector;
        public static int NumberOfCollectScans = 1;
        public static bool CollectItems = true;

        public DoScanAttackCollect(ICollectItems iCollector)
        {
            ICollector = iCollector;
        }

        bool ScanAttackCollect()
        {
            if (HealBotAbstract.SellItems == true)
            {
                if (CollectItems)
                {
                    for (int i = 0; i < NumberOfCollectScans; i++)
                    {
                        if (ICollector.ClickAndCollectItem())
                        {
                            return true;
                        }
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
                bool ScanAttackCollect()
                {
                    if (PixelMobAttack.AttackSkillMobWhenSelected())
                    {
                        return true;
                    }
                    if (CollectItems)
                    {
                        for (int i = 0; i < NumberOfCollectScans; i++)
                        {
                            if (ICollector.ClickAndCollectItem())
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
            return false;
        }


        public bool DoThisWhileMoving()
        {
           return ScanAttackCollect();
        }
    }
}
