﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using Textdata;
using sql;
using MyIni;
namespace _DBtoMedia_1._1
{
    class Program
    {

        static void Main(string[] args)
        {

            string[,] Queries = {

                ////Koleksiyon kitabı
                {"collectionbook_item.txt","SELECT [Service] ,[CodeName128] ,[ObjName128] ,[ThemeCodeName128] ,[SlotIndex] ,[Story128] ,[DDJFile128] FROM [dbo].[_RefCollectionBook_Item] WHERE [Service] = 1 "},
                {"collectionbook_theme.txt","SELECT [Service] ,[ID] ,[CodeName128] ,[ObjName128] ,[Name128] ,[Desc128] ,[CompleteNum] FROM [dbo].[_RefCollectionBook_Theme] WHERE [Service] = 1 "},

                ////Event
                {"eventdata.txt","SELECT [Service] ,[CodeName] ,[DescName] FROM [dbo].[_RefEvent] WHERE [Service] = 1 "},
                {"eventzonedata.txt","SELECT [Service] ,[ID] ,[ZoneName] ,[EventName] ,[Param1] ,[Param2] ,[Param3] ,[Param4] ,[Param5] ,[strParam1] ,[strParam2] ,[strParam3] ,[strParam4] ,[strParam5] FROM [dbo].[_RefEventZone] WHERE [Service] = 1 "},
                
                ////
                {"fmncategorytreedata.txt","SELECT [Service] ,[CategoryName] ,[StringID] ,[ParentCategoryName] ,[TidGroupID] ,[Degree] FROM [dbo].[_RefFmnCategoryTree] WHERE [Service] = 1 "},
                {"fmntidgroupmapdata.txt","SELECT [Service] ,[TidGroupID] ,[TypeID1] ,[TypeID2] ,[TypeID3] ,[TypeID4] FROM [dbo].[_RefFmnTidGroupMap] WHERE [Service] = 1 "},

                ////Gacha Item
                {"gachaitemset.txt","SELECT [Service] ,[Set_ID] ,[RefItemID] ,[Ratio] ,[Count] ,[GachaID] ,[Visible] ,[param1] ,[param1_Desc128] ,[param2] ,[param2_Desc128] ,[param3] ,[param3_Desc128] ,[param4] ,[param4_Desc128] FROM [dbo].[_RefGachaItemSet] WHERE [Service] = 1 "},
                {"gachanpcmap.txt","SELECT [Service] ,[NPC_ID] ,[SelectionGachaID] ,[WasteGachaID] FROM [dbo].[_RefGachaNpcMap] WHERE [Service] = 1 "},

                         ////Gameworld
                        {"gameworlddata.txt","SELECT [ID] ,[WorldCodeName128] ,[Type] ,[WorldMaxCount] ,[WorldMaxUserCount] ,[ConfigGroupCodeName128] FROM [dbo].[_RefGame_World]"},
                        ////Gameworld_config
                        {"gameworldconfigdata.txt","SELECT [GroupCodeName128] ,[ValueCodeName128] ,[Type] ,[Value] FROM [dbo].[_RefGame_World_Config]"},
                        ////Groupworld_config_forclient
                        {"groupworld_config_forclient.txt","SELECT [Service] ,[GroupCodeName128] ,[Value] FROM [dbo].[_RefGameWorldGroup_Config] WHERE [Service] = 1"},
                        ////hwanleveldata
                        {"hwanleveldata.txt","SELECT [HwanLevel] ,[Title_CH70] ,[Title_EU70] FROM [dbo].[_RefHWANLevel]"},
                        ////LevelData
                        {"leveldata.txt","SELECT [Lvl] ,[Exp_C] ,[Exp_M] ,[Cost_M] ,[Cost_ST] ,[GUST_Mob_Exp] ,[JobExp_Trader] ,[JobExp_Robber] ,[JobExp_Hunter] ,[Exp_P] ,[MaxSP] FROM [dbo].[_RefLevel]"},
                        // //MagicOpt
                        {"magicoption.txt","SELECT [Service] ,[ID] ,[MOptName128] ,[AttrType] ,[MLevel] ,[Prob] ,[Weight] ,[Param1] ,[Param2] ,[Param3] ,[Param4] ,[Param5] ,[Param6] ,[Param7] ,[Param8] ,[Param9] ,[Param10] ,[Param11] ,[Param12] ,[Param13] ,[Param14] ,[Param15] ,[Param16] ,[ExcFunc1] ,[ExcFunc2] ,[ExcFunc3] ,[ExcFunc4] ,[ExcFunc5] ,[ExcFunc6] ,[AvailItemGroup1] ,[ReqClass1] ,[AvailItemGroup2] ,[ReqClass2] ,[AvailItemGroup3] ,[ReqClass3] ,[AvailItemGroup4] ,[ReqClass4] ,[AvailItemGroup5] ,[ReqClass5] ,[AvailItemGroup6] ,[ReqClass6] ,[AvailItemGroup7] ,[ReqClass7] ,[AvailItemGroup8] ,[ReqClass8] ,[AvailItemGroup9] ,[ReqClass9] ,[AvailItemGroup10] ,[ReqClass10] FROM [dbo].[_RefMagicOpt] WHERE [Service] = 1"},       
                        ////MAgicOptAssign
                        {"magicoptionassign.txt","SELECT [Service] ,[Race] ,[TID3] ,[TID4] ,[AvailMOpt1] ,[AvailMOpt2] ,[AvailMOpt3] ,[AvailMOpt4] ,[AvailMOpt5] ,[AvailMOpt6] ,[AvailMOpt7] ,[AvailMOpt8] ,[AvailMOpt9] ,[AvailMOpt10] ,[AvailMOpt11] ,[AvailMOpt12] ,[AvailMOpt13] ,[AvailMOpt14] ,[AvailMOpt15] ,[AvailMOpt16] ,[AvailMOpt17] ,[AvailMOpt18] ,[AvailMOpt19] ,[AvailMOpt20] ,[AvailMOpt21] ,[AvailMOpt22] ,[AvailMOpt23] ,[AvailMOpt24] ,[AvailMOpt25] FROM [dbo].[_RefMagicOptAssign] WHERE Service = 1"},   
                        ////MagicOpt BY item level Data
                        {"refmagicoptbyitemoptleveldata.txt","SELECT [Link] ,[RefMagicOptID] ,[MagicOptValue] ,[TooltipType] ,[TooltipCodename] FROM [dbo].[_RefMagicOptByItemOptLevel]"},
                        ////MAgicOptAssignfortradeequip
                        {"magicoptionassignfortradeequip.txt","SELECT [Service] ,[Race] ,[TID3] ,[TID4] ,[AvailMOpt1] ,[AvailMOpt2] ,[AvailMOpt3] ,[AvailMOpt4] ,[AvailMOpt5] ,[AvailMOpt6] ,[AvailMOpt7] ,[AvailMOpt8] ,[AvailMOpt9] ,[AvailMOpt10] ,[AvailMOpt11] ,[AvailMOpt12] ,[AvailMOpt13] ,[AvailMOpt14] ,[AvailMOpt15] ,[AvailMOpt16] ,[AvailMOpt17] ,[AvailMOpt18] ,[AvailMOpt19] ,[AvailMOpt20] ,[AvailMOpt21] ,[AvailMOpt22] ,[AvailMOpt23] ,[AvailMOpt24] ,[AvailMOpt25] FROM [dbo].[_RefMagicOptAssignForTradeEquip] WHERE Service = 1"},

                        {"characterdatamain.txt","SELECT _RefObjCommon.Service, _RefObjCommon.ID, _RefObjCommon.CodeName128, _RefObjCommon.ObjName128, _RefObjCommon.OrgObjCodeName128, _RefObjCommon.NameStrID128, _RefObjCommon.DescStrID128, _RefObjCommon.CashItem, _RefObjCommon.Bionic, _RefObjCommon.TypeID1, _RefObjCommon.TypeID2, _RefObjCommon.TypeID3, _RefObjCommon.TypeID4, _RefObjCommon.DecayTime, _RefObjCommon.Country, _RefObjCommon.Rarity, _RefObjCommon.CanTrade, _RefObjCommon.CanSell, _RefObjCommon.CanBuy, _RefObjCommon.CanBorrow, _RefObjCommon.CanDrop, _RefObjCommon.CanPick, _RefObjCommon.CanRepair, _RefObjCommon.CanRevive, _RefObjCommon.CanUse, _RefObjCommon.CanThrow, _RefObjCommon.Price, _RefObjCommon.CostRepair, _RefObjCommon.CostRevive, _RefObjCommon.CostBorrow, _RefObjCommon.KeepingFee, _RefObjCommon.SellPrice, _RefObjCommon.ReqLevelType1, _RefObjCommon.ReqLevel1, _RefObjCommon.ReqLevelType2, _RefObjCommon.ReqLevel2, _RefObjCommon.ReqLevelType3, _RefObjCommon.ReqLevel3, _RefObjCommon.ReqLevelType4, _RefObjCommon.ReqLevel4, _RefObjCommon.MaxContain, _RefObjCommon.RegionID, _RefObjCommon.Dir, _RefObjCommon.OffsetX, _RefObjCommon.OffsetY, _RefObjCommon.OffsetZ, _RefObjCommon.Speed1, _RefObjCommon.Speed2, _RefObjCommon.Scale, _RefObjCommon.BCHeight, _RefObjCommon.BCRadius, _RefObjCommon.EventID, _RefObjCommon.AssocFileObj128, _RefObjCommon.AssocFileDrop128, _RefObjCommon.AssocFileIcon128, _RefObjCommon.AssocFile1_128, _RefObjCommon.AssocFile2_128, _RefObjChar.Lvl, _RefObjChar.CharGender, _RefObjChar.MaxHP, _RefObjChar.MaxMP, _RefObjChar.InventorySize, _RefObjChar.CanStore_TID1, _RefObjChar.CanStore_TID2, _RefObjChar.CanStore_TID3, _RefObjChar.CanStore_TID4, _RefObjChar.CanBeVehicle, _RefObjChar.CanControl, _RefObjChar.DamagePortion, _RefObjChar.MaxPassenger, _RefObjChar.AssocTactics, _RefObjChar.PD, _RefObjChar.MD, _RefObjChar.PAR, _RefObjChar.MAR, _RefObjChar.ER, _RefObjChar.BR, _RefObjChar.HR, _RefObjChar.CHR, _RefObjChar.ExpToGive, _RefObjChar.CreepType, _RefObjChar.Knockdown, _RefObjChar.KO_RecoverTime, _RefObjChar.DefaultSkill_1, _RefObjChar.DefaultSkill_2, _RefObjChar.DefaultSkill_3, _RefObjChar.DefaultSkill_4, _RefObjChar.DefaultSkill_5, _RefObjChar.DefaultSkill_6, _RefObjChar.DefaultSkill_7, _RefObjChar.DefaultSkill_8, _RefObjChar.DefaultSkill_9, _RefObjChar.DefaultSkill_10, _RefObjChar.TextureType, _RefObjChar.Except_1, _RefObjChar.Except_2, _RefObjChar.Except_3, _RefObjChar.Except_4, _RefObjChar.Except_5, _RefObjChar.Except_6, _RefObjChar.Except_7, _RefObjChar.Except_8, _RefObjChar.Except_9, _RefObjChar.Except_10 FROM _RefObjCommon INNER JOIN _RefObjChar ON _RefObjCommon.Link = _RefObjChar.ID WHERE (_RefObjCommon.CodeName128 like 'MOB%' OR _RefObjCommon.CodeName128 like 'NPC%' OR _RefObjCommon.CodeName128 like 'CHAR%' OR _RefObjCommon.CodeName128 like 'COS%' OR _RefObjCommon.CodeName128 like 'STRUCTURE%' OR _RefObjCommon.CodeName128 like 'MOV%') AND _RefObjCommon.ID BETWEEN 0 AND 999999 AND _RefObjCommon.Service = 1"},
                        ////Itemdata
                        {"itemdatamain.txt","SELECT _RefObjCommon.Service, _RefObjCommon.ID, _RefObjCommon.CodeName128, _RefObjCommon.ObjName128, _RefObjCommon.OrgObjCodeName128, _RefObjCommon.NameStrID128, _RefObjCommon.DescStrID128, _RefObjCommon.CashItem, _RefObjCommon.Bionic, _RefObjCommon.TypeID1, _RefObjCommon.TypeID2, _RefObjCommon.TypeID3, _RefObjCommon.TypeID4, _RefObjCommon.DecayTime, _RefObjCommon.Country, _RefObjCommon.Rarity, _RefObjCommon.CanTrade, _RefObjCommon.CanSell, _RefObjCommon.CanBuy, _RefObjCommon.CanBorrow, _RefObjCommon.CanDrop, _RefObjCommon.CanPick, _RefObjCommon.CanRepair, _RefObjCommon.CanRevive, _RefObjCommon.CanUse, _RefObjCommon.CanThrow, _RefObjCommon.Price, _RefObjCommon.CostRepair, _RefObjCommon.CostRevive, _RefObjCommon.CostBorrow, _RefObjCommon.KeepingFee, _RefObjCommon.SellPrice, _RefObjCommon.ReqLevelType1, _RefObjCommon.ReqLevel1, _RefObjCommon.ReqLevelType2, _RefObjCommon.ReqLevel2, _RefObjCommon.ReqLevelType3, _RefObjCommon.ReqLevel3, _RefObjCommon.ReqLevelType4, _RefObjCommon.ReqLevel4, _RefObjCommon.MaxContain, _RefObjCommon.RegionID, _RefObjCommon.Dir, _RefObjCommon.OffsetX, _RefObjCommon.OffsetY, _RefObjCommon.OffsetZ, _RefObjCommon.Speed1, _RefObjCommon.Speed2, _RefObjCommon.Scale, _RefObjCommon.BCHeight, _RefObjCommon.BCRadius, _RefObjCommon.EventID, _RefObjCommon.AssocFileObj128, _RefObjCommon.AssocFileDrop128, _RefObjCommon.AssocFileIcon128, _RefObjCommon.AssocFile1_128, _RefObjCommon.AssocFile2_128, _RefObjItem.MaxStack, _RefObjItem.ReqGender, _RefObjItem.ReqStr, _RefObjItem.ReqInt, _RefObjItem.ItemClass, _RefObjItem.SetID, REPLACE(_RefObjItem.Dur_L,',','.'), REPLACE(_RefObjItem.Dur_U,',','.'), REPLACE(_RefObjItem.PD_L,',','.'), REPLACE(_RefObjItem.PD_U,',','.'), REPLACE(_RefObjItem.PDInc,',','.'), REPLACE(_RefObjItem.ER_L,',','.'), REPLACE(_RefObjItem.ER_U,',','.'), REPLACE(_RefObjItem.ERInc,',','.'), REPLACE(_RefObjItem.PAR_L,',','.'), REPLACE(_RefObjItem.PAR_U,',','.'), REPLACE(_RefObjItem.PARInc,',','.'), REPLACE(_RefObjItem.BR_L,',','.'), REPLACE(_RefObjItem.BR_U,',','.'), REPLACE(_RefObjItem.MD_L,',','.'), REPLACE(_RefObjItem.MD_U,',','.'), REPLACE(_RefObjItem.MDInc,',','.'), REPLACE(_RefObjItem.MAR_L,',','.'), REPLACE(_RefObjItem.MAR_U,',','.'), REPLACE(_RefObjItem.MARInc,',','.'), REPLACE(_RefObjItem.PDStr_L,',','.'), REPLACE(_RefObjItem.PDStr_U,',','.'), REPLACE(_RefObjItem.MDInt_L,',','.'), REPLACE(_RefObjItem.MDInt_U,',','.'), _RefObjItem.Quivered, _RefObjItem.Ammo1_TID4, _RefObjItem.Ammo2_TID4, _RefObjItem.Ammo3_TID4, _RefObjItem.Ammo4_TID4, _RefObjItem.Ammo5_TID4, _RefObjItem.SpeedClass, _RefObjItem.TwoHanded, _RefObjItem.Range, REPLACE(_RefObjItem.PAttackMin_L,',','.'), REPLACE(_RefObjItem.PAttackMin_U,',','.'), REPLACE(_RefObjItem.PAttackMax_L,',','.'), REPLACE(_RefObjItem.PAttackMax_U,',','.'), REPLACE(_RefObjItem.PAttackInc,',','.'), REPLACE(_RefObjItem.MAttackMin_L,',','.'), REPLACE(_RefObjItem.MAttackMin_U,',','.'), REPLACE(_RefObjItem.MAttackMax_L,',','.'), REPLACE(_RefObjItem.MAttackMax_U,',','.'), REPLACE(_RefObjItem.MAttackInc,',','.'), REPLACE(_RefObjItem.PAStrMin_L,',','.'), REPLACE(_RefObjItem.PAStrMin_U,',','.'), REPLACE(_RefObjItem.PAStrMax_L,',','.'), REPLACE(_RefObjItem.PAStrMax_U,',','.'), REPLACE(_RefObjItem.MAInt_Min_L,',','.'), REPLACE(_RefObjItem.MAInt_Min_U,',','.'), REPLACE(_RefObjItem.MAInt_Max_L,',','.'), REPLACE(_RefObjItem.MAInt_Max_U,',','.'), REPLACE(_RefObjItem.HR_L,',','.'), REPLACE(_RefObjItem.HR_U,',','.'), REPLACE(_RefObjItem.HRInc,',','.'), REPLACE(_RefObjItem.CHR_L,',','.'), REPLACE(_RefObjItem.CHR_U,',','.'), _RefObjItem.Param1, _RefObjItem.Desc1_128, _RefObjItem.Param2,  LTRIM(RTRIM(_RefObjItem.Desc2_128)), _RefObjItem.Param3, _RefObjItem.Desc3_128, _RefObjItem.Param4, _RefObjItem.Desc4_128, _RefObjItem.Param5, _RefObjItem.Desc5_128, _RefObjItem.Param6, _RefObjItem.Desc6_128, _RefObjItem.Param7, _RefObjItem.Desc7_128, _RefObjItem.Param8, _RefObjItem.Desc8_128, _RefObjItem.Param9, _RefObjItem.Desc9_128, _RefObjItem.Param10, _RefObjItem.Desc10_128, _RefObjItem.Param11, _RefObjItem.Desc11_128, _RefObjItem.Param12, _RefObjItem.Desc12_128, _RefObjItem.Param13, _RefObjItem.Desc13_128, _RefObjItem.Param14, _RefObjItem.Desc14_128, _RefObjItem.Param15, _RefObjItem.Desc15_128, _RefObjItem.Param16, _RefObjItem.Desc16_128, _RefObjItem.Param17, _RefObjItem.Desc17_128, _RefObjItem.Param18, _RefObjItem.Desc18_128, _RefObjItem.Param19, _RefObjItem.Desc19_128, _RefObjItem.Param20, _RefObjItem.Desc20_128, _RefObjItem.MaxMagicOptCount, _RefObjItem.ChildItemCount FROM _RefObjCommon INNER JOIN _RefObjItem ON _RefObjCommon.Link = _RefObjItem.ID WHERE _RefObjCommon.CodeName128 like 'ITEM%' AND _RefObjCommon.ID BETWEEN 0 AND 999999 AND _RefObjCommon.Service = 1"},       
                        // //Items in shops
                        {"refshopgoods.txt","SELECT [Service] ,[Country] ,[RefTabCodeName] ,[RefPackageItemCodeName] ,[SlotIndex] ,[Param1] ,[Param1_Desc128] ,[Param2] ,[Param2_Desc128] ,[Param3] ,[Param3_Desc128] ,[Param4] ,[Param4_Desc128] FROM [dbo].[_RefShopGoods]WHERE [Service] = 1 "},
                        {"refpackageitem.txt","SELECT [Service] ,[Country] ,[ID] ,[CodeName128] ,[SaleTag] ,[ExpandTerm] ,[NameStrID] ,[DescStrID] ,[AssocFileIcon] ,[Param1] ,[Param1_Desc128] ,[Param2] ,[Param2_Desc128] ,[Param3] ,[Param3_Desc128] ,[Param4] ,[Param4_Desc128] FROM [dbo].[_RefPackageItem] WHERE [Service] = 1 "},
                        {"refscrapofpackageitem.txt","SELECT [Service] ,[Country] ,[RefPackageItemCodeName] ,[RefItemCodeName] ,[OptLevel] ,[Variance] ,[Data] ,[MagParamNum] ,[MagParam1] ,[MagParam2] ,[MagParam3] ,[MagParam4] ,[MagParam5] ,[MagParam6] ,[MagParam7] ,[MagParam8] ,[MagParam9] ,[MagParam10] ,[MagParam11] ,[MagParam12] ,[Param1] ,[Param1_Desc128] ,[Param2] ,[Param2_Desc128] ,[Param3] ,[Param3_Desc128] ,[Param4] ,[Param4_Desc128] ,[Index] FROM [dbo].[_RefScrapOfPackageItem]WHERE [Service] = 1 "},
                        {"refpricepolicyofitem.txt","SELECT [Service] ,[Country] ,[RefPackageItemCodeName] ,[PaymentDevice] ,[PreviousCost] ,[Cost] ,[Param1] ,[Param1_Desc128] ,[Param2] ,[Param2_Desc128] ,[Param3] ,[Param3_Desc128] ,[Param4] ,[Param4_Desc128] FROM [dbo].[_RefPricePolicyOfItem]WHERE [Service] = 1 "},                 
                        ////OtionalTeleport
                        {"refoptionalteleport.txt","SELECT [Service] ,[ID] ,[ObjName128] ,[ZoneName128] ,[RegionID] ,[Pos_X] ,[Pos_Y] ,[Pos_Z] ,[WorldID] ,[RegionIDGroup] ,[MapPoint] ,[LevelMin] ,[LevelMax] ,[Param1] ,[Param1_Desc_128] ,[Param2] ,[Param2_Desc_128] ,[Param3] ,[Param3_Desc_128] FROM [dbo].[_RefOptionalTeleport] WHERE [Service] = 1 "}, 
                         ////usableresobjiddata
                        {"usableresobjiddata.txt","SELECT [Service] ,[RefObjID] FROM [dbo].[_RefCharGen] WHERE [Service] = 1"},
                        ////tradeconflict_promotion
                        {"tradeconflict_promotion.txt","SELECT [PromotionPhase] ,[ReqType] ,[Param1_128] ,[Param2_128] ,[Param3_128] ,[Param4_128] ,[Param5_128] FROM [dbo].[_RefTradeConflict_PromotionReq] WHERE [Service] = 1"},
                        ////tradeconflict_promotion
                        {"tradeconflict_joblevel.txt","SELECT [JobLevel] ,[JobExp] ,[PromotionReq] FROM [dbo].[_RefTradeConflict_JobLevel]"},
                        ////Teleport
                        {"teleportlink.txt","SELECT [Service] ,[OwnerTeleport] ,[TargetTeleport] ,[Fee] ,[RestrictBindMethod] ,[RunTimeTeleportMethod] ,[CheckResult] ,[Restrict1] ,[Data1_1] ,[Data1_2] ,[Restrict2] ,[Data2_1] ,[Data2_2] ,[Restrict3] ,[Data3_1] ,[Data3_2] ,[Restrict4] ,[Data4_1] ,[Data4_2] ,[Restrict5] ,[Data5_1] ,[Data5_2] FROM [dbo].[_RefTeleLink] WHERE Service = 1"},
                        {"teleportdata.txt","SELECT [Service] ,[ID] ,[CodeName128] ,[AssocRefObjID] ,[ZoneName128] ,[GenRegionID] ,[GenPos_X] ,[GenPos_Y] ,[GenPos_Z] ,[GenAreaRadius] ,[CanBeResurrectPos] ,[CanGotoResurrectPos] ,[GenWorldID] FROM [dbo].[_RefTeleport] WHERE Service = 1"},
                        ////tradeconflict_promotion
                        {"refupgradeequipitem.txt","SELECT [Service] ,[BeforeRefID] ,[BeforeOptLevel] ,[UpgradeRefID] ,[UpgradeOptLevel] FROM [dbo].[_RefUpgradeEquipItem] WHERE [Service] = 1"},
 

                         ////MagicOpt Group
                        {"refmagicoptgroup.txt"," SELECT [Service] ,[LinkID] ,[MagicType] ,[CodeName128] ,[MOptID] ,[MOptLevel] ,[Value] ,[Param1] ,[Param1_Desc] ,[Param2] ,[Param2_Desc] FROM [dbo].[_RefMagicOptGroup] WHERE Service = 1"},
                        ////RefMappingShopGroup
                        {"refmappingshopgroup.txt","SELECT [Service] ,[Country] ,[RefShopGroupCodeName] ,[RefShopCodeName] FROM [dbo].[_RefMappingShopGroup] WHERE Service = 1"},
                        ////RefMappingShopWithTab
                        {"refmappingshopwithtab.txt","SELECT [Service] ,[Country] ,[RefShopCodeName] ,[RefTabGroupCodeName] FROM [dbo].[_RefMappingShopWithTab] WHERE Service = 1;"},
                        ////Quest
                        {"questdata.txt","SELECT [Service] ,[ID] ,[CodeName] ,[Level] ,[DescName] ,[NameString] ,[PayString] ,[ContentsString] ,[PayContents] ,[NoticeNPC] ,[NoticeCondition] FROM [dbo].[_RefQuest] WHERE Service = 1"},
                        {"refqusetreward.txt","SELECT [QuestID] ,[QuestCodeName] ,[IsView] ,[IsBasicReward] ,[IsItemReward] ,[IsCheckCondition] ,[IsCheckCountry] ,[SelectionCnt] ,[IsCheckClass] ,[IsCheckGender] ,[Gold] ,[Exp] ,[SPExp] ,[SP] ,[AP] ,[APType] ,[Hwan] ,[Inventory] ,[ItemRewardType] ,[Param1] ,[Param1_Desc] ,[Param2] ,[Param2_Desc] ,[Param3] ,[Param3_Desc] FROM [dbo].[_RefQuestReward] WHERE Service = 1 "},
                        {"refquestrewarditems.txt","SELECT [QuestID] ,[QuestCodeName] ,[RewardType] ,[ItemCodeName] ,[RentItemCodeName] ,[OptionalItemCode] ,[OptionalItemCnt] ,[AchieveQuantity] ,[Param1] ,[Param1_Desc] ,[Param2] ,[Param2_Desc] FROM [dbo].[_RefQuestRewardItems] WHERE Service = 1"},
                        {"refsetitemgroup.txt","SELECT [Service] ,[ID] ,[CodeName128] ,[ObjName128] ,[NameStrID128] ,[DescStrID128] ,[SetEffectMask] ,[SetMagicMask] ,[2SetMOptGroupID] ,[3SetMOptGroupID] ,[4SetMOptGroupID] ,[5SetMOptGroupID] ,[6SetMOptGroupID] ,[7SetMOptGroupID] ,[8SetMOptGroupID] ,[9SetMOptGroupID] ,[10SetMOptGroupID] ,[11SetMOptGroupID] FROM [dbo].[_RefSetItemGroup] WHERE Service = 1"},                 
                        ////Shop
                        {"refshop.txt","SELECT [Service] ,[Country] ,[ID] ,[CodeName128] ,[Param1] ,[Param1_Desc128] ,[Param2] ,[Param2_Desc128] ,[Param3] ,[Param3_Desc128] ,[Param4] ,[Param4_Desc128] FROM [dbo].[_RefShop] WHERE Service = 1"},
                        {"shopgroupdata.txt","SELECT [Service] ,[GroupID] ,[CodeName128] ,[StrID128_Group] FROM [dbo].[_RefShopItemGroup] WHERE Service = 1"},               
                        ////ShopTab
                        {"refshoptab.txt","SELECT [Service] ,[Country] ,[ID] ,[CodeName128] ,[RefTabGroupCodeName] ,[StrID128_Tab] FROM [dbo].[_RefShopTab] WHERE Service = 1"},
                        {"refshoptabgroup.txt","SELECT [Service] ,[Country] ,[ID] ,[CodeName128] ,[StrID128_Group] FROM [dbo].[_RefShopTabGroup] WHERE Service = 1"},     
                        ////Fortress
                        {"refsiegeblessbuff.txt","SELECT [Service] ,[BlessID] ,[FortressID] ,[RefBlessBuffID] ,[NeedGold] ,[NeedGP] FROM [dbo].[_RefSiegeBlessBuff] WHERE Service = 1"},
                        {"refsiegedungeon.txt","SELECT [Service] ,[FortressID] ,[WorldID] ,[MaxCreateCount] ,[EntryGold] ,[EntryGP] FROM [dbo].[_RefSiegeDungeon] WHERE Service = 1"},
                        {"siegefortress.txt","SELECT [Service] ,[FortressID] ,[CodeName128] ,[Name] ,[NameID128] ,[LinkedTeleportCodeName] ,[Scale] ,[MaxAdmission] ,[MaxGuard] ,[MaxBarricade] ,[TaxTargets] ,[RequestFee] ,[CrestPath128] ,[RequestNPCName128] FROM [dbo].[_RefSiegeFortress] WHERE Service = 1"},
                        {"siegefortressbattlerank.txt","SELECT TOP 1000000 [Service] ,[RankLvl] ,[RankName] ,[ReqPKCount] ,[BindedSkillID] ,[CrestPath128] FROM [dbo].[_RefSiegeFortressBattleRank] WHERE Service = 1"},
                        {"siegefortressguard.txt","SELECT [Service] ,[FortressID] ,[GuardRefObjID] FROM [dbo].[_RefSiegeFortressGuard] WHERE Service = 1"},
                        {"siegefortressitemforge.txt","SELECT [Service] ,[FortressID] ,[RefItemID] ,[ReqGold] ,[ReqGP] ,[ForgeTimeMin] FROM [dbo].[_RefSiegeFortressItemForge] WHERE Service = 1"},
                        {"siegestructupgradedata.txt","SELECT [Service] ,[Structname] ,[BaseStructcodename] ,[UpgradeStructname1] ,[UpgradeStructname2] ,[UpgradeStructname3] ,[UpgradeStructname4] FROM [dbo].[_RefSiegeStructUpgrade] WHERE Service = 1"},
                        {"skilldatamain.txt","SELECT * FROM [dbo].[_RefSkill] WHERE Service = 1 AND ID BETWEEN 0 AND 999999"},

            };


            dep dep = new dep();

            Console.WriteLine("------------------------\n _DBtoMedia \n Author: ExceeN \n Version 0.1 \n------------------------");

            for(int i = 0;i < 57;i++){
                dep.txtClear(Queries[i, 0]);
                dep.openTxt(Queries[i, 0]);
                dep.getAndWrite(Queries[i,1]);
     //           dep.txtWrite("//Made in Turkiye (ExceeN)", true);
                Console.WriteLine("Media/"+Queries[i,0]);
                dep.closeTxt();
             }
            

            
            IniFile ini = new IniFile();

            if (ini.getSetting("AutoEnc", "SKILLDATA") == "1")
            {
                Console.WriteLine("ENCODING...");
                  dep.skillDataENC();


            }


           


        
           





            //Console.ReadKey();
        
        }
    }
}
