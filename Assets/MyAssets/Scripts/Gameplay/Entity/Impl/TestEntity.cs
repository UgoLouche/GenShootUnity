using UnityEngine;

namespace Assets.MyAssets.Scripts.Gameplay.Entity.Impl
{
    class TestEntity : GenShootUnity.Gameplay.Spaceship.AbsSpaceship
    {
		public float TTL = 0;

		private float currentTTL = 0;

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
