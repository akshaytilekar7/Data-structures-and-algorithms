#include<stdio.h>
#include<stdlib.h>

void PtrToVariable()
{
	int n = 10;
	int* ptr = &n;
	printf("%d\n", *ptr);
}

void PtrToArray()
{
	int arr[] = { 5,10,15,20,25 };
	int* ptr = arr;

	for (int i = 0; i < 5; i++)
	{
		printf("%d\n", *(ptr + i));
		printf("%d\n", arr[i]);

	}
}

void PtrToArrayOfArrayStatic()
{
	int x1 = 10;
	int x2 = 20;
	int x3 = 30;
	int x4 = 40;
	int x5 = 50;

	int arr[] = { &x1 ,&x2 , &x3 , &x4 , &x5 };

	int* mainPtr = arr;

	for (int i = 0; i < 5; i++)
	{
		printf("%d\t%d\n", i, *(mainPtr + i)); // Print address
		int* p = *(mainPtr + i);
		printf("%d\t%d\n", *(mainPtr + i), *p); // Print value
		printf("\n");
	}
}

void PtrToArrayOfArrayDyanamic()
{
	int** ptrToArray = (int**)malloc(5 * sizeof(int));

	for (int i = 0; i < 5; i++)
	{
		ptrToArray[i] = (int*)malloc(sizeof(int));
		*ptrToArray[i] = 10 + i;
		// (*ptrToArray)[i] = 10 + i; 
	}
	for (int i = 0; i < 5; i++)
	{
		int *ptr = ptrToArray[i];
		printf("address is : %d\n", ptr);
		printf("value is : %d\n", *ptr);
		printf("value is : %d\n", *(ptrToArray[i]));
		printf("value is : %d\n", (*ptrToArray[i]));
	}

	for (int i = 0; i < 5; ++i)
	{
		// removing address inside array element
		free(ptrToArray[i]);
		ptrToArray[i] = NULL;
	}

	// removing address of array itself
	free(ptrToArray);
	ptrToArray = NULL;
}

int main1()
{
	PtrToArrayOfArrayDyanamic();
	//PtrToArrayOfArrayStatic();
	//PtrToVariable();
	//PtrToArray();
}