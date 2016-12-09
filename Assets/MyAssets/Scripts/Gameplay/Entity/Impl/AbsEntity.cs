using System;

using UnityEngine;

using GenShootUnity.Core.Services.ObjectsPooler;
using GenShootUnity.Gameplay.Trajectories;

namespace GenShootUnity.Gameplay.Entity
{
    // Everything related to Game Logic is likely an entity
    abstract class AbsEntity : AbsExtMonoBehaviour, IMovableObject, IDamageableObject, IPoolableObject
    {

        // Movable Object Fields.
        [SerializeField]
        private ITrajectory trajectory_ = null;
        private int curr_step = 0;

        // Movable Object
        public void RawMove(Vector3 newPos)
        {
            transform.position = newPos;
        }

        public void StepMove()
        {
            if (trajectory_ != null)
                curr_step = trajectory_.Step(transform, curr_step);
        }
    }
}
