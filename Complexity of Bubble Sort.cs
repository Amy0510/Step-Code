#include <iostream>
#include <stdlib.h>
#include <time.h>


void bubblesort(int arr[1000]) {
int count = 1;
while (count > 0) {
 count = 0;
 for (int i = 0; i < 1000-1; i++) {
  if (arr[i] > arr[i + 1]) {
   int x = arr[i+1];
   arr[i + 1] = arr[i];
   count++;
  }

 }
}

for (int i = 0; i < 1000; i++) {
 printf("%d, ", arr[i]);
}


}

int main()
{

int arr[1000];
srand(time(NULL));
clock_t time;
for (int i = 0; i < 1000; i++) {
 arr[i] = rand() % 1000;
}
time = clock();

bubblesort(arr);
time = clock() - time;

printf("\n\n\n it took me %d clicks (%f seconds).\n", time, ((float)time) / CLOCKS_PER_SEC);

}