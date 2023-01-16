/*
 

    Bubble sort 
        -   each pair of adjacent elements is compared and swapped if they are not in order
        -   first (0,1) then (1,2) then (2,3) then (3,4) then (4,5) 
        -   arr[0] > arr[1] SWAP else do nothing ie (arr[j] < arr[j+1])
        -   after one iteration largest elemenet bubbles up last position
        -   at each iteration one element is in its correct position
        -   after 2 iteration 2 element will be in its correct position
        -   FOR N ITERATION WE NEED N - 1 ITERATION
        
           
        
            78        55        45        98        13       // original


           [78        55]       45        98        13       // 78 > 55 YES so swap 

            55       [78        45]       98        13       // 78 > 45 YWA so swap 

            55        45       [78        98]       13       // 78 > 98 NO, so no swap

            55        45        78       [98        13]      // 98 > 13 so swap

            55        45        78        13        98       // After 1st iteration


          [55        45]       78        13        98       // 55 > 45

           45       [55        78]       13        98       // 78 > 45 No - no swap

           55        45       [78        13]       98       // 78 > 13 

           55        45       13        [78        98]      // 78 > 98 No -no swap

           55        45       78        13         98       // After 2nd Iteration


    
*/