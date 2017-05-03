using System;

using UnityEngine;

using GenShootUnity.Core.Services;

// Implementation Details.
using ServiceProviderImpl = GenShootUnity.Core.Services.ServiceProvider;

namespace GenShootUnity.Core.GameManager
{
    class GameManager : MonoBehaviour, IGameManager
    {
        // Static / Singleton Code.
        private static IGameManager instance = null;

        public static IGameManager Instance
        {
            get
            {
                if (instance == null) instance = new GameManager();
                return instance;
            }
        }

        // Private Constructor.
        private GameManager() { }




        // Non-Singleton Code.
        private IServicesProvider serviceProvider = null;
		[SerializeField]
		private ScriptableObj.ObjectsPooler.InitialPoolList initialPoolList= null;


        // IGameManager.
        public IServicesProvider GetServiceProvider()
        {
            return serviceProvider;
        }


        //Unity Methods.
        private void Awake()
        {
            // Enforce Singleton.
            if (instance != null)
            {
                // TODO: Do something ?
                if (Debug.isDebugBuild) Debug.Log("Another instance already exists."); // TODO: Debug bookmark.
            }
            else instance = this;

            serviceProvider = new ServiceProviderImpl();
            serviceProvider.Initialize();


			if (!serviceProvider.Initialized) 
			{
				if (Debug.isDebugBuild)
					Debug.Log ("Service provider failed to initialize."); // TODO: Debug Code bookmark. 
			} 
			else 
			{
				if (serviceProvider.ObjectPooler.Initialized && initialPoolList != null) 
				{
					GameObject pooler = new GameObject ();
					pooler.transform.parent = this.transform;
					serviceProvider.ObjectPooler.SetPoolsRoot (pooler);

					foreach (GameObject obj in initialPoolList.prefabs)
						serviceProvider.ObjectPooler.PoolObject (obj, true);
				}
			}
        }
    }
}
