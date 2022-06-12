#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h> 
#include "Queue.h"

int main(void)
{
	ListType* p_list = NULL;
	dataType data;
	statusType status;

	p_list = CreateList();
	assert(p_list);
	PrintList(p_list, "After creation:");

	assert(IsEmpty(p_list) == TRUE);
	assert(GetLength(p_list) == 0);
	assert(Peek(p_list, &data) == StackIsEmpty);
	assert(Dequeue(p_list, &data) == StackIsEmpty);

	for (data = 1; data <= 5; ++data)
		assert(Enqueue(p_list, data) == SUCCESS);
	PrintList(p_list, "After Insert:");

	for (data = 10; data <= 15; ++data)
		assert(Enqueue(p_list, data) == SUCCESS);
	PrintList(p_list, "After Insert:");

	assert(IsEmpty(p_list) == FALSE);
	assert(GetLength(p_list) != 0);

	status = Peek(p_list, &data);
	printf("Peek %d\n", data);

	status = Dequeue(p_list, &data);
	printf("Dequeue %d\n", data);

	status = Peek(p_list, &data);
	printf("Peek %d\n", data);

	status = Dequeue(p_list, &data);
	printf("Dequeue %d\n", data);

	data = GetLength(p_list);
	printf("Length %d\n", data);

	PrintList(p_list, "At last:");

	puts("Implementation successful");

	return (EXIT_SUCCESS);
}