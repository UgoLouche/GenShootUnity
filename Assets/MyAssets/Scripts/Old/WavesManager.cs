using UnityEngine;
using System.Collections;

public class WavesManager : MonoBehaviour {

	public static WavesManager instance = null;

	public GameObject currentWave = null;

	void Awake()
	{
		if (instance != null)
			Debug.Log("Another instance of WavesManager already exists !");

		instance = this;
	}
	
	void Start () 
	{
		StartCoroutine("MainCoroutine");
	}

	IEnumerator MainCoroutine()
	{
		WaveScript currentCopy;

		yield return new WaitForSeconds(2); //Wait two second before starting

		while (currentWave != null) 
		{
			currentCopy = ObjectPooler.GetObject(currentWave.name).GetComponent<MonoBehaviour>() as WaveScript;
			if (currentCopy == null)
				Debug.Log("WavesManager: cannot get wave: " + currentWave.name);

			currentCopy.transform.parent = transform;
			currentCopy.Run();

			yield return new WaitForSeconds( currentCopy.lockUpTime );

			//Prepare next Wave
			currentWave = currentCopy.nextWave;
		}

		Debug.Log ("The End");
	}
}
