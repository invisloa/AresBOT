using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace AresTrainerV3;

public static class PointersAndValues
{
    public const int hpOffset = 0x148;
    public const int MannaOffset = 0x980;
    public const int skill1Offset = 0x05c;
    public const int anim1Offset = 0x3a8;
    public const int anim2Offset = 0x3ac;
    public const int slotFirstOffset = 0xbb2;
    public const int fogOffset = 0x2B03CC;
    public const int cameraBaseOffset = 0x2AC578;

    public static int arcerAnim1 = 1153775900;
    public static int arcerAnim2 = 1161337300;
    public static int arcerFirstSkill = 111504;


    public static int spearSkillAnim1 = 1153814902;           //1153712127 anim value    // 1153814902; poprzednia wartosc testowana nie widac widocznej roznicy
    public static int spearSkillAnim2 = 0;                                  // na 0 nie widac wiekszych zmian 1153712127;             // anim max value 1153712127
    public static int spearFirstSkill = 131500;
    public static int spearNormalAnim1 = 1152700000;



    public static int mageAnim1 = 1162885990;
    public static int mageAnim2 = 1162724965;
    public static int mageDealBrandSkill = 60219;
    public static int mageStoneBulletSkill = 60219;

    public static IntPtr baseAddress = IntPtr.Zero;
    public static IntPtr client = IntPtr.Zero;
    public static Memory mem = new Memory();
    public static InputSimulator inputSimulator = new InputSimulator();



}
