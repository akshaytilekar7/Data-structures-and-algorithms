/*
A]
	[1,4] consists of 1,2,3,4.
		= 4 - 1 + 1 => 4

	(1,4) consists of 2,3.
		= 4 - 1 - 1 =>  2

	(1,4], consisting of 2,3,4.
		= 4 - 1

	[1,4), consisting of 1,2,3.
		= 4 - 1

		[a,b] = b - a + 1
		(a,b) = b - a - 1
		(a,b] = b - a
		[a,b) = b - a

	mid logic
		int size1 = mid - 1 + 1;
		int size2 = size - mid ;

	[a,b] = b - a + 1
	(a,b) = b - a - 1
	(a,b] = b - a
	[a,b) = b - a

B]

	MergeSort
		-	based on divide and conquer
		-	foundation logic
			-	divide array into 2 parts untils its undividable ( means subarray size 1 ) => Merge function
			-	sort 2 single element array into one sorted array => MergeProcedure function

		-	Merge(int arr[], int start, int end)
				-	input	-	array, start, end
				-	output	-	 
		-	MergeProcedure(int arr[], int start, int mid, int end)
				-	input 2 sorted array 
				-	output single sorted array
*/