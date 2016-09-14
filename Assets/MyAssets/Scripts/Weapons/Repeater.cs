using UnityEngine;
using System.Collections;

public class Repeater : Weapon
{
	public Bolt ammo;


	/***METHODS***/
	public override void Fire()
	{
		if ( !IsReady() )
			return;

		GameObject shot = ObjectPooler.GetObject (ammo.gameObject.name);
		TagBolt (shot);

		Reload ();
		MoveTurret ();

	}

}

