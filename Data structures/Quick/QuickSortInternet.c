// Not working 
#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>

void input(int* a, int N);
void output(int* a, int N, const char* msg);
void sort(int* a, int N);
void Quick(int arr[], int start, int end);
int Partition(int arr[], int start, int end);

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


int Partition(int arr[], int start, int end)
{
	int pivot = arr[start];
	int s = start;
	int e = end;

	while (s < e)
	{
		do {
			s++;
		} while (arr[s] <= pivot);

		do {
			e--;
		} while (arr[e] > pivot);

		if (s < e)
		{
			int t = arr[s];
			arr[s] = arr[e];
			arr[e] = t;
		}
	}

	int t = arr[start];
	arr[start] = arr[e];
	arr[e] = t;
	return e;
}


int Partition2(int arr[], int l, int h)
{
	int pivot = arr[l];
	int i = l;
	int j = h;

	while (i < j)
	{
		do {
			i++;
		} while (arr[i] <= pivot);

		do {
			j--;
		} while (arr[j] > pivot);

		if (i < j)
		{
			int temp1 = arr[i];
			arr[i] = arr[j];
			arr[j] = temp1;
		}
	}

	int temp2 = arr[l];
	arr[l] = arr[j];
	arr[j] = temp2;
	return j;
}

void Quick(int arr[], int start, int end)
{
	if (start < end)
	{
		int pivot = Partition2(arr, start, end);
		Quick(arr, start, pivot);
		Quick(arr, pivot + 1, end);
	}
}
void sort(int* a, int N)
{
	Quick(a, 0, N);
}