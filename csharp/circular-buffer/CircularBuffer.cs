public class CircularBuffer<T>
{
    private T[] _buffer;
    private int _readIndex;
    private int _writeIndex;
    
    public CircularBuffer(int capacity)
    {
        _buffer = new T[capacity];
        _readIndex = -1;
        _writeIndex = 0;
    }

    private void IncrementRead() => _readIndex = (_readIndex + 1) % _buffer.Length;
    private void IncrementWrite() => _writeIndex = (_writeIndex + 1) % _buffer.Length;

    public T Read()
    {
        if (_readIndex == -1)
            throw new InvalidOperationException("The buffer is empty.");
        
        var item = _buffer[_readIndex];
        _buffer[_readIndex] = default!;
        IncrementRead();
        if (_readIndex == _writeIndex)
        {
            _readIndex = -1;
        }
        return item;
    }

    public void Write(T value)
    {
        if (_writeIndex == _readIndex)
            throw new InvalidOperationException("The buffer is full.");
        
        _buffer[_writeIndex] = value;
        if (_readIndex == -1)
            _readIndex = _writeIndex;
        
        IncrementWrite();
    }

    public void Overwrite(T value)
    {
        _buffer[_writeIndex] = value;
        if (_writeIndex == _readIndex)
            IncrementRead();
        
        if (_readIndex == -1)
            _readIndex = _writeIndex;
        
        IncrementWrite();
    }

    public void Clear()
    {
        _buffer = new T[_buffer.Length];
        _readIndex = -1;
        _writeIndex = 0;
    }
}