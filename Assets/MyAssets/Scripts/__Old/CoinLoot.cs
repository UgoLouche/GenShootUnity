using UnityEngine;
using System.Collections;

public class CoinLoot : Loot
{
	public float value = 1;

	protected override void Reward()
	{
		GameManager.GetInstance ().AddMultiplier(value);
		ObjectPooler.PoolObject (this.gameObject);
	}

}

