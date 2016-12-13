using System;

using UnityEngine;

namespace GenShootUnity.Gameplay.Trajectories
{
    /*
     * Represent an entity's trajectory.
     * This allow to modelize complex move pattern, therefore each trajectory object
     * is linked to at most 1 entity.
     * 
     * Functionally, once linked the trajectory object automlatically modify the entity's 
     * transform according to the predefined move pattern with each call of Step().
     */
    interface ITrajectory
    {
        void Step(float speed, float deltaT);

        void Bind(Transform entityTransform); // May throw an exception if trajectory is already bound.
        void Unbind();

        void Reset();
    }
}
