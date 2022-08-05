// https://leetcode.com/problems/design-hashmap/submissions/
// 706. Design HashMap

/*
Runtime: 151 ms, faster than 65.89% of C online submissions for Design HashMap.
Memory Usage: 170.4 MB, less than 26.40% of C online submissions for Design HashMap.
*/

#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>
#include <string.h>

#define SIZE 1000000

typedef struct {
	int* arr;
} MyHashMap;


int hash(int x) {
	return x % SIZE;
}

MyHashMap* myHashMapCreate() {
	MyHashMap* obj = malloc(sizeof(MyHashMap));
	obj->arr = malloc(sizeof(int) * SIZE);
	memset(obj->arr, -1, SIZE * sizeof(int));
	return obj;
}

/** value will always be non-negative. */
void myHashMapPut(MyHashMap* obj, int key, int value) {
	obj->arr[hash(key)] = value;
}

/** Returns the value to which the specified key is mapped,
or -1 if this map contains no mapping for the key */
int myHashMapGet(MyHashMap* obj, int key) {
	return obj->arr[hash(key)];
}

/** Removes the mapping of the specified value key
if this map contains a mapping for the key */
void myHashMapRemove(MyHashMap* obj, int key) {
	obj->arr[hash(key)] = -1;
}

void myHashMapFree(MyHashMap* obj) {
	free(obj);
}

int main()
{
	MyHashMap* obj = myHashMapCreate();
	myHashMapPut(obj, 100, 100100);
	int param_2 = myHashMapGet(obj, 100);
	myHashMapRemove(obj, 500);
	myHashMapFree(obj);

	puts("Success");

	return 0;
}