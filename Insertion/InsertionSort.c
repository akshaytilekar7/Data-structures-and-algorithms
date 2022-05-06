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

int main()
{
	int size = 6;
	int arr3[] = { 5,1,2,9,6,4 };
	Print(arr3, size, "before");
	InsertionSort(&arr3[0], size);
	Print(arr3, size, "after");
	return 0;
}