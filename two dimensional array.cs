#include <iostream>
void border(int **arr, int n, int m) {
for (int i = 0; i < n; i++) {
 printf("\n");
 for (int j = 0; j < m; j++) {
  if (i == 0 || j == 0 || i == n - 1 || j == m - 1) {
   arr[i][j] = 1;
  }
  else arr[i][j] = 0;
  printf("%d", arr[i][j]);
 }
}
}

int main()
{
int n = 10;
int m = 8;
int** ppa = (int**)malloc(sizeof(int*) * n);
for (int i = 0; i < n; i++) {
 ppa[i] = (int*)malloc(sizeof(int) * m);
}
border(ppa, n, m);
}
