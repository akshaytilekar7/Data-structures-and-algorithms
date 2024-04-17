/*


Binary Search Trees BST 
    -   Tree is a graph, directed with no cycle
    -   MOST IMP FOR INTERVIEW
    -   Why to used - Insert/Delete/Search -> O (log n)
    -   Left smaller and right bigger elements -> so Order storage
    -   Cost efficient -> no restrucure when add or remove 
    -   Limitation
        -   Unbalance BST - insert find delete -> O n
        -   because difference in H(RST) - H(LST) > 1 
        -   means inefficient for sorted data 
    -   Example - File System, Database, Network Routing
                  Traverser used in maths, Expression in C#, LINQ
                  Compression of files, Heap used BST,   
    -   Size - Total number of nodes
    -   Child paretn
    -   Sibling - same parent
    -   Height - MAX number of edges between 2 nodes Ex - Root to node or node to node
    -   Leaf - bottom most nodes
    -   Leval   -   difference of H 
                -   Leval of root is always 0 => H(root) - H(node) = 0
                -       
    -   Ancestor and descendant
    -   Types
            -   Complete BST
                -   all leval are full 
                -   except last leval but when fill it left to right
            -   Full/Strict BST
                -   Each node either 0 or 2 children
                -   used in compression huffman 
            -   Perfect BST
                -   all levals are fulled
                -   simple perfect Trangle like Piryamid
            -   Height Balance Tree  - avg H O (log n)
            -   skewed BST - each node has only 1 child - same like LL
            -   Order BST - every node has some property
                          - BST - left smaller and right bigger


    -   Perfect BST 
        -   Total Node = [2 ^ (Height + 1)] - 1
            How

                    A                        2 ^ 0   => 1
                B       C                    2 ^ 1   => 2
            D     E       F     G            2 ^ 2   => 4
          H  I  J  K     L M   N  O          2 ^ 34  => 8 ...16..32

        -   (2^0) + (2^1) + (2^2) + (2^3) +.... + (2^H) => Gometric progression
        -    equvivalant to  [2 ^ (Height + 1)] - 1
        -    Leaf node in BST => 2 ^ height
        -    Internal node => [2^(h+1)-1] - (2^h) = 2^h - 1
    -   Strict BST , either 0 or 2
        -   Total nodes with N leaf node
        -   Total number of internal node => N -1
        -   no of LEAF node => number of internal node + 1
        -   No of leaf node = 1 + number of internal node with 2 children (not including root node)


    -   BST implmentation
        -   linked reporesentation
        -   using array - used in Complete BST (means heaps) / segment tree
        
        
*/ 