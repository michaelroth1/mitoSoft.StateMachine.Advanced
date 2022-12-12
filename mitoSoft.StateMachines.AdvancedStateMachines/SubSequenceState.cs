﻿using mitoSoft.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mitoSoft.StateMachine.AdvancedStateMachines
{
    public class SubSequenceState : State
    {
        Workflows.StateMachine SubSequenceStateMachine;
        
        public SubSequenceState(string name,Workflows.StateMachine _subSequenceStateMachine) : base(name)
        {
            SubSequenceStateMachine = _subSequenceStateMachine;
        }

        public override void StateFunction()
        {
            SubSequenceStateMachine.Invoke();
        }

    }
}
