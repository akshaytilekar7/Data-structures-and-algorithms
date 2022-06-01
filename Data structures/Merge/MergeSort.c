// https://leetcode.com/problems/sort-an-array/
// 912. Sort an Array
// https://leetcode.com/problems/sort-an-array/discuss/2097753/C-Language

/*
Runtime: 436 ms, faster than 5.26% of C online submissions for Sort an Array.
Memory Usage: 71.3 MB, less than 5.26% of C online submissions for Sort an Array.
*/
	
#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h> 
#include <time.h>

#define TRUE 1 

void Input(int* arr, int size);
void Output(int* arr, int size, char* msg);
void MergeProcedure(int arr[], int start, int mid, int end);
void Merge(int arr[], int start, int end);

void Input(int* arr, int size)
{
	for (int i = 0; i < size; i++)
		arr[i] = rand(); 
}

void Output(int* arr, int size, char* msg)
{
	printf("%s\n", msg);
	for (int i = 0; i < size; i++)
		printf("arr[%d] = %d\n", i, arr[i]);
}

void MergeProcedure(int arr[], int start, int mid, int end)
{
	int i = 0;
	int j = 0;
	int k = 0;

	// arr[start + k] when k = 0
	// arr[k] when k = start

	int size1 = mid - start + 1; // [start, mid] 
	int size2 = end - mid; // (mid, end] 

	int* arr1 = (int*)malloc(size1 * sizeof(int));
	int* arr2 = (int*)malloc(size2 * sizeof(int));

	for (int i = 0; i < size1; i++)
		arr1[i] = arr[start + i]; //**
	for (int i = 0; i < size2; i++)
		arr2[i] = arr[mid + 1 + i]; // **

	while (TRUE)
	{
		if (arr1[i] <= arr2[j])
		{
			arr[start + k] = arr1[i];
			i++;
			k++;
			if (i == size1)
			{
				while (j < size2) 
				{
					arr[start + k] = arr2[j];
					j++;
					k++;
				}
				break;
			}
		}
		else
		{
			arr[start + k] = arr2[j];
			k++;
			j++;
			if (j == size2)
			{
				while (i < size1)
				{
					arr[start + k] = arr1[i];
					i++;
					k++;
				}
				break;
			}
		}
	}
}

void Merge(int arr[], int start, int end)
{
	if (start < end)
	{
		int mid = (start + end) / 2;

		Merge(arr, start, mid);
		Merge(arr, mid + 1, end);
		MergeProcedure(arr, start, mid, end);
	}
}

int main(int argc, char* argv[])
{
	int n = atoi(argv[1]);
	time_t start_t, end_t;
	double diff_t;

	int* arr = (int*)malloc(n * sizeof(int));
	Input(arr, n);

	Output(arr, n, "before");
	
	time(&start_t);
	Merge(arr, 0, n - 1);
	time(&end_t);

	Output(arr, n, "after");

	diff_t = difftime(end_t, start_t);

	printf("Execution time to sort = %f\n", diff_t);
}
