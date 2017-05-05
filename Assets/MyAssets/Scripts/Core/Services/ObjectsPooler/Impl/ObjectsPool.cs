using UnityEngine;
using System.Collections.Generic;

using GenShootUnity.Core.Initializable;
using GenShootUnity.Gameplay.Entity;

namespace GenShootUnity.Core.Services.ObjectsPooler
{
	class ObjectsPool : AbsInitializable, IObjectsPool 
	{
		// Fields.
		// When possible, keep a copy if a reseed is needed.
		private AbsEntity referenceCopy = null;
		private Stack<AbsEntity> objects = new Stack<AbsEntity>(0);
		private int totalCreated = 0;

		private GameObject root = null;
		private string name = "";

		// IObjectsPool
		// Shouldn't be called directly. Use obj.Pool()
		public void PoolObject(AbsEntity obj)
		{
			obj.Notify_enterPool (this);
			obj.gameObject.SetActive (false);
			obj.transform.parent = root.transform;

			// Grab a copy for re-seed if none set
			if (referenceCopy == null) 
			{
				referenceCopy = GameObject.Instantiate (obj.gameObject).GetComponent<AbsEntity> ();
				referenceCopy.gameObject.name = obj.gameObject.name;
				referenceCopy.transform.parent = root.transform;
			}
				
			objects.Push (obj);
		}

		public GameObject GetObject()
		{
			if (objects.Count == 0) 
			{
				if (FillPool (1 + totalCreated * 2) == 0) 
				{
					if (Debug.isDebugBuild)
						Debug.Log ("Empty pool '" + name + "'  cannot be filled"); //TODO: Debug code bookmark.
					return null;
				}
			}

			GameObject ret = objects.Pop ().gameObject;
			ret.transform.parent = null;
			ret.SetActive (true);
			ret.GetComponent<AbsEntity> ().Notify_leavePool ();

			return ret;
		}

		public int FillPool (int size, GameObject prefab = null)
		{
			if (referenceCopy == null) 
			{
				if (prefab == null ||
				    (referenceCopy = prefab.GetComponent<AbsEntity> ()) == null) 
				{
					if (Debug.isDebugBuild)
						Debug.Log ("Cannot instatiate from prefab in FillPool (pool '" + name + "')");

					return 0;
				}
			} 
			else if (prefab != null && Debug.isDebugBuild)
				Debug.Log ("Copy prefab already set, prefab argument of FillPool (pool '" + name + "') ignored");

			// Actual filling starts here
			for (int i = 0; i < size; ++i) 
			{
				AbsEntity tmp = GameObject.Instantiate (referenceCopy.gameObject).GetComponent<AbsEntity> ();
				tmp.name = referenceCopy.name;

				PoolObject (tmp);
				++totalCreated;
			}

			return size;
		}

		public void Initialize(string name, GameObject root) //SubRoot creation is done here.
		{
			this.name = name;

			this.root = new GameObject ();
			this.root.name = name;
			this.root.transform.parent = root.transform;

			Initialize ();
		}

		protected override bool InitProcedure ()
		{
			// Is there anything to do here ?
			return true;
		}
	}
}