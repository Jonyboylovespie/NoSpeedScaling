using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using MelonLoader;
using NoSpeedScaling;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;


[assembly: MelonInfo(typeof(NoScalingMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace NoSpeedScaling
{
    public class NoScalingMod : BloonsTD6Mod
    {
        public override void OnBloonCreated(Bloon bloon)
        {

            int bloonSpawnRound = InGame.instance.currentRoundId + 1;

            if (bloonSpawnRound > RoundSpeedCap)
            {
                bloon.bloonModel.Speed = GetSpeed(RoundSpeedCap, bloon.bloonModel.name);
            }

        }

        public static float GetSpeed(int Round, string bloonName)
        {

            float OGspeed = Game.instance.model.GetBloon(bloonName).speed;
            float speed;
            
            if (Round <= 80)
            {
                speed = OGspeed;
            }
            else if (Round <= 100)
            {
                speed = OGspeed * (1.0f + (Round - 80) * 0.02f);
            }
            else if (Round <= 150)
            {
                speed = OGspeed * (1.6f + (Round - 101) * 0.02f);
            }
            else if (Round <= 200)
            {
                speed = OGspeed * (3.0f + (Round - 151) * 0.02f);
            }
            else if (Round <= 250)
            {
                speed = OGspeed * (4.5f + (Round - 201) * 0.02f);
            }
            else
            {
                speed = OGspeed * (6.0f + (Round - 252) * 0.02f);
            }

            return speed;
            
        }
        
        public static readonly ModSettingInt RoundSpeedCap = new(200)
        {
            displayName = "Cap Speed at Round",
            description = "Sets round at which speed stops increasing"
        };
    }
}
