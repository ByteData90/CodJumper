using InfinityScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodJumper
{
    class CodJumper : BaseScript
    {
        public CodJumper()

        {
            PlayerConnected += OnPlayerSpawned; // Unsure how this is used... 
        }

        private void OnPlayerSpawned(Entity player)

        {
            Vector3 saved = player.GetOrigin();  // Setting default saved position to where player spawned 
            Vector3 color;
            color.X = 0;
            color.Y = 1;            // If I am not mistaken, color is just a Vector3 type. Was unable to find function or constructor to set values
            color.Z = 2;

            HudElem controls = HudElem.CreateFontString(player, HudElem.Fonts.HudSmall, 14f); //  I didn't use loop because I have few elements here to construct
            HudElem controls2 = HudElem.CreateFontString(player, HudElem.Fonts.HudSmall, 14f);
            HudElem controls3 = HudElem.CreateFontString(player, HudElem.Fonts.Bold, 20f);

            controls3.GlowColor = color;

            controls.SetText("2x ^3E^7 Save Location");
            controls2.SetText("2x ^3F^7 Teleport Location");
            controls3.SetText("CodJumper GameMode");

            controls.HorzAlign = HudElem.HorzAlignments.Left;
            controls.VertAlign = HudElem.VertAlignments.Top;
            controls2.HorzAlign = HudElem.HorzAlignments.Left;
            controls2.VertAlign = HudElem.VertAlignments.Top;
            controls3.HorzAlign = HudElem.HorzAlignments.Center;
            controls3.VertAlign = HudElem.VertAlignments.Top;     // useless comment so that a change is detected...

            controls.X = 10;
            controls2.X = 10;
            controls.Y = 300;
            controls2.Y = 325;
            controls3.Y = 15;

            while (player.IsAlive) // Maybe this is the problem... 
            {
                Wait(20);
                if (player.MeleeButtonPressed())
                {
                        saved = player.GetOrigin();
                        GSCFunctions.IPrintLn("Saved Location");
                }
                Wait(20);
                if (player.UseButtonPressed()) 
                {
                        player.SetOrigin(saved);
                        GSCFunctions.IPrintLn("Teleported");
                }
            }
            controls.Destroy(); // Coming out of loop due to player death is expected to destroy hud elements.
            controls2.Destroy();
            controls3.Destroy();
        }
    }
}