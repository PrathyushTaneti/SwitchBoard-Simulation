using System;

namespace Task{
    public class Appliance
    {
        public Appliance(string name, int id)
        {
            this.Name = name;
            this.State = State.Off;
            this.Id = id;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public State State { get; set; }
    }
}