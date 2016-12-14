//using UnityEngine;
//using System.Collections;

//public class PlayerShip : Spaceship
//{
//	private GameManager manager = null;

//	//Hide some irrelevant fields
//	//new private Trajectory trajectory;

//	void Start()
//	{
//		GameManager.GetInstance ().RegisterPlayer (this);
//	}

//	new void Update () 
//	{
//		if (manager == null && (manager = GameManager.GetInstance ()) == null) //Ensure that manager is set
//			return;
		
//		//Move the ship
//		Move(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		
//		//Fire the Guns
//		Fire ();
//	}

//	private void Move(float xAxis, float yAxis)
//	{
//		transform.position = new Vector3(
//			Mathf.Clamp( transform.position.x + xAxis * speed * Time.deltaTime, manager.XMin(), manager.XMax() ),
//			Mathf.Clamp( transform.position.y + yAxis * speed * Time.deltaTime, manager.YMin(), manager.YMax() ),
//			0
//			);
//	}


//}

