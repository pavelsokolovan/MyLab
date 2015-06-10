using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLabService
{
    public class Patient
    {
        // Properties
        public int MRN { get; set; }                // Mediacal Record Number of patient
        public string FirstName { get; set; }       // First Name of patient
        public string LastName { get; set; }        // Last Name of patient
        public PatientGender Gender { get; set; }   // Gender of patient
    }
}
