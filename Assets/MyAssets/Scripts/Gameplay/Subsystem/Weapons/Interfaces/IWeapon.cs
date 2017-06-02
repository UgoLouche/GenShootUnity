namespace GenShootUnity.Gameplay.Subsystem.Weapons
{
    public interface IWeapon
    {
        IAmmo Ammo { get; set; }

        bool CanShoot   { get; }
        float FireRate  { get; }

        bool Fire();
    }
}
