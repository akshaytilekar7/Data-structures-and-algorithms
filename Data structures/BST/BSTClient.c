#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include "BST.h"

int main()
{
	//int arr[] = { 30,10,20,15,25,5 };
	int arr[] = { 10,20,30,40,50 };
	struct BST* head = Create();

	struct Node* min = GetMinNode(head);
	struct Node* max = GetMaxNode(head);

	printf("Min is %d :\n", max == NULL ? -100 : max->Data);
	printf("Max is %d :\n", max == NULL ? -100 : max->Data);

	for (int i = 0; i < sizeof(arr) / sizeof(int); i++)
	{
		Insert(head, arr[i]);
	}
	Preorder(head);
	Inorder(head);
	Postorder(head);

	min = GetMinNode(head);
	max = GetMaxNode(head);
	
	printf("Min is %d\n", min == NULL ? -100 : min->Data);
	printf("Max is %d\n", max == NULL ? -100 : max->Data);
	printf("count is %d :\n", head->count);

	puts("success");
	return 1;
}