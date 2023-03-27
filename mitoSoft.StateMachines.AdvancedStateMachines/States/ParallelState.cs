using mitoSoft.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mitoSoft.StateMachine.AdvancedStateMachines
{
    public class ParallelState : State
    {
        public List<Workflows.StateMachine> stateMachines;
        public ParallelState(string name) : base(name)
        {
            stateMachines = new List<Workflows.StateMachine>();
        }

        public ParallelState AddToParallel(Workflows.StateMachine stateMachine)
        {
            stateMachines.Add(stateMachine);

            return this;
        }

        public override void StateFunction()
        {
            List<Thread> tasks = new List<Thread>();

            foreach (var machine in stateMachines)
            {
                tasks.Add(new Thread(machine.Invoke));
            }

            tasks.ForEach(x => x.Start());

            tasks.ForEach(x => x.Join());
        }
    }
}
