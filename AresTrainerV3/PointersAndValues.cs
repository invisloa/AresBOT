using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace AresTrainerV3;

public static class PointersAndValues
{

    //  x 1126112223        1119396195

    // MAIN OFFSETS
    public static bool isNostalgia = true;
    public const int mouseWaitTimeMs = 1;


    public static string GameProcessName
    {
        get
        {
            if (isNostalgia) { return "Nostalgia.exe"; }
            else { return "Epic Of Ares.exe"; }
        }
    }
    public static string GameWindowProcessName
    {
        get
        {
            if (isNostalgia) { return "Nostalgia"; }
            else { return "Epic Of Ares"; }
        }
    }
    public static string GameWindowVisualName
    {
        get
        {
            if (isNostalgia) { return "Nostalgia"; }
            else { return "Epic Of Ares Client"; }
        }
    }
    public static int baseNormalMOffset
    {
        get
        {
            if (isNostalgia) { return 0x2ad1fc; }
            else { return 0x2ad2fc; }
        }
    }
    public static int fogMOffset
    {
        get
        {
            if (isNostalgia) { return 0x2B03CC; }
            else { return 0x2A9194; }
        }
    }
    public static int antiBlackMOffset
    {
        get
        {
            if (isNostalgia) { return 0x2a9084; }
            else { return 0x2a9184; }
        }
    }




    public static int cameraFogPointer
    {
        get
        {
            if (isNostalgia) { return 0xd16; }
            else { return 0xfb6; }
        }
    }


    public static int cameraBaseMOffset
    {
        get
        {
            if (isNostalgia) { return 0x2AC578; }
            else { return 0x2AC678; }
        }
    }
    public static int mobSelectedMOffset
    {
        get
        {
            if (isNostalgia) { return 0x2A9648; }
            else { return 0x2A9748; }
        }
    }
    public static int MouseoverHighlightedMOffset
    {
        get
        {
            if (isNostalgia) { return 0x2AAA14; }
            else { return 0x2AAB14; }
        }
    }

    public static int inventoryCurrentTabMOffset
    {
        get
        {
            if (isNostalgia) { return 0x2AD1EC; }
            else { return 0x2AD2EC; }
        }
    }

    public static int SellWindowMOffset
    {
        get
        {
            if (isNostalgia) { return 0x2AD208; }
            else { return 0x2AD308; }
        }
    }

    public static int UiWindowMOffset
    {
        get
        {
            if (isNostalgia) { return 0x2AD218; }
            else { return 0x2AD318; }
        }
    }
    public static int CurrentSkillBar1Address
    {
        get
        {
            if (isNostalgia) { return 0x6A9A3C; }
            else { return 0x6A9B3C; }
        }
    }


    public static int CurrentSkillBar2Address
    {
        get
        {
            if (isNostalgia) { return 0x6A9A40; }
            else { return 0x6A9B40; }
        }
    }
    public static int CurrentSkillBar3Address
    {
        get
        {
            if (isNostalgia) { return 0x6A9A44; }
            else { return 0x6AB44; }
        }
    }

    public static int CurrentItemHighlightedType
    {
        get
        {
            if (isNostalgia) { return 0x8C9Ed0; }
            else { return 0x8C9Fd0; }
        }
    }
    public static int isAttackingMob
    {
        get
        {
            if (isNostalgia) { return 0x6aa9fc; }
            else { return 0x6aaafc; }
        }
    }

    // OFF offsets
    public const int hpOffset = 0x148;
    public const int MannaOffset = 0x980;
    public const int WeightOffset = 0x998;
    public const int WeightMaxOffset = 0x99c;
    public const int skill1Offset = 0x05c;
    public const int anim1Offset = 0x3a8;
    public const int anim2Offset = 0x3ac;
    public const int slotHPOffset = 0xbb2;
    public const int slotMannaOffset = 0xbce;
    public const int slotRedPotOffset = 0xbea;
    public const int slotWhitePotOffset = 0xc06;
    public const int slotCandleOffset = 0xc22;
    public const int slotScrollOffset = 0xc3e;
    public const int slotFirstSellOffset = 0xd02;
    public const int MouseoverHighlightedOffset = 0x7c;
    public const int cameraDistancePointer = 0x19c;
    public const int cameraAngleYPointer = 0x1b6;
    public const int cameraAngleXPointer = 0x1a0;
    public const int skillDelayShortPointer = 0x806;
    public const int clickDelayPointer = 0xb2e;
    public const int runSpeedOffset = 0xb8e;
    public const int mapNumberOffset = 0x5a8;
    public const int isInCityOffset = 0x5a4;
    public const int positionXOffset = 0x23c;
    public const int positionYOffset = 0x244;
    public const int positionZOffset = 0x240;
    public const int positionXShortOffset = 0x23e;
    public const int positionYShortOffset = 0x246;

    public const int clickPositionXOffset = 0x544;
    public const int clickPositionYOffset = 0x53c;
    public const int mobSelected = 0xfd;
    public const int AttackSpeedOffset = 0x470;     
    public const int mobBeingTargeted = 0x050;
    public const int typeOfAnimationIsRunning = 0x3b5;
    public const int lastSlotItemStat1 = 0xf84;
    public const int classSelected = 0x7d4;
    public const int visualSkillAttack = 0x64;

    
    public const int ShopWindow2MOffset = 0x90;
    public const int CurrentSkillTabMOffset = 0x58;
    public const int StorageWindow2MOffset = 0x94;
    public const int InventoryWindow2MOffset = 0x60;
    public const int Buff1FirstOffOffset = 0x15c;
    public const int Buff1FirstOffset = 0x118;  // second is 0x150 every next is 0x38 or +70 dec
    public const int Buff2FirstOffset = 0x158;  // second is 0x150 every next is 0x38 or +70 dec
    public const int Buff3FirstOffset = 0x198;  // second is 0x150 every next is 0x38 or +70 dec
    public const int Buff4FirstOffset = 0x1d8;  // second is 0x150 every next is 0x38 or +70 dec

    public const int CurrentSkillTabOffOffset = 0x174;

    public const int ShopWindowOffset1 = 0xc0;
    public const int ShopWindowOffset2 = 0xd8;
    public const int StorageWindowOffset1 = 0xc0;
    public const int StorageWindowOffset2 = 0xd8;
    public const int inventoryWindowOffset1 = 0xc0;
    public const int inventoryWindowOffset2 = 0xd8;
    public const int inventoryCurrentTabOffset = 0x110;
    public const int SellWindowOffset = 0xc0;
    public const int SellItemSelectedOffset = 0x12e;

    public const int AntiBlack1Offset = 0x850;
    public const int AntiBlack2Offset = 0x9b0;
    public const int AntiBlack3Offset = 0xb10;


    // BUFF VALUES

    public const int BuffSpearMeditation = 3353;
    public const int BuffSpearShout = 3354;




    // Class
    public const int ClassKnight = 0;
    public const int ClassArcher = 1;
    public const int ClassSorcerer = 2;
    public const int ClassSpear= 3;


    // values
    public const int runSpeedNormalValue = 16859264;
    public const int runSpeedWhitePotValue = 16859315;
    public const int attackSpeedSpearImpNotLastSkill = 1068948334;
    public const int attackSpeedSpearImp = 1070945622;
    public const int attackSpeedSpearImpBos = 1073741824;
    public const int attackSpeednormalValueBow = 1070945622;
    public const int attackSpeedKishValueBow = 1073741824;
    public const int castingSpeeDelaydZero = 16256;
    public const int castingSpeedDelayOrbWithRosAoe = 16255;

    public const int castingSpeedDelayPlus1 = 16204;
    public const int castingSpeedDelayPlus2 = 16204;
    
    
    
    
    public const int cameraDistanceAnimValue = 1127253120;
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
    // public static int AttackSpeed = 1431715797;
    public static Tuple<int, int> expBotMouseStartingPos = new Tuple<int, int>(930, 500);

    public static int MouseoverItemValue = 43880704;
    public static int MouseoverMobValue = 43881072;
    public static int ItemCount1 = 16777217;
    public static int MouseoverMobValueNoItem = 42106960;
    public static int MouseoverMobValueKharon = 41980528;
    public static int MouseoverItemValueKharon = 43028736;
    // public static int MouseoverItemValueKharon = 42766592;
    // public static int MouseoverItemValueKharon = 42963200;








    public static int mannaPotionsCountValue = 16777257;  ///to jest jedna potka jak jest 0 to == 0 jak 1 to 16777217
    public static int whitePotionsCountValue = 16777222;  ///to jest jedna potka jak jest 0 to == 0 jak 1 to 16777217
    public static int redPotionsCountValue = 16777222;  ///to jest jedna potka jak jest 0 to == 0 jak 1 to 16777217

    public const int isRunningAnimationArcALLIOutside = 4535616;
    public const int isRunningAnimationArcEMPOutside = 4536352;
    public const int isRunningAnimationSorcAlliStaffOutside = 4523712;
    public const int isRunningAnimationSorcAlliOrbOutside = 4363264;
    public const int isRunningAnimationSpearALLIOutside = 4500992;
    
    
    public const int isRunningAnimationArcAlliInCity = 4545808;
    public const int isRunningAnimationArcEmpInCity = 4546528;
    public const int isRunningAnimationSpearAlliInCity = 4545808;



    // is now standing animation
    public const int isStandingAnimationArcerAlliOut = 4534400;
    public const int isStandingAnimationArcerAlliCity = 4550176;
    public const int isStandingAnimationArcerEmpOut = 4535136;
    public const int isStandingAnimationArcerEmpCity = 4550976;
    public const int isStandingAnimationSorcAlliOutStaff = 4522496;
    public const int isStandingAnimationSorcAlliOutOrb = 4331520;
    public const int isStandingAnimationSorcAlliCity = 4550976;
    public const int isStandingAnimationSorcEmpCityF = 4552960;
    public const int isStandingAnimationSorcEmpOutF = 4522944;
    public const int isStandingAnimationSpearAlliOut = 4498752;
    public const int isStandingAnimationSpearAlliCity = 4550176;


    // being hit animation
    public const int isBeingHitSorcAlli = 4446720;
    public const int isBeingHitSorcAlli2 = 4451328;

    

    //4541440



    public const int isBeingHitAnimation = 4536960;
    public const int isAttackingBowAlliAnimation = 4536096;
    public const int isAttackingBowEmpAnimation = 4536832;
    public const int isAttackingSorcAlliAnimation = 4541440;
    public const int isAttackingKnightAlliAnimation = 4425728;
    public const int isAttackingSpearAlliAnimation = 4510144;





    // arcer
    public const int arcerAnim1 = 1161436900;
    public const int arcerAnim2 = 0;
    public const int arcerFirstSkill = 111504;
    public const int arcerEmpBlasting = 110919;
    public const int arcerEmpExplosion = 110719;
    public const int arcerSpeedUpSkill = 12619;
    public const int arcerAlliLastSingle = 12419;
    // spear
    public static int spearSkillAnim1FirstSkill = 1153814902;           //1153712127 anim value    // 1153814902; poprzednia wartosc testowana nie widac widocznej roznicy
    public static int spearSkillAnim1ThirdSkill = 1154085000;
    public static int spearSkillAnim1FiestAoE = 1154553000;  //1154502000;           
    public static int spearSkillAnim2 = 0;                                  // na 0 nie widac wiekszych zmian 1153712127;             // anim max value 1153712127
    public static int spearFirstSkill = 31519;
    public static int spearThirdSkill = 31719;
    public static int spearFirstAoESkill = 31819;
    public static int spearBuffMeditation = 32519;
    public static int spearBuffBawlShout = 32719;
    public static int spearBuffStoneBody = 32919;
    public static int spearBuffShout= 32619;
    public static int spearAllianceFireFury = 32419;
    public static int spearNormalAnim1 = 1152700000;
    // mage
    public static int mageAnim1 = 1162783990; // 15.06.22 1162765990;
    public static int mageAnim2 = 0;
    public static int mageFireSingleLast = 61819;
    public static int mageWaterSingleLast = 51819;
    public static int mageFireAOEleLast = 61919;
    public static int mageWaterAOEleLast = 51919;
    public static int mageSupportFireBarrier = 62719;
    public static int mageSupportLightningBarrier = 52719;
    public static int mageSupportRapid = 62519;
    public static int mageSupportEnergyShield = 63019;
    public static int mageSupportBlastArmor = 62619;

    // KNIGHT
    public static int knightskilllAnim1 = 1135783990;
    public static int knightskilllAnim2 = 0;
    public static int knightNormalAnim1 = 1124500000;
    public static int knightFirstSkill = 120009;
    public static int knightSecondSkill = 120108;
    public static int knightFirstBlunt = 20501;


    // item values


    // cry items



    public static IntPtr baseAddress = IntPtr.Zero;
    public static IntPtr client = IntPtr.Zero;
    public static Memory mem = new Memory();
    //  CHyba nie potrzebne public static InputSimulator inputSimulator = new InputSimulator();

    public static Color blackPixelColor = ColorTranslator.FromHtml("#000000");


}