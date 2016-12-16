using UnityEngine;

namespace GenShootUnity.ScriptableObj.Trajectories
{
    /*
     * Beware that StepLenght != StepTime. Longer step need a proportinally longer StepLenght or speed make no sense
     * (although this is negligible for small curved path ...)
     */
    [System.Serializable]
    public class TrajectoryStep
    {
        [SerializeField]
        private float fwd_off_ = 0, theta_off_ = 0, scale_mult_ = 1, stepLenght_ = 1;

        public float Fwd_off    { get { return fwd_off_; } }
        public float Theta_off  { get { return theta_off_; } }
        public float Scale_mult { get { return scale_mult_; } }
        public float StepLenght { get { return stepLenght_; } }
    }
}
