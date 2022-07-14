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
			printf("SMALL INPUT %d\n", data);
			if (root->Right == NULL)
			{
				root->Right = newNode;
				head->count++;
				return (SUCCESS);
			}
			else
			{
				InsertHelper(head, root->Right, data);
				newNode->Parent = root->Right;
			}
		}
		else
		{
			if (root->Data < data)
			{
				printf("BIGGER INPUT %d\n", data);
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

static struct Node* InsertNode(struct Node* head, int data) {
	
	if (head == NULL)
	{
		head = GetNewNode(data);
		return head;
	}
	if (head->Data < data)
		head->Right = InsertNode(head->Right, data);
	else
		head->Left = InsertNode(head->Left, data);
	
	return head;
}

int Insert(struct BST* head, int data)
{
	if (head->root == NULL)
	{
		head->root = GetNewNode(data);
		head->count++;
		return SUCCESS;
	}

	InsertNode(head->root, data);
	head->count++;
	return SUCCESS;
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

struct Node* GetMaxNode(struct BST* head)
{
	if (head->root == NULL)
		return NULL;
	return GetMaxNodeHelper(head->root);
}

static struct Node* GetMaxNodeHelper(struct Node* node)
{
	if (node->Right == NULL)
		return node;
	return GetMaxNodeHelper(node->Right);
}

struct Node* GetMinNode(struct BST* head)
{
	if (head->root == NULL)
		return NULL;
	return GetMinNodeHelper(head->root);
}

static struct Node* GetMinNodeHelper(struct Node* node)
{
	if (node->Left == NULL)
		return node;
	return GetMinNodeHelper(node->Left);
}

int GetMaxData(struct BST* head)
{
	struct Node* max = GetMaxNode(head);
	return max == NULL ? -100 : max->Data;
}

int GetMinData(struct BST* head)
{
	struct Node* min = GetMinNode(head);
	return min == NULL ? -100 : min->Data;
}


