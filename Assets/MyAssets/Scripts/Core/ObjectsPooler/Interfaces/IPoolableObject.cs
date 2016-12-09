namespace GenShootUnity.Core.ObjectsPooler
{
    interface IPoolableObject
    {
        // Each CLASS has a UNIQUE PoolID.
        int PoolID { get; } 
    }
}
