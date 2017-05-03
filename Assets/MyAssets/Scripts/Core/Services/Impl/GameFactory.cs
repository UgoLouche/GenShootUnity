using GenShootUnity.Core.Initializable;
using GenShootUnity.Gameplay.Trajectories;
using GenShootUnity.Core.Services.ObjectsPooler;

//Implementation Details.
using TrajectoryHandlerImpl = GenShootUnity.Gameplay.Trajectories.TrajectoryHandler;
using ObjectPoolsImpl = GenShootUnity.Core.Services.ObjectsPooler.ObjectsPool;

namespace GenShootUnity.Core.Services
{
    class GameFactory : AbsInitializable, IGameFactory
    {
        // IGameFacotry.
        public ITrajectoryHandler NewTrajectoryHandler()
        {
            return new TrajectoryHandlerImpl();
        }

		public IObjectsPool NewObjectsPool()
		{
			return new ObjectPoolsImpl();
		}

        // AbsInitializable.
        override protected bool InitProcedure()
        {
            return true; // Nothing to initialize for now.
        }
    }
}
