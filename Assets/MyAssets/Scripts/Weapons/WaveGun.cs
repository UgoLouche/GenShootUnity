using UnityEngine;
using System.Collections;

public class WaveGun : Weapon
{
    public Bolt ammo;

    /***METHODS***/
    public override void Fire()
    {
        if (level == 0) return;

        if (!IsReady())
            return;

        GameObject shot = ObjectPooler.GetObject(ammo.gameObject.name, false); 
		//Active start the TTL timer, but we need to tag the bolt first (and modify its level) before that 

        TagBolt(shot);
		shot.SetActive (true);

        Reload();
        MoveTurret();

    }

}

