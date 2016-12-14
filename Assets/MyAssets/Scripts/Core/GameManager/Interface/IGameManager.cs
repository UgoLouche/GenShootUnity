using GenShootUnity.Core.Services;

namespace GenShootUnity.Core.GameManager
{
    // God-level object.
    interface IGameManager
    {
        IServicesProvider GetServiceProvider();
    }
}
