#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>

struct Node {
	int Data;
	struct Node* Next;
	struct Node* Prev;
};

/*

	A.	LL should be of any data type
	B.	It should provied functionality like

			// add last
			// otherwise -1
		1	int Add(Type * head, Type data) 

			//	insert at given position
			// otherwise return -1
		2	int InsertAtPosition(Type * head,int position, Type data)

			//	UpdateAt at given pos
			// otherwise return -1
		3	int UpdateAt(Type * head,int position, Type data)

			//	Update first occurence
			//  otherwise return -1
		4	int UpdateFirst(Type * head,Type old,Type new)

			//	Update last occurence
			//  otherwise return -1
		5	int Updatelast(Type * head,Type old,Type new)

			//	Update all occurence
			//  otherwise return -1
		6	int UpdateAll(Type * head,Type old,Type new)

			//	remove at given position
			//  otherwise return -1
		7	int RemoveAt(Type * head,int position)

			//	remove at elements
			//  otherwise return -1
		8	int RemoveAll(Type * head)

			//	remove all given elements occurences
			//  otherwise return -1
		9	int RemoveAll(Type * head,Type data)

			//	remove first given elements occurences
			//  otherwise return -1
		10	int RemoveFirst(Type * head,Type data)

			//	remove last given elements occurences
			//  otherwise return -1
		11	int RemoveLast(Type * head,Type data)

			// if exist true
			// otherwise false
		12	bool IsExist(Type * head,Type data)
		13	bool IsNull(Type * head)

		14	void Print(Type * head)
		15	void PrintReverse(Type * head)

		16	void Free(Type * head)

*/

int main(int argc, char* argv[])
{
	return 0;
}