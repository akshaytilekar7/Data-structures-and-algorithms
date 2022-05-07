#include<stdio.h>
#include<stdlib.h>
#include <string.h>
#include <stdbool.h>
#include <string.h>
#define _CRT_SECURE_NO_DEPRECATE
#pragma warning (disable : 4996)
#define BUFFER_MAX_LENGTH 1024

struct WordInfo
{
	char* Word;
	int LineNumber;
	int WordNumber;
};

struct FileInfo
{
	char* FileName;
	struct WordInfo** WordInfoArray;
	int SizeOfWordInfo;
};

struct MetaDataFileInfo
{
	struct FileInfo** FileInfoArray;
	int SizeOfFileInfo;
};

void SetFileInfoInMetaDataFileInfo(int argc, char* argv[], struct MetaDataFileInfo** ptrToMetaDataFileInfo)
{
	int size = argc - 1;
	(*ptrToMetaDataFileInfo)->SizeOfFileInfo = size;
	(*ptrToMetaDataFileInfo)->FileInfoArray = (struct FileInfo**)malloc(size * sizeof(struct FileInfo*));
	for (int i = 1; i < argc; i++)
	{
		//printf("file name is %s\n", argv[i]);
		(*ptrToMetaDataFileInfo)->FileInfoArray[i - 1] = (struct FileInfo*)malloc(sizeof(struct FileInfo));
		(*ptrToMetaDataFileInfo)->FileInfoArray[i - 1]->FileName = argv[i];
	}
}

void SetWordInfoFileByFile(struct FileInfo** fileInfo)
{
	(*fileInfo)->WordInfoArray = (struct WordInfo**)malloc(sizeof(struct WordInfo*));
	(*fileInfo)->SizeOfWordInfo = 0;

	char* temp = (*fileInfo)->FileName;
	char* full_name = "D:\\Akshay\\C-DSA\\C-DSA\\" + (*temp);
	FILE* file = fopen(temp, "r");

	if (file == NULL)
		return;

	char c;
	int n = 0;
	char* code = malloc(1024);
	int lineNumber = 1;
	int wordCount = 0;
	int Index = 0;

	while ((c = fgetc(file)) != EOF)
	{
		if (c == ' ' || c == '\n')
		{
			wordCount++;
			code[n + 1] = '\0';
			(*fileInfo)->WordInfoArray[Index] = (struct WordInfo*)malloc(sizeof(struct WordInfo));
			(*fileInfo)->WordInfoArray[Index]->LineNumber = lineNumber;
			(*fileInfo)->WordInfoArray[Index]->WordNumber = wordCount;
			(*fileInfo)->WordInfoArray[Index]->Word = code;
			((*fileInfo)->SizeOfWordInfo) = wordCount;
			n = 0;
			Index++;
			code = NULL;
			code = malloc(1024);
			memset(code, 0, sizeof code);
			if (c == '\n')
			{
				lineNumber++;
				// wordCount = 0;
			}
		}
		else
		{
			code[n++] = c;
		}
	}
	// TODOL move to helper function
	wordCount++;
	code[n + 1] = '\0';
	(*fileInfo)->WordInfoArray[Index] = (struct WordInfo*)malloc(sizeof(struct WordInfo));
	(*fileInfo)->WordInfoArray[Index]->LineNumber = lineNumber;
	(*fileInfo)->WordInfoArray[Index]->WordNumber = wordCount;
	(*fileInfo)->WordInfoArray[Index]->Word = code;
	((*fileInfo)->SizeOfWordInfo) = wordCount;
	n = 0;
	Index++;
	//
}

void SetWordInfo(struct MetaDataFileInfo** ptrToMetaDataFileInfo)
{
	int sizeOfFileInfo = (*ptrToMetaDataFileInfo)->SizeOfFileInfo;
	for (int i = 0; i < sizeOfFileInfo; i++)
		SetWordInfoFileByFile(&(*ptrToMetaDataFileInfo)->FileInfoArray[i]);
}

void PrintMetaDataFileInfo(struct MetaDataFileInfo** ptrToMetaDataFileInfo)
{
	printf("file count is : %d\n", (*ptrToMetaDataFileInfo)->SizeOfFileInfo);

	for (int i = 0; i < (*ptrToMetaDataFileInfo)->SizeOfFileInfo; i++)
	{
		printf("file name : %s\t", (*ptrToMetaDataFileInfo)->FileInfoArray[i]->FileName);
		printf("and word count : %d\n", (*ptrToMetaDataFileInfo)->FileInfoArray[i]->SizeOfWordInfo);

		for (int j = 0; j < (*ptrToMetaDataFileInfo)->FileInfoArray[i]->SizeOfWordInfo; j++)
		{
			printf("%d : ", (*ptrToMetaDataFileInfo)->FileInfoArray[i]->WordInfoArray[j]->LineNumber);
			printf("%s\n", (*ptrToMetaDataFileInfo)->FileInfoArray[i]->WordInfoArray[j]->Word);
		}
	}
}

void SearchWord(struct MetaDataFileInfo** ptrToMetaDataFileInfo, char* word)
{
	printf("\nSearch result \n");
	printf("Word: %s \n", word);
	for (int i = 0; i < (*ptrToMetaDataFileInfo)->SizeOfFileInfo; i++)
	{
		printf("\tfile name : %s\n", (*ptrToMetaDataFileInfo)->FileInfoArray[i]->FileName);
		for (int j = 0; j < (*ptrToMetaDataFileInfo)->FileInfoArray[i]->SizeOfWordInfo; j++)
		{
			char* fileWord = (*ptrToMetaDataFileInfo)->FileInfoArray[i]->WordInfoArray[j]->Word;
			if (strcmp(fileWord, word) == 0)
			{
				printf("\t\tLine Number: %d \t Word Number: %d \n", (*ptrToMetaDataFileInfo)->FileInfoArray[i]->WordInfoArray[j]->LineNumber, (*ptrToMetaDataFileInfo)->FileInfoArray[i]->WordInfoArray[j]->WordNumber);
			}
		}
		printf("\n");
	}
	printf("\n\n\n");
}

int main(int argc, char* argv1[])
{
	argc = 3;
	char* argv[] = { "a", "Yash.txt", "Akshay.txt" };

	puts("aa");

	struct MetaDataFileInfo* ptrToMetaDataFileInfo = (struct MetaDataFileInfo*)malloc(sizeof(struct MetaDataFileInfo));

	SetFileInfoInMetaDataFileInfo(argc, argv, &ptrToMetaDataFileInfo);

	SetWordInfo(&ptrToMetaDataFileInfo);

	// print line by line
	// PrintMetaDataFileInfo(&ptrToMetaDataFileInfo);

	char* search = NULL;

	SearchWord(&ptrToMetaDataFileInfo, "akshay");

	printf("\n ---SUCESSS---");
}
