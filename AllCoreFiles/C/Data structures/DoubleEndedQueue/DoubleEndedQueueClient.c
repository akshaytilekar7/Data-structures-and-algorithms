#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h> 
#include "DoubleEndedQueue.h"
// not sure about working

int main(void)
{
	ListType* p_list = NULL;
	dataType data;
	statusType status;

	p_list = CreateList();
	assert(p_list);
	PrintList(p_list, "After creation:");

	assert(IsEmpty(p_list) == TRUE);
	//assert(GetLength(p_list) == 0);

	for (data = 1; data <= 5; ++data)
	{
		assert(PushFront(p_list, data) == SUCCESS);
		PrintList(p_list, "After Insert:");
	}
	

	//for (data = 10; data <= 15; ++data)
	//	assert(Enqueue(p_list, data) == SUCCESS);
	//PrintList(p_list, "After Insert:");

	//assert(IsEmpty(p_list) == FALSE);
	//assert(GetLength(p_list) != 0);

	//status = Peek(p_list, &data);
	//printf("Peek %d\n", data);

	//status = Dequeue(p_list, &data);
	//printf("Dequeue %d\n", data);


	puts("Implementation successful");

	return (EXIT_SUCCESS);
}