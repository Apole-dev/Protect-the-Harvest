namespace Enums
{
    public enum SoundType
    {
        #region Gun
            Pistol,
            Shotgun,
            Rifle,
            SniperRifle,
            MachineGun,
            RocketLauncher,
            GrenadeLauncher,
        #endregion

        #region Shield
            ShieldPickup,
            ShieldBreak,
            ShieldRecharge,
        #endregion

        #region Health
            HealthPickup,
            HealthRecharge,
        #endregion
        
        #region General
            WinSound,
            LoseSound,
        #endregion
    }
}