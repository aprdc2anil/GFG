using System;
using System.Collections.Generic;
using System.Text;

namespace GFGCodes
{
    public class KMergeMinHeap<T>
    {
        private MinHeapKMergeType<T>[] internalArray;

        private int size;

        private IComparer<T> comparer;

        public KMergeMinHeap():this(5, default)
        {
            
        }

        public KMergeMinHeap(int size) : this(size, default)
        {

        }
        
        public KMergeMinHeap(int size, IComparer<T> comparer)
        {
            this.size = size;
            this.Count = 0;
            internalArray = new MinHeapKMergeType<T>[size];

            if (comparer != null)
            {
                this.comparer = comparer;
            }
            else
            {
                this.comparer = Comparer<T>.Default;
            }
        }

        public KMergeMinHeap(T[] inputArray): this(inputArray, default)
        {
           
        }

        public KMergeMinHeap(T[] inputArray, IComparer<T> comparer)
        {
            this.size = this.Count = inputArray.Length;
            internalArray = new MinHeapKMergeType<T>[this.size];
            Array.Copy(inputArray, internalArray, this.size);

            if (comparer != null)
            {
                this.comparer = comparer;
            }
            else
            {
                this.comparer = Comparer<T>.Default;
            }

            this.HeapifyArray();
        }

        public int Count { get; private set; }

        public void Add(MinHeapKMergeType<T> item)
        {
            if (this.Count == this.size)
            {
                this.IncreaseHeapSize();
            }

            internalArray[this.Count++] = item;

            if(this.Count>1)
                HeapifyIndexUp(LastChildIndex);
        }

        public MinHeapKMergeType<T> RemoveMin()
        {
            if (this.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            MinHeapKMergeType<T> min = internalArray[0];

            if (this.Count == 1)
            {
                --this.Count;
                return min;                
            }

            
            internalArray[0] = internalArray[LastChildIndex];

            // this is for non zero elements just to make sure for debugging not confused
            internalArray[LastChildIndex] = default;
            --Count;

            if (this.Count > 1)
                HeapifyIndexDown(0);

            return min;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            for (int i = 0; i < this.Count; ++i)
            {
                array[i] = internalArray[i].Data;
            }

            return array;
        }
        
        public MinHeapKMergeType<T> GetMin()
        {
            if (this.Count > 0)
                return internalArray[0];
            else throw new IndexOutOfRangeException();
        }

        private void HeapifyArray()
        {
            /* size 
             * 0 -> [1 -> [3 -> [7, 8], 4 -> [9, 10]], 2 -> [5 -> [11, 12], 6 -> [13, 14]]] 
             * 
             * parentIndex  i -> [(childIndex+1)/2-1] ; where 1<=childIndex<=heapCount-1 
             * 
             *  leaf nodes = 14, last index =13 => parentindex = [(13+1=heapCount)/2-1]=6
            */

            if (this.Count <= 1)
                return;            
            
            int currIndex = LastChildIndex;
            
            while (currIndex > LastParentIndex)
            {
                HeapifyIndexUp(currIndex--);
            }
        }

        private void HeapifyIndexUp(int index)
        {
            int curr = index;
            int parentIndex = ParentIndex(curr);

            while (curr>=FirstChildIndex)
            {
                parentIndex = ParentIndex(curr);

                if (this.comparer.Compare(internalArray[curr].Data, internalArray[parentIndex].Data) < 0)
                {
                    this.Swap(internalArray, curr, parentIndex);
                    curr = ParentIndex(curr);
                }
                else
                {
                    break;
                }                
            }
        }
        
        private void HeapifyIndexDown(int index)
        {
            int curr = index;

            while (curr <= LastParentIndex)
            {
                int leftIndex = LeftChildIndex(curr);
                int rightIndex = -1;
                int swapIndex = curr;

                try
                {
                    rightIndex = RightChildIndex(curr);
                }
                catch (Exception ex)
                {
                }


                if (this.comparer.Compare(internalArray[leftIndex].Data, internalArray[curr].Data) < 0)
                {
                    swapIndex = leftIndex;
                }
                if (rightIndex != -1)
                {
                    if (this.comparer.Compare(internalArray[rightIndex].Data, internalArray[swapIndex].Data) < 0)
                    {
                        swapIndex = rightIndex;
                    }
                }

                if (curr != swapIndex)
                {
                    this.Swap(internalArray, curr, swapIndex);
                    curr = swapIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private int LastParentIndex => this.Count >= 2 ? (this.Count / 2) - 1 : throw new IndexOutOfRangeException();

        private int LastChildIndex => this.Count >= 2 ? this.Count - 1 : throw new IndexOutOfRangeException();

        private int FirstChildIndex => this.Count >= 2 ? 1 : throw new IndexOutOfRangeException();

        private int ParentIndex(int childIndex)
        {
            if (childIndex < FirstChildIndex)
                throw new IndexOutOfRangeException();

            return ((childIndex + 1) / 2) - 1;            
        }

        private int LeftChildIndex(int parentIndex)
        {
            if (parentIndex > LastParentIndex)
                throw new IndexOutOfRangeException();

            return parentIndex * 2 + 1;
        }

        private int RightChildIndex(int parentIndex)
        {
            if (parentIndex > LastParentIndex || parentIndex * 2 + 2 > LastChildIndex)
                throw new IndexOutOfRangeException();

            return parentIndex * 2 + 2;
        }

        private void Swap(MinHeapKMergeType<T>[] array, int aIndex, int bIndex)
        {
            MinHeapKMergeType<T> temp = array[aIndex];
            array[aIndex] = array[bIndex];
            array[bIndex] = temp;
        }

        private void IncreaseHeapSize()
        {
            Array.Resize(ref internalArray, this.size = this.size * 2);
        }
    }
}
