#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include "BST.h"
#include <stdbool.h>

int main()
{
	//int arr[] = { 30,10,20,15,25,5 };
	int arr[] = { 10,20,30,40,50 };
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

	puts("success");
	return 1;
}