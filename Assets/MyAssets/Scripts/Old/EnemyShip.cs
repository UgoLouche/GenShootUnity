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

	protected override void OnExplode(GameObject explosion = null)
	{
		GameManager.GetInstance ().AddPoint (pointValue);
		if (lootTable != null) lootTable.SpawnLoot (transform);

		base.OnExplode ();
	}
}

