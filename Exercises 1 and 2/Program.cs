//Exercise 1
int Solution (int[] numbers) {
    int small = numbers[0]; // This is the edited line
    for (int i = 1; i < numbers.Length; i++) {
        if (numbers[i] < small) {
            small = numbers[i];
        }
    }
    return small;
}

//Exercise 2
int PowerSum (int X, int N) {
    return X is >= 1 and <= 1000 && N is >= 2 and <= 10 ? RecPowerSum(X, N, 1, 0) : -1;
}

int RecPowerSum (int X, int N, int b, int sum) {
    int cur = (int)Math.Pow(b, N);
    if (sum > X || cur > X)
        return 0;
    if ((sum + cur) == X)
        return 1;
    return RecPowerSum(X, N, b + 1, (sum + cur)) + RecPowerSum(X, N, b + 1, sum);
}

Console.WriteLine($"Exercise 1 {Solution(new int[]{-1, 1, -2, 2})}");
Console.WriteLine($"Exercise 2 {PowerSum(10, 2)}");