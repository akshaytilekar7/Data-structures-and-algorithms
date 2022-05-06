#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h> 

#define TRUE 1 

// Every index will be initialized by (index) * 10 
int* allocate_and_input_array(int* p_size); // &N
// zip array 
void zip(int* p_arr, int size);
// output array
void output_array(int* p_arr, int size, const char* msg);

int* allocate_and_input_array(int* p_size)
{
	printf("Enter size : ");
	scanf("%d", p_size);

	int* t = (int*)malloc((*p_size) * sizeof(int));
	for (int i = 0; i < *p_size; i++)
		t[i] = i * 10;
	return t;
}

void output_array(int* p_arr, int size, const char* msg)
{
	printf("%s", msg);

	for (int i = 0; i < size; i++)
		printf("arr[%d] = %d\n", i, p_arr[i]);
}

void zip(int* p_arr, int size)
{
	//  [a, b] = b - a + 1
	//	(a, b) = b - a - 1
	//	(a, b] = b - a
	//	[a, b) = b - a

	int mid = size / 2;
	int size1 = mid - 1 + 1;
	int size2 = size - mid;

	printf("size : %d\n", size);
	printf("mid : %d\n", mid);
	printf("size1 : %d\n", size1);
	printf("size2 : %d\n", size2);

	int* arr1 = (int*)malloc(size1 * sizeof(int));
	int* arr2 = (int*)malloc(size2 * sizeof(int));

	for (int i = 0; i < size1; i++)
		arr1[i] = p_arr[i];

	for (int i = 0; i < size2; i++)
		arr2[i] = p_arr[i + size2];

	int i = 0;
	int j = 0;
	int k = 0;

	while (TRUE)
	{
		if (k % 2 == 0)
		{
			p_arr[k] = arr1[i];
			i++;
			k++;
			if (i == size1)
			{
				while (j < size2)
				{
					p_arr[k] = arr2[j];
					j++;
					k++;
				}
				break;
			}
		}
		else
		{
			p_arr[k] = arr2[j];
			j++;
			k++;
			if (j == size2)
			{
				while (i < size1)
				{
					p_arr[k] = arr1[i];
					k++;
					i++;
				}
				break;
			}
		}
	}

}
int main()
{
	int  N = 0;
	int* arr = allocate_and_input_array(&N);
	output_array(arr, N, "before\n");
	zip(arr, N);
	output_array(arr, N, "after\n");
	return (0);
}