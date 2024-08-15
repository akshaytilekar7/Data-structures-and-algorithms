namespace Stack;

public class SlidingWindow
{
    public static List<int> MaxSlidingWindow(int[] nums, int k)
    {
        List<int> result = new List<int>();
        if (nums == null || nums.Length == 0 || k <= 0)
            return result;

        LinkedList<int> list = new LinkedList<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (list.Count > 0 && list.First.Value < i - k + 1)
                list.RemoveFirst();

            while (list.Count > 0 && nums[list.Last.Value] < nums[i])
                list.RemoveLast();

            list.AddLast(i);

            if (i >= k - 1)
                result.Add(nums[list.First.Value]);
        }

        return result;
    }
}
