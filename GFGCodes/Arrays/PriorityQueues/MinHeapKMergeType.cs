using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GFGCodes
{
    public class MinHeapKMergeType<T>
    {
        public T Data { get; private set; }
        public int ArrayNumber { get; private set; }
        public int DataAtIndex { get; private set; }

        public MinHeapKMergeType(T data, int arrayNumber, int dataAtIndex)
        {
            this.Data = data;
            this.ArrayNumber = arrayNumber;
            this.DataAtIndex = dataAtIndex;
        }
    }  
}
