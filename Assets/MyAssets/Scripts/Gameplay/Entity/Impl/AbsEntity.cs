using System;
using GenShootUnity.Core.ObjectsPooler;
using UnityEngine;

namespace GenShootUnity.Gameplay.Entity
{
    // Everything related to Game Logic is likely an entity
    abstract class AbsEntity : AbsExtMonoBehaviour, IMovableObject, IDamageableObject, IPoolableObject
    {

        // Movable Object
        void IMovableObject.Move(Vector3 newPos)
        {
            throw new NotImplementedException();
        }

        void IMovableObject.StepMove()
        {
            throw new NotImplementedException();
        }
    }
}
