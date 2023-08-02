#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h> 
#include "List.h"

ListType* p_list = NULL;
dataType data;

void IsEmptyCheck()
{
	assert(IsEmpty(p_list) == TRUE);
	assert(InsertAtEnd(p_list, data) == SUCCESS);
	assert(IsEmpty(p_list) == FALSE);
}

void AddFirst_1()
{

	assert(InsertAtStart(p_list, 100) == SUCCESS);
	assert(GetStart(p_list, &data) != ListIsEmpty);
	assert(data == 100);
	assert(GetLength(p_list) == 1);
}

void AddFirst_2()
{
	assert(InsertAtStart(p_list, 100) == SUCCESS);
	assert(InsertAtStart(p_list, 200) == SUCCESS);
	assert(InsertAtEnd(p_list, 300) == SUCCESS);
	assert(GetStart(p_list, &data) != ListIsEmpty);
	assert(data == 200);
	assert(GetLength(p_list) == 3);
}

void AddLast_1()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(GetStart(p_list, &data) != ListIsEmpty);
	assert(data == 100);
	assert(GetLength(p_list) == 1);
}

void AddLast_2()
{
	assert(InsertAtStart(p_list, 100) == SUCCESS);
	assert(InsertAtStart(p_list, 200) == SUCCESS);
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	data = -1;
	assert(GetStart(p_list, &data) != ListIsEmpty);
	assert(data == 200);
	data = -1;
	assert(GetEnd(p_list, &data) != ListIsEmpty);
	assert(data == 100);
	assert(GetLength(p_list) == 3);
}

void AddLast_3()
{
	data = -1;
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(InsertAtEnd(p_list, 200) == SUCCESS);
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(GetEnd(p_list, &data) != ListIsEmpty);
	assert(data == 100);
	assert(GetLength(p_list) == 3);
}

void AddAfter_1()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	InsertAfter(p_list, 100, 150);
	assert(GetLength(p_list) == 2);
	assert(GetStart(p_list, &data) != ListIsEmpty);
	assert(data == 100);
	assert(GetEnd(p_list, &data) != ListIsEmpty);
	assert(data == 150);
	assert(IsExist(p_list, 150) == TRUE);
}

void AddAfter_2()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(InsertAtEnd(p_list, 200) == SUCCESS);

	assert(InsertAfter(p_list, 100, 150) == SUCCESS);

	assert(GetLength(p_list) == 3);

	assert(GetStart(p_list, &data) != ListIsEmpty);
	assert(data == 100);

	assert(GetEnd(p_list, &data) != ListIsEmpty);
	assert(data == 200);

	assert(IsExist(p_list, 150) == TRUE);
}

void AddBefore_1()
{
	assert(InsertAtStart(p_list, 100) == SUCCESS);

	assert(InsertBefore(p_list, 100, 50) == SUCCESS);

	assert(GetLength(p_list) == 2);

	assert(GetStart(p_list, &data) != ListIsEmpty);
	assert(data == 50);

	assert(GetEnd(p_list, &data) != ListIsEmpty);
	assert(data == 100);

	assert(IsExist(p_list, 50) == TRUE);
}

void AddBefore_2()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(InsertAtEnd(p_list, 200) == SUCCESS);

	assert(InsertBefore(p_list, 200, 150) == SUCCESS);

	assert(GetLength(p_list) == 3);

	assert(GetStart(p_list, &data) != ListIsEmpty);
	assert(data == 100);

	assert(GetEnd(p_list, &data) != ListIsEmpty);
	assert(data == 200);

	assert(IsExist(p_list, 150) == TRUE);
}

void IsExistCheck()
{
	assert(IsExist(p_list, 100) == FALSE);
	assert(GetLength(p_list) == 0);
	assert(InsertAtStart(p_list, 100) == SUCCESS);
	assert(IsExist(p_list, 100) == TRUE);
	assert(IsExist(p_list, 40) == FALSE);
	assert(GetLength(p_list) == 1);

}

void Delete_WhenEmpty()
{
	assert(RemoveFirstOccurenceOfData(p_list, 3) == DataNotFound);
	assert(GetLength(p_list) == 0);
}

void Delete_Single()
{
	assert(InsertAtEnd(p_list, 400) == SUCCESS);
	assert(GetLength(p_list) == 1);
	assert(RemoveFirstOccurenceOfData(p_list, 400) == SUCCESS);
	assert(GetLength(p_list) == 0);
}

void Delete_Last()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(InsertAtEnd(p_list, 200) == SUCCESS);
	assert(InsertAtEnd(p_list, 300) == SUCCESS);
	assert(InsertAtEnd(p_list, 400) == SUCCESS);

	assert(GetLength(p_list) == 4);

	assert(RemoveFirstOccurenceOfData(p_list, 400) == SUCCESS);

	assert(GetLength(p_list) == 3);

	assert(IsExist(p_list, 400) == FALSE);

	assert(IsExist(p_list, 100) == TRUE);
	assert(IsExist(p_list, 200) == TRUE);
	assert(IsExist(p_list, 300) == TRUE);

}

void Delete_First()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(InsertAtEnd(p_list, 200) == SUCCESS);
	assert(InsertAtEnd(p_list, 300) == SUCCESS);
	assert(InsertAtEnd(p_list, 400) == SUCCESS);

	assert(GetLength(p_list) == 4);
	assert(RemoveFirstOccurenceOfData(p_list, 100) == SUCCESS);
	assert(GetLength(p_list) == 3);

	assert(IsExist(p_list, 100) == FALSE);
	assert(IsExist(p_list, 200) == TRUE);
	assert(IsExist(p_list, 300) == TRUE);
	assert(IsExist(p_list, 400) == TRUE);
}

void Delete_MiddleSomewher()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(InsertAtEnd(p_list, 200) == SUCCESS);
	assert(InsertAtEnd(p_list, 300) == SUCCESS);
	assert(InsertAtEnd(p_list, 400) == SUCCESS);

	assert(GetLength(p_list) == 4);
	assert(RemoveFirstOccurenceOfData(p_list, 200) == SUCCESS);
	assert(GetLength(p_list) == 3);

	assert(IsExist(p_list, 200) == FALSE);
	assert(IsExist(p_list, 100) == TRUE);
	assert(IsExist(p_list, 300) == TRUE);
	assert(IsExist(p_list, 400) == TRUE);
}

void Delete_All()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(InsertAtEnd(p_list, 200) == SUCCESS);
	assert(InsertAtEnd(p_list, 300) == SUCCESS);
	assert(InsertAtEnd(p_list, 400) == SUCCESS);

	assert(GetLength(p_list) == 4);

	assert(RemoveFirstOccurenceOfData(p_list, 100) == SUCCESS);
	assert(GetLength(p_list) == 3);
	assert(RemoveFirstOccurenceOfData(p_list, 200) == SUCCESS);
	assert(GetLength(p_list) == 2);
	assert(RemoveFirstOccurenceOfData(p_list, 300) == SUCCESS);
	assert(GetLength(p_list) == 1);
	assert(RemoveFirstOccurenceOfData(p_list, 400) == SUCCESS);
	assert(GetLength(p_list) == 0);

	assert(IsExist(p_list, 100) == FALSE);
	assert(IsExist(p_list, 200) == FALSE);
	assert(IsExist(p_list, 300) == FALSE);
	assert(IsExist(p_list, 400) == FALSE);
}

void PopFirst_Empty()
{
	assert(PopStart(p_list, &data) == ListIsEmpty);
	assert(data == -1);
	assert(GetLength(p_list) == 0);
}

void PopFirst_Single()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(GetLength(p_list) == 1);
	assert(PopStart(p_list, &data) != ListIsEmpty);
	assert(data == 100);
	assert(GetLength(p_list) == 0);

}

void PopFirst_TwoNode()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(InsertAtEnd(p_list, 200) == SUCCESS);

	assert(PopStart(p_list, &data) == SUCCESS);
	assert(data == 100);
	assert(GetLength(p_list) == 1);

	assert(PopStart(p_list, &data) == SUCCESS);
	assert(data == 200);
	assert(GetLength(p_list) == 0);
}

void PopFirst_Multiple()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(InsertAtEnd(p_list, 200) == SUCCESS);
	assert(InsertAtEnd(p_list, 300) == SUCCESS);

	assert(GetLength(p_list) == 3);

	assert(PopStart(p_list, &data) == SUCCESS);
	assert(data == 100);
	assert(GetLength(p_list) == 2);

	assert(PopStart(p_list, &data) == SUCCESS);
	assert(data == 200);
	assert(GetLength(p_list) == 1);

	assert(PopStart(p_list, &data) == SUCCESS);
	assert(data == 300);
	assert(GetLength(p_list) == 0);

}

void PopLast_Empty()
{
	assert(PopEnd(p_list, &data) == ListIsEmpty);
	assert(data == -1);
	assert(GetLength(p_list) == 0);

}

void PopLast_Single()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(GetLength(p_list) == 1);
	assert(PopEnd(p_list, &data) != ListIsEmpty);
	assert(data == 100);
	assert(GetLength(p_list) == 0);
}

void PopLast_TwoNode()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(InsertAtEnd(p_list, 200) == SUCCESS);

	assert(GetLength(p_list) == 2);
	assert(PopEnd(p_list, &data) == SUCCESS);
	assert(data == 200);

	assert(GetLength(p_list) == 1);
	assert(PopEnd(p_list, &data) == SUCCESS);
	assert(data == 100);

	assert(GetLength(p_list) == 0);

}

void PopLast_Multiple()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(InsertAtEnd(p_list, 200) == SUCCESS);
	assert(InsertAtEnd(p_list, 300) == SUCCESS);

	assert(GetLength(p_list) == 3);
	assert(PopEnd(p_list, &data) == SUCCESS);
	assert(data == 300);

	assert(GetLength(p_list) == 2);
	assert(PopEnd(p_list, &data) == SUCCESS);
	assert(data == 200);

	assert(GetLength(p_list) == 1);
	assert(PopEnd(p_list, &data) == SUCCESS);
	assert(data == 100);

	assert(GetLength(p_list) == 0);
}

void GetFirst_Empty()
{
	assert(GetStart(p_list, &data) == ListIsEmpty);
	assert(GetEnd(p_list, &data) == ListIsEmpty);
}

void GetFirst_Single()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(GetLength(p_list) == 1);
	assert(GetStart(p_list, &data) == SUCCESS);
	assert(data == 100);
	assert(GetLength(p_list) == 1);
}

void GetFirst_TwoNode()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(InsertAtEnd(p_list, 200) == SUCCESS);

	assert(GetLength(p_list) == 2);
	assert(GetStart(p_list, &data) == SUCCESS);
	assert(data == 100);

	assert(GetLength(p_list) == 2);
	assert(GetStart(p_list, &data) == SUCCESS);
	assert(data == 100);

	assert(GetLength(p_list) == 2);
}

void GetFirst_Multiple()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(InsertAtEnd(p_list, 200) == SUCCESS);
	assert(InsertAtEnd(p_list, 300) == SUCCESS);

	assert(GetLength(p_list) == 3);
	assert(GetStart(p_list, &data) == SUCCESS);
	assert(data == 100);

	assert(GetLength(p_list) == 3);
	assert(GetStart(p_list, &data) == SUCCESS);
	assert(data == 100);

	assert(GetLength(p_list) == 3);
	assert(GetStart(p_list, &data) == SUCCESS);
	assert(data == 100);

	assert(GetLength(p_list) == 3);

}

void GetLast_Empty()
{
	assert(GetEnd(p_list, &data) == ListIsEmpty);
	assert(GetStart(p_list, &data) == ListIsEmpty);
}

void GetLast_Single()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);

	assert(GetLength(p_list) == 1);
	assert(GetEnd(p_list, &data) == SUCCESS);
	assert(data == 100);
	assert(GetLength(p_list) == 1);
}

void GetLast_TwoNode()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(InsertAtEnd(p_list, 200) == SUCCESS);

	assert(GetLength(p_list) == 2);
	assert(GetEnd(p_list, &data) == SUCCESS);
	assert(data == 200);

	assert(GetLength(p_list) == 2);
	assert(GetEnd(p_list, &data) == SUCCESS);
	assert(data == 200);

	assert(GetLength(p_list) == 2);
}

void GetLast_Multiple()
{
	assert(InsertAtEnd(p_list, 100) == SUCCESS);
	assert(InsertAtEnd(p_list, 200) == SUCCESS);
	assert(InsertAtEnd(p_list, 300) == SUCCESS);

	assert(GetLength(p_list) == 3);
	assert(GetEnd(p_list, &data) == SUCCESS);
	assert(data == 300);

	assert(GetLength(p_list) == 3);
	assert(GetEnd(p_list, &data) == SUCCESS);
	assert(data == 300);

	assert(GetLength(p_list) == 3);
	assert(GetEnd(p_list, &data) == SUCCESS);
	assert(data == 300);

	assert(GetLength(p_list) == 3);
}

int main(void)
{
	puts("[ dcll test case started ]");

	data = -1;
	p_list = CreateList();
	IsEmptyCheck();

	data = -1;
	p_list = CreateList();
	AddFirst_1();

	data = -1;
	p_list = CreateList();
	AddFirst_2();

	data = -1;
	p_list = CreateList();
	AddLast_1();

	data = -1;
	p_list = CreateList();
	AddLast_2();

	data = -1;
	p_list = CreateList();
	AddLast_3();

	data = -1;
	p_list = CreateList();
	AddAfter_1();

	data = -1;
	p_list = CreateList();
	AddAfter_2();

	data = -1;
	p_list = CreateList();
	AddBefore_1();

	data = -1;
	p_list = CreateList();
	AddBefore_2();

	data = -1;
	p_list = CreateList();
	IsExistCheck();

	data = -1;
	p_list = CreateList();
	Delete_WhenEmpty();

	data = -1;
	p_list = CreateList();
	Delete_Single();

	data = -1;
	p_list = CreateList();
	Delete_Last();

	data = -1;
	p_list = CreateList();
	Delete_First();

	data = -1;
	p_list = CreateList();
	Delete_MiddleSomewher();

	data = -1;
	p_list = CreateList();
	PopFirst_Empty();

	data = -1;
	p_list = CreateList();
	PopFirst_Single();

	data = -1;
	p_list = CreateList();
	PopFirst_TwoNode();

	data = -1;
	p_list = CreateList();
	PopFirst_Multiple();

	data = -1;
	p_list = CreateList();
	PopLast_Empty();

	data = -1;
	p_list = CreateList();
	PopLast_Single();

	data = -1;
	p_list = CreateList();
	PopLast_TwoNode();

	data = -1;
	p_list = CreateList();
	GetFirst_Empty();

	data = -1;
	p_list = CreateList();
	GetFirst_Single();

	data = -1;
	p_list = CreateList();
	GetFirst_TwoNode();

	data = -1;
	p_list = CreateList();
	GetFirst_Multiple();

	data = -1;
	p_list = CreateList();
	GetLast_Empty();

	data = -1;
	p_list = CreateList();
	GetLast_Single();

	data = -1;
	p_list = CreateList();
	GetLast_TwoNode();

	data = -1;
	p_list = CreateList();
	GetLast_Multiple();

	puts("[ all dcll test cases run successfully ]");

}
