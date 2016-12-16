using GenShootUnity.Core.Initializable;
using GenShootUnity.Gameplay.Trajectories;

//Implementation Details.
using TrajectoryHandlerImpl = GenShootUnity.Gameplay.Trajectories.TrajectoryHandler;

namespace GenShootUnity.Core.Services
{
    class GameFactory : AbsInitializable, IGameFactory
    {
        // IGameFacotry.
        public ITrajectoryHandler NewTrajectoryHandler()
        {
            return new TrajectoryHandlerImpl();
        }

        // AbsInitializable.
        override protected bool InitProcedure()
        {
            return true; // Nothing to initialize for now.
        }
    }
}
