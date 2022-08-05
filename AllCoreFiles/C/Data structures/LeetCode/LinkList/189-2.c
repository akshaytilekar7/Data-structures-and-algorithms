// https://leetcode.com/problems/rotate-array/
// 189. Rotate Array
/*
Time Limit Exceeded
*/
#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>
#include <string.h>


void PrintArray(int* nums, int numsSize, char* msg)
{
	printf("' %s '\n", msg);

	printf("[");
	for (int i = 0; i < numsSize; i++)
		printf(" %d ", nums[i]);
	printf("]\n");

}

void rotate(int* nums, int numsSize, int k)
{
	if (numsSize == 0 || k == 0)
		return;

	if (numsSize == 1)
		return;

	if (k > numsSize)
	{
		int t = k / numsSize;
		k = k - (t * numsSize);
	}

	int* tempArr = malloc(k * sizeof(int));
	int temp = k;
	int start = 0;
	int last = numsSize - 1;
	while (temp > 0)
	{
		tempArr[start] = nums[last];
		start++;
		temp--;
		last--;
	}

	for (int i = numsSize - 1; i > 0; i--)
		nums[i] = nums[i - k];

	for (int i = 0; i < k; i++)
		nums[i] = tempArr[k - i - 1];

}


int main(int argc, char* argv[])
{
	int size = atoi(argv[1]);
	int k = atoi(argv[2]);

	int* nums = malloc(size * sizeof(int));

	for (int i = 0; i < size; i++)
		nums[i] = i + 1;

	PrintArray(nums, size, "Before");
	rotate(nums, size, k);
	PrintArray(nums, size, "final");
	return 0;
}