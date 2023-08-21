
namespace CourseProject.Services
{
    public static class Counter
    {
        public static int Count { get; private set; }
        public static void IncreaseCount(int value) => Count += value;
        public static void ResetCount() => Count = -1;
    }
}
