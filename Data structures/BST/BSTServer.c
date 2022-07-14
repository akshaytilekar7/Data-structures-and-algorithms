#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include "BST.h"
#include <stdbool.h>

struct Node* GetNewNode(int data)
{
	struct Node* root = (struct Node*)malloc(sizeof(struct Node));
	root->Data = data;
	root->Parent = NULL;
	root->Left = NULL;
	root->Right = NULL;
	return root;
};

// Not wroking TODO
static int InsertHelper(struct BST* tree, struct Node* root, int data)
{
	struct Node* newNode = GetNewNode(data);
	if (tree->root == NULL)
	{
		tree->root = newNode;
		tree->count++;
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
				tree->count++;
				return (SUCCESS);
			}
			else
			{
				InsertHelper(tree, root->Right, data);
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
					tree->count++;
					return (SUCCESS);
				}
				else
				{
					InsertHelper(tree, root->Left, data);
					newNode->Parent = root->Left;
				}
			}
		}
		return (SUCCESS);
	}
}

static struct Node* InsertNode(struct Node* root, int data) {

	if (root == NULL)
	{
		root = GetNewNode(data);
		return root;
	}
	if (root->Data < data)
		root->Right = InsertNode(root->Right, data);
	else
		root->Left = InsertNode(root->Left, data);

	return root;
}

int Insert(struct BST* tree, int data)
{
	if (tree->root == NULL)
	{
		tree->root = GetNewNode(data);
		tree->count++;
		return SUCCESS;
	}

	InsertNode(tree->root, data);
	tree->count++;
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

void Inorder(struct BST* tree)
{
	printf("[INORDER START]");
	InorderHelper(tree->root);
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

void Preorder(struct BST* tree)
{
	printf("[PREORDER START]");
	PreorderHelper(tree->root);
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

void Postorder(struct BST* tree)
{
	printf("[POSTORDER START]");
	PostorderHelper(tree->root);
	puts("[END]\n");
}

struct BST* Create()
{
	struct BST* tree = (struct BST*)malloc(sizeof(struct BST));
	tree->root = NULL;
	tree->count = 0;
	return tree;
}

struct Node* GetMaxNode(struct BST* tree)
{
	if (tree->root == NULL)
		return NULL;
	return GetMaxNodeHelper(tree->root);
}

static struct Node* GetMaxNodeHelper(struct Node* root)
{
	if (root->Right == NULL)
		return root;
	return GetMaxNodeHelper(root->Right);
}

struct Node* GetMinNode(struct BST* tree)
{
	if (tree->root == NULL)
		return NULL;
	return GetMinNodeHelper(tree->root);
}

static struct Node* GetMinNodeHelper(struct Node* root)
{
	if (root->Left == NULL)
		return root;
	return GetMinNodeHelper(root->Left);
}

int GetMaxData(struct BST* tree)
{
	struct Node* max = GetMaxNode(tree);
	return max == NULL ? -100 : max->Data;
}

int GetMinData(struct BST* tree)
{
	struct Node* min = GetMinNode(tree);
	return min == NULL ? -100 : min->Data;
}

struct Node* SeachNode(struct BST* tree, int data)
{
	if (tree->root == NULL)
		return NULL;
	return SeachNodeHelper(tree->root, data);
}

static struct Node* SeachNodeHelper(struct Node* root, int data)
{
	if (root == NULL)
		return NULL;

	if (root->Data == data)
		return root;

	if (data > root->Data)
		SeachNodeHelper(root->Right, data);
	else
		SeachNodeHelper(root->Left, data);

}

bool IsExist(struct BST* tree, int data)
{
	return (SeachNode(tree, data) != NULL);
}

