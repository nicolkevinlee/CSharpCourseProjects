// See https://aka.ms/new-console-template for more information





//PrintList(tests);







public interface ILinkedList<T> : ICollection<T>
{
    void AddToFront(T item);
    void AddToBack(T item);
}
