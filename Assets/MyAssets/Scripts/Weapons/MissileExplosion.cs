using UnityEngine;
using System.Collections;

public class MissileExplosion : Explosion {

    public float damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<FlyingObject>().ReduceHp(damage);
        }
    }
}
