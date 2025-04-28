namespace Learn_DesignPatterns.Behavioral.Strategy.SortExample
{
    public interface ISortStrategy
    {
        void Sort(List<int> list);
    }

    public class BubbleSort : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            // bubble sort algorithm
        }
    }

    public class QuickSort : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            // quick sort algorithm
        }
    }

    public class MergeSort : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            // merge sort algorithm
        }
    }
}
