// https://leetcode.com/problems/design-hashset/
// 705. Design HashSet

/*
Runtime: 99 ms, faster than 87.53% of C online submissions for Design HashSet.
Memory Usage: 43.7 MB, less than 14.70% of C online submissions for Design HashSet.
*/

#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>
#include <string.h>
#include <stdbool.h>

typedef struct {
	int val[1000001];
} MyHashSet;

MyHashSet* myHashSetCreate() {
	MyHashSet* obj = calloc(1, sizeof(MyHashSet));
	return obj;
}

void myHashSetAdd(MyHashSet* obj, int key) {
	obj->val[key] = 1;
}

void myHashSetRemove(MyHashSet* obj, int key) {
	obj->val[key] = 0;
}

bool myHashSetContains(MyHashSet* obj, int key) {
	return obj->val[key] == 1 ? true : false;
}

void myHashSetFree(MyHashSet* obj) {
	free(obj);
}

int main(int argc, char* argv[])
{
	MyHashSet* obj = myHashSetCreate();
	myHashSetAdd(obj, 1);
	myHashSetAdd(obj, 2);

	bool param_1 = myHashSetContains(obj, 1);
	bool param_2 = myHashSetContains(obj, 3);
	myHashSetAdd(obj, 2);
	bool param_3 = myHashSetContains(obj, 2);
	myHashSetRemove(obj, 2);
	bool param_4 = myHashSetContains(obj, 2);

	myHashSetFree(obj);

	printf("%s\n", param_1 == true ? "T" : "F");
	printf("%s\n", param_2 == true ? "T" : "F");
	printf("%s\n", param_3 == true ? "T" : "F");
	printf("%s\n", param_4 == true ? "T" : "F");

	puts("success");
	return 0;
}

