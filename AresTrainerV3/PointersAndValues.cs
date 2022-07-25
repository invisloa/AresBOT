using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace AresTrainerV3;

public static class PointersAndValues
{
    public const int baseNormalMOffset = 0x2ad1fc;
    public const int fogMOffset = 0x2B03CC;
    public const int cameraBaseMOffset = 0x2AC578;
    public const int mobSelectedMOffset = 0x2A9648;
    public const int mobBeingAttackedMOffset = 0x2AD1FC;
    public const int MouseoverHighlightedMOffset = 0x2AAE68;


    // offsets
    public const int hpOffset = 0x148;
    public const int MannaOffset = 0x980;
    public const int WeightOffset = 0x980;
    public const int skill1Offset = 0x05c;
    public const int anim1Offset = 0x3a8;
    public const int anim2Offset = 0x3ac;
    public const int slotHPOffset = 0xbb2;
    public const int slotMannaOffset = 0xbce;
    public const int slotRedPotOffset = 0xbea;
    public const int slotWhitePotOffset = 0xc06;
    public const int slotCandleOffset = 0xc22;
    public const int slotScrollOffset = 0xc3e;
    public const int MouseoverHighlightedOffset = 0xc;



    // d02 chyba slot 3/1
    public static int[] inventoryArray = new int[60];
    public static void initializeInventoryArray()
    {
        int tempOffsetValue = 0;
        for (int i = 0; i<60; i++)
			{
                inventoryArray[i] = 0xd02+tempOffsetValue;
                tempOffsetValue += 0x1c;
			}
    }




    public const int cameraDistancePointer = 0x19c;
    public const int cameraFogPointer = 0xd16;
    public const int cameraAngleYPointer = 0x1b6;
    public const int cameraAngleXPointer = 0x1a0;
    public const int skillDelayPointer = 0x802;
    public const int clickDelayPointer = 0xb2e;
    public const int runSpeedOffset = 0xb8e;
    public const int mapNumberOffset = 0x5a8;
    public const int positionYOffset = 0x244;
    public const int positionXOffset = 0x23c;
    public const int positionZOffset = 0x240;
    public const int clickPositionXOffset = 0x544;
    public const int clickPositionYOffset = 0x53c;
    public const int mobSelected = 0xfd;
    public const int mobBeingTargeted= 0x050;
    public const int typeOfAnimationIsRunning = 0x3b5;

    /*  
     *  
     *  minPosY = 1145899483
        maxPosY = 1146086822
    
        minPosX = 1119676532
        maxPosX = 1126508151
    */




    // values
    public const int runSpeedNormalValue = 16859264;
    public const int cameraDistanceAnimValue = 1125253120;
    public const int cameraDistanceBotValue = 1112599680;
    public const int cameraFogValue = 18000;
    public const int cameraAngleYValue = 81853;
    public static int skill1AnimValue = 0;
    public static int skill2AnimValue = 0;
    public static int normal1AnimValue = 0;
    public static int normal2AnimValue = 0;
    public static int skillValue = 0;
    public static int skillDelayValue = 0;
    public static int clickDelayValue = 0;
    public static int ToCheckValue0 = 0;
    public static int cameraAngleXValue = 0;
    public static int AttackSpeed = 1431715797;
    public static Tuple<int,int> expBotMouseStartingPos = new Tuple<int, int>(930, 500);

    public static int MouseoverItemValue = 43880704;
    public static int MouseoverMobValue = 43881072;

    


    public static int mannaPotionsCountValue = 16777257;  ///to jest jedna potka jak jest 0 to == 0 jak 1 to 16777217
    public static int whitePotionsCountValue = 16777222;  ///to jest jedna potka jak jest 0 to == 0 jak 1 to 16777217
    public static int redPotionsCountValue = 16777222;  ///to jest jedna potka jak jest 0 to == 0 jak 1 to 16777217

    public const int isRunningAnimationOutside = 4535616;
    public const int isRunningAnimationInCity = 4545808;

    public const int isStandingAnimation = 4534400;
    public const int isBeingHitAnimation = 4536960;
    public const int isAttackingBowAlliAnimation = 4536096;
    public const int isAttackingBowEmpAnimation = 4536832;


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



    public static Tuple<int, int>[] PositionsArray =
    {
        new Tuple<int, int>(5, 78),
        new Tuple<int, int>(5, 78),
        new Tuple<int, int>(5, 78),
        new Tuple<int, int>(5, 78),
    };

    public static List<int> KoValuesToTestList = new List<int>()
    {

        12001,
        12106,
        12210,
        12312,
        12409,
        12410,
        12515,
        12720,
        38319,
        40002,
        40003,
        51268,
        64778,
        78309,
        91818,
        105428,
        110119,
        110309,
        110501,
        110604,
        110708,
        110779,
        110812,
        110908,
        111011,
        111215,
        111505,
        111619,
        111808,
        111916,
        112020,
        112119
    };
}