using UnityEngine;

using GenShootUnity.Core.Initializable;
using GenShootUnity.Gameplay.Entity;

namespace GenShootUnity.Core.Services.ObjectsPooler
{
    interface IObjectsPooler : IInitializable
    {
        GameObject GetObject(string name);
        GameObject GetObject(AbsEntity prefab);
        GameObject GetObject(GameObject prefab);
        GameObject[] GetObject(string name, int nb_copies);
        GameObject[] GetObject(AbsEntity prefab, int nb_copies);
        GameObject[] GetObject(GameObject prefab, int nb_copies);

		// Special call for prefabs because you need to duplicate the object first.
		// Default this second argument in implementation ?
		void PoolObject(GameObject obj, bool prefab = false);
		void PoolObject(AbsEntity obj);

        void SetPoolsRoot(GameObject poolsRoot);
    }
}
