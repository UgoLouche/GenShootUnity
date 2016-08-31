using UnityEngine;
using System.Collections;

public class WaveScript : MonoBehaviour {

	public GameObject nextWave; //The next wave in line
	public float lockUpTime; 	//For how much second we wait before launching the next wave.
								//-1 means to wait for the wave to be over
	public bool isOver; 		//True if the last ship has been destroyed

	public GameObject[] 	enemies;
	public Vector3[]   		spawnPositions; //xAxis, yAxis, zRotation,  DO NOT MESS WITH SCALE
	public float[]			spawnTimes;

	private int step = 0;
	private GameObject lastEnemy = null; //Track the last spawned enemy to determine when the wave is over

	public void Run()
	{
		StartCoroutine ("SpawnCoRoutine");
	}

	void Start()
	{
		if (enemies.Length != spawnPositions.Length
			|| enemies.Length != spawnTimes.Length) 
		{
			Debug.Log("Wave name: " + gameObject.name + "Arrays Length do not match.");
			Debug.Log("enemies length: " + enemies.Length + 
			          " --- positions length: " + spawnPositions.Length +
			          " --- times length: " + spawnTimes.Length);
		}
	}

	void Update()
	{
		if (lastEnemy != null && !lastEnemy.activeInHierarchy) //Waves will take care of themselves. It's easier that way
		{ 
			isOver = true;
			ObjectPooler.PoolObject(gameObject);
		}
	}

	void OnEnable()
	{
		step = 0;
		lastEnemy = null;
		isOver = false;
	}

	private IEnumerator SpawnCoRoutine()
	{
		GameObject current = null;

		while (step < enemies.Length) 
		{
			yield return new WaitForSeconds( spawnTimes[step] );

			current = ObjectPooler.GetObject(enemies[step].name);
			current.SetActive(false);
			current.transform.position = new Vector3( spawnPositions[step].x,
			                                          spawnPositions[step].y,
			                                          0);
			current.transform.rotation = Quaternion.Euler( new Vector3( 0, 0, spawnPositions[step].z) );

			//Failsafe and force repropagation of tag
			current.tag = "Enemy"; 
			current.SetActive(true);

			step++;
		}

		//If we are here, current is the last enemy of the wave
		lastEnemy = current;
	}
}
