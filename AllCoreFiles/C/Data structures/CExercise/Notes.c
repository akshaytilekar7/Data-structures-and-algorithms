// 073_Akshay_Tilekar

/*

 x << y		(where y is - number of places to shift )
	-	multiplying x with 2^y (2 raised to power y).

 x >> y		(where y is - number of places to shift )
	-	dividing x with 2^y.


 Example  1 << 3
				=> 1 * (2^3)
				=> 1 * (2 * 2 * 2)
				=> 8


		Create Node of each vertices
		and append each ADJECENT node (same as 2D array)

		S[even] + S[odd] = 2 * no_of_people
		S[odd] = 2 * no_of_people - S[even];
		S[odd] = EVEN

		S[even] + S[odd] = 2 * no_of_people
		S[even] = (2 * no_of_people) - s[odd];
		s[even] = even - odd;
		s[even] = odd;



		G = (V,E) is connected components of graph because there is NOT exist any path from Vi to Vj
			and there is exist some vertices such that Vk whoes Vk-1 is not same as Vk+1



		G = (V,E) is graph having vertices can have the most 2 edges and no cycle exist

*/


Insert(bst, data)
{
	if (bst == NULL)
	{
		bst.data = data;
		return
	}

	if (bst.data <= data)
		Insert(bst->left, data)

		if (bst.data >= data)
			Insert(bst->right, data)
}

Proorder(bst)
{
	print(bst->data);


}

Max(bst, )
{

}