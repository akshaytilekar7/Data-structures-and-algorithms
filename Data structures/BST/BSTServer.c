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

static int InsertHelper(struct BST* head, struct Node* root, int data)
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

static void InorderHelper(struct Node* root)
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
	printf("[INORDER START]");
	InorderHelper(head->root);
	puts("[END]\n");
}

static void PreorderHelper(struct Node* root)
{
	if (root != NULL)
	{
		printf("<-[%d]->", root->Data);
		PreorderHelper(root->Left);
		PreorderHelper(root->Right);
	}
}

void Preorder(struct BST* head)
{
	printf("[PREORDER START]");
	PreorderHelper(head->root);
	puts("[END]\n");
}

static void PostorderHelper(struct Node* root)
{
	if (root != NULL)
	{
		PostorderHelper(root->Left);
		PostorderHelper(root->Right);
		printf("<-[%d]->", root->Data);
	}
}

void Postorder(struct BST* head)
{
	printf("[POSTORDER START]");
	PostorderHelper(head->root);
	puts("[END]\n");
}

struct BST* Create()
{
	struct BST* head = (struct BST*)malloc(sizeof(struct BST));
	head->root = NULL;
	head->count = 0;
	return head;
}

