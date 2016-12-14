//using UnityEngine;
//using System.Collections;

//public class WaveBolt : Bolt
//{
//    private float remainingTTL;

//    override public int level
//    {
//        get { return base.level; }
//        set
//        {
//            //First reset reload time to its 0 level
//            if (base.level >= 1)
//                timeToLive = timeToLive / Mathf.Pow(1.1f, base.level - 1);

//            //Then Set the new level
//            if (value >= 1)
//                timeToLive = timeToLive *  Mathf.Pow(1.1f, value - 1);

//            base.level = value;
//        }
//    }

//    override protected void Update()
//    {
//        remainingTTL -= Time.deltaTime;
//        base.Update();
//    }

//    override protected void OnEnable()
//    {
//        remainingTTL = timeToLive;
//        base.OnEnable();
//    }
//}
