// precondtion	-	unordered array of N element
// problem statement - make array sorted
// [6, 1, 400, 3, 98] =>  [1, 3, 6, 98, 400]

#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h> 

void Print(int arr[], int size, char* msg)
{
	printf("%s\n", msg);
	for (int i = 0; i < size; i++)
		printf("%d\n", arr[i]);
}

void SortLastElement(int* arr, int size) {

	int key = arr[size - 1];
	int i;
	for (i = size - 2; i > -1 && arr[i] > key; i--) {
		arr[i + 1] = arr[i];
	}
	arr[i + 1] = key;
}

void InsertionSort(int* p, int N)
{
	int i;
	for (i = 2; i <= N; ++i)
		SortLastElement(p, i);
}

void InsertionSortInOneWithIf(int* arr, int size)
{
	int i = 0;
	for (int index = 2; index <= size; ++index)
	{
		int key = arr[index - 1];
		for (i = index - 2; i > -1 && arr[i] > key; i--) {
			arr[i + 1] = arr[i];
		}
		arr[i + 1] = key;
	}
}

void InsertionSortInOneWithWhile(int* arr, int size)
{
	int i = 0;
	for (int index = 2; index <= size; ++index)
	{
		int key = arr[index - 1];
		i = index - 2;
		while (i >= 0) // (i > -1)
		{
			if (arr[i] > key)
			{
				arr[i + 1] = arr[i];  // element shifting to right
				i = i - 1; // maintain count
			}
			else
				break; // found appropriate place 
		}
		arr[i + 1] = key; // add last ele to appropriate place
	}
}

int main()
{
	int size = 6;
	int arr3[] = { 5,1,2,9,6,4 };
	Print(arr3, size, "before");
	InsertionSortInOneWithWhile(&arr3[0], size);
	Print(arr3, size, "after");
	return 0;
}