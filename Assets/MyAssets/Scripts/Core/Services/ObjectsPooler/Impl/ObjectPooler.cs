using UnityEngine;

using System.Collections.Generic;

using GenShootUnity.Core.Exceptions;
using GenShootUnity.Core.Initializable;
using GenShootUnity.Core.Services;
using GenShootUnity.Gameplay.Entity;

// Detail Implementation.
using GameManagerImpl = GenShootUnity.Core.GameManager.GameManager;

namespace GenShootUnity.Core.Services.ObjectsPooler
{
    class ObjectPooler : AbsInitializable, IObjectsPooler
    {
        // Shorcuts
        private IGameFactory factory_ = null;
        private IGameFactory Factory
        {
            get
            {
                if (factory_ == null) factory_ = GameManagerImpl.Instance.GetServiceProvider().GameFactory;

                return factory_;
            }
        }


        // Fields.
        private Dictionary<string, IObjectsPool> pools = new Dictionary<string, IObjectsPool>();
        private GameObject pools_root;


        // GetObject methods.
		public GameObject GetObject(string name)
		{
			return GetObject (name, 1)[0];
		}
		public GameObject GetObject(AbsEntity prefab)
		{
			return GetObject (prefab, 1)[0];
		}
		public GameObject GetObject(GameObject prefab)
		{
			return GetObject (prefab, 1)[0];
		}
		public GameObject[] GetObject(AbsEntity prefab, int nb_copies)
		{
			return GetObject (prefab.gameObject.name, nb_copies);
		}

		public GameObject[] GetObject(GameObject prefab, int nb_copies)
		{
			return GetObject (prefab.name, nb_copies);
		}

        public GameObject[] GetObject(string name, int nb_copies)
        {
            GameObject[] ret = new GameObject[nb_copies];

            IObjectsPool selected_Pool = GetPool(name);
            if (selected_Pool != null)
            {
                for (int i = 0; i < nb_copies; ++i) ret[i] = selected_Pool.GetObject();
            }
            else
            {
                if (Debug.isDebugBuild) Debug.LogError("Pool not Found for " + name); // TODO: Debug Bookmark
                ret = null;
            }

            return ret;
        }


        // PoolObject methods.
		public void PoolObject(AbsEntity obj)
        {
            IObjectsPool selected_Pool = GetPool(obj);
            if (selected_Pool == null)
            {
                selected_Pool = Factory.NewObjectsPool();
                selected_Pool.Initialize("Pool_" + obj.gameObject.name, pools_root);

                if (!selected_Pool.Initialized) throw new GameException("Cannot Initialize new Pool");

                pools.Add(obj.gameObject.name, selected_Pool);
                if (Debug.isDebugBuild) Debug.Log("Unexpected Pool Created for object: " + obj.gameObject.name);
            }

            selected_Pool.PoolObject(obj);
        }

		public void PoolObject(GameObject obj, bool prefab = false)
        {
			// If prefab create a copy of the object.
			// /!\ change name as unity will call it "copy_of_XXX" or something.  
			if (prefab) 
			{
				string name = obj.name;
				obj = GameObject.Instantiate (obj);
				obj.name = name;
			}

            AbsEntity absEnt = obj.GetComponent<AbsEntity>();

            if (absEnt == null)
            {
                if (Debug.isDebugBuild) Debug.LogError("Trying to pool and non-PoolableObject: " + obj.name);
            }
            else
                PoolObject(absEnt);
        }

		public void SetPoolsRoot(GameObject poolsRoot)
		{
			pools_root = poolsRoot;
		}


		// Protected. 
		protected override bool InitProcedure()
		{
			// Is there anything to do here ?
			return false;
		}


        // Ad-Hoc Functions.
        private IObjectsPool GetPool(string name)
        {
            IObjectsPool ret;
            if (pools.TryGetValue(name, out ret)) return ret;
            else return null;
        }

        private IObjectsPool GetPool(AbsEntity obj)
        {
            IObjectsPool ret = obj.ParentPool;

            if (ret == null) return GetPool(obj.gameObject.name);
            else return ret;
        }

        private IObjectsPool GetPool(GameObject obj)
        {
            AbsEntity absEnt = obj.GetComponent<AbsEntity>();

            if (absEnt == null)
            {
                if (Debug.isDebugBuild) Debug.LogError("Tried to pool and non-Poolable Object: " + obj.name); // TODO: Debug Bookmark
                return null;
            }
            else return GetPool(absEnt);
        }
    }
}
