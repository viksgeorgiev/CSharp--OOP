

namespace Farm
{
    public class StartUp
    {
        public static void Main()
        {
            Animal animal = new Animal();
            Dog dog = new Dog();

            animal.Eat();
            dog.Eat();
            dog.Bark();
        }
    }
}
