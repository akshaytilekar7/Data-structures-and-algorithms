#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include "BST.h"
#include <stdbool.h>

void execute(struct BST* tree, int* arr, int size, int deletedSize);

int main()
{
	struct BST* tree = Create();

	//int arr1[] = { 100, 150, 75, 200, 125, 85, 50, 65, 130, 129, 127, 128 };
	//execute(tree, arr1, sizeof(arr1) / sizeof(int), sizeof(arr1) / sizeof(int));

	int arr2[] = { 0, 50, 5, 100, 600, 1 };
	execute(tree, arr2, sizeof(arr2) / sizeof(int), sizeof(arr2) / sizeof(int));

	return 1;
}

void execute(struct BST* tree, int* arr, int size, int deletedSize)
{
	printf("\n\nexecute start array size: %d and deleted size: %d\n", size, deletedSize);
	struct Node* min = GetMinNode(tree);
	struct Node* max = GetMaxNode(tree);

	printf("Min Data is %d\n", GetMinData(tree));
	printf("Max Data is %d\n", GetMaxData(tree));

	for (int i = 0; i < size; i++)
		Insert(tree, arr[i]);

	printf("count is %d :\n", tree->count);

	Preorder(tree);
	PreorderIterative(tree);

	Inorder(tree);
	InorderIterative(tree);
	
	//Postorder(tree);
	//InorderParent(tree);

	/*printf("Min is %d\n", GetMinData(tree));
	printf("Max is %d\n", GetMaxData(tree));

	assert(SeachNode(tree, 500) == NULL);
	assert(SeachNode(tree, -854) == NULL);
	assert(!IsExist(tree, 500));
	assert(!IsExist(tree, -854));

	for (int i = 0; i < size; i++)
	{
		assert(SeachNode(tree, arr[i]) != NULL);
		assert(IsExist(tree, arr[i]));
	}

	printf("Deleted started\n");

	for (int i = 0; i < deletedSize; i++)
	{
		if (DeleteNode(tree, arr[i]) != SUCCESS)
			printf("something worng may be : no data found : %d\n", arr[i]);
	}

	printf("Deleted ended\n");

	for (int i = 0; i < deletedSize; i++)
		assert(DeleteNode(tree, arr[i]) == DataNotFound);

	Preorder(tree);
	Inorder(tree);
	Postorder(tree);

	printf("count is %d\n", tree->count);*/
	puts("execute end success");
}