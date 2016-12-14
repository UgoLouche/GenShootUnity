//using UnityEngine;
//using System.Collections;

//public class ProximityDetector : MonoBehaviour
//{
//	void OnTriggerEnter2D(Collider2D other)
//	{
//		ProximityAware parent;

//		if (transform.parent != null) 
//		{
//			if ( (parent = transform.parent.gameObject.GetComponent<MonoBehaviour>() as ProximityAware) != null)
//				parent.OnTriggerProximity(other);
//		}
//	}
//}

