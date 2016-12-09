using UnityEngine;

namespace GenShootUnity.Gameplay.Entity
{
    interface IMovableObject
    {
        void RawMove(Vector3 newPos);
        void StepMove();
    }
}
