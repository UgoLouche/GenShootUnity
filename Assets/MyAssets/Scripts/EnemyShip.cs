using UnityEngine;
using System.Collections;

public class EnemyShip : Spaceship
{
	public float pointValue;
	public LootTable lootTable;

	new void Update ()
	{
		base.Update ();
		Fire ();
	}

	protected override void OnExplode()
	{
		GameManager.GetInstance ().AddPoint (pointValue);
		lootTable.SpawnLoot (transform);

		base.OnExplode ();
	}
}

