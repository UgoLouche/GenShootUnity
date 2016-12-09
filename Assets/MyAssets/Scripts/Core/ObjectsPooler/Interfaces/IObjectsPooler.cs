using UnityEngine;

namespace GenShootUnity.Core.ObjectsPooler
{
    interface IObjectsPooler
    {
        GameObject GetObject(IPoolableObject obj);
        GameObject GetObject(int poolID);

        void PoolObject(IPoolableObject obj);
    }
}
