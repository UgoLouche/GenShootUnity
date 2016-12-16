namespace GenShootUnity.Core.Initializable
{
    abstract class AbsInitializable : IInitializable
    {
        private bool initialized_ = false;
        public bool Initialized { get { return initialized_; } }

        public void Initialize()
        {
            if (!Initialized)
            {
                if (InitProcedure()) initialized_ = true;
            }
        }

        protected abstract bool InitProcedure();
    }
}
