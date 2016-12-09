using UnityEngine;

namespace GenShootUnity.Core.Services.ObjectsPooler
{
    interface IObjectsPooler
    {
        GameObject GetObject(IPoolableObject obj);
        GameObject GetObject(int poolID);

        void PoolObject(IPoolableObject obj);
    }
}
