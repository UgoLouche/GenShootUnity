using UnityEngine;

using GenShootUnity.Core.Initializable;
using GenShootUnity.Gameplay.Entity;

namespace GenShootUnity.Core.Services.ObjectsPooler
{
    interface IObjectsPool : IInitializable
    {
        GameObject GetObject();

        void PoolObject(AbsEntity obj);

        void Initialize(string name, GameObject root); //SubRoot creation is done here.

		// Fill the pool
		// The pool will automatically make a copy of the first object pooled for Filling purpose and prefab is ignored.
		// On a completely new pool, you must provide a valid prefab.
		// Return the number of created objects
		int FillPool (int size, GameObject prefab = null); 
    }
}
