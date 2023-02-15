namespace mitoSoft.Workflows.AdvancedStateMachines
{
    public class TransitionArgs
    {
        public Dictionary<(string Name, string Target), mitoSoft.Workflows.Condition> Conditions { get; } = new();
        
        public System.Action Action { get; set; }

        public string Name { get; set; } = String.Empty;

        public void AddCondition(string transitionName, mitoSoft.Workflows.Condition condition, string target)
        {
            this.Conditions.Add((transitionName, target), condition);           
        }
    }
}