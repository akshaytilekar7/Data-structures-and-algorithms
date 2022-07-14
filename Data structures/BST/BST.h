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
void InorderHelper(struct Node* head);
void Inorder(struct BST* head);
struct BST* Create();
