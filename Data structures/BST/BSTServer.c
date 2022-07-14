#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include "BST.h"

struct Node* GetNewNode(int data)
{
	struct Node* node = (struct Node*)malloc(sizeof(struct Node));
	node->Data = data;
	node->Parent = NULL;
	node->Left = NULL;
	node->Right = NULL;
	return node;
};

int InsertHelper(struct BST* head, struct Node* root, int data)
{
	struct Node* newNode = GetNewNode(data);
	if (head->root == NULL)
	{
		head->root = newNode;
		head->count++;
		return (SUCCESS);
	}
	else
	{
		if (root->Data >= data)
		{
			if (root->Right == NULL)
			{
				root->Right = newNode;
				head->count++;
				return (SUCCESS);
			}
			else
			{
				InsertHelper(head, root->Right, data);
				newNode->Parent = head->root->Right;
			}
		}
		else
		{
			if (root->Data <= data)
			{
				if (root->Left == NULL)
				{
					root->Left = newNode;
					head->count++;
					return (SUCCESS);
				}
				else
				{
					InsertHelper(head, root->Left, data);
					newNode->Parent = root->Left;
				}
			}
		}
		return (SUCCESS);
	}
}

int Insert(struct BST* head, int data)
{
	InsertHelper(head, head->root, data);
}

void InorderHelper(struct Node* root)
{
	if (root != NULL)
	{
		InorderHelper(root->Left);
		printf("<-[%d]->", root->Data);
		InorderHelper(root->Right);
	}
}

void Inorder(struct BST* head)
{
	printf("[START]<->");
	InorderHelper(head->root);
	puts("[END]\n");
}

struct BST* Create()
{
	struct BST* head = (struct BST*)malloc(sizeof(struct BST));
	head->root = NULL;
	head->count = 0;
	return head;
}

