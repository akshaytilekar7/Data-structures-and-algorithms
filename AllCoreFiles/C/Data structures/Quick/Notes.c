/*
	Foundation
		-	 we consider last element is pivot
			-	means first we place pivot (last element) in its final place such that
				start <= pivot < end

				arr  6 7 2 95 45 9

				ex : 9 is pivot
					-	2 7 6 [9] 95 45
						=> [9] is at right place as smaller elements are to the left
							greater elemets are to the right

		-	 in each leval Pivot element is at approprate/final place

		-	psudo code
		-	QuickSort(arr, start, end)
				int partitionIndex = Partition(arr, start, end);
				QuickSort(arr, start, partitionIndex - 1)
				QuickSort(arr, partitionIndex + 1, end)

			-	partitionIndex - 1
			-	partitionIndex + 1
				Coz - we are not cosiderting partitionIndex again as element is already at correct place

		-	int Partition(arr[], start, end)
				pivot = arr[end];
				partitionIndex = start;
					for (int i = start; i < end; i++)
					{
						if (arr[i] <= pivot)
						{
							Swap(&arr, i, partitionIndex);
							partitionIndex++;
						}
					}
				Swap(&arr, partitionIndex, end);
				return partitionIndex;

		-	to fast and elegant
}
*/