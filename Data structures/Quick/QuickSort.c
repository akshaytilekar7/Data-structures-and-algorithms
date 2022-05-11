#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>

void input(int* a, int N);
void output(int* a, int N, const char* msg);
void sort(int* a, int N);
void Swap(int** arr, int x, int y);
int Partition(int arr[], int start, int end);
void QuickSort(int arr[], int start, int end);

int main(int argc, char* argv[])
{
	int* a = NULL;
	int N = 0;

	if (argc != 2)
	{
		fprintf(stderr, "Usage Error: Correct Usage %s nr_elements", argv[0]);
		exit(EXIT_FAILURE);
	}

	N = atoi(argv[1]);
	assert(N > 0);

	a = (int*)malloc(N * sizeof(int));
	assert(a != NULL);

	input(a, N);
	output(a, N, "Before sort:");
	sort(a, N);
	output(a, N, "After sort:");

	free(a);
	a = NULL;

	return (EXIT_SUCCESS);
}

void input(int* a, int N)
{
	int i;

	for (i = 0; i < N; ++i)
		a[i] = rand();
}

void output(int* a, int N, const char* msg)
{
	int i;

	if (msg)
		puts(msg);

	for (i = 0; i < N; ++i)
		printf("a[%d]:%d\n", i, a[i]);
}

void Swap(int** arr, int x, int y)
{
	int tmp = (*arr)[x];
	(*arr)[x] = (*arr)[y];
	(*arr)[y] = tmp;
}

int Partition(int arr[], int start, int end)
{
	int pivot = arr[end];
	int partitionIndex = start;

	for (int i = start; i < end; i++)
	{
		if (arr[i] <= pivot)
		{
			Swap(&arr, i, partitionIndex);
			partitionIndex++;
		}
	}

	Swap(&arr, partitionIndex, end);
	return partitionIndex;
}

void QuickSort(int arr[], int start, int end)
{
	if (start < end) // main
	{
		int partitionIndex = Partition(arr, start, end);
		QuickSort(arr, start, partitionIndex - 1);
		QuickSort(arr, partitionIndex + 1, end);
	}
}

void sort(int* a, int N)
{
	QuickSort(a, 0, N - 1);
}