using mitoSoft.Workflows.AdvancedStateMachines;
using mitoSoft.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mitoSoft.Graphs;

namespace mitoSoft.StateMachine.AdvancedStateMachines
{
    public class SequenceStateMachine : ParallelStateMachine
    {

        public SequenceStateMachine AddSequenceNode(SequenceState node)
        {
            if (this.Start == null)
            {
                this.Start = node;
            }

            base.AddNode(node);

            return this;
        }

        public new SequenceStateMachine AddSingleNode(string nodeName, string nextNode, Action action)
        {
            return (SequenceStateMachine)base.AddSingleNode(nodeName, nextNode, action);
        }

        public new SequenceStateMachine AddSingleNode(State state, string nextNodeName)
        {
            return (SequenceStateMachine)base.AddSingleNode(state, nextNodeName);
        }

        public new SequenceStateMachine AddParallelNode(ParallelState node)
        {
            return (SequenceStateMachine)base.AddParallelNode(node);
        }

        public new SequenceStateMachine AddNode(State state)
        {
            return (SequenceStateMachine) base.AddNode(state);
        }

        public new SequenceStateMachine AddNode(string nodeName, Action action, Action? exitAction = null)
        {
            return (SequenceStateMachine)base.AddNode(nodeName, action, exitAction);
        }

        public new SequenceStateMachine AddConditionalNode(string name, TransitionHandler transitionAction)
        {
            return (SequenceStateMachine)base.AddTransition(name, transitionAction);
        }

        public new SequenceStateMachine AddEdge(string sourceName, string targetName)
        {
            return (SequenceStateMachine)base.AddEdge(sourceName, targetName, () => true, "true");
        }

        public new SequenceStateMachine AddEdge(string sourceName, string targetName, Condition condition)
        {
            return (SequenceStateMachine)base.AddEdge(sourceName, targetName, condition, "");
        }

        public new SequenceStateMachine AddEdge(string sourceName, string targetName, Condition condition, string description)
        {
            return (SequenceStateMachine)base.AddEdge(sourceName, targetName, condition, description);
        }

        public override SequenceStateMachine Build()
        {
            return (SequenceStateMachine)base.Build();
        }

        public List<string> GetAllNodes()
        {
            var nodes = new List<string>();
            foreach (var item in _nodes)
            {
                nodes.Add(item.Key);
            }
            return  nodes;
        }

        public List<Workflows.Transition> GetAllEdges()
        {
            var edges = new List<Workflows.Transition>();
            foreach (var item in Edges)
            {
                edges.Add(item);
            }
            return edges;
        }
    }
}
