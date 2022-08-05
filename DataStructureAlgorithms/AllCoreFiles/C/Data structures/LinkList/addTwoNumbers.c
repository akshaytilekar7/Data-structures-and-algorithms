struct ListNode* Add(struct ListNode* head, int data)
{
	struct ListNode* temp = (struct ListNode*)malloc(sizeof(struct ListNode));
	temp->val = data;
	temp->next = NULL;

	if (head == NULL)
	{
		head = (struct ListNode*)malloc(sizeof(struct ListNode));
		head->val = data;
		head->next = NULL;
	}
	else
	{
		struct ListNode* traverse = head;
		while (traverse->next != NULL)
		{
			traverse = traverse->next;
		}
		traverse->next = temp;
	}
	return head;
}


struct ListNode* addTwoNumbers(struct ListNode* l1, struct ListNode* l2)
{
	struct ListNode* t1 = l1;
	struct ListNode* t2 = l2;
	int* arr1 = (int*)calloc(100, sizeof(int));
	int* arr2 = (int*)calloc(100, sizeof(int));
	int* arr3 = (int*)calloc(100, sizeof(int));
	int cnt1 = 0;
	int cnt2 = 0;
	int sumPerNode = 0;
	int reminderPerNode = 0;
	int size = 0;
	while (t1 != NULL && t2 != NULL)
	{
		arr1[cnt1] = t1->val;
		arr2[cnt2] = t2->val;
		t1 = t1->next;
		t2 = t2->next;
		sumPerNode = reminderPerNode + arr1[cnt1] + arr2[cnt2];
		reminderPerNode = 0;
		if (sumPerNode >= 10)
		{
			reminderPerNode = (sumPerNode / 10);
			sumPerNode = sumPerNode % 10;
			arr3[size++] = sumPerNode;
		}
		else {
			arr3[size++] = sumPerNode;
		}
		cnt1++;
		cnt2++;
	}
	while (t1 != NULL)
	{
		arr1[cnt1] = t1->val;
		t1 = t1->next;
		sumPerNode = reminderPerNode + arr1[cnt1];
		reminderPerNode = 0;
		if (sumPerNode >= 10)
		{
			reminderPerNode = (sumPerNode / 10);
			sumPerNode = sumPerNode % 10;
			arr3[size++] = sumPerNode;
		}
		else {
			arr3[size++] = sumPerNode;
		}
		cnt1++;
	}
	while (t2 != NULL)
	{
		arr2[cnt2] = t2->val;
		t2 = t2->next;
		sumPerNode = reminderPerNode + arr2[cnt2];
		reminderPerNode = 0;
		if (sumPerNode >= 10)
		{
			reminderPerNode = (sumPerNode / 10);
			sumPerNode = sumPerNode % 10;
			arr3[size++] = sumPerNode;
		}
		else {
			arr3[size++] = sumPerNode;
		}
		cnt2++;
	}
	if (reminderPerNode != 0)
		arr3[size++] = reminderPerNode;
	struct ListNode* finalLL = NULL;
	for (int i = 0; i < size; i++)
		finalLL = Add(finalLL, arr3[i]);
	return finalLL;
}