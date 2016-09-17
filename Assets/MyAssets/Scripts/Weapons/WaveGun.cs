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

        GameObject shot = ObjectPooler.GetObject(ammo.gameObject.name);
        TagBolt(shot);

        Reload();
        MoveTurret();

    }

}

