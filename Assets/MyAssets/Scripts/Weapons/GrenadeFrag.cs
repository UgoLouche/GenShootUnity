using UnityEngine;
using System.Collections;

public class GrenadeFrag : Weapon
{

    public Bolt ammo;

    //Property
    override public int level
    {
        get { return base.level; }

        set
        {
            base.level = value;
        }
    }

    /***METHODS***/
    public override void Fire()
    {
        if (level == 0) return;

        for (int i = 0; i < 360; i = i + (360 / ( 10 + level * 3) ) )
        {
            GameObject shot = ObjectPooler.GetObject(ammo.gameObject.name);
            TagBolt(shot);
            shot.transform.Rotate(0f, 0f, i);
        } 
    }

}
