/*
 
 Recursion
    -   space complexity is more as compared to iteration approch as function call in stack
    -   fib(n) = fib(n-1) + fib(n-2) // this is known as Recurrence relation

    -   Tail Recursion
        -   last line of methos is function call
            {
            
                Fun(x);
            }
        -   Not a tail recursion
            {
            
                return Fun(x) + Fun(x-1); // call Fun with x then Fun with x-1 then returns the addition of result
            }

 */ 