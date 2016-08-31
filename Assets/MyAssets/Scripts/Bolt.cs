using UnityEngine;
using System.Collections;

/*A bolt is a Flying Object that can do damage*/
public abstract class Bolt : FlyingObject
{
	public int damage;

	public Weapon fragGun;
	public int timeToLive;

	/*** METHODS ***/
	protected void InflictDamage(FlyingObject obj) 
	{
		obj.ReduceHp (damage);
	}

	protected new void Reset() //Clean everything for use
	{
		if (fragGun != null) 
		{
			fragGun.gameObject.transform.parent = transform;
			fragGun.gameObject.transform.position = transform.position;
		}
		base.Reset ();
	}

	void OnEnable()
	{
		if (timeToLive != -1) 
			StartCoroutine ("EndOfLife");
		Reset ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		FlyingObject fObj = other.GetComponent (typeof(FlyingObject)) as FlyingObject;

		//Filter for the case where something happens
		//Namely : it's a mess :-) Bolt does not have the same tag as other object, otherwise, bolt collide
		if (fObj != null)
		{
			if (   ( gameObject.CompareTag("Bolt_Player") && fObj.gameObject.CompareTag("Enemy")  )
			    || ( gameObject.CompareTag("Bolt_Enemy")  && fObj.gameObject.CompareTag("Player") ) )
			{
				InflictDamage (fObj);
				Explode ();
			}
		}

	}

	private IEnumerator EndOfLife()
	{
		yield return new WaitForSeconds (timeToLive);

		if (fragGun != null) 
		{
			fragGun.Fire();
		}

		Explode ();
	}
}
