using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenShootUnity.Core.Services;

namespace GenShootUnity.Core.GameManager
{
    class GameManager : IGameManager
    {
        // Static.
        private static IGameManager instance = null;

        public static IGameManager Instance
        {
            get
            {
                if (instance == null) instance = new GameManager();

                return instance;
            }
        }

        // Private Constructor.
        private GameManager() { }


        // IGameManager.
        IServicesProvider IGameManager.GetServiceProvider()
        {
            throw new NotImplementedException();
        }
    }
}
