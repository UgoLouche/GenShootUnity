using UnityEngine;

using GenShootUnity.Gameplay.Entity;

namespace GenShootUnity.Gameplay.Subsystem.Weapons
{
	public class AbsAmmo : AbsEntity, IAmmo
	{
		//IDammageable
		//Ammo explode on contact by default.
		public override void TakeDamage (float damage)
		{
			Explode ();
		}

		public override void Heal()
		{
		}

		public override void Heal(float amount)
		{
		}
	}
}

