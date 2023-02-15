namespace mitoSoft.Workflows.AdvancedStateMachines
{
    public delegate void TransitionHandler(mitoSoft.Workflows.StateMachine sender, TransitionArgs args);

    public delegate void ScopeHandler(mitoSoft.Workflows.StateMachine sender);

    public class Transition
    {
        public string Name { get; set; }

        public TransitionHandler TransitionHandler { get; set; }

        public Transition(string name, TransitionHandler trans)
        {
            this.Name = name;
            this.TransitionHandler = trans;
        }
    }
}