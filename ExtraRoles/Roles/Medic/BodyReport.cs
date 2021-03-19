using System;
using System.Collections.Generic;
using static ExtraRolesMod.ExtraRoles;

namespace ExtraRolesMod.Roles.Medic
{
    //body report class for when medic reports a body
    public class BodyReport
    {
        public DeathReason DeathReason { get; set; }
        public PlayerControl Killer { get; set; }
        public PlayerControl Reporter { get; set; }
        public float KillAge { get; set; }

        public static string ParseBodyReport(BodyReport br)
        {
            var age = Math.Round(br.KillAge / 1000);
            if (age >= Main.Config.medicKillerColorDuration)
            {
                return @$"Body Report:
The corpse is too old to gain information from.
The victim appears to have died {age}s ago";
            }
            else if (br.DeathReason == (DeathReason)3)
            {
                return $@"Body Report:
The cause of death appears to be suicide. 
The victim died {age}s ago";
            }
            else if (age < Main.Config.medicKillerNameDuration)
            {
                var colors = new Dictionary<byte, string>()
                {
                    {0, "red"},
                    {1, "blue"},
                    {2, "green"},
                    {3, "pink"},
                    {4, "orange"},
                    {5, "yellow"},
                    {6, "black"},
                    {7, "white"},
                    {8, "purple"},
                    {9, "brown"},
                    {10, "cyan"},
                    {11, "lime"},
                };
                var typeOfColor = colors[br.Killer.Data.ColorId];
                return $@"Body Report:
Traces of a {typeOfColor} fabric has been found on the victim. 
The victim appears to have died {age}s ago";
            }
            else
            {
                //TODO (make the type of color be written to chat
                var colors = new Dictionary<byte, string>()
                {
                    {0, "darker"},
                    {1, "darker"},
                    {2, "darker"},
                    {3, "lighter"},
                    {4, "lighter"},
                    {5, "lighter"},
                    {6, "darker"},
                    {7, "lighter"},
                    {8, "darker"},
                    {9, "darker"},
                    {10, "lighter"},
                    {11, "lighter"},
                };
                var typeOfColor = colors[br.Killer.Data.ColorId];
                return $@"Body Report:
Traces of a {typeOfColor} fabric has been found on the victim. 
The victim appears to have died {age}s ago";
            }
        }
    }
}
