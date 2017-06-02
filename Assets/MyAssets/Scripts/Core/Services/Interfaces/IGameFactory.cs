using GenShootUnity.Core.Initializable;
using GenShootUnity.Core.Services.ObjectsPooler;
using GenShootUnity.Gameplay.Trajectories;


namespace GenShootUnity.Core.Services
{
    // General Purpose Factory for Game classes
    // Allow for centralized implementations details
    public interface IGameFactory : IInitializable
    {
        // Trajectory.
        ITrajectoryHandler NewTrajectoryHandler();

        // Object Pooler
        IObjectsPool NewObjectsPool();
    }
}
