namespace GenShootUnity.Core.Initializable
{
    public interface IInitializable
    {
        bool Initialized { get; }

        void Initialize();
    }
}
