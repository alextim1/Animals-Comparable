using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsComparble
{
    public static class AnimalReader
    {
        public static AnimalComparable AnimalRead()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            if (inputs[0] == "Cat")
                return new Cat(inputs[1], inputs[2]);
            else if (inputs[0] == "Dog")
                return new Dog(inputs[1], inputs[2]);
            else
                return new Duck(inputs[1], inputs[2]);
                 
             
        }
    }

    public class Cat : AnimalComparable, IComparable<Cat> 
    {
        public Cat(string ID, string Age):base(ID, Age)
        {

        }

        public int CompareTo(Cat other)
        {
            return this.GetHashCode() - other.GetHashCode();
        }

        public override int GetHashCode()
        {
            return 1000 + Age; // 1000 - define an uniq order of cats in animal range 
        }
    }

    public class Dog : AnimalComparable, IComparable<Dog>
    {

        public Dog(string ID, string Age):base(ID, Age)
        {

        }

        public int CompareTo(Dog other)
        {
            return this.GetHashCode() - other.GetHashCode();
        }

        public override int GetHashCode()
        {
            return 2000 + Age; // 2000 - define an uniq order of dogs in animal range 
        }
    }


    public class Duck : AnimalComparable, IComparable<Duck>
    {

        public Duck(string ID, string Age):base(ID, Age)
        {

        }

        public int CompareTo(Duck other)
        {
            return this.GetHashCode() - other.GetHashCode();
        }

        public override int GetHashCode()
        {
            return 3000 + Age; // 3000 - define an uniq order of ducks in animal range 
        }
    }


    public class AnimalComparable : IComparable<AnimalComparable>
    {
        public string ID { get; set; }
        public byte Age { get; set; }

        public AnimalComparable() { }

        public AnimalComparable(string ID, string Age)
        {
            this.ID = ID;
            this.Age = byte.Parse(Age);
        }

        public int CompareTo(AnimalComparable other)
        {
            return this.GetHashCode() - other.GetHashCode();
        }

        public override string ToString()
        {
            return this.GetType().ToString() + " " + ID + " " + Age.ToString();
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input five animals (example Cat Murka 6)");

            AnimalComparable[] Animals = new AnimalComparable [5] ;
            for (int i=0; i<5; i++)
            {
                Animals[i] = AnimalReader.AnimalRead();
            }

            Array.Sort(Animals);

            foreach(var animal in Animals)
            {
                Console.Write(animal.ToString());
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
