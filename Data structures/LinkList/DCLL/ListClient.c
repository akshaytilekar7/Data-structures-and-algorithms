#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h> 
#include "List.h"

int main(void)
{
	ListType* p_list = NULL;
	ListType* p_reversed_list = NULL;
	ListType* p_list_1 = NULL;
	ListType* p_list_2 = NULL;
	ListType* p_concat_list = NULL;
	ListType* p_merged_list = NULL;
	dataType data;
	statusType status;

	p_list = CreateList();
	assert(p_list);
	PrintList(p_list, "After creation:");

	assert(IsEmpty(p_list) == TRUE);
	assert(GetLength(p_list) == 0);
	assert(GetStart(p_list, &data) == ListIsEmpty);
	assert(GetEnd(p_list, &data) == ListIsEmpty);
	assert(PopStart(p_list, &data) == ListIsEmpty);
	assert(PopEnd(p_list, &data) == ListIsEmpty);
	assert(RemoveFirst(p_list) == ListIsEmpty);
	assert(RemoveEnd(p_list) == ListIsEmpty);

	for (data = 1; data <= 5; ++data)
		assert(InsertAtEnd(p_list, data) == SUCCESS);
	PrintList(p_list, "After InsertAtStart:");

	for (data = 6; data <= 10; ++data)
		assert(InsertAtEnd(p_list, data) == SUCCESS);
	PrintList(p_list, "After InsertAtEnd:");

	assert(InsertAfter(p_list, -10, 100) == DataNotFound);
	assert(InsertBefore(p_list, 13, 5) == DataNotFound);
	assert(InsertBefore(p_list, 19, 5) == DataNotFound);

	assert(InsertAfter(p_list, 3, 5) == SUCCESS);
	PrintList(p_list, "After InsertAfter:");
	assert(InsertBefore(p_list, 9, 5) == SUCCESS);
	PrintList(p_list, "After InsertBefore:");

	assert(InsertAfter(p_list, 2, 7) == SUCCESS);
	PrintList(p_list, "After InsertAfter:");
	assert(InsertBefore(p_list, 6, 7) == SUCCESS);
	PrintList(p_list, "After InsertBefore:");

	/*
	assert(GetLength(p_list) > 0);
	data = -1;
	assert(GetStart(p_list, &data) == SUCCESS);
	printf("Start Data:%d\n", data);
	PrintList(p_list, "After GetStart:");

	data = -1;
	assert(GetEnd(p_list, &data) == SUCCESS);
	printf("End Data:%d\n", data);
	PrintList(p_list, "After GetEnd:");

	data = -1;
	assert(PopStart(p_list, &data) == SUCCESS);
	printf("Poped Start Data:%d\n", data);
	PrintList(p_list, "After PopStart:");

	data = -1;
	assert(PopEnd(p_list, &data) == SUCCESS);
	printf("Poped End Data:%d\n", data);
	PrintList(p_list, "After PopEnd:");

	assert(RemoveFirst(p_list) == SUCCESS);
	PrintList(p_list, "After RemoveFirst:");

	assert(RemoveEnd(p_list) == SUCCESS);
	PrintList(p_list, "After RemoveEnd:");

	assert(RemoveFirstOccurenceOfData(p_list, -10) == DataNotFound);*/
	assert(RemoveFirstOccurenceOfData(p_list, 3) == SUCCESS);
	PrintList(p_list, "After RemoveFirstOccurenceOfData 3");

	assert(RemoveLastOccurenceOfData(p_list, 7) == SUCCESS);
	PrintList(p_list, "After RemoveLastOccurenceOfData 7");

	assert(RemoveAllOccurenceOfData(p_list, 7) == SUCCESS);
	PrintList(p_list, "After RemoveAllOccurenceOfData 7");

	printf("Length = %d\n", GetLength(p_list));
	printf("Recursive Length = %d\n", RecusiveGetLength(p_list));
	printf("Recursive Length = %d\n", RecusiveGetLength(p_list));

	assert(IsEmpty(p_list) == FALSE);

	if (IsExist(p_list, -10) == FALSE)
		puts("-10 is not present in list");

	if (IsExist(p_list, 2) == TRUE)
		puts("2 is present in list");
	/*
	while (IsEmpty(p_list) != TRUE)
		assert(RemoveEnd(p_list) == SUCCESS);

	assert(IsEmpty(p_list) == TRUE);

	PrintList(p_list, "Should be empty");
	assert(reverse_list(p_list) == SUCCESS);
	PrintList(p_list, "Reversed of empty list should be empty as well");

	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	PrintList(p_list, "Should contain one element");
	assert(reverse_list(p_list) == SUCCESS);
	PrintList(p_list, "Reversed version of list with one element is same list");*/

	// assert(destroy_list(&p_list) == SUCCESS && p_list == NULL);

	puts("Testing inter-list routines");

	p_list_1 = CreateList();
	p_list_2 = CreateList();
	assert(IsEmpty(p_list_1) && IsEmpty(p_list_2));

	for (data = 5; data < 8; data += 1)
		assert(InsertAtEnd(p_list_1, data) == SUCCESS);

	for (data = 20; data <= 23; data += 1)
		assert(InsertAtEnd(p_list_2, data) == SUCCESS);

	PrintList(p_list_1, "p_list_1");
	PrintList(p_list_2, "p_list_2");

	assert(ConcatMutable(p_list_1, p_list_2) == SUCCESS);
	PrintList(p_list_1, "After ConcatMutable 1");

	ListType* list3 = ConcatImmutable(p_list_1, p_list_1);
	PrintList(list3, "After ConcatImmutable XXXX");

	ListType* list4 = GetReverseList(list3);
	PrintList(list4, "After GetReverseList");

	ReverseListBySwap(p_list_1);
	PrintList(p_list_1, "Again GetReverseList 1 1");

	puts("Implementation successful");

	return (EXIT_SUCCESS);
}