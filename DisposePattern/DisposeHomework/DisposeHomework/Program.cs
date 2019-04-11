namespace DisposeHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass bc = new BaseClass();
            DerivedClass dc = new DerivedClass();
            BaseClassUnmanaged bcu = new BaseClassUnmanaged("test.txt");
            DerivedClassUnmanaged dcu = new DerivedClassUnmanaged("test.txt");
            dcu.WriteFileInfo();
        }
    }
}
