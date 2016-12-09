using UnityEngine;

namespace GenShootUnity.Gameplay.Trajectories
{
    interface ITrajectory
    {
        int Step(Transform transform, int step);
    }
}
