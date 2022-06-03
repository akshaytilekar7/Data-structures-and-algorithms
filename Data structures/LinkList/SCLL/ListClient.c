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
	PrintList(p_list, "DSLL After creation:");

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
	PrintList(p_list, "DSLL After InsertAtStart:");

	for (data = 6; data <= 10; ++data)
		assert(InsertAtEnd(p_list, data) == SUCCESS);
	PrintList(p_list, "DSLL After InsertAtEnd:");

	assert(InsertAfter(p_list, -10, 100) == DataNotFound);
	assert(InsertBefore(p_list, 13, 5) == DataNotFound);
	assert(InsertBefore(p_list, 19, 5) == DataNotFound);

	assert(InsertAfter(p_list, 3, 5) == SUCCESS);
	PrintList(p_list, "DSLL After InsertAfter 3 5:");
	assert(InsertBefore(p_list, 9, 5) == SUCCESS);
	PrintList(p_list, "DSLL After InsertBefore:9 5");

	assert(InsertAfter(p_list,10, 7) == SUCCESS);
	PrintList(p_list, "DSLL After InsertAfter:");
	assert(InsertBefore(p_list, 10, 7) == SUCCESS);
	PrintList(p_list, "DSLL After InsertBefore:");

	assert(GetLength(p_list) > 0);
	data = -1;
	assert(GetStart(p_list, &data) == SUCCESS);
	printf("Start Data :[%d]\n", data);
	PrintList(p_list, "DSLL After GetStart:");

	data = -1;
	assert(GetEnd(p_list, &data) == SUCCESS);
	printf("End Data :[%d]\n", data);
	PrintList(p_list, "DSLL After GetEnd:");

	data = -1;
	assert(PopStart(p_list, &data) == SUCCESS);
	printf("Poped Start Data:%d\n", data);
	PrintList(p_list, "DSLL After PopStart:");

	data = -1;
	assert(PopEnd(p_list, &data) == SUCCESS);
	printf("Poped End Data:%d\n", data);
	PrintList(p_list, "DSLL After PopEnd:");

	assert(RemoveFirst(p_list) == SUCCESS);
	PrintList(p_list, "DSLL After RemoveFirst:");

	assert(RemoveEnd(p_list) == SUCCESS);
	PrintList(p_list, "DSLL After RemoveEnd:");

	assert(RemoveFirstOccurenceOfData(p_list, -10) == DataNotFound);

	assert(RemoveFirstOccurenceOfData(p_list, 3) == SUCCESS);
	PrintList(p_list, "DSLL After RemoveFirstOccurenceOfData 3 ");

	assert(RemoveLastOccurenceOfData(p_list, 7) == SUCCESS);
	PrintList(p_list, "DSLL After RemoveLastOccurenceOfData 7 ");

	InsertBefore(p_list, 1, 7);
	InsertBefore(p_list, 5, 7);
	InsertBefore(p_list, 9, 7);
	assert(RemoveAllOccurenceOfData(p_list, 7) == SUCCESS);
	PrintList(p_list, "DSLL After RemoveAllOccurenceOfData 7 ");

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
	PrintList(p_list, "Reversed version of list with one element is same list");

	// assert(destroy_list(&p_list) == SUCCESS && p_list == NULL);
	*/
	puts("Testing inter-list routines");

	p_list_1 = CreateList();
	p_list_2 = CreateList();
	assert(IsEmpty(p_list_1) && IsEmpty(p_list_2));

	for (data = 5; data < 8; data += 1)
		assert(InsertAtEnd(p_list_1, data) == SUCCESS);

	for (data = 20; data <= 23; data += 1)
		assert(InsertAtEnd(p_list_2, data) == SUCCESS);

	PrintList(p_list_1, "p_list_1 ");
	PrintList(p_list_2, "p_list_2 ");

	assert(ConcatMutable(p_list_1, p_list_2) == SUCCESS);
	PrintList(p_list_1, "DSLL After ConcatMutable 1 ");

	ListType* list3 = ConcatImmutable(p_list_1, p_list_1);
	PrintList(list3, "DSLL After ConcatImmutable XXXX ");

	ListType*  p_list_5 = CreateList();

	for (data = 0; data <= 10; data += 1)
		assert(InsertAtEnd(p_list_5, data) == SUCCESS);

	PrintList(p_list_5, "DSLL After new p_list_5 ");

	ListType* list4 = ReverseListImmutable(p_list_5);
	PrintList(list4, "DSLL After ReverseListImmutable ");


	PrintList(list4, "DSLL Before ReverseListMutableIterative ");
	assert(ReverseListMutableIterative(list4) == SUCCESS);
	PrintList(list4, "DSLL After ReverseListMutableIterative ");

	puts("Implementation successful");

	return (EXIT_SUCCESS);
}