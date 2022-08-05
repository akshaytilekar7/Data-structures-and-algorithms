#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>

void input(int* a, int N); 
void output(int* a, int N, const char* msg);
void sort(int* a, int N); 

int main(int argc, char* argv[])
{
    int* a = NULL; 
    int N = 0; 

    if(argc != 2)
    {
        fprintf(stderr, "Usage Error: Correct Usage %s nr_elements", argv[0]); 
        exit(EXIT_FAILURE); 
    }

    N = atoi(argv[1]); 
    assert(N > 0); 

    a = (int*)malloc(N * sizeof(int)); 
    assert(a != NULL); 

    input(a, N); 
    output(a, N, "Before sort:"); 
    sort(a, N); 
    output(a, N, "After sort:"); 

    free(a); 
    a = NULL; 

    return (EXIT_SUCCESS); 
}

void input(int* a, int N)
{
    int i; 

    for(i = 0; i < N; ++i)
        a[i] = rand();
} 

void output(int* a, int N, const char* msg)
{
    int i; 

    if(msg)
        puts(msg); 

    for(i = 0; i < N; ++i)
        printf("a[%d]:%d\n", i, a[i]); 
}

void sort(int* a, int N)
{

}