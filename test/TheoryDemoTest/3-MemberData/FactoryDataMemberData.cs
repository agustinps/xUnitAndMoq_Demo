namespace TheoryDemoTest.MemberData
{
    public class FactoryDataMemberData
    {
        public static IEnumerable<object[]> GetData1() => new List<object[]>
        {
            new object[]{10, 5, 5},
            new object[]{15, 10, 5 },
        };

        public static IEnumerable<object[]> GetData2(int c)
        {
            var data = new List<object[]>
            {
                new object[]{10, 5, 5},
                new object[]{15, 10, 5 },
                new object[]{5, 2, 3},
                new object[]{17, 10, 7 },
                new object[]{21, 4, 17},
                new object[]{6, 4, 2 },
            };

            return data.Take(c);
        }

        public static TheoryData<int, int, int> GetData3()
        {
            //var data = new TheoryData<int, int, int>();
            //data.Add(10, 5, 5);
            //data.Add(4, 3, 1);
            //data.Add(22, 18, 4);

            var data = new TheoryData<int, int, int>()
            {
                { 10, 5, 5 },
                { 4, 3, 1 },
                { 22, 18, 4 }
            };

            return data;
        }



    }
}
