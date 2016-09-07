using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

	//Static field
	private static ObjectPooler instance = null;


	//Regular fields
	public List<GameObject> prefabs; //List of all Prefabs

	private List<Stack<GameObject>> 	pooledObjects; 	//All Objects currently in the pool
	public List<int> 					poolsSizes;		//Base Size for each pool

	public int defaultPoolSize;


	public static ObjectPooler GetInstance()
	{
		return instance;
	}

	public static int RequestID(FlyingObject obj)
	{
		return RequestID (obj.gameObject);
	}

	public static int RequestID(GameObject obj)
	{
		for (int i = 0; i < instance.prefabs.Count; i++) //Search for a prefab matching the name
		{
			if (instance.prefabs [i].name == obj.name)
				return i;
		}

		//The object does not exist as a prefab so we add it
		instance.prefabs.Add (obj);
		instance.initPool (instance.prefabs.Count - 1);
		return instance.prefabs.Count - 1;
	}

	public static void PoolObject( GameObject obj ) 
	{
		int i;
		bool matchFound = false;

		for (i = 0; i < instance.prefabs.Count; i++) 
		{
			if ( instance.prefabs[i].name == obj.name )
			{
				matchFound = true;
				break;
			}
		}

		if (!matchFound) //Exit if there is no match
		{ 
			Debug.Log("PoolObject : No match found for: " + obj.name + ", adding it to prefabs");
			i = RequestID (obj);
		}

		if (instance.pooledObjects [i] == null) //Check for null, if happens something is seriously wrong
		{
			Debug.Log ("PoolObject: A null pointer is in the polledObject list at ID " + i +
			           ". Abort");
			return;
		}

		if (instance.pooledObjects [i].Count == instance.poolsSizes [i]) //Check if we are pooling more object than expected
		{
			instance.poolsSizes[i]++;
			Debug.Log( "Size overflow when pooling. Size increased to " + instance.poolsSizes[i] + " and i=" +i ); 
			//If this happens, it means we are creating objects out of nowhere
		}

		//Hierarchy stuff
		obj.transform.parent = instance.transform;
		obj.SetActive (false);

		instance.pooledObjects [i].Push(obj);

		return;
	}

	public static GameObject GetObject( string typeName ) 
	{
		bool matchFound = false;
		int i;
		GameObject ret;

		for ( i = 0; i < instance.prefabs.Count; i++) 
		{
			if ( instance.prefabs[i].name == typeName ) //Yup, this work in C# ...
			{
				matchFound = true;
				break;
			}
		}

		if (!matchFound) //Exit if there is no match
		{ 
			Debug.Log("GetObject : No match found for: " + typeName );
			return null;
		}

		if (instance.pooledObjects [i] == null) //Check for null, if happens something is seriously wrong
		{
			Debug.Log ("GetObject: A null pointer is in the polledObject list at ID " + i +
			           ". Abort");
			return null;
		}

		if (instance.pooledObjects [i].Count == 0) //Log an error, and create a new object
		{
			instance.poolsSizes[i]++;

			GameObject extraObj = Instantiate( instance.prefabs[i] );
			extraObj.name = instance.prefabs[i].name;
			PoolObject( extraObj );

			Debug.Log("Too few objects in pool " + i + ". One more was created (new size is: " + 
			          instance.poolsSizes[i] + ").");
		}

		ret = instance.pooledObjects [i].Pop ();

		//Hierarchy and enable stuff
		ret.transform.parent = null; 
		ret.SetActive (true);

		return ret;
	}

	void Start()
	{
		if (instance.prefabs.Count != instance.poolsSizes.Count)
			Debug.Log ("ObjectPooler: prefabs and poolsSizes Lengths do not match !");

		instance.pooledObjects = new List<Stack<GameObject>> (instance.prefabs.Count);

		for (int i = 0; i < instance.prefabs.Count; i++) 
		{
			if ( instance.poolsSizes[i] == 0 ) instance.poolsSizes[i] = instance.defaultPoolSize;

			instance.pooledObjects.Add (new Stack<GameObject> ());
			initPool(i); //Fill the pool
		}
	}

	void Awake()
	{
		if (instance != null)
			Debug.Log("An other instance of ObjectPooler already Exists !");

		instance = this;

	}

	private void initPool(int i)
	{
		GameObject tmp;

		if (instance.poolsSizes.Count < i) //Something is serously wrong here
		{
			Debug.Log("initPool: argument was " + i + "but poolsSizes' size is " + instance.poolsSizes.Count + 
			          " something is seriously wrong here");
			return;
		}

		if (instance.pooledObjects.Count < i) //Something is serously wrong here
		{
			Debug.Log("initPool: argument was " + i + "but pooledObjects' size is " + instance.poolsSizes.Count + 
			          " something is seriously wrong here");
			return;
		}

		if (instance.poolsSizes.Count == i) //The entry does not exist yet, create it
			instance.poolsSizes.Add(instance.defaultPoolSize);


		if (instance.pooledObjects.Count == i) //The entry does not exist yet, create it
			instance.pooledObjects.Add (new Stack<GameObject> ());

		for (int j = 0; j < instance.poolsSizes[i]; j++) 
		{
			tmp = Instantiate(instance.prefabs[i]);
			tmp.name = instance.prefabs[i].name;
			PoolObject(tmp);
		}
	}
}
