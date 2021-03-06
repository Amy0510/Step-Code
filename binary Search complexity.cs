#include <iostream>
//Binary Search through recursion
int binarysearch(int* a, int l, int r, int x) {
if (l > r) return -1;
int m = (r + l) / 2;
if (a[m] == x) return m;
else if (a[m] < x) return binarysearch(a, m + 1, r, x);
else return binarysearch(a, l, m - 1, x);
}

int main()
{
int n, x;
scanf_s("%d %d", &n, &x);
int* a = new int[n];
for (int i = 0; i < n; i++) {
scanf_s("%d", &a[i]);
}
printf("\n%d", binarysearch(a, 0, n, x));
delete[] a;


}
