using System;
using System.Collections.Generic;

namespace SetsAndDictionaries
{
    // dictionaries

    class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, int> studentsMarks = new Dictionary<string, int>();
            studentsMarks.Add("Pepo", 6);
            studentsMarks.Add("Goga", 2);
            studentsMarks.Add("Ana", 3);

            Console.WriteLine(studentsMarks["Ana"]);

            foreach (KeyValuePair<string, int> item in studentsMarks)
            {
                Console.WriteLine($"{item.Key} has a mark of {item.Value}");
            }

            if (!studentsMarks.ContainsKey("Atanas"))
            {
                Console.WriteLine("adding atanas");
                studentsMarks.Add("Atanas", 4);
                Console.WriteLine(studentsMarks["Atanas"]);
            }

            studentsMarks.Remove("Atanas");

            foreach (KeyValuePair<string, int> item in studentsMarks)
            {
                Console.WriteLine($"{item.Key} has a mark of {item.Value}");
            }

            // Associative array, Map, Dictionary 
            // all they mean dictionary
            // indexed by keys that can be anything (numbers, arrays, strings)

            // Arrays are a sequence of elements
            // in C# - same type
            // fixed length/size, cannot be resized
            // Length - number of array elements

            // SortedDictionary<K, V> and Dictionary<K, V> are Associative Arrays

            // Dictionary<K, V> - collection of key and value pairs
            // unique keys
            // C# keeps the keys in their order of addition
            // uses a hash-table + list
            // Add, Remove, ContainsKey, ContainsValue (not recommended, slower)
            // in abstract data structures this is not the case

            // SortedDictionary<K, V> is slower than normal dictionary, but still very fast
            // keys are always sorted
            // uses balanced search tree (red/black, binary tree)
            // used for foreach

            // Add(key, value), Remove(key), ContainsKey(key), 
            // ContainsValue(value), OrderBy(), OrderByDescending()

            // HashTable
            // Dictionary
            // AssociativeArray
            // HashMap
            // Map
            // collections with keys and values

            // Set<T> - guarantees unique values - very, very fast
            // Add, Remove, Search elements

            // HashSet<T> - keeps a set of elements in a hash table
            // Fast "add", "search" and "remove" (thanks to hash-table) 
            // similar to List<T>, different implementation
            // they have order in C#, otherwise, as a concept, they don't - no insertion order
            // Contains method, is very fast, the fastest in programming
            // main feature - is some value in the array or not
            // no duplicates, (every value is unique), as Set
            // HashSet, Dictionary are used greatly in Caches

            // List<T>
            // holds a sequence of elements of the same type
            // add, insert, remove, find
            // Add(element) - add element in the list
            // Count - number of elements
            // Remove(element) - removes an element (returns true / false)
            // RemoveAt(index)- removes an element at a certain index
            // Insert(index, element) - inserts an element to a given index
            // Contains(elements) - determines whether an element is in the list
            // Sort() - sorts the array/list in ascending order
            // Reverse() reverses the list
            // Fast "add", slow "search" and "remove" (pass through each element)
            // allowed duplicates
            // insertion order guaranteed
        }
    }
}
