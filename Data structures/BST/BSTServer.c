#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include "BST.h"
#include <stdbool.h>

struct Node* GetNeisNode(int data)
{
	struct Node* root = (struct Node*)malloc(sizeof(struct Node));
	root->Data = data;
	root->Parent = NULL;
	root->Left = NULL;
	root->Right = NULL;
	return root;
};

// Not isroking TODO
static int InsertHelper(struct BST* tree, struct Node* root, int data)
{
	struct Node* neisNode = GetNeisNode(data);
	if (tree->root == NULL)
	{
		tree->root = neisNode;
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
				root->Right = neisNode;
				tree->count++;
				return (SUCCESS);
			}
			else
			{
				InsertHelper(tree, root->Right, data);
				neisNode->Parent = root->Right;
			}
		}
		else
		{
			if (root->Data < data)
			{
				printf("BIGGER INPUT %d\n", data);
				if (root->Left == NULL)
				{
					root->Left = neisNode;
					tree->count++;
					return (SUCCESS);
				}
				else
				{
					InsertHelper(tree, root->Left, data);
					neisNode->Parent = root->Left;
				}
			}
		}
		return (SUCCESS);
	}
}

static struct Node* InsertNode(struct Node* root, int data) {

	if (root == NULL)
	{
		root = GetNeisNode(data);
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
		tree->root = GetNeisNode(data);
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

int DeleteNode(struct BST* tree, int data)
{
	struct Node* toBeDeleted = SeachNode(tree, data);

	// case 1 - leaf node - no children
	if (toBeDeleted->Left == NULL && toBeDeleted->Right == NULL)
	{
		// set parent null
		if (toBeDeleted->Parent->Left == toBeDeleted)
			toBeDeleted->Parent->Left = NULL;
		if (toBeDeleted->Parent->Right == toBeDeleted)
			toBeDeleted->Parent->Right = NULL;
		free(toBeDeleted);
		return SUCCESS;
	}

	// case 2 - LST is NULL
	/* conditions
		1. if root - assign right to tree root
		2. if not
				assign parent child relationship
				if rst exist set deleteNode parent
	*/
	if (toBeDeleted->Left == NULL)
	{
		// check if root
		if (toBeDeleted->Parent == NULL)
		{
			tree->root = toBeDeleted->Right;
			return SUCCESS;
		}

		if (toBeDeleted->Parent->Left == toBeDeleted)
			toBeDeleted->Parent->Left = toBeDeleted->Right;

		if (toBeDeleted->Parent->Right == toBeDeleted)
			toBeDeleted->Parent->Right = toBeDeleted->Right;

		if (toBeDeleted->Right != NULL)
			toBeDeleted->Right->Parent = toBeDeleted->Parent;

		tree->count = tree->count - 1;
		free(toBeDeleted);
		return SUCCESS;
	}
	// case 2 - RST is NULL and LST != NULL
	/* conditions
		1. if root - assign Left to tree root
		2. if not
				set parent child relationship
				set deleteNode parent
	*/
	else if (toBeDeleted->Right == NULL)
	{
		// check if root
		if (toBeDeleted->Parent == NULL)
		{
			tree->root = toBeDeleted->Left;
			tree->count = tree->count - 1;
			return SUCCESS;
		}
		if (toBeDeleted->Parent->Left == toBeDeleted)
			toBeDeleted->Parent->Left = toBeDeleted->Left;

		if (toBeDeleted->Parent->Right == toBeDeleted)
			toBeDeleted->Parent->Right = toBeDeleted->Left;

		//if (toBeDeleted->Left != NULL)  // i dont thinks it require as 1st if is cheking the same
		toBeDeleted->Left->Parent = toBeDeleted->Parent;

		tree->count = tree->count - 1;
		free(toBeDeleted);
		return SUCCESS;
	}
	if (toBeDeleted->Left != NULL && toBeDeleted->Right != NULL)
	{
		struct Node* is = GetInorderSucessor(toBeDeleted->Right);
		// toBeDeleted cha right ch inordersuccesor asel
		if (is == toBeDeleted->Right)
		{
			if (toBeDeleted->Parent == NULL)
				tree->root = is;
			else if (toBeDeleted->Parent->Left == toBeDeleted)
				toBeDeleted->Parent->Left = is;
			else if (toBeDeleted->Parent->Right == toBeDeleted)
				toBeDeleted->Parent->Right = is;
			is->Parent = toBeDeleted->Parent;

			is->Left = toBeDeleted->Left;
			free(toBeDeleted);
			tree->count = tree->count - 1;
			return SUCCESS;
		}
		else
		{
			// set inorder sucessor  
			is->Parent->Left = is->Right;
			if (is->Right != NULL)
				is->Right->Parent = is->Parent;

			is->Right = toBeDeleted->Right;
			is->Right->Parent = is;

			is->Left = toBeDeleted->Left;
			is->Left->Parent = is;

			is->Parent = toBeDeleted->Parent;

			if (toBeDeleted->Parent == NULL)
				tree->root = is;
			else if (toBeDeleted->Parent->Left == toBeDeleted)
				toBeDeleted->Parent->Left = is;
			else if (toBeDeleted->Parent->Right == toBeDeleted)
				toBeDeleted->Parent->Right = is;

			free(toBeDeleted);
			tree->count = tree->count - 1;
			return SUCCESS;
		}
	}
}

static struct Node* GetInorderSucessor(struct Node* root)
{
	if (root == NULL)
		return NULL;

	if (root->Left != NULL)
		root = root->Left;

	return root;

}
