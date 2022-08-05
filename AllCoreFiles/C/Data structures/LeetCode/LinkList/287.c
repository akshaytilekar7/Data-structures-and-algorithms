// https://leetcode.com/problems/find-the-duplicate-number/
// 287. Find the Duplicate Number
// https://www.youtube.com/watch?v=32Ll35mhWg0 // TODO

/*
Runtime: 169 ms, faster than 34.31% of C online submissions for Find the Duplicate Number.
Memory Usage: 14.6 MB, less than 9.04% of C online submissions for Find the Duplicate Number.
*/

#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>
#include <string.h>
#include <stdbool.h>

void PrintArray(int* nums, int numsSize) {
	for (int i = 0; i < numsSize; i++)
		printf("[%d] : %d\n", i, nums[i]);
}

// create another array of n - 1 with values -1
// iterate thr main array and store at index (arr[nums[i]]) = nums[i]
// check wether we have same value already exist each time if YES - duplicates
int findDuplicate(int* nums, int numsSize) {
	
	int* arr = (int*)calloc(numsSize, sizeof(int));

	for (int i = 0; i < numsSize; i++) {
		if (arr[nums[i]] == 1)
			return nums[i];
		arr[nums[i]] = 1;
	}

	return 0;
}


int main(int argc, char* argv[])
{
	int arr[] = { 1,3,4,2,2 };
	int size = 5;

	PrintArray(arr, size);

	int result = findDuplicate(arr, size);

	printf("xx duplicate number : %d\n", result);
	return 0;
}