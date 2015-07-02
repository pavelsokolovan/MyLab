using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLabService
{
    internal class Order
    {
        private int orderNumber;        // Order Number
        private Patient patient;        // Patient in Order

        // Property OrderNumber
        public int OrderNumber
        {
            get
            {
                return orderNumber;
            }
        }

        // Property Patient
        public Patient Patient
        {
            get
            {
                return patient;
            }
        }

        // Properties
        public Clinic Clinic { get; set; }          // Clinic in Order
        public Test Test { get; set; }              // Test in Order
        public Specimen Specimen { get; set; }      // Specimen in Order
        public Tube Tube { get; set; }              // Tube in Order

        // Constructor
        public Order(int orderNumber, Patient patient, Clinic clinic, Test test, Specimen specimen, Tube tube)
        {
            this.orderNumber = orderNumber;
            this.patient = patient;
            this.Clinic = clinic;
            this.Test = test;
            this.Specimen = specimen;
            this.Tube = tube;
        }
    }
}
