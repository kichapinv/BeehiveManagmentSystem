﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem
{
    internal class EggCare : Bee
    {
        public override float CostPerShift { get { return 1.35f; } }
        public const float CARE_PROGRESS_PER_SHIFT = 0.15f;
        private Queen queen;

        public EggCare(Queen queen) : base("EggCare") 
        {
            this.queen = queen;
        }

        protected override void DoJob()
        {
            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
}
