#include <iostream>
#include <Windows.h>
#define ARR_SIZE 100000000
HANDLE hThreadXDone = NULL;
HANDLE hThreadYDone = NULL;
DWORD WINAPI Steve(_In_ LPVOID lpParameter) {

    FILE* pFile = (FILE*)lpParameter;
    for (int i = 0; i < 1000; i++) {
        fprintf(pFile, "x");
    }
    SetEvent(hThreadXDone);
    return 0;
}
DWORD WINAPI Steve2(_In_ LPVOID lpParameter) {

    DWORD result = WaitForSingleObject(hThreadXDone, INFINITE);
    if (result == WAIT_OBJECT_0) {
        FILE* pFile = (FILE*)lpParameter;
        for (int x = 0; x < 1000; x++) {
            fprintf(pFile, "y");
        }
        SetEvent(hThreadYDone);
        return 0;
    }
   
}

int main()
{
    FILE* pFile = NULL;
    fopen_s(&pFile, "C:\\Users\\Student\\thingy.txt", "w");


    hThreadXDone = CreateEvent(NULL, TRUE, FALSE, NULL);
    hThreadYDone = CreateEvent(NULL, TRUE, FALSE, NULL);
   // HANDLE eventArray[2] = { hThreadXDone, hThreadYDone };

    HANDLE hThread1 = CreateThread(NULL, 0, Steve, (void*)pFile, 0, NULL);
    HANDLE hThread2 =CreateThread(NULL, 0, Steve2, (void*)pFile, 0, NULL);

   // DWORD result = WaitForMultipleObjects(2, eventArray, TRUE, 1200);

    /*if (result == WAIT_OBJECT_0) {
        printf("Thread X is Done");
    }
    else if (result = WAIT_TIMEOUT){
        printf("timeout!!! \n");
    }
    else{
        printf("Something unexpected happened!\n");
    }
    if (result == WAIT_OBJECT_0+1) {
        printf("Thread Y is Done");
    }
    CloseHandle(hThread1);
    CloseHandle(hThread2);
    CloseHandle(hThreadXDone);
    CloseHandle(hThreadYDone);*/

    Sleep(1000);
    fclose(pFile);

    return 0;

}


