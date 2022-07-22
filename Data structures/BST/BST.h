#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include <stdbool.h>

#define SUCCESS	1
#define TRUE	1
#define FALSE	0

#define TreeIsEmpty 2
#define DataNotFound 2
#define SomethingWentWrong 100

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

int Insert(struct BST* tree, int data);
static int InsertHelper(struct BST* tree, struct Node* root, int data);

static void InorderHelper(struct Node* head);
void Inorder(struct BST* tree);
static void PreorderHelper(struct Node* head);
void Preorder(struct BST* tree);
static void PostorderHelper(struct Node* head);
void Postorder(struct BST* tree);

struct Node* GetMaxNode(struct BST* tree);
static struct Node* GetMaxNodeHelper(struct Node* head);

struct Node* GetMinNode(struct BST* tree);
static struct Node* GetMinNodeHelper(struct Node* head);

struct Node* SeachNode(struct BST* tree, int data);
static struct Node* SeachNodeHelper(struct Node* node, int data);

int GetMinData(struct BST* tree);
int GetMaxData(struct BST* tree);
bool IsExist(struct BST* tree, int data);


int DeleteNode(struct BST* tree, int data);
static struct Node* GetInorderSucessor(struct Node* root);

static void InorderHelperParent(struct Node* root);
void InorderParent(struct BST* tree);

bool IsEmpty(struct BST* tree);

void InorderIterative(struct BST* tree);
void PreorderIterative(struct BST* tree);
void PostorderIterative(struct BST* tree);

struct BST* Create();