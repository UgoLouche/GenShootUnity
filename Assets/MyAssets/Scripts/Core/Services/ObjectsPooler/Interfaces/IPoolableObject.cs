namespace GenShootUnity.Core.Services.ObjectsPooler
{
    interface IPoolableObject
    {
        // Pool Cache if the object went through a pool already.
        IObjectsPool ParentPool { get; }

        // Pool "this".
        void Pool();
    }
}
