﻿namespace Common.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public partial class SafeBinarySearchTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            return this.InOrderIterator.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.InOrderIterator.GetEnumerator();
        }
    }
}
