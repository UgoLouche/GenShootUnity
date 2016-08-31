using UnityEngine;
using System.Collections;

public class CoinLoot : Loot
{
	public float value = 10;

	protected override void Reward()
	{
		GameManager.GetInstance ().AddPoint (value);
		ObjectPooler.PoolObject (this.gameObject);
	}

}

