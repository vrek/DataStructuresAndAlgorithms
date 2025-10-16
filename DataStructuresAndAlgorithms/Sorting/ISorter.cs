using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Sorting;

public interface ISorter<T> where T : IComparable<T>
{
    void Sort(List<T> list);
}
