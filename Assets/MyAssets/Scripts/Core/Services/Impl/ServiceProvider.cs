using UnityEngine;

using GenShootUnity.Core.Initializable;
using GenShootUnity.Core.Services.ObjectsPooler;

// Implementation Details.
using GameFactoryImpl = GenShootUnity.Core.Services.GameFactory;

namespace GenShootUnity.Core.Services
{
    class ServiceProvider : AbsInitializable, IServicesProvider
    {
        private IObjectsPooler objectPooler_ = null;
        private IGameFactory gameFactory_ = null;

        public IObjectsPooler ObjectPooler { get { return objectPooler_; } }
        public IGameFactory GameFactory { get { return gameFactory_; } }

        // AbsInitializable.
        protected override bool InitProcedure()
        {
            bool initFlag = true;

            // Object Pooler.
            // Nothing for now.


            // GameFactory
            gameFactory_ = new GameFactoryImpl();
            GameFactory.Initialize();

            initFlag = initFlag && GameFactory.Initialized;
            if (Debug.isDebugBuild && !GameFactory.Initialized) Debug.Log("GameFactory Initialization failed."); // TODO: Debug code bookmark.


            return initFlag;
        }
    }
}
