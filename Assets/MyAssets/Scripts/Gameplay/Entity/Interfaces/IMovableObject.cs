using UnityEngine;

namespace GenShootUnity.Gameplay.Entity
{
    interface IMovableObject
    {
        void Move(Vector3 newPos);
        void StepMove();
    }
}
