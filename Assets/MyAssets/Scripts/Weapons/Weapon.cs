using UnityEngine;
using System.Collections;
using System;

public abstract class Weapon : MonoBehaviour, PoolableObject
{
	public float[] turretPattern;
	public float reloadTime;
    public int level;

	private float nextShot = 0;
	private int turretIndice = 0;

    private int poolID = -1;


	public abstract void Fire();

	protected void TagBolt(GameObject shot)
	{
		//Assign the right tag
		if (gameObject.CompareTag ("Player"))
			shot.gameObject.tag = "Bolt_Player";
		else if (gameObject.CompareTag ("Enemy"))
			shot.gameObject.tag = "Bolt_Enemy";
		else
			Debug.Log ("A bolt have been fired by an Tag-Unknown object. Tag: " 
			           + gameObject.tag);

		shot.transform.position = transform.position;
		shot.transform.rotation = transform.rotation;
		shot.transform.localScale = Vector3.one;
	}


	protected bool IsReady()
	{
		if (Time.time >= nextShot)
			return true;
		else
			return false;
	}

	protected void Reload()
	{
		nextShot = Time.time + reloadTime;
	}

	protected void MoveTurret()
	{
		if (turretPattern.Length == 0) //SafeGuard, should not happen
		{
			Debug.Log ("Weapon: Empty Turret pattern");
			turretPattern = new float[1];
			turretPattern[0] = 0;
			turretIndice = 0;
		}

		if (turretIndice > turretPattern.Length - 1)  //SafeGuard
		{
			Debug.Log("Weapon: turretIndice out of bound (turretIndice: " + turretIndice + ")");
			turretIndice %= turretPattern.Length;
		}

		transform.rotation = Quaternion.Euler (new Vector3 (0, 
		                                                    0, 
		                                                    turretPattern [turretIndice = ++turretIndice % turretPattern.Length]
		                                                    ) );
		//Debug.Log ("---" + turretPattern [turretIndice % turretPattern.Length] + "---" + turretIndice);
	}

    public int GetPoolID()
    {
        if (poolID == -1)
            ObjectPooler.RequestID(this.gameObject);

        return poolID;
    }
}

