using System.Collections.Generic;

public static class ListExtensions
{
    private static System.Random random = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int count = list.Count;
        while (count > 1)
        {
            count--;
            int index = random.Next(count + 1);
            T value = list[index];
            list[index] = list[count];
            list[count] = value;
        }
    }
}