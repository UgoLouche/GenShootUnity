using GenShootUnity.Core.Initializable;
using GenShootUnity.Core.Services.ObjectsPooler;

namespace GenShootUnity.Core.Services
{
    public interface IServicesProvider : IInitializable
    {
        IObjectsPooler ObjectPooler { get; }
        IGameFactory GameFactory { get; }
    }
}
