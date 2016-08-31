using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootTable : MonoBehaviour
{
	public List<GameObject> lootList;
	public List<float>		weights; //Those are PROBABILITY weights (i.e. in [0, 1] )

	public void SpawnLoot(Transform t)
	{
		for (int i = 0; i < lootList.Count; i++) 
		{
			if (Random.value < weights[i])
				SpawnItem(t, i);
		}
	}

	private void SpawnItem(Transform t, int i)
	{
		GameObject item = ObjectPooler.GetObject (lootList [i].name);

		item.transform.position = t.position;
		item.tag = "Loot";
	}
}

