/*

    SLL
        -  only next pointer and no baclword and NO circular
            
    SCLL
     -  worst LL as dosen't add any advantages
     -  one adv - from last node we can easily go to first node
     -  but its useless as we already have an pointer on first node

    DLL
       -   move forword and backword
    DCLL 
        -  BEST move forword and backword + circular



SLL
    var traverse = linkList.Next;
    while(traverse != null)

    for PopLast
        while (traverse.Next != null) // travel to 2nd last node // IMP

    GenericInsert 3 parameter
    GenericDelelet 1 parapter : previousNode

DLL
    var traverse = linkList.Next;
    while(traverse != null)

    GenericInsert 3 parameter
    GenericDelelet 1 parapter : deleteNode



SCLL / DCLL
    var traverse = linkList.Next;
    while(traverse != linkList)



*/