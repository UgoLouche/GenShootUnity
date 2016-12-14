//using UnityEngine;
//using System.Collections;

//public class Explosion : MonoBehaviour
//{
//	public float timeToLive = 1;

//    private Vector3 originScale; //Beware of WHEN the bolt is activated

//	void OnEnable()
//	{
//		StartCoroutine ("EndOfLife");
//        originScale = transform.localScale;
//	}

//	private IEnumerator EndOfLife()
//	{
//		yield return new WaitForSeconds (timeToLive);

//        transform.localScale = originScale; //reset scale
//		ObjectPooler.PoolObject (gameObject);
//	}


//}

