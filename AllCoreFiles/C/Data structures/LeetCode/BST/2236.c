// 2236. Root Equals Sum of Children
// https://leetcode.com/problems/root-equals-sum-of-children/
// Runtime: 7 ms, faster than 15.69% of C online submissions for Root Equals Sum of Children.
// Memory Usage : 5.9 MB, less than 36.86 % of C online submissions for Root Equals Sum of Children.

#include <iostream>

struct TreeNode {
	int val;
	struct TreeNode* left;
	struct TreeNode* right;
};

bool checkTree(struct TreeNode* root) {
	return root->val == root->left->val + root->right->val;
}