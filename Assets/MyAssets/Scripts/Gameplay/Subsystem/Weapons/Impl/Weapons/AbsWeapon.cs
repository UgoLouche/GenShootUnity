using UnityEngine;

using GenShootUnity.Gameplay.Entity;

namespace GenShootUnity.Gameplay.Subsystem.Weapons
{
	public abstract class AbsWeapon : AbsExtMonoBehaviour, IWeapon
	{
		[SerializeField]
		private AbsAmmo ammo_ = null;

		[SerializeField]
		private float cooldown_base = 0;
		private float current_cooldown = 0;


		//Properties
		public IAmmo Ammo
		{
			get { return ammo_; }
			set { ammo_ = (AbsAmmo)value; } //That's a tad ugly, but Unity doesn't serialize interfaces. 
		}

		public bool CanShoot
		{
			get { return current_cooldown == 0; }
		}

		public float FireRate
		{
			get { return 1.0f / cooldown_base; }
		}

		//Methods.
		public bool Fire()
		{
			if (!CanShoot)
				return false;
			else
				return Custom_Fire ();
		}

		protected abstract bool Custom_Fire ();

		private void Update()
		{
			if (current_cooldown != 0) 
			{
				current_cooldown -= Time.deltaTime;

				if (current_cooldown <= 0)
					current_cooldown = 0;
			}
		}
	}
}

