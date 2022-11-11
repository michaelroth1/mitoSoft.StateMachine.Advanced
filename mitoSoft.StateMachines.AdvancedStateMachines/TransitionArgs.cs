namespace mitoSoft.Workflows.AdvancedStateMachines
{
    public class TransitionArgs
    {
        public Dictionary<string, mitoSoft.Workflows.Condition> Conditions { get; } = new();

        public System.Action Action { get; set; }

        public string Name { get; set; } = String.Empty;

        public void AddCondition(mitoSoft.Workflows.Condition condition, string target)
        {
            this.Conditions.Add(target, condition);
        }
    }
}