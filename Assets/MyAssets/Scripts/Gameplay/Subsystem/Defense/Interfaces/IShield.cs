namespace GenShootUnity.Gameplay.Subsystem.Defense
{ 
    interface IShield
    {
        float Value { get; }

        float RechargeRate { get; }
        float RechargeDelay { get; }

    }
}
