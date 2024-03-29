﻿using mitoSoft.Graphs.Exceptions;
using mitoSoft.StateMachine.AdvancedStateMachines;

namespace mitoSoft.Workflows.AdvancedStateMachines
{
    public class TransitionalStateMachine : BuildableStateMachine
    {
        public new TransitionalStateMachine AddNode(mitoSoft.Workflows.State state)
        {
            base.AddNode(state);

            return this;
        }

        public new TransitionalStateMachine AddEdge(string sourceName, string targetName)
        {
            return (TransitionalStateMachine)base.AddEdge(sourceName, targetName, () => true, "true");
        }

        public new TransitionalStateMachine AddEdge(string sourceName, string targetName, mitoSoft.Workflows.Condition condition)
        {
            return (TransitionalStateMachine)base.AddEdge(sourceName, targetName, condition, "");
        }

        public new TransitionalStateMachine AddEdge(string sourceName, string targetName, mitoSoft.Workflows.Condition condition, string description)
        {
            return (TransitionalStateMachine)base.AddEdge(sourceName, targetName, condition, description);
        }

        public override TransitionalStateMachine Build()
        {
            return (TransitionalStateMachine)base.Build();
        }

        public TransitionalStateMachine AddTransition(string name, TransitionHandler transitionAction)
        {
            this.AddTransition(new Transition(name, transitionAction));

            return this;
        }

        private void AddTransition(Transition transition)
        {
            var args = new TransitionArgs()
            {
                Name = transition.Name,
            };

            transition.TransitionHandler.Invoke(this, args);

            this.AddNode(new TransitionState($"{transition.Name}_Transi", args.Action));
            this.AddEdge($"{transition.Name}", $"{transition.Name}_Transi");

            foreach (var condition in args.Conditions)
            {
                this.AddEdge($"{transition.Name}_Transi", condition.Key.Target, condition.Value, condition.Key.Name);
            }

            this.TryAddEdge($"{transition.Name}_Transi", $"{transition.Name}_Transi"); //Notfallplan um Deadlock zu vermeiden
        }

        /// <summary>
        /// Notfallplan um Deadlock zu vermeiden
        /// Ist in Try/catch gepackt um einen Buildfehler zu vermeiden, wenn bereits eine direkte Verbindung(selfloop) an der Nde existiert 
        /// </summary>
        private void TryAddEdge(string from, string to)
        {
            try
            {
                if(!TempEdgeExists(from,to))
                    this.AddEdge(from, to);
            }
            catch { }
        }
         


        public new bool TempEdgeExists(string source, string target)
        {
            return base.TempEdgeExists(source, target);  
        }
    }
}