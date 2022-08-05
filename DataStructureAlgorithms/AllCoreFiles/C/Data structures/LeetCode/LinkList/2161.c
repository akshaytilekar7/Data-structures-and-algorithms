// https://leetcode.com/problems/partition-array-according-to-given-pivot/
// 2161. Partition Array According to Given Pivot

/*
Runtime: 1415 ms, faster than 7.14% of C online submissions for Partition Array According to Given Pivot.
Memory Usage: 94.2 MB, less than 21.43% of C online submissions for Partition Array According to Given Pivot.
*/

#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>
#include <string.h>

/*
 Create one result array of same size.
	Run a loop 
		1st time all elements less that pivot
		2nd time equal to pivot from next index.
		3rd time greater to pivot from next index.
	return array
*/
int* pivotArray(int* nums, int numsSize, int pivot, int* returnSize) {

	int n = numsSize;
	*returnSize = n;
	int* ans = (int*)malloc(numsSize * sizeof(int));

	int len = 0;
	for (int i = 0; i < n; i++) {
		if (nums[i] < pivot) {
			ans[len++] = nums[i];
		}
	}

	for (int i = 0; i < n; i++) {
		if (nums[i] == pivot) {
			ans[len++] = nums[i];
		}
	}

	for (int i = 0; i < n; i++) {
		if (nums[i] > pivot) {
			ans[len++] = nums[i];
		}
	}

	return ans;

}

int main(int argc, char* argv[])
{
	int size = 7;
	int arr[] = { 9,12,5,10,14,3,10 };
	int pivot = 10;
	int returnSize = 0;

	puts("before Start - ");
	for (int i = 0; i < size; i++)
		printf(" [%d] ", arr[i]);
	puts("End \n");

	int *ans =pivotArray(arr, size, pivot, &returnSize);

	puts("After Start - ");
	for (int i = 0; i < size; i++)
		printf(" [%d] ", ans[i]);
	puts("End \n");

	return 0;
}