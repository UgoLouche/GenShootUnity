using UnityEngine;

using GenShootUnity.Core.GameManager;
using GenShootUnity.Core.Services;

// Implementation Details.
using GameManagerImpl = GenShootUnity.Core.GameManager.GameManager;

namespace GenShootUnity.Gameplay.Entity
{
    // Add some functionality to MonoBehaviour.
    public abstract class AbsExtMonoBehaviour : MonoBehaviour
    {
        // Define a bunch of shortcut properties for child classes.
        private IGameManager gameManager_ = null;
        private IServicesProvider serviceProvder_ = null;

        protected IGameManager GameManager
        {
            get
            {
                if (gameManager_ == null) gameManager_ = GameManagerImpl.Instance;

                return gameManager_;
            }
        }

        protected IServicesProvider ServiceProvider
        {
            get
            {
                if (serviceProvder_ == null) serviceProvder_ = GameManager.GetServiceProvider();

                return serviceProvder_;
            }
        }
    }
}
