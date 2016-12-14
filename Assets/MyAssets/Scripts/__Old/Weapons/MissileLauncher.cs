//using UnityEngine;
//using System.Collections;

//public class MissileLauncher : Weapon {

//    public Bolt ammo;

//    //Property
//    override public int level
//    {
//        get { return base.level; }

//        set
//        {
//            //First reset reload time to its 0 level
//            if (base.level >= 1)
//                reloadTime /= Mathf.Pow(0.9f, base.level - 1);

//            //Then Set the new level
//            if (value >= 1)
//                reloadTime *= Mathf.Pow(0.9f, value - 1);

//            base.level = value;
//        }
//    }


//    /***METHODS***/
//    public override void Fire()
//    {
//        if (level == 0) return;

//        if (!IsReady())
//            return;

//        int nbShot;
//        if (level < 5) nbShot = 1;
//        else if (level < 10) nbShot = 2;
//        else nbShot = 3;

//        for (int i = 0; i < nbShot; ++i)
//        {
//            GameObject shot = ObjectPooler.GetObject(ammo.gameObject.name);
//            TagBolt(shot);
//        }

//        Reload();
//        MoveTurret();

//    }
//}
