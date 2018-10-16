namespace AnimalProject.Domain.Models.Interfaces
{
    public interface IAnimal
    {
        int Age { get; set; }
        string Name { get; set; }
        void Move(int speed, int angle);
        bool Active { get; set; }
    }
}