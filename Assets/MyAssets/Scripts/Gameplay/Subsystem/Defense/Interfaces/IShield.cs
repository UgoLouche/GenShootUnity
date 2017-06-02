using GenShootUnity.Gameplay.Entity;

namespace GenShootUnity.Gameplay.Subsystem.Defense
{ 
	public interface IShield : IDamageableObject
    {
        float Value { get; }

        float RechargeRate { get; }
        float RechargeDelay { get; }

    }
}
