using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.DoWhileMoving
{
    internal class DoScanAttackCollect : IDoWhileMoving
    {
        public static void MoveScanAndAttackAncCollect(int x, int y)
        {
            while (PixelMobAttack.AttackSkillMobWhenSelected()) ;
            ScanAndCollectClickLeftOnhighlightedForNow();

            if (isNowStandingOut())
            {

                moveToPosition(x, y);

            }

            /*            if (!PixelMobAttack.AttackSkillMobWhenSelected())
                        {
                            ScanAndCollectClickLeftOnhighlightedForNow();
                        }

            */
        }


        public void DoWhileMoving()
        {
            throw new NotImplementedException();
        }
    }
}
