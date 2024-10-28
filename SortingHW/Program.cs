﻿//Code Project by Chris Cane
//Used as resource: https://www.simplilearn.com/tutorials/c-sharp-tutorial/sorting-algorithms-in-c-sharp


using System.Buffers.Text;
using System.Diagnostics;
using System;


Stopwatch stopwatch = Stopwatch.StartNew();

// usage 100 thousand values
stopwatch.Start();
int[] largeArr = GenerateRandomArray(100000, 1, 1000);
stopwatch.Stop();
DisplayRuntime(stopwatch);

// Write your function to test each algorithm here


// Write individual functions for each algorithm here (Bubble, Insertion, Merge, and Quick sort)

//Bubble Sort
class GFG
{

    // An optimized version of Bubble Sort
    static void bubbleSort(int[] arr, int n)
    {
        int i, j, temp;
        bool swapped;
        for (i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {

                    // Swap arr[j] and arr[j+1]
                    temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }

            // If no two elements were
            // swapped by inner loop, then break
            if (swapped == false)
                break;
        }
    }

    // Function to print an array
    static void printArray(int[] arr, int size)
    {
        int i;
        for (i = 0; i < size; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }

    // Driver method
    public static void Main()
    {
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
        int n = arr.Length;
        bubbleSort(arr, n);
        Console.WriteLine("Sorted array:");
        printArray(arr, n);
    }
}

//Insertion Sort
class InsertionSort
{
    /* Function to sort array using insertion sort */
    void sort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; ++i)
        {
            int key = arr[i];
            int j = i - 1;

            /* Move elements of arr[0..i-1], that are
               greater than key, to one position ahead
               of their current position */
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
    }

    /* A utility function to print array of size n */
    static void printArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");

        Console.WriteLine();
    }

    // Driver method
    public static void Main()
    {
        int[] arr = { 12, 11, 13, 5, 6 };

        InsertionSort ob = new InsertionSort();
        ob.sort(arr);

        printArray(arr);
    }
}

/* This code is contributed by Hritik Shah. */

// Merge Sort
class GfG
{

    // Merges two subarrays of []arr.
    // First subarray is arr[l..m]
    // Second subarray is arr[m+1..r]
    static void merge(int[] arr, int l, int m, int r)
    {
        // Find sizes of two
        // subarrays to be merged
        int n1 = m - l + 1;
        int n2 = r - m;

        // Create temp arrays
        int[] L = new int[n1];
        int[] R = new int[n2];
        int i, j;

        // Copy data to temp arrays
        for (i = 0; i < n1; ++i)
            L[i] = arr[l + i];
        for (j = 0; j < n2; ++j)
            R[j] = arr[m + 1 + j];

        // Merge the temp arrays

        // Initial indexes of first
        // and second subarrays
        i = 0;
        j = 0;

        // Initial index of merged
        // subarray array
        int k = l;
        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                arr[k] = L[i];
                i++;
            }
            else
            {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        // Copy remaining elements
        // of L[] if any
        while (i < n1)
        {
            arr[k] = L[i];
            i++;
            k++;
        }

        // Copy remaining elements
        // of R[] if any
        while (j < n2)
        {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    // Main function that
    // sorts arr[l..r] using
    // merge()
    static void mergeSort(int[] arr, int l, int r)
    {
        if (l < r)
        {

            // Find the middle point
            int m = l + (r - l) / 2;

            // Sort first and second halves
            mergeSort(arr, l, m);
            mergeSort(arr, m + 1, r);

            // Merge the sorted halves
            merge(arr, l, m, r);
        }
    }

    // A utility function to
    // print array of size n
    static void printArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }

    // Driver code
    public static void Main(String[] args)
    {
        int[] arr = { 12, 11, 13, 5, 6, 7 };
        Console.WriteLine("Given array is");
        printArray(arr);
        mergeSort(arr, 0, arr.Length - 1);
        Console.WriteLine("\nSorted array is");
        printArray(arr);
    }
}

//Quick Sort
class GfG
{

    // Partition function
    static int Partition(int[] arr, int low, int high)
    {

        // Choose the pivot
        int pivot = arr[high];

        // Index of smaller element and indicates 
        // the right position of pivot found so far
        int i = low - 1;

        // Traverse arr[low..high] and move all smaller
        // elements to the left side. Elements from low to 
        // i are smaller after every iteration
        for (int j = low; j <= high - 1; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        // Move pivot after smaller elements and
        // return its position
        Swap(arr, i + 1, high);
        return i + 1;
    }

    // Swap function
    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    // The QuickSort function implementation
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {

            // pi is the partition return index of pivot
            int pi = Partition(arr, low, high);

            // Recursion calls for smaller elements
            // and greater or equals elements
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    static void Main(string[] args)
    {
        int[] arr = { 10, 7, 8, 9, 1, 5 };
        int n = arr.Length;

        QuickSort(arr, 0, n - 1);
        foreach (int val in arr)
        {
            Console.Write(val + " ");
        }
    }
}

// function
static int[] GenerateRandomArray(int length, int minValue, int maxValue)
{
    Random rand = new Random();
    int[] array = new int[length];

    for (int i = 0; i < length; i++)
    {
        array[i] = rand.Next(minValue, maxValue); // Generates a random integer within the specified range
    }

    return array;
}

static void DisplayRuntime(Stopwatch stopwatch)
{
    TimeSpan ts = stopwatch.Elapsed;

    // Format and display the TimeSpan value.
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        ts.Hours, ts.Minutes, ts.Seconds,
        ts.Milliseconds / 10);
    Console.WriteLine("Time Taken: " + elapsedTime);
}



//QUICK SORT
//MERGE SORT
//BUBBLE SORT
//INSERTION SORT
//Implement a function that uses the System.Diagnostics.Stopwatch class to measure the execution time
//of the following sorting algorithms:
//Measure the time taken to sort the array using each algorithm. Display the results in the format:
//Algorithm: [Name] Time Taken: [milliseconds]
//Based on the results, add a comment explaining why certain algorithms are more efficient than 
//others for large datasets.