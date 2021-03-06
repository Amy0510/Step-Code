#include <iostream>
using namespace std;

void quicksort(int* arr, int l, int r) {
printf("%d  %d\n", l, r);
if (l >= r) return;
int begl = l;
int begr = r;
l++;
while (l < r) {
if (arr[l] > arr[begl]) {
swap(arr[l], arr[r]);
r--;
}
else l++;

for (int i = begl; i <= begr; i++) {
printf("%d, ", arr[i]);
}
printf("\n");
}
if(arr[l] > arr[begl]) swap(arr[begl], arr[l-1]);
else swap(arr[begl], arr[l]);

printf("\n\n");
quicksort(arr, begl, l-1);
quicksort(arr, r, begr);
}
int main()
{
srand(3);
int n = 10;
int arr[10] = {10,9,8,7,6,5,4,3,2,1};
/*int *arr = new int [n];
for (int i = 0; i < n; i++) {
arr[i] = rand() % 10;
}*/
for (int i = 0; i < n; i++) {
printf("%d, ", arr[i]);
}
printf("\n");
quicksort(arr, 0, n - 1);
printf("result: ");
for (int i = 0; i < n; i++) {
printf("%d, ", arr[i]);
}
}