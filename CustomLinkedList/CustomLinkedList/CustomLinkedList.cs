// See https://aka.ms/new-console-template for more information
using System.Collections;

public class CustomLinkedList<T> : ILinkedList<T?>
{
    private Node<T>? _first;
    private int _size = 0;
    public int Count => _size;

    public bool IsReadOnly => false;

    public void Add(T? item)
    {
        AddToBack(item);
    }

    public void AddToBack(T? item)
    {
        var node = new Node<T>(item);
        if (_first == null)
        {
            _first = node;
        }
        else
        {
            var tail = GetNodes().Last();
            tail.Next = node;
            node.Previous = tail;
        }
        ++_size;
    }

    public void AddToFront(T? item)
    {
        var node = new Node<T>(item)
        {
            Next = _first
        };
        if (_first is not null)
        {
            _first.Previous = node;
        }
        _first = node;
        ++_size;
    }

    public void Clear()
    {
        if (_first == null) return;

        var current = _first;
        Node<T>? next;
        while(current is not null)
        {
            next = current.Next;
            current.Next = null;
            current.Previous = null;
            current = next;
        }

        _first = null;
        _size = 0;
    }

    public bool Contains(T? item)
    {
        if(item is null)
        {
            return GetNodes().Any(node => node.Item is null);
        }

        return GetNodes().Any(node => item.Equals(node.Item));
    }

    public void CopyTo(T?[] array, int arrayIndex)
    {
        if (array == null) throw new ArgumentNullException($"{nameof(array)} is null.");
        if (arrayIndex < 0 || arrayIndex >= array.Length) throw new ArgumentOutOfRangeException($"{nameof(arrayIndex)} is out of bounds.");
        if (array.Length < _size + arrayIndex) throw new ArgumentException("Array is not long enough.");
        foreach(var node in GetNodes()){
            array[arrayIndex] = node.Item;
            ++arrayIndex;
        }

    }

    public bool Remove(T? item)
    {
        if(_first == null) return false;

        Node<T>? previous = null;

        foreach(var current in GetNodes())
        {
            if ((current.Item is null && item is null) ||
                (current.Item is not null && current.Item.Equals(item)))
            {
                if (previous is null)
                {
                    _first = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                    if (previous.Next is not null)
                    {
                        previous.Next.Previous = previous;
                    }
                }
                current.Next = null;
                --_size;
                return true;
            }
            previous = current;
        }
        return false;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T?> GetEnumerator()
    {
        foreach(var node in GetNodes()) 
        {
            yield return node.Item;
        }

    }

    private IEnumerable<Node<T>> GetNodes()
    {
        var current = _first;
        while (current is not null)
        {
            yield return current;
            current = current.Next;
        }
    }
}