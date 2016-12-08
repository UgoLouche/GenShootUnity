using UnityEngine;
using System.Collections;

public class ShotGun : Weapon
{
    public Bolt ammo;

    public override void Fire()
    {
        if (!IsReady())
            return;

        GameObject shot;
        float rotateAngle = 0;
        for (int i = 0; i < 3 * level; i++) //NBShot = 3 * lvl
        {
            shot = ObjectPooler.GetObject(ammo.gameObject.name);

            TagBolt(shot);



            shot.transform.Rotate(0, 0, rotateAngle);
            if (i % 2 == 0)
                rotateAngle = rotateAngle * -1 + 3;
            else
                rotateAngle *= -1;

            Reload();
            MoveTurret();
        }
    }
}

