// https://leetcode.com/problems/power-of-two/submissions/
// 231. Power of Two
// https://leetcode.com/problems/power-of-two/discuss/2120549/C-Language

/*
Runtime: 0 ms, faster than 100.00% of C online submissions for Power of Two.
Memory Usage: 5.6 MB, less than 52.99% of C online submissions for Power of Two.
*/
#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>
#include <string.h>
#include <stdbool.h>

bool isPowerOfTwoHelper(long power, long product, long n) {

	if (power > n)
		return false;

	if (product == n)
		return true;

	if (product > n)
		return false;

	return isPowerOfTwoHelper(power, power * product, n);
}

bool isPowerOfTwo(int n) {

	if (n <= 0) return false;

	return isPowerOfTwoHelper(2, 1, n);
}


int main(int argc, char* argv[])
{
	int arg1 = atoi(argv[1]);
	printf("isPowerOfTwo : %s\n", isPowerOfTwo(arg1) ? "YES" : "NO");
	return 0;
}