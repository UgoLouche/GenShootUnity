using UnityEngine;
using System.Collections;

public class LaserGun : MonoBehaviour {

	public GameObject bolt;
	public float reloadTime;

	private float nextShotTime;

	void Start()
	{
		nextShotTime = 0;
	}

	public void Fire()
	{
		GameObject newBolt;

		if (Time.time > nextShotTime) 
		{
			newBolt = ObjectPooler.GetObject (bolt.name);
			newBolt.transform.position = transform.position;
			newBolt.transform.rotation = transform.rotation;
			newBolt.transform.parent = transform;

			nextShotTime = Time.time + reloadTime;
		}
	}
}
