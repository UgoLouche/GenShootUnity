namespace GenShootUnity.Gameplay.Subsystem.Weapons
{
    interface IWeapon
    {
        IAmmo Ammo { get; set; }

        bool CanShoot   { get; }
        float FireRate  { get; }

        bool Fire();
    }
}
