namespace TheoryDemoTest.ClassData
{
    public class FactoryDataClassData : TheoryData<int, int, int>
    {
        public FactoryDataClassData()
        {
            Add(10, 5, 5);
            Add(12, 9, 3);
            Add(4, 2, 2);
            Add(8, 7, 1);
        }
    }
}
