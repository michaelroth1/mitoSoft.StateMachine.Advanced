using mitoSoft.Graphs.Exceptions;
using mitoSoft.Workflows;

namespace mitoSoft.Workflows.AdvancedStateMachines
{
    public class BuildableStateMachine : mitoSoft.Workflows.StateMachine
    {
        private readonly List<TempEdge> _edges = new();

        public new BuildableStateMachine AddNode(mitoSoft.Workflows.State state)
        {
            base.AddNode(state);

            return this;
        }

        public BuildableStateMachine AddEdge(string sourceName, string targetName)
        {
            return this.AddEdge(sourceName, targetName, () => true, "true");
        }

        public new BuildableStateMachine AddEdge(string sourceName, string targetName, mitoSoft.Workflows.Condition condition)
        {
            return this.AddEdge(sourceName, targetName, condition, "");
        }

        public BuildableStateMachine AddEdge(string sourceName, string targetName, mitoSoft.Workflows.Condition condition, string description)
        {
            _edges.Add(new TempEdge(sourceName, targetName, condition, description));
            return this;
        }

        public virtual BuildableStateMachine Build()
        {
            foreach (var edge in _edges)
            {
                base.AddEdge(edge.Source, edge.Target, edge.Condition);
                var e = base.GetEdge(edge.Source, edge.Target);
                e.Description = edge.Description;
            }

            return this;
        }

        public BuildableStateMachine AddState(string name)
        {
            this.AddNode(new mitoSoft.Workflows.State(name));

            return this;
        }

        public BuildableStateMachine AddState(string name, Action stateAction)
        {
            this.AddNode(new mitoSoft.Workflows.State(name, stateAction));

            return this;
        }

        public BuildableStateMachine AddState(string name, Action stateAction, Action stateExitAction)
        {
            this.AddNode(new mitoSoft.Workflows.State(name, stateAction, stateExitAction));

            return this;
        }

        public bool TempEdgeExists(string source, string target)
        {                     
            return _edges.Any(x=>x.Source==source && x.Target == target);
        }

        //public BuildableStateMachine AddTransition(string name, TransitionHandler transitionActiom)
        //{
        //    this.AddTransition(new Transition(name, transitionActiom));

        //    return this;
        //}

        //public BuildableStateMachine AddTransition(string sourceName, string targetName)
        //{
        //    this.AddEdge(sourceName, targetName);

        //    return this;
        //}

        //private void AddTransition(Transition transition)
        //{
        //    var args = new TransitionArgs()
        //    {
        //        Name = transition.Name,
        //    };

        //    transition.TransitionHandler.Invoke(this, args);

        //    this.AddNode(new mitoSoft.Workflows.State($"{transition.Name}", args.Action));

        //    bool selfLoopExisting = false;
        //    foreach (var condition in args.Conditions)
        //    {
        //        if (condition.Key == transition.Name)
        //        {
        //            selfLoopExisting = true;
        //        }
        //        this.AddEdge($"{transition.Name}", condition.Key, condition.Value, args.Descriptions[condition.Key]);
        //    }

        //    if (!selfLoopExisting) //Notfallplan um Deadlock zu vermeiden
        //    {
        //        this.AddEdge($"{transition.Name}", $"{transition.Name}");
        //    }
        //}

        //public BuildableStateMachine AddScope(ScopeHandler scope)
        //{
        //    scope.Invoke(this);

        //    return this;
        //}
    }

    internal class TempEdge
    {
        public string Source { get; set; }

        public string Target { get; set; }

        public mitoSoft.Workflows.Condition Condition { get; set; }

        public string Description { get; set; }

        public TempEdge(string source, string target, mitoSoft.Workflows.Condition condition, string description)
        {
            this.Source = source;
            this.Target = target;
            this.Condition = condition;
            this.Description = description;
        }
    }

}