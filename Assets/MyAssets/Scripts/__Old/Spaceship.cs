//using UnityEngine;
//using System.Collections;

//public abstract class Spaceship : FlyingObject
//{
//	public Weapon[] weapons;

//	public void Fire()
//	{
//		foreach (Weapon w in weapons)
//			w.Fire ();
//	}

//	void OnEnable()
//	{
//		PropagateTag (transform);
//		Reset ();

//        foreach (Weapon w in weapons)
//            w.level = 1;
//	}

//	public void PropagateTag(Transform t)
//	{
//		t.gameObject.tag = tag;
		
//		for (int i = 0; i < t.childCount; i++)
//			PropagateTag (t.GetChild (i));
//	}
//}

