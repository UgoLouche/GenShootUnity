using GenShootUnity.Core.ObjectsPooler;

namespace GenShootUnity.Core.ServicesProvider
{
    interface IServicesProvider
    {
        IObjectsPooler ObjectPooler();
    }
}
