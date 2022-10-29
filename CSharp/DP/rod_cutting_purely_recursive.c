#include <stdio.h> 
#include <stdlib.h> 
#include <time.h> 

typedef unsigned long long int u64; 

void build_p(); 
u64 compute_r(u64 N); 

u64* pa = NULL;
u64 N = 0; 
u64 paN = 0; 
u64 rs = 0; 

int main(int argc, char* argv[])
{
    u64 i; 

    if(argc != 2)
    {
        fprintf(stderr, "Usage Error: %s Positive_Integer\n", argv[0]); 
        exit(EXIT_SUCCESS); 
    }

    N = atoll(argv[1]); 
    paN = N + 1; 
    build_p(); 
    

    puts("Showing p:"); 
    for(i = 1; i < paN; ++i)
        printf("pa[%llu]:%llu\n", i, pa[i]); 

    time_t start, end, delta; 
    
    for(i = 1; i < paN; ++i)
    {
        start = time(0);
        rs = 0; 
        rs = compute_r(i); 
        end = time(0); 
        delta = end - start; 
        printf("r[%llu]:%llu\n", i, rs); 
        printf("Time required to compute r[%llu]:%lld\n", i, delta); 
    }
    
    free(pa); 
    pa = NULL; 

    return (0); 
}

void build_p(void)
{
    u64 i; 
    
    pa = (u64*)calloc(paN, sizeof(u64)); 
    if(pa == NULL)
    {
        fprintf(stderr, "fatal:error in allocating memory\n"); 
        exit(EXIT_FAILURE); 
    }

    for(i = 1; i < paN; ++i)
    {
        if(i % 2 == 0)
        {
            pa[i] = 2*i + 1; 
        }
        else 
        {
            pa[i] = 2*i - 2; 
        }
    }   
}

u64 compute_r(u64 N)
{
    u64 i; 
    u64 rN = pa[N]; 
    u64 ri = 0; 

    if(N == 1)
        return pa[1]; 

    for(i = 1; i < N/2; ++i)
    {
        ri = compute_r(i) + compute_r(N-i); 
        if(ri > rN)
            rN = ri; 
    }

    return (rN); 
}
