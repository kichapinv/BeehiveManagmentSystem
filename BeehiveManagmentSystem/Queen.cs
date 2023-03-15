using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem
{
    internal class Queen : Bee
    {
        public override float CostPerShift { get { return 2.15f; } }
        public const float EGGS_PER_SHIFT = 0.45f;
        public const float HONEY_PER_UNASSIGNED_WORKER = .5f;

        private Bee[] workers = new Bee[0];
        private float eggs = 0;
        private float unassignedWorkers = 3;

        public string StatusReport { get; private set; }
        public Queen() : base("Queen") 
        {
            AssignBee("NectarCollector");
            AssignBee("EggCare");
            AssignBee("HoneyManufacturer");
        }

        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach (Bee worker in workers)
            {
                worker.WorkTheNextShift();         
            }
            HoneyVault.ConsumeHoney(unassignedWorkers * HONEY_PER_UNASSIGNED_WORKER);
            UpdateStatusReport();
        }

        private string WorkerStatus(string job)
        {
            int count = 0;
            foreach (Bee worker in workers)
            {
                if (worker.Job == job) count++;
            }
            string s = "s";
            if (count == 1) s = "";
            return $"{count} {job} bee{s}";
            
        }
        private void UpdateStatusReport()
        {
            StatusReport = $"Vault report:\n{HoneyVault.StatusReport}\n" +
            $"\nEgg count: {eggs:0.0}\nUnassigned workers: {unassignedWorkers:0.0}\n" +
            $"{WorkerStatus("NectarCollector")}\n{WorkerStatus("HoneyManufacturer")}" +
            $"\n{WorkerStatus("EggCare")}\nTOTAL WORKERS: {workers.Length}";
        }

        public void AssignBee(string job)
        {
            switch (job)
            {
                case "EggCare":
                    AddWorker(new EggCare(this));
                    break;
                case "NectarCollector":
                    AddWorker(new NectarCollector());
                    break;
                case "HoneyManufacturer":
                    AddWorker(new HoneyManufacturer());
                    break;
            }
        }

        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }

        private void AddWorker(Bee worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }

        
    }
}
