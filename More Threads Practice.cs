#include <iostream>
#include <Windows.h>
#include <time.h>

struct Context {
    char* p;
    int count;
    unsigned int* pres;
};


DWORD WINAPI Worker(void* lparameter) {
    Context* ctx = (Context*)lparameter;
    for (int i = 0; i < ctx->count; i++) {
        *(ctx->pres) += ctx->p[i];
    }
    return 0;
}
int main()
{
    unsigned int sum = 0;
    char* arr = (char*)malloc(sizeof(char) * 400000000);
    for (int i = 0; i < 400000000; i++) {
        arr[i] = rand() % 10;
    }
    clock_t start = clock();
    for (int i = 0; i < 40000000; i++) {
        sum += arr[i];
    }
    clock_t stop = clock();
    double duration = (double)(stop - start) / CLOCKS_PER_SEC;
    printf("%lf \n", duration);
    printf("%u\n", sum);
    unsigned int sum2[4] = {};
    Context ctx[4] = {};
    ctx[0].p = arr;
    ctx[0].count = 100000000;
    ctx[0].pres = &sum2[0];
    ctx[1].p = arr+100000000;
    ctx[1].count = 100000000;
    ctx[2].p = arr+200000000;
    ctx[2].count = 100000000;
    ctx[3].p = arr+300000000;
    ctx[3].count = 100000000;
    ctx[1].pres = &sum2[1];
    ctx[2].pres = &sum2[2];
    ctx[3].pres = &sum2[3];


    clock_t start2 = clock();
    HANDLE h1 = CreateThread(NULL, 0, Worker, &ctx[0], 0, NULL);
    HANDLE h2 = CreateThread(NULL, 0, Worker, &ctx[1], 0, NULL);
    HANDLE h3 = CreateThread(NULL, 0, Worker, &ctx[2], 0, NULL);
    HANDLE h4 = CreateThread(NULL, 0, Worker, &ctx[3], 0, NULL);

    HANDLE h[4] = { h1, h2, h3, h4 };
    WaitForMultipleObjects(4, h, TRUE, INFINITE);
    clock_t stop2 = clock();
    double duration2 = (double)(stop2 - start2) / CLOCKS_PER_SEC;
    printf("%lf \n", duration2);
    printf("%u", sum2[0] + sum2[1] + sum2[2] + sum2[3]);

    /*int val = 1000;
    HANDLE he = CreateMutex(NULL, FALSE, NULL);

    Context ctx;
    ctx.hMutex = he;
    ctx.pval = &val;

    HANDLE h1 = CreateThread(NULL, 0, Worker1, &ctx, 0, NULL);
    HANDLE h2 = CreateThread(NULL, 0, Worker2, &ctx, 0, NULL); //os scheduler

    HANDLE h[2] = { h1, h2 };
    WaitForMultipleObjects(2, h, TRUE, INFINITE);
    //WaitForSingleObject(h1, INFINITE);
    //WaitForSingleObject(h2, INFINITE);
    printf("%d\n ", val);*/

}