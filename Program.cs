using System;

public class UniversalCollection<T>
{
    private T[] items;
    private int count;
    public UniversalCollection()
    {
        items = new T[10];
        count = 0;
    }
    public void Add(T item)
    {
        if (count == items.Length)
        {
            Array.Resize(ref items, items.Length * 2);
        }
        items[count] = item;
        count++;
    }
    public void Remove(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException("Индекс находится за пределами");
        }
        Array.Copy(items, index + 1, items, index, count - index - 1);
        count--;
    }
    public T Get(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException();
        }
        return items[index];
    }
    public void print()
    {
        if (count == 0)
        {
            Console.WriteLine("Коллекция пуста");
        }
        else
        {
            Console.WriteLine("Элементы коллекции: ");
            for (int i = 0; i < count; i++)
            {
                Console.Write(items[i] + " ");
            }
        }
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        UniversalCollection<int> collection = new UniversalCollection<int>();
        Console.WriteLine("");
        Console.WriteLine("Введите количество элементов, которые хотите добавить в универсальную коллекцию: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите элементы: ");
        for (int i = 0; i < n; i++)
        {
            collection.Add(Convert.ToInt32(Console.ReadLine()));
        }
        int c = 1;
        while (c != 0)
        {
            Console.WriteLine("Выберите действие: 0-выход из программы, 1-вывести все элементы, 2-удалить определенный элемент, 3-получить элемент по индексу");
            c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 0: break;
                case 1: collection.print(); break;
                case 2:
                    Console.WriteLine("Введите индекс элемента, который хотите удалить: ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    collection.Remove(index); break;
                case 3:
                    Console.WriteLine("Введите индекс для элемента: ");
                    int i = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Элемент " + collection.Get(i)); break;
            }
        }
    }
}
