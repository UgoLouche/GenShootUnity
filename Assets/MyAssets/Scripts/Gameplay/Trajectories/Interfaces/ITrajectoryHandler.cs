using System;

using UnityEngine;

using GenShootUnity.ScriptableObj.Trajectories;

namespace GenShootUnity.Gameplay.Trajectories
{
    /*
     * Dedicated class for handling comlplex trajectories.
     * 
     * Once binded to a transform and a trajectory each subsequent call to Step will
     * change the transform according to the trajectory.
     */
    interface ITrajectoryHandler
    {
        void Step(float speed, float deltaT);

        void Bind(Transform entityTransform, Trajectory trajectory);
        void Unbind();

        void Reset();
    }
}
