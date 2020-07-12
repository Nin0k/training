using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _3._2._1.DYNAMIC_ARRAY
{
    class DynamicArray<T> : IEnumerable<T>
    {
        private const int INITIAL_CAPACITY = 8;
        protected T[] array;

        public DynamicArray()
        {
            array = new T[INITIAL_CAPACITY];

        }

        public DynamicArray(int newCapacity)
        {
            array = new T[newCapacity];
        }

        public DynamicArray(IEnumerable<T> arrayCollection)
        {
            array = new T[arrayCollection.Count()];

            AddRange(arrayCollection);
        }

        public void Add(T element)
        {

            if (Length == Capacity)
            {

                ExpandArray(Capacity * 2);
            }

            array[Length++] = element;

        }

        public void AddRange(IEnumerable<T> elements)
        {


            if (Length + elements.Count() > Capacity)
            {
                ExpandArray(Capacity + elements.Count());
            }
            foreach (var i in elements)
            {
                array[Length++] = i;
            }
        }
        public void ExpandArray(int capacityExpansion)
        {

            if (Length < 1)
            {
                array = new T[capacityExpansion];
            }
            else
            {
                T[] newArray = new T[capacityExpansion];
                array.CopyTo(newArray, 0);
                array = newArray;

            }

        }

        public bool Remove(T element)
        {

            for (int i = 0; i < Length; i++)
            {
                int sourceIndex = i + 1;

                if (array[i].Equals(element))
                {
                    Array.Copy(array, sourceIndex, array, i, Length - sourceIndex);

                    Length--;
                    return true;
                }
            }

            return false;
        }
        public void RemoveAt(int index)
        {
            if (index >= Length)
            {
                throw new IndexOutOfRangeException("The index cannot go beyond the array boundary");
            }

            int shiftStart = index + 1;

            if (shiftStart < Length)
            {
                Array.Copy(array, shiftStart, array, index, Length - shiftStart);
                Length--;
            }


        }
        public bool Insert(T element, int index)
        {
            if (index > 0 || index > Length)
            {
                if (Length == Capacity)
                {
                    ExpandArray(Capacity * 2);
                }
                Array.Copy(array, index, array, index + 1, Length - index);

                array[index] = element;

                Length++;
                return true;
            }
            throw new ArgumentOutOfRangeException("The index cannot go beyond the array boundary");
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in array)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public int Length { get; set; }
        public int Capacity
        {
            get
            {

                return array.Length;
            }
            set
            {

                array = new T[value];
            }
        }
        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if (index >= array.Length || index <= -array.Length)
                {
                    throw new IndexOutOfRangeException("The index cannot go beyond the array boundary");
                }
                array[index] = value;
            }
        }
        public object Clone()
        {
            T[] newArray = new T[Capacity];

            Array.Copy(array, newArray, Length);

            return new DynamicArray<T>(newArray);
        }
    }
}
