using mitoSoft.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mitoSoft.StateMachine.AdvancedStateMachines
{
    public class TransitionState : State
    {
        public TransitionState(string name, Action action) : base(name, action) { }
    }
}
