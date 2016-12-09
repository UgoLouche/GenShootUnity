namespace GenShootUnity.Core.StateMachine
{
    enum TransitionMode
    {
        POP,
        PUSH,
        REPLACE
    }

    interface IStackStateMachine
    {
        void NewState(IState newState, TransitionMode mode);
    }
}
