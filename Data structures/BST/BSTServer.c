#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include <stdbool.h>
#include "BST.h"

struct Node* GetNewNode(int data)
{
	struct Node* root = (struct Node*)malloc(sizeof(struct Node));
	root->Data = data;
	root->Parent = NULL;
	root->Left = NULL;
	root->Right = NULL;
	return root;
};

static struct Node* InsertNode(struct Node* root, int data) {

	if (root == NULL)
	{
		root = GetNewNode(data);
		return root;
	}
	if (root->Data < data)
	{
		root->Right = InsertNode(root->Right, data);
		root->Right->Parent = root;
	}
	else
	{
		root->Left = InsertNode(root->Left, data);
		root->Left->Parent = root;
	}
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
		printf(" [%d]", root->Data);
		InorderHelper(root->Right);
	}
}

void Inorder(struct BST* tree)
{
	printf("[IN]");
	InorderHelper(tree->root);
	puts(" [END]\n");
}

static void InorderHelperParent(struct Node* root)
{
	if (root != NULL)
	{
		InorderHelperParent(root->Left);
		if (root->Parent != NULL)
			printf("data %d and Parent %d\n", root->Data, root->Parent->Data);
		else {
			printf("for data %d Parent is null\n", root->Data);
		}
		InorderHelperParent(root->Right);
	}
}

// JUST FOR TESTING
void InorderParent(struct BST* tree)
{
	printf("[IN PARENT");
	InorderHelperParent(tree->root);
	puts(" [END]\n");
}

static void PreorderHelper(struct Node* root)
{
	if (root != NULL)
	{
		printf(" [%d]", root->Data);
		PreorderHelper(root->Left);
		PreorderHelper(root->Right);
	}
}

void Preorder(struct BST* tree)
{
	printf("[PRE]");
	PreorderHelper(tree->root);
	puts(" [END]\n");
}

static void PostorderHelper(struct Node* root)
{
	if (root != NULL)
	{
		PostorderHelper(root->Left);
		PostorderHelper(root->Right);
		printf(" [%d]", root->Data);
	}
}

void Postorder(struct BST* tree)
{
	printf("[POST]");
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

	if (toBeDeleted == NULL) return DataNotFound;

	if (toBeDeleted->Left == NULL)
	{
		if (toBeDeleted->Parent == NULL)
		{
			tree->root = toBeDeleted->Right;
			if (toBeDeleted->Right != NULL)
				toBeDeleted->Right->Parent = toBeDeleted->Parent;
			free(toBeDeleted);
			tree->count--;
			return SUCCESS;
		}

		if (toBeDeleted->Parent->Left == toBeDeleted)
			toBeDeleted->Parent->Left = toBeDeleted->Right;
		else if (toBeDeleted->Parent->Right == toBeDeleted)
			toBeDeleted->Parent->Right = toBeDeleted->Right;

		if (toBeDeleted->Right != NULL)
			toBeDeleted->Right->Parent = toBeDeleted->Parent;

		free(toBeDeleted);
		tree->count--;
		return SUCCESS;
	}

	if (toBeDeleted->Right == NULL)
	{
		if (toBeDeleted->Parent == NULL)
		{
			tree->root = toBeDeleted->Left;
			if (toBeDeleted->Left != NULL)
				toBeDeleted->Left->Parent = toBeDeleted->Parent;
			free(toBeDeleted);
			tree->count--;
			return SUCCESS;
		}
		if (toBeDeleted->Parent->Left == toBeDeleted)
			toBeDeleted->Parent->Left = toBeDeleted->Left;
		else if (toBeDeleted->Parent->Right == toBeDeleted)
			toBeDeleted->Parent->Right = toBeDeleted->Left;
		if (toBeDeleted->Left != NULL)
			toBeDeleted->Left->Parent = toBeDeleted->Parent;
		free(toBeDeleted);
		tree->count--;
		return SUCCESS;
	}

	if (toBeDeleted->Left != NULL && toBeDeleted->Right != NULL)
	{
		struct Node* inorderSuc = GetInorderSucessor(toBeDeleted->Right);

		if (toBeDeleted->Right != inorderSuc)
		{
			inorderSuc->Parent->Left = inorderSuc->Right;
			if (inorderSuc->Right != NULL)
				inorderSuc->Right->Parent = inorderSuc->Parent;

			inorderSuc->Right = toBeDeleted->Right;
			inorderSuc->Right->Parent = inorderSuc;
		}
		if (toBeDeleted->Parent == NULL)
			tree->root = inorderSuc;
		else if (toBeDeleted == toBeDeleted->Parent->Left)
			toBeDeleted->Parent->Left = inorderSuc;
		else if (toBeDeleted == toBeDeleted->Parent->Right)
			toBeDeleted->Parent->Right = inorderSuc;

		inorderSuc->Parent = toBeDeleted->Parent;
		inorderSuc->Left = toBeDeleted->Left;
		inorderSuc->Left->Parent = inorderSuc;

		free(toBeDeleted);
		tree->count--;
		return SUCCESS;
	}

	return SomethingWentWrong;
}

static struct Node* GetInorderSucessor(struct Node* root)
{
	if (root == NULL)
		return NULL;

	while (root->Left != NULL)
		root = root->Left;

	return root;
}

bool IsEmpty(struct BST* tree)
{
	return tree->root == NULL;
}

void InorderIterative(struct BST* tree)
{
	struct Node** arr = (struct Node**)malloc(sizeof(struct Node*) * tree->count);

	printf("[IN IT]");
	struct Node* travel = tree->root;
	int index = 0;
	while (TRUE)
	{
		while (travel != NULL)
		{
			arr[index++] = travel;
			travel = travel->Left;
		}

		travel = arr[--index];
		if (index < 0) break;

		printf(" [%d]", travel->Data);
		travel = travel->Right;
	}

	puts(" [END]\n");
}

void PreorderIterative(struct BST* tree)
{
	struct Node** arr = (struct Node**)malloc(sizeof(struct Node*) * tree->count);
	printf("[PRE IT]");
	struct Node* travel = tree->root;
	int index = 0;
	while (TRUE)
	{
		while (travel != NULL)
		{
			printf(" [%d]", travel->Data);
			arr[index++] = travel;
			travel = travel->Left;
		}

		travel = arr[--index];
		if (index < 0) break;

		travel = travel->Right;
	}

	puts(" [END]\n");
}

struct Dictionary
{
	struct Node* node;
	int VisitedCount;
};

// NOT WORKING
void PostorderIterative(struct BST* tree)
{
	/*struct Dictionary** arr = (struct Dictionary**)malloc(sizeof(struct Dictionary*) * tree->count);

	printf("[PO IT]");
	struct Node* travel = tree->root;
	int startIndex = 0;

	while (TRUE)
	{
		struct Dictionary* dict = NULL;
		while (travel != NULL)
		{
			dict = (struct Dictionary*)malloc(sizeof(struct Dictionary));
			dict->node = travel;
			dict->VisitedCount = 1;
			arr[startIndex] = dict;

			startIndex = startIndex + 1;

			travel = travel->Left;
		}

		if (startIndex < 0) break;

		int lastIndex = startIndex - 1;

		if (arr[lastIndex]->VisitedCount == 3)
			continue;

		arr[lastIndex]->VisitedCount++;
		travel = arr[lastIndex]->node;

		if (arr[lastIndex]->VisitedCount == 3)
		{
			printf(" [%d]", travel->Data);
			startIndex--;
		}
		travel = travel->Right;
	}

	puts(" [END]\n");*/

}

void BFS(struct BST* tree)
{
	BFSHelper(tree, tree->root);
}

void BFSHelper(struct BST* tree, struct Node* root)
{
	puts("\n[BFS BFS BFS START ]");
	int index = 0, startQueueIndex = 0;

	struct Node** arr = (struct Node**)calloc(tree->count + 1, sizeof(struct Node*));
	arr[index++] = root;

	while (index >= 0 && arr[startQueueIndex] != NULL)
	{
		struct Node* node = arr[startQueueIndex];
		printf(" [%d] ", node->Data);
		arr[startQueueIndex] = NULL;
		startQueueIndex++;

		if (node->Left != NULL)
			arr[index++] = node->Left;
		if (node->Right != NULL)
			arr[index++] = node->Right;
	}
	puts("\n[BFS BFS BFS END]\n");
}

void DFS(struct BST* tree)
{
	puts("\n[DFS DFS DFS START ]");
	DFSHelper(tree, tree->root);
	puts("\n[DFS DFS DFS END ]\n");
}

void DFSHelper(struct BST* tree, struct Node* root)
{
	if (root == NULL)
		return;

	printf(" [%d] ", root->Data);
	DFSHelper(tree, root->Left);
	DFSHelper(tree, root->Right);
}

/*
Remaining TODO

	Inorder Sucessor
	Inorder Predcessor

	Preorder Sucessor
	Preorder Predcessor

	Postorder Sucessor
	Postorder Predcessor

	int GetAllOccurrences(struct BST* tree, int data, struct Node*** p_to_array_of_node_ptrs)

*/