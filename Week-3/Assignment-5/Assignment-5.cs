int[] twoSum(int[] nums, int target) {
    Dictionary<int, int> numIndexMap = new Dictionary<int, int>();

    for (int i = 0; i < nums.Length; i++) {
        int complement = target - nums[i];

        if (numIndexMap.ContainsKey(complement)) {
            return new int[] { numIndexMap[complement], i };
        }

        numIndexMap[nums[i]] = i;
    }

    return new int[0];
}

   /*
    For example:
    twoSum([2, 7, 11, 15], 9);
    Should returns:
    [0, 1]
    Because:
    nums[0]+nums[1] is 9
   */