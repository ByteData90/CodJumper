using InfinityScript;
using System;

namespace CodJumper
{
    public class CodJumper : BaseScript
    {
        
        public CodJumper()
        {
            PlayerConnected += OnPlayerConnect;
        }
        private void OnPlayerConnect(Entity player)
        {
            InfinityScript.BaseScript.Players.Remove(player);
            Vector3 saved = player.GetOrigin();
            Vector3 color;
            color.X = 0;
            color.Y = 1;
            color.Z = 2;
            var credit = HudElem.CreateFontString(player, HudElem.Fonts.HudSmall, 14);     // Credit mainly to Slvr99
            var velocity = HudElem.CreateFontString(player, HudElem.Fonts.HudSmall, 14f);
            var controls = HudElem.CreateFontString(player, HudElem.Fonts.HudSmall, 14f); //  I didn't use loop because I have few elements here to construct
            var controls2 = HudElem.CreateFontString(player, HudElem.Fonts.HudSmall, 14f);
            var controls3 = HudElem.CreateFontString(player, HudElem.Fonts.HudBig, 14f);
            controls.Archived = true;
            controls2.Archived = true;
            controls3.Archived = true;
            
            velocity.Color = color + color + color + color + color;
            controls3.GlowColor = color;
            controls3.GlowAlpha = 1;

            velocity.SetText("0");
            controls.SetText("^3E^7 Save Location");
            controls2.SetText("^3F^7 Teleport Location");
            controls3.SetText("CodJumper");
            credit.SetText("Made Possible by ^1Slvr99");

            credit.HorzAlign = HudElem.HorzAlignments.Left;
            credit.VertAlign = HudElem.VertAlignments.Top;
            controls.HorzAlign = HudElem.HorzAlignments.Left;
            controls.VertAlign = HudElem.VertAlignments.Top;
            velocity.VertAlign = HudElem.VertAlignments.Top;
            velocity.HorzAlign = HudElem.HorzAlignments.Left;
            controls2.HorzAlign = HudElem.HorzAlignments.Left;
            controls2.VertAlign = HudElem.VertAlignments.Top;
            controls3.HorzAlign = HudElem.HorzAlignments.Center;
            controls3.VertAlign = HudElem.VertAlignments.Top;

            velocity.X = 10;
            velocity.Y = 235;
            controls.X = 10;
            controls2.X = 10;
            controls.Y = 300;
            controls2.Y = 325;
            credit.X = 10;
            credit.Y = 350;
            controls3.X = -10;
            controls3.Y = 5;
            Tick += () => Monitor(player, ref saved, ref velocity);
        }
        
        private void Monitor(Entity player, ref Vector3 saved, ref HudElem velocity)
        {
            int v = Convert.ToInt32((Math.Truncate(Math.Sqrt((Math.Pow(player.GetVelocity().X, 2)) + (Math.Pow(player.GetVelocity().Y, 2))))));
            velocity.SetValue(v);
            if (player.IsPlayer && player.IsAlive)
            {
                if (player.MeleeButtonPressed())
                {
                    saved = player.GetOrigin();
                    player.IPrintLnBold("Saved Location");
                }
                if (player.UseButtonPressed())
                {
                    player.SetOrigin(saved);
                    player.IPrintLnBold("Teleported");
                }
            }
        }
    }
}