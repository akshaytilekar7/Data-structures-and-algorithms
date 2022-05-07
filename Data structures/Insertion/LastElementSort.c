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
		arr[i + 1] = arr[i]; // element shift to right side
	}
	arr[i + 1] = key; // put appropriate element
}


void SortLastElement_2(int* p_arr, int N)
{
	int key;
	int i;
	key = p_arr[N - 1];
	i = N - 2;
	while (i > -1)
	{
		if (p_arr[i] > key)
		{
			p_arr[i + 1] = p_arr[i];  // element shifting to right
			i = i - 1; // maintain count
		}
		else
			break; // found appropriate place 
	}
	p_arr[i + 1] = key; // add last ele to appropriate place
}

int main()
{
	int size = 5;
	int arr[] = { 1,2,4,5,3 };
	Print(arr, size, "before");
	SortLastElement_1(&arr[0], size);
	Print(arr, size, "after");

	puts("----");

	int arr2[] = { 10,21,27,30,19 };
	Print(arr2, size, "before");
	SortLastElement_2(&arr2[0], size);
	Print(arr2, size, "after");

	return 0;
}
