//using UnityEngine;
//using System.Collections;

///*A bolt is a Flying Object that can do damage*/
//public abstract class Bolt : FlyingObject
//{
//	public int damage;

//	public Weapon fragGun;
//	public float timeToLive;


//    //Properties
//    private int level_ = 1;

//    public virtual int level
//    {
//        get { return level_; }
//        set
//        {
//            level_ = value;
//            Color col = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
//            col.b = 1 - 0.1f * value;
//            col.g = 1 - 0.1f * value;

//            transform.GetChild(0).GetComponent<SpriteRenderer>().color = col;

//            if (fragGun != null) fragGun.level = value;
//        }
//    }

//	/*** METHODS ***/
//	protected void InflictDamage(FlyingObject obj) 
//	{
//		if (level > 0) obj.ReduceHp (damage * (0.5f + level / 2f));
//	}

//	protected new void Reset() //Clean everything for use
//	{
//		if (fragGun != null) 
//		{
//			fragGun.gameObject.transform.parent = transform;
//			fragGun.gameObject.transform.position = transform.position;
//		}
//		base.Reset ();
//	}

//	protected virtual void OnEnable()
//	{
//		if (timeToLive != -1) 
//			StartCoroutine ("EndOfLife");
//		Reset ();
//	}

//	void OnTriggerEnter2D(Collider2D other)
//	{
//		FlyingObject fObj = other.GetComponent (typeof(FlyingObject)) as FlyingObject;

//		//Filter for the case where something happens
//		//Namely : it's a mess :-) Bolt does not have the same tag as other object, otherwise, bolt collide
//		if (fObj != null)
//		{
//			if (   ( gameObject.CompareTag("Bolt_Player") && fObj.gameObject.CompareTag("Enemy")  )
//			    || ( gameObject.CompareTag("Bolt_Enemy")  && fObj.gameObject.CompareTag("Player") ) )
//			{
//				InflictDamage (fObj);

//                if (fragGun != null)
//                {
//                    fragGun.Fire();
//                }

//                Explode ();
//			}
//		}

//	}

//	protected IEnumerator EndOfLife()
//	{
//		yield return new WaitForSeconds (timeToLive);

//		if (fragGun != null) 
//		{
//			fragGun.Fire();
//		}

//		Explode ();
//	}
//}
