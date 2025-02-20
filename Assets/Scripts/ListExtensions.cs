using System.Collections.Generic;

public static class ListExtensions
{
    private static System.Random _random = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int count = list.Count;
        while (count > 1)
        {
            count--;
            int index = _random.Next(count + 1);
            (list[index], list[count]) = (list[count], list[index]);
        }
    }
}