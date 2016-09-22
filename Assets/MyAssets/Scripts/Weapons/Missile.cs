using UnityEngine;
using System.Collections;

public class Missile : Bolt {

    public float rotationSpeed;

    public GameObject target = null;


    protected override void OnExplode(GameObject explosion)
    {
        base.OnExplode();

        explosion.transform.localScale *= 1 + (0.1f * level);
        explosion.GetComponent<MissileExplosion>().damage = damage / 2f;

        //reset target
        target = null;
    }

    protected override void Update()
    {
        if (target != null)
        {
            if (!target.activeInHierarchy) target = null;
            else
            {
                //Compute the move Vector
                //Compute rotation to point toward this
                //Clamp rotation if needed
                //Take a step toward that direction according to the trajectory
                Vector3 moveVector = target.transform.position - transform.position;

                Vector3 newDir = Vector3.RotateTowards(
                    transform.up,
                    moveVector,
                    rotationSpeed * Time.deltaTime,
                    0f
                    );

                transform.up = newDir;
            }
        }

        base.Update();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        pickTarget();
    }

    private void pickTarget()
    {
        Transform enemyManager_transform = 
            GameManager.GetInstance().EnemyManager.transform;

        if (enemyManager_transform.childCount != 0)
        {
            target =
                enemyManager_transform.GetChild(
                    Random.Range(0, enemyManager_transform.childCount - 1)
                    ).gameObject;
        }
    }
}
