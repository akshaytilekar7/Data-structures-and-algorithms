#include<stdio.h>
#include<stdlib.h>

void AcceptDyanamicNumbers()
{
    int n;
    int response;
    int size = 0;
    int* p = NULL;
    while (1)
    {
        printf("enter 1 for stop : ");
        scanf("%d", &response);
        if (response == 1)
            break;
        n = response;
        p = (int*)realloc(p, (size + 1) * sizeof(int));
        p[size] = n;
        size++;
    }
    for (int i = 0; i < size; i++)
        printf("%d\n", p[i]);
}

int main()
{
    AcceptDyanamicNumbers();
    return 0;
}