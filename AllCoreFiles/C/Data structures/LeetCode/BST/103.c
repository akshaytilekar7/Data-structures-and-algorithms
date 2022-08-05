// https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
// 103. Binary Tree Zigzag Level Order Traversal
//

/*

*/

#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include <stdbool.h>

struct TreeNode {
	int val;
	struct TreeNode* left;
	struct TreeNode* right;
};


int** zigzagLevelOrder(struct TreeNode* root, int* returnSize, int** returnColumnSizes) {

	if (root == NULL)
	{
		*returnSize = 0;
		returnColumnSize = NULL;
	}

	struct TreeNode* traverse = root;
	struct TreeNode** arr = (struct TreeNode**)calloc(2000, sizeof(struct TreeNode*));

	int index = 0, queueStartIndex = 0;
	arr[index++] = root;
	while (index > 0 && arr[queueStartIndex] != NULL)
	{
		struct TreeNode* node = arr[index];

		traverse = traverse->left;
	}
}