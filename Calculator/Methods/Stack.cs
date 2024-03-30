/*namespace Calculator;

public class Stack<T>
{
    private readonly List<T> _items = new();

    public int Count => _items.Count;

    public void Push(T item)
    {
        _items.Add(item);
    }

    public T Pop()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        int lastIndex = _items.Count - 1;
        T item = _items[lastIndex];
        _items.RemoveAt(lastIndex);

        return item;
    }

    public T Peek()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty!");
        }
        
        return _items[^1];
    }

    public void Clear()
    {
        _items.Clear();
    }
}*/