// https://leetcode.com/problems/fibonacci-number/
// 509. Fibonacci Number

/*
Runtime: 19 ms, faster than 15.62% of C online submissions for Fibonacci Number.
Memory Usage: 5.5 MB, less than 43.62% of C online submissions for Fibonacci Number.
*/

#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>
#include <string.h>
#include <stdbool.h>


int fib(int n) {
	if (n == 0) return 0;
	if (n == 1) return 1;
	return fib(n - 1) + fib(n - 2);
}

int main(int argc, char* argv[])
{
	int arg1 = atoi(argv[1]);
	int result = fib(arg1);
	printf("fibo of %d is : %d\n", arg1, result);

	return 0;
}