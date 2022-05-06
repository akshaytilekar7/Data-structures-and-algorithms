#include<stdio.h>
#include<stdlib.h>
#include <string.h>
#include <stdbool.h>

struct WordInfo
{
	char* word;
	int LineNumber;
	int WordNumber;
};

struct FileInfo
{
	char* FileName;
	struct WordInfo* WordInfo;
	int CharactersCount;
	int WordCount;
	int LineCount;
	int Size;
};

struct ListFileInfo
{
	struct FileInfo* FileInfo;
	int Size;
};

int main(int argc, char* argv[])
{
	if (argc < 2)
	{
		puts("not valid input");
		return (EXIT_FAILURE);
	}

	struct ListFileInfo** ptrToListFileInfo = (struct ListFileInfo**)malloc(argc * sizeof(struct ListFileInfo*));
	puts("struct ListFileInfo** ptrToListFileInf");

	for (int i = 1; i < argc; i++)
	{
		puts("for loop");
		ptrToListFileInfo[i] = (struct ListFileInfo*)malloc(sizeof(struct ListFileInfo));
		ptrToListFileInfo[i]->FileInfo = (struct FileInfo*)malloc(sizeof(struct FileInfo));
		ptrToListFileInfo[i]->FileInfo->FileName = argv[i];

		FILE* file = fopen(ptrToListFileInfo[i]->FileInfo->FileName, "r");
		char ch;
		if (file == NULL)
		{
			printf("\nUnable to open file.\n");
			printf("Please check if file exists and you have read privilege.\n");
			exit(EXIT_FAILURE);
		}

		char tempCh[1024];
		int tempCount = 0;
		bool isOtherThanChar = false;
		puts("while start");

		while ((ch = fgetc(file)) != EOF)
		{
			ptrToListFileInfo[i]->FileInfo->CharactersCount++;

			if (ch == '\n' || ch == '\0')
			{
				isOtherThanChar = true;
				ptrToListFileInfo[i]->FileInfo->LineCount++;
			}
			if (ch == ' ' || ch == '\t' || ch == '\n' || ch == '\0')
			{
				isOtherThanChar = true;
				ptrToListFileInfo[i]->FileInfo->WordCount++;
			}
			else
			{
				for (int x = 0; x < tempCount; x++)
				{
					ptrToListFileInfo[i]->FileInfo->WordInfo = (struct WordInfo*)malloc(sizeof(struct WordInfo));
					memcpy(ptrToListFileInfo[i]->FileInfo->WordInfo->word, &tempCh[1024], tempCount + 1);
				}
				tempCh[tempCount + 1] = '\0';
				tempCount = 0;
			}

			if (isOtherThanChar == true) {
				tempCh[tempCount] = ch;
				tempCount++;
				isOtherThanChar = false;
			}

			if (ptrToListFileInfo[i]->FileInfo->CharactersCount > 0)
			{
				ptrToListFileInfo[i]->FileInfo->WordCount++;
				ptrToListFileInfo[i]->FileInfo->LineCount++;
			}
		}
		printf("%d", ptrToListFileInfo[i]->FileInfo->FileName);
		printf("%d", ptrToListFileInfo[i]->FileInfo->LineCount);
		printf("%d", ptrToListFileInfo[i]->FileInfo->CharactersCount);

		puts("while end");

	}

	puts("EXIT_SUCCESS");

	return(0);
}
