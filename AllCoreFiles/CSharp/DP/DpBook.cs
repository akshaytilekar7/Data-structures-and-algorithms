/*

recusrive and non recursive
    -  if both are easy and taking equal time to execute     
        then non recursive takes less memory and less time to execute
    -   Recursion is just replacement for loop int the form of iterative solution
    
Memory allocation
    1.  Code (Text)
        -   machine code
        -   read only and cant change when program is executing
        -   may be shareable
        -   size is fixed at load time
    2.  Data        
        -   global and static data
        -   memory is allocated before program load ie, before call to main(),
            so they called at load time variable
        -   if no value then 0 by default
        -   internally divide into 2 part
            initilized
            un-initilized 
            -   separate becoz un-initilized can set to zero in single opeartion 
        -   size is fixed at load time and wont change at runtime
    3.  Stack
        -   contain activation record (stack frames) of an all active funtion
        -   when fun called
            -   activation record is created and push on top of stack
            -   funtion returns then activation record is poped from stack
            -   non static local variable of function are allocated 
                MEMORY INSIDE activation record of function
            -   variable allocated inside memory of stack are not initilized by default
            -   if not initlized then garbage value
            -   SP register keeps the track of top of stack
    4.  Heap 
            -   dyanamic / runtime memory. malloc/calloc/realloc
            -   Heap and Stack segment share common area and grows toward each other
        

*/ 