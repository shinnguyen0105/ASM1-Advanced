using System;
using System.Text;

namespace ASM1_Advanced
{
    public interface ElectricCard
    {
        bool Battery { get; }
    }
    public interface Icar
    {
        string Model { get; }
        string Color { get; }
        string Start();
        string Stop();
    }
    public abstract class Car : Icar
    {
        public Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }
        public string Model { get; protected set; }
        public string Color { get; protected set; }
        public string Start()
        {
            return "start";
        }
        public string Stop()
        {
            return "stop\n";
        }
        protected virtual string Get_infor_of_car()
        {
            return $"{this.Color}  {this.GetType().Name}  {this.Model}";
        }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(this.Start()).AppendLine(this.Get_infor_of_car()).Append(this.Stop());

            return builder.ToString();
        }
    }

    public class Tesla : Car, Icar, ElectricCard
    {
        public Tesla(string model, string color, bool battery) : base(model, color)
        {
            this.Battery = battery;
        }

        public bool Battery { get; private set; }

        protected override string Get_infor_of_car()
        {
            return base.Get_infor_of_car() + $" with  {this.Battery} Li-on Batteries";
        }
    }
    public class Mercedes : Car, Icar, ElectricCard
    {
        public Mercedes(string model, string color, bool battery) : base(model, color)
        {
            this.Battery = battery;
        }

        public bool Battery { get; private set; }

        protected override string Get_infor_of_car()
        {
            return base.Get_infor_of_car() + $" with  {this.Battery} Li-on Batteries";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Icar tesla = new Tesla("Model 3", "Red", true);
            Icar Merc = new Mercedes("C300", "Black", false);
            Console.WriteLine(tesla.ToString());
            Console.WriteLine(Merc.ToString());
        }
    }
}
