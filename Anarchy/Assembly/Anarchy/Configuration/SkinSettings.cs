﻿using UnityEngine;

namespace Anarchy.Configuration
{
    public static class SkinSettings
    {
        public static readonly string HumansPath = Application.dataPath + "/Configuration/HumanSkins/";
        public static readonly string MapsPath = Application.dataPath + "/Configuration/MapSkins/";
        public static readonly string SkyboxesPath = Application.dataPath + "/Configuration/SkyboxSkins/";
        public static readonly string TitansPath = Application.dataPath + "/Configuration/TitanSkins/";

        public static BoolSetting DisableCustomGas = new BoolSetting(nameof(DisableCustomGas), false);

        public static StringSetting CitySet = new StringSetting(nameof(CitySet), StringSetting.NotDefine);
        public static IntSetting CitySkins = new IntSetting(nameof(CitySkins), 1);

        public static StringSetting CustomMapSet = new StringSetting(nameof(CustomMapSet), StringSetting.NotDefine);
        public static IntSetting CustomSkins = new IntSetting(nameof(CustomSkins), 1);

        public static StringSetting ForestSet = new StringSetting(nameof(ForestSet), StringSetting.NotDefine);
        public static IntSetting ForestSkins = new IntSetting(nameof(ForestSkins), 1);

        public static StringSetting HumanSet = new StringSetting(nameof(HumanSet), StringSetting.NotDefine);
        public static IntSetting HumanSkins = new IntSetting(nameof(HumanSkins), 1);

        public static StringSetting SkyboxSet = new StringSetting(nameof(SkyboxSet), StringSetting.NotDefine);
        public static BoolSetting SkyboxSkinsEnabled = new BoolSetting(nameof(SkyboxSkinsEnabled), true);

        public static IntSetting TitanSkins = new IntSetting(nameof(TitanSkins), 1);
        public static StringSetting TitanSet = new StringSetting(nameof(TitanSet), StringSetting.NotDefine);

        public static bool SkinsCheck(IntSetting set)
        {
            return set.Value > 0 && (set.Value == 2 || IN_GAME_MAIN_CAMERA.GameType == GameType.Single || PhotonNetwork.IsMasterClient);
        }
    }
}
