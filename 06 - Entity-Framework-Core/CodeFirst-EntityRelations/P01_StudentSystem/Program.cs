using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    class Program
    {
        static void Main()
        {
            var context = new StudentSystemContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //SeedData(context);
        }

        private static void SeedData(StudentSystemContext context)
        {
        }
    }
}
