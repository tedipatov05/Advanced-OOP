namespace P04.Recharge
{
    public abstract class Worker : ISleeper, IWorker
    {
        private string id;
        private int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public void Work(int hours)
        {
            this.workingHours += hours;
        }

        public void Sleep()
        {
            System.Console.WriteLine("sleep...");
        }

        
    }
}