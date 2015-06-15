using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLabService
{
    public class Specimen: Item
    {
        // Property VolumeUnit
        public SpecimenVolumeUnit VolumeUnit { get; set; }

        // Constructor
        public Specimen(string code, string name, SpecimenVolumeUnit volumeUnit): base(code, name)
        {
            this.VolumeUnit = volumeUnit;
        }
    }
}
