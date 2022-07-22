#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include "BST.h"
#include <stdbool.h>

void execute(struct BST* tree, int* arr);

int main()
{
	//int arr[] = { 30,10,20,15,25,5 };
	// int arr[] = { 100, 150, 75, 200, 125, 85, 50, 65, 130 };
	int arr[] = { 100, 150, 75, 200, 125, 85, 50, 65, 130, 129, 127, 128 };
	//int arr[] = { 100, 75, 150 };

	struct BST* tree = Create();
	struct Node* min = GetMinNode(tree);
	struct Node* max = GetMaxNode(tree);

	printf("Min Data is %d\n", GetMinData(tree));
	printf("Max Data is %d\n", GetMaxData(tree));

	for (int i = 0; i < sizeof(arr) / sizeof(int); i++)
		Insert(tree, arr[i]);

	Preorder(tree);
	Inorder(tree);
	Postorder(tree);

	//InorderParent(tree);

	printf("Min is %d\n", GetMinData(tree));
	printf("Max is %d\n", GetMaxData(tree));

	assert(SeachNode(tree, 500) == NULL);
	assert(SeachNode(tree, -854) == NULL);
	assert(!IsExist(tree, 500));
	assert(!IsExist(tree, -854));

	for (int i = 0; i < sizeof(arr) / sizeof(int); i++)
	{
		assert(SeachNode(tree, arr[i]) != NULL);
		assert(IsExist(tree, arr[i]));
	}

	printf("count is %d :\n", tree->count);

	printf("Deleted started\n");

	for (int i = 0; i < sizeof(arr) / sizeof(int); i++)
	{
		if (DeleteNode(tree, arr[i]) != SUCCESS)
			printf("something worng ma be : no data found : %d\n", arr[i]);
	}

	printf("Deleted ended\n");

	for (int i = 0; i < sizeof(arr) / sizeof(int); i++)
		assert(DeleteNode(tree, arr[i]) == DataNotFound);

	printf("count is %d :\n", tree->count);
	puts("at the end success");

	return 1;
}

void execute(struct BST* tree, int* arr)
{
	struct Node* min = GetMinNode(tree);
	struct Node* max = GetMaxNode(tree);

	printf("Min Data is %d\n", GetMinData(tree));
	printf("Max Data is %d\n", GetMaxData(tree));

	for (int i = 0; i < sizeof(arr) / sizeof(int); i++)
		Insert(tree, arr[i]);

	Preorder(tree);
	Inorder(tree);
	InorderParent(tree);

	printf("Min is %d\n", GetMinData(tree));
	printf("Max is %d\n", GetMaxData(tree));

	assert(SeachNode(tree, 500) == NULL);
	assert(SeachNode(tree, -854) == NULL);
	assert(!IsExist(tree, 500));
	assert(!IsExist(tree, -854));

	for (int i = 0; i < sizeof(arr) / sizeof(int); i++)
	{
		assert(SeachNode(tree, arr[i]) != NULL);
		assert(IsExist(tree, arr[i]));
	}

	printf("count is %d :\n", tree->count);

	printf("Deleted started\n");

	for (int i = 0; i < sizeof(arr) / sizeof(int); i++)
	{
		if (DeleteNode(tree, arr[i]) != SUCCESS)
			printf("something worng ma be : no data found : %d\n", arr[i]);
	}

	printf("Deleted ended\n");

	for (int i = 0; i < sizeof(arr) / sizeof(int); i++)
		assert(DeleteNode(tree, arr[i]) == DataNotFound);

	printf("count is %d :\n", tree->count);
	puts("at the end success");
}