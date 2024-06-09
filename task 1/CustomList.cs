namespace task_1
{
    internal class CustomList<T> : IEnumerable<T>
    {
        public T ElementAtOrDefault(int index)
        {
            if (index >= 0 && index < count)
            {
                return array[index];
            }
            return default;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return array[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
        private T[] array;
        private int capacity;
        private int count;
        private readonly int initialCount;
        public int Capacity { get => capacity; }
        public int Count { get => count; }
        public T[] Arr { get => array; }
        public CustomList()
        {
            array = new T[4];
            capacity = array.Length;
        }
        public void Add(T item)
        {
            if (count == Capacity)
            {
                Array.Resize(ref array, capacity == 0 ? initialCount : array.Length * 2);
                capacity = array.Length;
            }
            array[count] = item;
            count++;
        }
        public void Remove(T item)
        {
            var index = Array.IndexOf(array, item);
            if (index != -1)
            {
                for (int i = 0; i < count; i++)
                    array[i] = array[i + 1];
                count--;
            }
        }
        public void GetAll()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        public bool Contains(T item)
        {
            var index = Array.IndexOf(array, item);
            if (index != -1)
                return true;
            return false;
        }
        public void Clear()
        {
            array = new T[0];
        }
        public bool Any(Predicate<T> predicate = null)
        {
            if (count > 0 && predicate == null)
            {
                return true;
            }
            foreach (var element in array)
            {
                if (predicate(element))
                    return true;
            }
            return false;
            
        }
        public T FirstOrDefault(Predicate<T> predicate = null)
        {
            if (count > 0 && predicate == null)
            {
                return array[0];
            }
            foreach (var element in array)
            { if (predicate(element)) return element;}
            return default;
        }
        public T LastOrDefault(Predicate<T> predicate = null)
        {
            if (count > 0 && predicate == null)
            { 
                return array[array.Length - 1];
            }
            foreach (var element in array)
            { if (predicate(element)) return array[array.Length-1];}
            return default;
        }
        
    }
}
