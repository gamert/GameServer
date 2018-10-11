namespace LeagueSandbox.GameServer.API
{
    public enum CrowdControlType
    {
        AIRBORNE, BLIND, DISARM, GROUND, INVULNERABLE, NEARSIGHT, ROOT, SILENCE, STASIS, STUN, SUPPRESSION, SNARE
    }

    /*
     * Crowd control (commonly shortened to CC) is a blanket term used in LeagueSandbox 
     * to describe abilities or spells that remove or diminish the control a target unit 
     * has over aspects of itself - aspects such as being able to cast spells or initiate 
     * movement commands. As crowd controls impact a unit's combat ability, they are 
     * essentially more specialized forms of debuffs - however, this ability to directly 
     * hinder a unit's ability to fight means that crowd controls are often given significantly 
     * more importance in regular gameplay than normal debuffs, resulting in their special 
     * classification.
     */
    public class UnitCrowdControl
    {
        public CrowdControlType Type { get; private set; }
        public float Duration { get; private set; }
        public float CurrentTime { get; private set; }
        public bool IsRemoved { get; private set; }

        public UnitCrowdControl(CrowdControlType type, float duration = -1)
        {
            Type = type;
            Duration = duration;
        }

        public void Update(float diff)
        {
            CurrentTime += diff / 1000.0f;
            if (CurrentTime >= Duration && !IsRemoved && Duration != -1)
            {
                IsRemoved = true;
            }
        }

        public bool IsTypeOf(CrowdControlType type)
        {
            return type == Type;
        }
    }
}
