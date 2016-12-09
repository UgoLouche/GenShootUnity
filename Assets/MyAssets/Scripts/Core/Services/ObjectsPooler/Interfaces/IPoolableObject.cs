namespace GenShootUnity.Core.Services.ObjectsPooler
{
    interface IPoolableObject
    {
        // Each CLASS has a UNIQUE PoolID.
        int PoolID { get; }

        // Pool "this".
        void Pool();
    }
}
