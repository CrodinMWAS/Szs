﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szs
{
    internal class Person
    {
        string name;
        string age;
        string id;

        public Person(string name, string age, string id)
        {
            this.name = name;
            this.age = age;
            this.id = id;
            dogs = new List<Dog> { };
        }

        public string Name { get => name; set => name = value; }
        public string Age { get => age; set => age = value; }
        public string Id { get => id; set => id = value; }
        public List<Dog> dogs { get; set; }
        public void AddDog(Dog dog)
        {
            dogs.Add(dog);
        }
    }
}
