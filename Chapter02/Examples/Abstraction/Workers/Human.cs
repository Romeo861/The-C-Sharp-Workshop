﻿namespace Chapter02.Examples.Abstraction.Workers
{
    public abstract class Human : IWorker
    {
        public string Name { get; }
        public int Age { get; }
        public float Weight { get; }
        public float Height { get; }

        protected Human(string name, int age, float weight, float height)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
        }

        public abstract void Work();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}," +
                   $"{nameof(Age)}: {Age}," +
                   $"{nameof(Weight)}: {Weight}," +
                   $"{nameof(Height)}: {Height}";
        }
    }
}
