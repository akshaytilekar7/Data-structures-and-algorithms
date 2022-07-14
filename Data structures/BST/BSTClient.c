#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include "BST.h"

int main()
{
	//int arr[] = { 30,10,20,15,25,5 };
	int arr[] = { 10,20,30,40,50 };

	struct BST* head = Create();
	for (int i = 0; i < sizeof(arr) / sizeof(int); i++)
	{
		Insert(head, arr[i]);
	}

	Preorder(head);
	Inorder(head);
	Postorder(head);

	printf("count is %d :\n", head->count);
	puts("success");
	return 1;
}