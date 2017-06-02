using UnityEngine;

namespace Assets.MyAssets.Scripts.Gameplay.Entity.Impl
{
    class TestEntity : GenShootUnity.Gameplay.Spaceship.AbsSpaceship
    {
		public float TTL = 0;

		private float currentTTL = 0;


		public override void TakeDamage(float damage)
		{
		}

		public override void Heal(float amount) 
		{
		}

		public override void Heal()
		{
		}

		protected override void Update()
		{
			base.Update ();

			if (currentTTL < 0) 
			{
				currentTTL = TTL;
				Pool ();
			} 
			else 
			{
				currentTTL -= Time.deltaTime;
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable ();

			currentTTL = TTL;
		}
    }
}
