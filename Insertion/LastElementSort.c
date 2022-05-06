// precondtion	-	array of N element
//				-	first N-1 element are sorted
// problem statement - make array sorted, sort last element of array
// [3, 4, 18, 19, 10] =>  [3, 4, 10, 18, 19] 

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


int main()
{
	int size = 5;
	int arr[] = { 1,2,4,5,3 };
	Print(arr, size, "before");
	SortLastElement(&arr[0], size);
	Print(arr, size, "after");

	puts("----");

	int arr2[] = { 10,21,27,30,19 };
	Print(arr2, size, "before");
	SortLastElement(&arr2[0], size);
	Print(arr2, size, "after");

	return 0;
}
