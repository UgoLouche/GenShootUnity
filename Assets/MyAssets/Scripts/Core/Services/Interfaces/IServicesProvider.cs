using GenShootUnity.Core.Services.ObjectsPooler;

namespace GenShootUnity.Core.Services
{
    interface IServicesProvider
    {
        IObjectsPooler ObjectPooler { get; }
        IGameFactory GameFactory { get; }
    }
}
