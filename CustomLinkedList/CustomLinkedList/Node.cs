// See https://aka.ms/new-console-template for more information





//PrintList(tests);








public class Node<T>
{
    public T? Item { get; init; }
    public Node<T>? Next { get; set; }
    public Node<T>? Previous { get; set; }

    public Node(T? item)
    {
        Item = item;
    }

}
