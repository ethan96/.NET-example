using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public short Level { get; set; }
        private decimal _salary;
        [DataMember]
        public decimal Salary
        {
            get { return this._salary; }
            set { this._salary = value; }
        }
    }

}
