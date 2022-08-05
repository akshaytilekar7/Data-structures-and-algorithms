#include<stdio.h>
#include<stdlib.h>

struct Points
{
	int x, y, z;
};

void PtrToUserDefineDataType()
{
	struct Points* ptrPoints = (struct Points*)malloc(sizeof(struct Points));

	ptrPoints->x = 10;
	ptrPoints->y = 20;
	ptrPoints->z = 30;

	printf("%d\n", ptrPoints->x);
	printf("%d\n", ptrPoints->y);
	printf("%d\n", ptrPoints->z);

	free(ptrPoints);
	ptrPoints = NULL;
}

void ArrayOfUserDefineDataType()
{
	struct Points* ptr = (struct Points*)malloc(5 * sizeof(struct Points));
	for (int i = 0; i < 5; i++)
	{
		ptr[i].x = i + 1;
		ptr[i].y = i + 2;
		ptr[i].z = i + 3;
	}

	for (int i = 0; i < 5; i++)
	{
		printf("%d\n", ptr[i].x);
		printf("%d\n", (*(ptr + i)).x);

		printf("%d\n", ptr[i].y);
		printf("%d\n", (*(ptr + i)).y);

		printf("%d\n", ptr[i].z);
		printf("%d\n", (*(ptr + i)).z);

		printf("\n");


	}
}

void ArrayOfPointerToUserDefineDataTypes()
{
	struct Points** mainPtr = (struct Points**)malloc(5 * sizeof(struct Points));

	for (int i = 0; i < 5; i++)
	{
		mainPtr[i] = (struct Points*)malloc(sizeof(struct Points));
		mainPtr[i]->x = i + 1;
		mainPtr[i]->y = i + 2;
		mainPtr[i]->z = i + 3;
	}

	for (int i = 0; i < 5; i++)
	{
		printf("%d\n", mainPtr[i]->x);
		printf("%d\n", mainPtr[i]->y);
		printf("%d\n", mainPtr[i]->z);
		printf("\n");
	}
}


int main()
{
	ArrayOfPointerToUserDefineDataTypes();
	ArrayOfUserDefineDataType();
	PtrToUserDefineDataType();
}