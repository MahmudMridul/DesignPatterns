namespace Learn_DesignPatterns.Behavioral.Strategy.SortExample
{
    public class StrategyClient
    {
        public static void Run()
        {
            List<int> data = new List<int>() { 100, 21, 23, 32, 4, 88, 66 };

            // create strategies
            ISortStrategy bubble = new BubbleSort();
            ISortStrategy quick = new QuickSort();
            ISortStrategy merge = new MergeSort();

            SortContext context = new SortContext(bubble);

            // use bubble sort
            context.Sort(data);

            List<int> data2 = new List<int>() { 100, 21, 23, 32, 4, 88, 66 };

            if (data2.Count > 10)
            {
                context.SetSortStrategy(merge);
            }
            else
            {
                context.SetSortStrategy(quick);
            }
            context.Sort(data2);

        }
    }
}
