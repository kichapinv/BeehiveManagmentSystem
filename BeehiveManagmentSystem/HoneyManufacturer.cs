using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem
{
    internal class HoneyManufacturer : Bee
    {
        public override float CostPerShift { get { return 1.7f; } }
        public const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;

        public HoneyManufacturer() : base("HoneyManufacturer") { }

        protected override void DoJob()
        {
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }
    }
}
