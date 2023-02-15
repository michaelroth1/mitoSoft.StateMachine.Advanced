using mitoSoft.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mitoSoft.StateMachine.AdvancedStateMachines
{
    public class SubWorkflowState : State
    {
        public Workflows.StateMachine SubWorkflowStateMachine;
        
        public SubWorkflowState(string name,Workflows.StateMachine _subSequenceStateMachine) : base(name)
        {
            SubWorkflowStateMachine = _subSequenceStateMachine;
        }

        public override void StateFunction()
        {
            SubWorkflowStateMachine.Invoke();
        }

    }
}
