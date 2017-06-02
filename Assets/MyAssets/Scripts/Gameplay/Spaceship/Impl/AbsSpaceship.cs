using UnityEngine;

using GenShootUnity.Gameplay.Entity;
using GenShootUnity.Gameplay.Controller;
using GenShootUnity.Gameplay.Subsystem.Weapons;
using GenShootUnity.Gameplay.Subsystem.Defense;

namespace GenShootUnity.Gameplay.Spaceship
{
    public abstract class AbsSpaceship : AbsEntity, IControlledEntity
    {
		[SerializeField]
		private AbsWeapon[] weapons;

		[SerializeField]
		private IShield shield = null;

		[SerializeField]
		private float health;
		private float health_current;


		//Default behaviour for damage handling
		public override void TakeDamage(float damage)
		{
			if (shield != null) 
			{
				float damageToShield = damage > shield.Value ? shield.Value : damage;

				shield.TakeDamage (damageToShield);
				damage -= damageToShield;
			}

			health_current -= damage;

			if (health_current <= 0)
				Explode ();
				
		}

		public override void Heal()
		{
			Heal (health);
		}

		public override void Heal(float amount)
		{
			if (amount > health - health_current)
				health_current = health;
			else
				health_current += amount;
		}

		//Override default behaviours
		protected override void Update()
		{
			base.Update ();

			foreach (IWeapon w in weapons) 
			{
				w.Fire ();
			}
		}
    }
}
