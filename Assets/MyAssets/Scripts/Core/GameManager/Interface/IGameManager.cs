using GenShootUnity.Core.Services;

namespace GenShootUnity.Core.GameManager
{
    // God-level object.
    public interface IGameManager
    {
        IServicesProvider GetServiceProvider();
    }
}
