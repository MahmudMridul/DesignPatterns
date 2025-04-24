namespace Learn_DesignPatterns.Behavioral.Strategy.SortExample
{
    public class SortContext
    {
        private ISortStrategy _strategy;

        public SortContext(ISortStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetSortStrategy(ISortStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Sort(List<int> data)
        {
            _strategy.Sort(data);
        }
    }
}
