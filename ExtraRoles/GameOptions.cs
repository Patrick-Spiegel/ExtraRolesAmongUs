using Essentials.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraRolesMod
{
    public partial class HarmonyMain
    {
        //This section uses the https://github.com/DorCoMaNdO/Reactor-Essentials framework


        public static CustomNumberOption
            medicSpawnChance = CustomOption.AddNumber("Medic Spawn Chance", 100, 0, 100, 5);

        public static CustomNumberOption officerSpawnChance =
            CustomOption.AddNumber("Officer Spawn Chance", 100, 0, 100, 5);

        public static CustomNumberOption engineerSpawnChance =
            CustomOption.AddNumber("Engineer Spawn Chance", 100, 0, 100, 5);

        public static CustomNumberOption
            jokerSpawnChance = CustomOption.AddNumber("Joker Spawn Chance", 100, 0, 100, 5);

        public static CustomToggleOption showMedic = CustomOption.AddToggle("Show Medic", false);
        public static CustomStringOption showShieldedPlayer = CustomOption.AddString("Show Shielded Player",
            new[] { "Self", "Medic", "Self+Medic", "Everyone" });
        public static CustomToggleOption playerMurderIndicator =
            CustomOption.AddToggle("Murder Attempt Indicator for Shielded Player", false);

        public static CustomToggleOption medicReportSwitch = CustomOption.AddToggle("Show Medic Reports", true);

        public static CustomNumberOption medicReportNameDuration =
            CustomOption.AddNumber("Time Where Medic Reports Will Have Name", 0, 0, 60, 2.5f);

        public static CustomNumberOption medicReportColorDuration =
            CustomOption.AddNumber("Time Where Medic Reports Will Have Color Type", 15, 0, 120, 2.5f);


        public static CustomToggleOption showOfficer = CustomOption.AddToggle("Show Officer", false);
        public static CustomNumberOption OfficerKillCooldown =
            CustomOption.AddNumber("Officer Kill Cooldown", 30f, 10f, 60f, 2.5f);
        public static CustomStringOption
            officerKillBehaviour = CustomOption.AddString("Officer Kill Behaviour", new[] { "Impostor", "Joker", "Crew Die", "Anyone" });
        public static CustomToggleOption officerShouldDieToShieldedPlayers =
         CustomOption.AddToggle("Officer Dies When Attacking Shielded Players", true);



        public static CustomToggleOption showEngineer = CustomOption.AddToggle("Show Engineer", false);
        public static CustomToggleOption showJoker = CustomOption.AddToggle("Show Joker", false);

    }
}
