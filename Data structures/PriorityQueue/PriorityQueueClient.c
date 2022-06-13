#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h> 
#include "PriorityQueue.h"

int main(void)
{
	ListType* p_list = NULL;
	statusType status;
	EmployeeType* data;

	p_list = CreateList();
	assert(p_list);
	PrintList(p_list, "After creation:");

	assert(IsEmpty(p_list) == TRUE);
	assert(GetLength(p_list) == 0);
	assert(Peek(p_list, data) == StackIsEmpty);
	assert(Dequeue(p_list, data) == StackIsEmpty);

	for (int i = 1; i <= 5; ++i)
	{
		
		EmployeeType* employee = (EmployeeType*)malloc(sizeof(EmployeeType));
		employee->RollNumber = i;

		char fname[5];
		itoa(10 * i, fname, 10);
		employee->FirstName = fname;

		char lname[5];
		itoa(100 * i, lname, 10);
		employee->LastName = lname;

		assert(Enqueue(p_list, employee) == SUCCESS);
	}

	PrintList(p_list, "Print List");

	assert(IsEmpty(p_list) == FALSE);
	assert(GetLength(p_list) != 0);

	EmployeeType* emp = (EmployeeType*)malloc(sizeof(EmployeeType));

	assert(Peek(p_list, emp) == SUCCESS);
	PrintEmployee("Peek 1", emp);

	assert(Dequeue(p_list, emp) == SUCCESS);
	PrintEmployee("Dequeue 1", emp);

	assert(Peek(p_list, emp) == SUCCESS);
	PrintEmployee("Peek 2", emp);
	
	assert(Dequeue(p_list, emp) == SUCCESS);
	PrintEmployee("Dequeue 2", emp);


	assert(Dequeue(p_list, emp) == SUCCESS);
	PrintEmployee("Dequeue 3", emp);

	assert(Dequeue(p_list, emp) == SUCCESS);
	PrintEmployee("Dequeue 4", emp);

	assert(Dequeue(p_list, emp) == SUCCESS);
	PrintEmployee("Dequeue 5", emp);

	int len = GetLength(p_list);
	printf("Length %d\n", len);

	PrintList(p_list, "At last:");

	puts("Implementation successful");

	return (EXIT_SUCCESS);
}