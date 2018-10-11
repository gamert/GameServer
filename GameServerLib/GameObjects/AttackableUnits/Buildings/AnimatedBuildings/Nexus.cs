using GameServerCore.Domain.GameObjects;
using GameServerCore.Enums;

namespace LeagueSandbox.GameServer.GameObjects.AttackableUnits.Buildings.AnimatedBuildings
{
    /*
     * The Nexus is the primary objective for each map. 
     * In order to win a match, a team has to destroy the opposing team's Nexus.
     */
    public class Nexus : ObjAnimatedBuilding, INexus
    {
        public Nexus(
            Game game,
            string model,
            TeamId team,
            int collisionRadius = 40,
            float x = 0,
            float y = 0,
            int visionRadius = 0,
            uint netId = 0
        ) : base(game, model, new Stats.Stats(), collisionRadius, x, y, visionRadius, netId)
        {
            Stats.CurrentHealth = 5500;
            Stats.HealthPoints.BaseValue = 5500;

            SetTeam(team);
        }

        public override void Die(IAttackableUnit killer)
        {
            var cameraPosition = _game.Map.MapGameScript.GetEndGameCameraPosition(Team);
            _game.Stop();
            _game.PacketNotifier.NotifyGameEnd(cameraPosition, this, _game.PlayerManager.GetPlayers());
            _game.SetGameToExit();
        }

        public override void SetToRemove()
        {

        }

        public override float GetMoveSpeed()
        {
            return 0;
        }
    }
}
