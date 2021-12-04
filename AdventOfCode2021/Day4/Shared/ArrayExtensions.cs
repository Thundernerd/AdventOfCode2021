namespace AdventOfCode2021.Day4.Shared
{
    public static class ArrayExtensions
    {
        public static T[] Slice<T>(this T[,] array, int index, int dimension)
        {
            bool isFirstDimension = dimension == 0;
            int length = array.GetLength(1 - dimension);
            T[] slice = new T[length];

            for (int i = 0; i < length; i++)
            {
                slice[i] = isFirstDimension ? array[index, i] : array[i, index];
            }

            return slice;
        }
    }
}