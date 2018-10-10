namespace GameServerCore.Enums
{
    public enum DamageText : byte
    {
        DAMAGE_TEXT_INVULNERABLE = 0x0,//无懈可击
        DAMAGE_TEXT_DODGE = 0x2,    //躲闪
        DAMAGE_TEXT_CRITICAL = 0x3, //
        DAMAGE_TEXT_NORMAL = 0x4,   //
        DAMAGE_TEXT_MISS = 0x5      //
    }
}