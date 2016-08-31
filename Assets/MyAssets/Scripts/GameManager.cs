using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	private static GameManager instance = null;
	
	public float width;
	public float height;
	
	private float xMax, xMin, yMax, yMin;

	private float playerScore = 0;
	private float playerMultiplier = 1;

	private PlayerShip player = null;
	
	public static GameManager GetInstance()
	{
		return instance;
	}
	
	void Awake()
	{
		if (instance != null)
			Debug.Log("An other instance of ObjectPooler already Exists !");

		instance = this;
		
		xMax = width / 2;
		xMin = -1 * xMax;
		yMax = height / 2;
		yMin = -1 * yMax;
	}

	public FlyingObject getPlayer()
	{
		return player;
	}

	public void RegisterPlayer(PlayerShip ship)
	{
		if (player != null)
			Debug.Log ("PlayerShip already registered: " + player.gameObject.name);
		else
			player = ship;
	}

	public float AddPoint(float points)
	{
		playerScore += points * playerMultiplier;

		return playerScore;
	}

	public float Score()
	{
		return playerScore;
	}

	public float Multiplier()
	{
		return playerMultiplier;
	}
	
	public float XMax()
	{
		return xMax;
	}
	
	public float YMax()
	{
		return yMax;
	}
	
	public float XMin()
	{
		return xMin;
	}
	
	public float YMin()
	{
		return yMin;
	}
}
