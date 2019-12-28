using System;
using System.Collections.Generic;
using System.Text;

namespace GFGCodes
{
    public class MinHeap
    {
        private int[] internalArray;

        private int size;

        public MinHeap():this(5)
        {
            
        }
            

        public MinHeap(int size)
        {
            this.size = size;
            this.Count = 0;
            internalArray = new int[size];
        }

        public MinHeap(int[] inputArray)
        {
            this.size = this.Count = inputArray.Length;
            internalArray = new int[this.size];
            Array.Copy(inputArray, internalArray, this.size);
            this.HeapifyArray();
        }

        public int Count { get; private set; }

        public void Add(int item)
        {
            if (this.Count == this.size)
            {
                this.IncreaseHeapSize();
            }

            internalArray[this.Count++] = item;

            if(this.Count>1)
                HeapifyIndexUp(LastChildIndex);
        }

        public int RemoveMin()
        {
            if (this.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int min = internalArray[0];
            if (this.Count == 1)
            {
                --this.Count;
                return min;                
            }
            
            internalArray[0] = internalArray[LastChildIndex];

            // this is for non zero elements just to make sure for debugging not confused
            internalArray[LastChildIndex] = 0;
            --Count;

            if (this.Count > 1)
            {
                HeapifyIndexDown(0);
            }

            return min;
        }

        public int[] ToArray()
        {
            int[] array = new int[this.Count];
            Array.Copy(internalArray, array, this.Count);
            return array;
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

                if (internalArray[leftIndex] < internalArray[curr])
                {
                    swapIndex = leftIndex;
                }
                if (rightIndex != -1)
                {
                    if (internalArray[rightIndex] < internalArray[swapIndex])
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

        public int GetMin()
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

                if (internalArray[curr]< internalArray[parentIndex])
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

        private void Swap(int[] array, int aIndex, int bIndex)
        {
            int temp = array[aIndex];
            array[aIndex] = array[bIndex];
            array[bIndex] = temp;
        }

        private void IncreaseHeapSize()
        {
            Array.Resize(ref internalArray, this.size = this.size * 2);
        }
    }
}
