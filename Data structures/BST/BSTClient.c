#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include "BST.h"
#include <stdbool.h>

int main()
{
	//int arr[] = { 30,10,20,15,25,5 };
	int arr[] = { 10,20,30,40,50 };
	struct BST* head = Create();

	struct Node* min = GetMinNode(head);
	struct Node* max = GetMaxNode(head);

	printf("Min Data is %d\n", GetMinData(head));
	printf("Max Data is %d\n", GetMaxData(head));

	for (int i = 0; i < sizeof(arr) / sizeof(int); i++)
		Insert(head, arr[i]);
	
	
	Preorder(head);
	Inorder(head);
	Postorder(head);

	printf("Min is %d\n", GetMinData(head));
	printf("Max is %d\n", GetMaxData(head));

	assert(SeachNode(head, 500) == NULL);
	assert(SeachNode(head, -854) == NULL);
	assert(!IsExist(head, 500));
	assert(!IsExist(head, -854));

	for (int i = 0; i < sizeof(arr) / sizeof(int); i++)
	{
		assert(SeachNode(head, arr[i]) != NULL);
		assert(IsExist(head, arr[i]));
	}
	printf("count is %d :\n", head->count);

	puts("success");
	return 1;
}