/*

Data Structres
	-	Arrangement of multiple anonymous instance of given data type that allows 
		computations of base address of every instance possible from the one named instance and properties of arragement

		namespace pollution
			-	to many variable in a class
			-	solu - we want multiple data bit only one named to it

		named data 
			-	int n

		anonymoues data
			-	language provide basis to allocate anonymoues memory 
			-	in C its malloc()

		Collection of T
			-	multiple anonyouse instances of T considered togethere
		
		"a data structure property" 
			-	if we can reach or know the base address of each instance of collection 
				from the one name instance
			-	we understand that randomly created collection of T will not automatically have a data strcuture property
			-	if adopting a certain rule/strategy while allocation colletion T, 
				allows collection T to have a "data structure property"
				then that rule/rule set/ startegy is known as DATA Structure

				P + (i * sizeof(T)) where i = 0, and N -1
		
		-	why we need a different DSA
			-	No existing data dtrcuture provide a way te read/acccess as much as I want 

		Algorithm types
			type 1  -   only on one instance - file structre - zip
			
			type 2	-	collection of T - add in tree / remove in tree
					-	time complexity of colletion algorithm directly a consequence of data structure


			-	No existing data dtrcuture provide a way te read/acccess as much as I want 
				-	so we need a new data structure
			-	There might be new algo in town where implementation require totally different arrangement

Day 2	-	
	
		-   STL = forwardList use SLL
		-	but STL = DLL anu build in List is DLL

*/


