#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h> 
#include "Stack.h"

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
	assert(Pop(p_list, &data) == StackIsEmpty);

	for (data = 1; data <= 5; ++data)
		assert(InsertAtEnd(p_list, data) == SUCCESS);
	PrintList(p_list, "After InsertAtStart:");

	for (data = 10; data <= 15; ++data)
		assert(InsertAtEnd(p_list, data) == SUCCESS);
	PrintList(p_list, "After InsertAtEnd:");

	assert(IsEmpty(p_list) == FALSE);
	assert(GetLength(p_list) != 0);

	status = Peek(p_list, &data);
	printf("Peek %d\n", data);

	status = Pop(p_list, &data);
	printf("Pop %d\n", data);

	status = Peek(p_list, &data);
	printf("Peek %d\n", data);

	status = Pop(p_list, &data);
	printf("Pop %d\n", data);

	data = GetLength(p_list);
	printf("Length %d\n", data);

	PrintList(p_list, "At last:");

	puts("Implementation successful");

	return (EXIT_SUCCESS);
}