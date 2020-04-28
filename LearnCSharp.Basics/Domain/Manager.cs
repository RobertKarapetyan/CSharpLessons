namespace LearnCSharp.Basics.Domain
{
    public class Manager : Employee
    {
        private readonly string _taskMessage;
        
        public Manager(string firstName, string lastName, string taskMessage) : base(firstName, lastName)
        {
            _taskMessage = taskMessage;
        }

        public override string PerformDuties()
        {
            var result = _taskMessage;
            return result;
        }
    }
}