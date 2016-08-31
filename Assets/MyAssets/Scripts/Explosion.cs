using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
	public float timeToLive = 1;

	void OnEnable()
	{
		StartCoroutine ("EndOfLife");
	}

	private IEnumerator EndOfLife()
	{
		yield return new WaitForSeconds (timeToLive);

		ObjectPooler.PoolObject (gameObject);
	}


}

