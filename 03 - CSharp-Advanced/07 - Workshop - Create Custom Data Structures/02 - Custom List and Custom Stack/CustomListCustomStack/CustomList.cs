using System;
using System.Collections;
using System.Collections.Generic;

public class CustomList<T> : IEnumerable<T>
{
	private const int InitialCapacity = 2;

	private T[] internalArray;

	public int Count { get; private set; }

	public T this[int index]
    {
		get
        {
            if (index >= this.Count)
            {
				throw new ArgumentOutOfRangeException();
            }

			return internalArray[index];
        }
        set
        {
            if (index >= this.Count)
            {
				throw new ArgumentOutOfRangeException();
			}

			internalArray[index] = value;
		}
    }

	public CustomList()
	{
		this.internalArray = new T[InitialCapacity];
		this.Count = 0;
	}

	public void Add(T element)
    {
		if (this.Count == this.internalArray.Length)
		{
			this.Resize();
		}

		this.internalArray[this.Count] = element;
		this.Count++;
	}

	public T RemoveAt(int index)
	{
		if (index >= this.Count)
		{
			throw new ArgumentOutOfRangeException();
		}

		T element = internalArray[index];
		internalArray[index] = default(T);

		this.Shift(index);
		this.Count--;

        if (this.Count <= this.internalArray.Length / 4)
        {
			this.Shrink();
        }

		return element;
	}

	public void Insert(int index, T element)
	{
        if (index > this.Count)
        {
			throw new IndexOutOfRangeException();
        }

        if (this.Count == this.internalArray.Length)
        {
			this.Resize();
        }

		this.ShiftToRight(index);
		this.internalArray[index] = element;
		this.Count++;
	}

	public void Swap(int firstIndex, int secondIndex)
	{
        if (firstIndex < this.Count && secondIndex < this.Count)
        {
			T temp = this.internalArray[firstIndex];
			this.internalArray[firstIndex] = this.internalArray[secondIndex];
			this.internalArray[secondIndex] = temp;
        }
	}
	
	public bool Contains(T element)
    {
        for (int current = 0; current < this.Count; current++)
        {
            if (this.internalArray[current].Equals(element))
            {
				return true;
            }
        }

		return false;
	}

	private void Resize() 
	{
		T[] copy = new T[internalArray.Length * 2];

        for (int element = 0; element < internalArray.Length; element++)
        {
			copy[element] = this.internalArray[element];
        }

		this.internalArray = copy;
	}

	private void Shrink()
	{
		T[] copy = new T[internalArray.Length / 2];

		for (int element = 0; element < this.Count; element++)
		{
			copy[element] = this.internalArray[element];
		}

		this.internalArray = copy;
	}

	private void Shift(int index)
	{
        for (int element = index; element < this.Count - 1; element++)
        {
            internalArray[element] = this.internalArray[element + 1];
        }
	}

	private void ShiftToRight(int index)
	{
		for (int element = Count; element > index; element--)
		{
			internalArray[element] = this.internalArray[element - 1];
		}
	}

	public IEnumerator<T> GetEnumerator()
    {
		int indexer = 0;

        foreach (T item in internalArray)
        {
            if (indexer != this.Count)
            {
				yield return item;
				indexer++;
			}
			else
			{
				break;
			}
		}
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
		return this.GetEnumerator();
    }
}
