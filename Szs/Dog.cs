using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szs
{
    internal class Dog
    {
        string name;
        string breed;
        string age;
        string owner_id;

        public Dog(string name, string breed, string age, string owner_id)
        {
            this.name = name;
            this.breed = breed;
            this.age = age;
            this.owner_id = owner_id;
        }

        public string Name { get => name; set => name = value; }
        public string Breed { get => breed; set => breed = value; }
        public string Age { get => age; set => age = value; }
        public string Owner_id { get => owner_id; set => owner_id = value; }
    }
}
