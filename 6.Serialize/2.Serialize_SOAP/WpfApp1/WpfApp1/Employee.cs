using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    //[Serializable]//一定要加不然會錯
    //public class Employee
    //{
    //    public string Name { get; set; }
    //    public short Level { get; set; }
    //    private decimal _salary;
    //    public decimal Salary
    //    {
    //        get { return this._salary; }
    //        set { this._salary = value; }
    //    }
    //}

    [Serializable]//一定要加不然會錯
    public class Employee : ISerializable
    {
        public string Name { get; set; }
        public short Level { get; set; }
        private decimal _salary;
        public decimal Salary
        {
            get { return this._salary; }
            set { this._salary = value; }
        }

        [NonSerialized]
        public int TestID;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Level", Level);
            info.AddValue("Salary", Salary);
        }
        public Employee()
        { }
        private Employee(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Level = info.GetInt16("Level");
            Salary = info.GetDecimal("Salary");
        }
    }
}
