using AnimalProject.Domain.Models.Interfaces;

namespace AnimalProject.Domain.Models
{
    public abstract class Animal : IAnimal
    {
        public virtual int Age { get; set; }

        public virtual string Name { get; set; }

        public bool Active { get; set; } = true;

        public virtual void Move(int speed, int angle)
        {

        }
    }

    public abstract class Bird : IAnimal
    {
        private void Fly()
        {
            //Fly
        }

        public int Age { get; set; }
        public string Name { get; set; }

        public bool Active { get; set; } = true;

        public void Move(int speed, int angle)
        {
            Fly();
        }
    }

    public class Giraffe : Animal
    {
        public override void Move(int speed, int angle)
        {

        }
    }

    public class Cat : Animal
    {

    }

    public class Sparrow : Bird
    {

    }
}
