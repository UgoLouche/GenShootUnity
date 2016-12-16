namespace GenShootUnity.Core.Initializable
{
    interface IInitializable
    {
        bool Initialized { get; }

        void Initialize();
    }
}
