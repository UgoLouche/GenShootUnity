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

        void PoolObject(GameObject obj);
        void PoolObject(AbsEntity obj);

        void SetPoolsRoot(GameObject poolsRoot);
    }
}
