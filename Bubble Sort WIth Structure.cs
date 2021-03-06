#include <iostream>

struct Person {
    int age;
    const char* name;
    float height;
};

void bubble_sort(int n[], int a) {
    int was_swap = 0;
    do {
        was_swap = 0;
        for (int i = 0; i < a - 1; i++) {
            if (n[i] > n[i + 1]) {
                int x = n[i];
                n[i] = n[i + 1];
                n[i + 1] = x;
                was_swap = 1;
            }
        }
    } while (was_swap);
    
    for (int i = 0; i < 100; i++) {
        printf("%d, ", n[i]);
    }

}

void PrintPerson(Person*pPerson) {
    printf("Person data: \n" "Age = %d \n" "Name = %s \n" "Height = %f \n", pPerson->age, pPerson->name, pPerson->height);
}

void PrintAgeIn2050(Person*pPerson) {
    printf("Your age in 2050 will be %d", pPerson->age + 31);
}

int main()
{
    char str[256];
    Person p1;
    printf("What is your age?");
    scanf("%d", &p1.age);
    printf("What is your name?");
    scanf("%s", str);
    p1.name = str;
    printf("What is your height?");
    scanf("%f", &p1.height);
    PrintPerson(&p1);
    PrintAgeIn2050(&p1); 
}
