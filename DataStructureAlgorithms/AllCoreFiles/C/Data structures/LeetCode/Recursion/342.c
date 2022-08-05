// 342. Power of Four
// https://leetcode.com/problems/power-of-four/
// https://leetcode.com/problems/power-of-four/discuss/2120580/C-Language-or-No-bit-manipulation

/*
Runtime: 3 ms, faster than 56.85% of C online submissions for Power of Four.
Memory Usage: 5.7 MB, less than 34.83% of C online submissions for Power of Four.
*/

#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>
#include <string.h>
#include <stdbool.h>

bool isPower(long power, long product, long n) {

	if (power > n)
		return false;

	if (product == n)
		return true;

	if (product > n)
		return false;

	return isPower(power, power * product, n);
}

bool isPowerOfFour(int n) {

	if (n <= 0) return false;
	if (n == 1) return true;
	return isPower(4, 1, n);
}

int main(int argc, char* argv[])
{
	int arg1 = atoi(argv[1]);
	printf("isPowerOfFour : %s\n", isPowerOfFour(arg1) ? "YES" : "NO");
	return 0;
}




