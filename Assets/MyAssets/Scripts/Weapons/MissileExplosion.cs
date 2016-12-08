using UnityEngine;
using System.Collections;

public class MissileExplosion : Explosion {

    public float damage;
    public float radius;

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        other.gameObject.GetComponent<FlyingObject>().ReduceHp(damage);
    //    }
    //}

    void OnAwake()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            radius
            );

        foreach(Collider coll in hits)
        {
            if (coll.gameObject == gameObject) continue; //Ignore the explosion itself

            FlyingObject fo = coll.gameObject.GetComponent<FlyingObject>();
            if (coll.gameObject.tag == "Enemy" && fo != null)
            {
                fo.ReduceHp(damage);
            }
        }
    }
}
