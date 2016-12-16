using GenShootUnity.Core.Initializable;
using GenShootUnity.Gameplay.Trajectories;


namespace GenShootUnity.Core.Services
{
    // General Purpose Factory for Game classes
    // Allow for centralized implementations details
    interface IGameFactory : IInitializable
    {
        ITrajectoryHandler NewTrajectoryHandler();
    }
}
