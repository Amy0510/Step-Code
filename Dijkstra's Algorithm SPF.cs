#include <iostream>

using namespace std;

const int INF = 10000;

int g[6][6] = {
				{-1, 1, 7, -1, -1, -1},
				{-1, -1, 2, -1, -1, 12},
				{7, 2, -1, 3, 2, -1},
				{-1, -1, 3, -1, 2, -1},
				{-1, -1, 2, 2, -1, 5},
				{-1, 12, -1, -1, 5, -1},
};

bool visited[6] = { false };
int d[6] = { 0, 100, 100, 100, 100, 100 };

void dijkstra() {
	int shortest = 100;
	int i = 0;
	for (int n = 0; i < 6; n++) {
		visited[i] = true;
		shortest = 100;
		for (int j = 0; j < 6; j++) {
			if (visited[j] == false && g[i][j] >= 0 && g[i][j] + d[i] < d[j]) {
				d[j] = g[i][j] + d[i];	
			}
		}
		for (int i = 0; i < 6; i++) {
			if (visited[i] == false) {
				if (d[i] < shortest) shortest = i;
			}
		}
		i = shortest;
	}

}

int main()
{
	dijkstra();
	for (int i = 0; i < 6; i++) {
		printf("%d ", d[i]);
	}
	int n;
	scanf_s("%d", &n);
}
