using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using HarmonyLib;
using System;
using System.Linq;
using System.Net;
using Reactor;
using Essentials.Options;
using static ExtraRolesMod.ExtraRoles;
using Reactor.Unstrip;
using UnityEngine;
using System.IO;
using Reactor.Extensions;

namespace ExtraRolesMod
{
    [BepInPlugin(Id)]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    public partial class HarmonyMain : BasePlugin
    {
        public const string Id = "gg.reactor.extraroles";

        public Harmony Harmony { get; } = new Harmony(Id);

        public ConfigEntry<string> Ip { get; set; }
        public ConfigEntry<ushort> Port { get; set; }

        public override void Load()
        {
            Ip = Config.Bind("Custom", "Ipv4 or Hostname", "127.0.0.1");
            Port = Config.Bind("Custom", "Port", (ushort)22023);

            Main.Assets.bundle = AssetBundle.LoadFromFile(Directory.GetCurrentDirectory() + "\\Assets\\bundle");
            Main.Assets.breakClip = Main.Assets.bundle.LoadAsset<AudioClip>("SB").DontUnload();
            Main.Assets.repairIco = Main.Assets.bundle.LoadAsset<Sprite>("RE").DontUnload();
            Main.Assets.shieldIco = Main.Assets.bundle.LoadAsset<Sprite>("SA").DontUnload();
            Main.Assets.smallShieldIco = Main.Assets.bundle.LoadAsset<Sprite>("RESmall").DontUnload();

            //Disable the https://github.com/DorCoMaNdO/Reactor-Essentials watermark.
            //The code said that you were allowed, as long as you provided credit elsewhere. 
            //I added a link in the Credits of the GitHub page, and I'm also mentioning it here.
            //If the owner of this library has any problems with this, just message me on discord and we'll find a solution

            //Hunter101#1337
            CustomOption.ShamelessPlug = false;

            RegisterInIl2CppAttribute.Register();
            RegisterCustomRpcAttribute.Register(this);

            AddCustomRegion();

            Harmony.PatchAll();
        }

        private void AddCustomRegion()
        {
            var defaultRegions = ServerManager.DefaultRegions.ToList();
            var ip = Ip.Value;
            if (Uri.CheckHostName(Ip.Value).ToString() == "Dns")
            {
                foreach (var address in Dns.GetHostAddresses(Ip.Value))
                {
                    if (address.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
                        continue;
                    ip = address.ToString();
                    break;
                }
            }

            defaultRegions.Insert(0, new DnsRegionInfo(
                "Custom", ip, StringNames.NoTranslation, new[]
                {
                    new ServerInfo($"Custom-Server", ip, Port.Value)
                }).Cast<IRegionInfo>()
            );

            ServerManager.DefaultRegions = defaultRegions.ToArray();
        }
    }
}