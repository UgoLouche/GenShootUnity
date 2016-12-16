using System;

using UnityEngine;

using GenShootUnity.Core.Exceptions;
using GenShootUnity.ScriptableObj.Trajectories;

namespace GenShootUnity.Gameplay.Trajectories
{
    // Need to extend MB
    class TrajectoryHandler : ITrajectoryHandler
    {
        private Trajectory trajectory = null;
        private Transform transform = null;

        // Step tracking.
        private int step = -1;
        private float timeToStepEnd = 0;

        public void Bind(Transform entityTransform, Trajectory trajectory)
        {
            if (this.trajectory == null && transform == null)
            {
                this.trajectory = trajectory;
                transform = entityTransform;

                Reset();
            }
            else throw new GameException("Trajectory Handler already bound.");
        }

        public void Reset()
        {
            step = 0;
            timeToStepEnd = 1; // Time to step end is alway 1, see Step's comment
        }

        /*
         * A few remarks on the math behind this:
         * - For simplicity's sake, each step is treated as having a timeStep of 1, thus deltaT is rescaled
         *      wrt the actual timestep at the beginning.
         * - Offsets are additive, e.g. x = x + x_off * RescaledDelaTime (=> x = x + x_off * DT1 + x_off * DT2 .... = x + x_off (DT1 + DT2 ...) = x + x_off
         * - Multipliers are multiplicative (duh), e.g. scale = scale * scale_mult ^ RescaledDeltaTime (=> scale = scale * scale_mult ^ DT1 * scale_mult ^ DT2 ....
         *       = scale * scale_mult ^ (DT1 + DT2 + ...) = scale * scale_mult.
         * - When deltaT is bigger than the remaining TimeToStepEnd the step is performed to its end, then the function is called again with the remaining deltaT on the next step.
         * - Speed acts as a direct multiplier on deltaT
         */
        public void Step(float speed, float deltaT)
        {
            // Error Handling.
            if (step == -1 || timeToStepEnd == 0)
            {
                if (Debug.isDebugBuild) Debug.Log("Trajectory Handler in an inconsistent state."); // TODO: Test and find a proper way to handle debugging and release build.

                Reset();
            }


            // Actual Step Code
            float curr_deltaT = 0;
            float remaining_deltaT = 0;

            deltaT *= speed;
            if (deltaT < timeToStepEnd)
            {
                curr_deltaT = deltaT;
                timeToStepEnd -= deltaT;
            }
            else // The call will extend to the next step.
            {
                curr_deltaT = timeToStepEnd;
                remaining_deltaT = deltaT - timeToStepEnd;
                timeToStepEnd = 0;
            }

            // Normalize DeltaT.
            curr_deltaT /= trajectory.Steps[step].StepLenght;

            // Modify Transform
            transform.position += new Vector3(trajectory.Steps[step].X_off * curr_deltaT,
                                              trajectory.Steps[step].Y_off * curr_deltaT,
                                              trajectory.Steps[step].Z_off * curr_deltaT);

            transform.Rotate(new Vector3(0, 0, 1) * trajectory.Steps[step].Theta_off * curr_deltaT);

            transform.localScale *= Mathf.Pow(trajectory.Steps[step].Scale_mult, curr_deltaT);


            // Wrap up update step tracking and recall Step() if needed.
            if (timeToStepEnd == 0)
            {
                step = (step + 1) % trajectory.Steps.Length;
                timeToStepEnd = 1;

                if (remaining_deltaT > 0)
                    Step(speed, deltaT);
            }
        }

        public void Unbind()
        {
            Reset();

            trajectory = null;
            transform = null;
        }
    }
}
