using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace AresTrainerV3;

public static class PointersAndValues
{
    public const int baseNormalOffset = 0x2ad1fc;
    public const int fogOffset = 0x2B03CC;
    public const int cameraBaseOffset = 0x2AC578;
    public const int mobSelectedOffset = 0x2A9648;

    

    // offsets
    public const int hpOffset = 0x148;
    public const int MannaOffset = 0x980;
    public const int skill1Offset = 0x05c;
    public const int anim1Offset = 0x3a8;
    public const int anim2Offset = 0x3ac;
    public const int slotFirstOffset = 0xbb2;
    public const int cameraDistancePointer = 0x19e;
    public const int cameraFogPointer = 0xd16;
    public const int cameraAnglePointer = 0x1b6;
    public const int skillDelayPointer = 0x802;
    public const int clickDelayPointer = 0xb2e;
    public const int runSpeedOffset = 0xb8e;
    public const int mapNumberOffset = 0x5a8;
    public const int positionXOffset = 0x244;
    public const int positionYOffset = 0x23c;
    public const int positionZOffset = 0x240;
    public const int mobSelected = 0xfd;
    public const int clickPositionXOffset = 0x544;
    public const int clickPositionYOffset = 0x53c;
    

    // values
    public const int runSpeedValue4 = 16859340;
    public const int cameraDistanceAnimValue = 1764311826;
    public const int cameraDistanceBotValue = 1764311750;
    public const int cameraFogValue = 18000;
    public const int cameraAngleValue = 81853;
    public static int skill1AnimValue = 0;
    public static int skill2AnimValue = 0;
    public static int normal1AnimValue = 0;
    public static int normal2AnimValue = 0;
    public static int skillValue = 0;
    public static int skillDelayValue = 0;
    public static int clickDelayValue = 0;
    public static int ToCheckValue0 = 0;
    // arcer
    public static int arcerAnim1 = 1161436900;
    public static int arcerAnim2 = 0;                         // nie widac roznicy po zmianie na 0 NIE TESTOWANO!!!!!!!    1161337300;
    public static int arcerFirstSkill = 111504;
    // spear
    public static int spearSkillAnim1FirstSkill = 1153814902;           //1153712127 anim value    // 1153814902; poprzednia wartosc testowana nie widac widocznej roznicy
    public static int spearSkillAnim1ThirdSkill = 1154085000;
    public static int spearSkillAnim1FiestAoE = 1154553000;  //1154502000;           
    public static int spearSkillAnim2 = 0;                                  // na 0 nie widac wiekszych zmian 1153712127;             // anim max value 1153712127
    public static int spearFirstSkill = 131500;
    public static int spearThirdSkill = 131704;
    public static int spearFirstAoESkill = 31801;
    public static int spearNormalAnim1 = 1152700000;
    // mage
    public static int mageAnim1 = 1162783990; // 15.06.22 1162765990;
    public static int mageAnim2 = 0;
    public static int mageDealBrandSkill = 60219;
    public static int mageStoneBulletSkill = 60219;
    public static int mageFirstAoeSkill = 60309;
    public static int mageDealBrand = 60204;
    public static int mageStriking = 60403;
    // KNIGHT
    public static int knightskilllAnim1 = 1135783990;
    public static int knightskilllAnim2 = 0;
    public static int knightNormalAnim1 = 1124500000;
    public static int knightFirstSkill = 120009;
    public static int knightSecondSkill = 120108;
    public static int knightFirstBlunt = 20501;




    public static IntPtr baseAddress = IntPtr.Zero;
    public static IntPtr client = IntPtr.Zero;
    public static Memory mem = new Memory();
    //  CHyba nie potrzebne public static InputSimulator inputSimulator = new InputSimulator();
}
