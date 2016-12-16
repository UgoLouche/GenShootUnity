using UnityEngine;
using GenShootUnity.Gameplay.Trajectories;

namespace GenShootUnity.ScriptableObj.Trajectories
{
    [CreateAssetMenu(fileName = "TrajectorySO", menuName = "ScriptableObject/Trajectory/TrajectorySO", order = 1)]
    public class Trajectory : ScriptableObject
    {
        [SerializeField]
        private TrajectoryStep[] steps_ = null;

        public TrajectoryStep[] Steps { get { return steps_; } }
    }
}
