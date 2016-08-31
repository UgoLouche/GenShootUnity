using UnityEngine;
using System.Collections;

public abstract class Loot : MonoBehaviour, ProximityAware, PoolableObject
{
	public float speed = 1;
	
	private bool isMagnet = false; //Rush toward the player's ship

	private int poolID = -1;

	public void OnTriggerProximity(Collider2D other)
	{
		if (!isMagnet && other.gameObject.CompareTag ("Player"))
			isMagnet = true;
	}

	public int GetPoolID()
	{
		if (poolID == -1)
			ObjectPooler.RequestID (this.gameObject);
		
		return poolID;
	}
	
	void Update () //Handle movement, Two 'mode' of movement available.
	{
		Vector3 dist2Player;


		if (isMagnet) 
		{
			if (GameManager.GetInstance().getPlayer().gameObject.activeInHierarchy)
			{
				dist2Player = GameManager.GetInstance().getPlayer().transform.position - transform.position;
				dist2Player.Normalize();
				transform.position = transform.position + dist2Player * Time.deltaTime * speed;
			}
			else 
				isMagnet = false;

		} 
		else 
		{
			transform.position = transform.position + Vector3.down * Time.deltaTime * speed;
		}
	}

	void OnEnable() //Rotation failsafe
	{
		transform.rotation = Quaternion.Euler (0, 0, 0);
		gameObject.tag = "Loot";
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
			Reward ();
	}

	protected abstract void Reward();
}

