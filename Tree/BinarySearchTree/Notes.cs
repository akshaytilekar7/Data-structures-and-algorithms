/*

Tree
    number of nodes = edges + 1  // as there is no cycle in tree
    

Key thing : 
    Diameter at each node is defined by 1 + leftHeight + rightHeight.
    Just calculate that at each node to get the maximum diameter.
    Hence use the height method and just add the 
    line to calculate the diameter which gives the O(N) solution.

Code : 
    int diameter = 0;
    int height(Node root){
        if(root== null)
            return 0;
        int lh = height(root.left);
        int rh = height(root.right);
        diameter = Math.max(diameter, 1 + lh + rh);
        reurn 1 + Math.max(lh, rh);
    }


 
*/ 