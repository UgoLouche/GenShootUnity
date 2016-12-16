using UnityEngine;

using GenShootUnity.Core.Initializable;
using GenShootUnity.Gameplay.Entity;

namespace GenShootUnity.Core.Services.ObjectsPooler
{
    interface IObjectsPool : IInitializable
    {
        GameObject GetObject();

        void PoolObject(AbsEntity obj);

        void Initialize(string name, GameObject root, int size = 10); //SubRoot creation is done here.
    }
}
