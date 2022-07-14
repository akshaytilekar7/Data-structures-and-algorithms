#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>

#define SUCCESS	1
#define TRUE	1
#define FALSE	0

#define TreeIsEmpty 2
#define DataNotFound 2

struct Node
{
	int Data;
	struct Node* Parent;
	struct Node* Left;
	struct Node* Right;
};

struct BST
{
	struct Node* root;
	unsigned long long int count;
};

struct Node* GetNewNode(int data);

int Insert(struct BST* head, int data);
static int InsertHelper(struct BST* head, struct Node* root, int data);

static void InorderHelper(struct Node* head);
void Inorder(struct BST* head);
static void PreorderHelper(struct Node* head);
void Preorder(struct BST* head);
static void PostorderHelper(struct Node* head);
void Postorder(struct BST* head);

struct Node* GetMaxNode(struct BST* head);
static struct Node* GetMaxNodeHelper(struct Node* head);

struct Node* GetMinNode(struct BST* head);
static struct Node* GetMinNodeHelper(struct Node* head);

struct BST* Create();
