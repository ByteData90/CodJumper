using InfinityScript;


namespace CodJumper
{
    public class CodJumper : BaseScript
    {
        public CodJumper()
        {
            PlayerConnected += OnPlayerConnect; // Unsure how this is used... 
        }
        private void OnPlayerConnect(Entity player)
        {
            Vector3 color;
            color.X = 0;
            color.Y = 1;
            color.Z = 2;
            var controls = HudElem.CreateFontString(player, HudElem.Fonts.HudSmall, 14f); //  I didn't use loop because I have few elements here to construct
            var controls2 = HudElem.CreateFontString(player, HudElem.Fonts.HudSmall, 14f);
            var controls3 = HudElem.CreateFontString(player, HudElem.Fonts.HudBig, 32f);
            controls.Archived = true;
            controls2.Archived = true;
            controls3.Archived = true;

            controls3.GlowColor = color;

            controls.SetText("^3E^7 Save Location");
            controls2.SetText("^3F^7 Teleport Location");
            controls3.SetText("CodJumper");

            controls.HorzAlign = HudElem.HorzAlignments.Left;
            controls.VertAlign = HudElem.VertAlignments.Top;
            controls2.HorzAlign = HudElem.HorzAlignments.Left;
            controls2.VertAlign = HudElem.VertAlignments.Top;
            controls3.HorzAlign = HudElem.HorzAlignments.Center;
            controls3.VertAlign = HudElem.VertAlignments.Top;

            controls.X = 10;
            controls2.X = 10;
            controls.Y = 300;
            controls2.Y = 325;
            Tick += () => Monitor(player, controls, controls2, controls3);
        }
     
        private void Monitor(Entity player, HudElem x, HudElem y, HudElem z)
        {
            Vector3 saved = player.GetOrigin();  // Setting default saved position to where player spawned
            if (player.IsPlayer && player.IsAlive)
            {
                if (player.MeleeButtonPressed())
                {
                    saved = player.GetOrigin();
                    BaseScript.Wait(20);
                    GSCFunctions.IPrintLnBold("Saved Location");
                }
                if (player.UseButtonPressed())
                {
                    player.SetOrigin(saved);
                    BaseScript.Wait(20);
                    GSCFunctions.IPrintLnBold("Teleported");
                }
            }
        }
    }
}