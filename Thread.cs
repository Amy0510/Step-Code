#include <iostream>
#include <thread>
#include <mutex>
using namespace std;
int t = 0;
mutex m;
void incr(int n) {
for (int i = 0; i < n; i++) {
m.lock();
t++;
m.unlock();
// cout << this_thread::get_id() << " t =" << t << "\n";
}

}


int main()
{
thread t1(incr, 10000);
thread t2(incr, 10000);
thread t4(incr, 10000);
thread t5(incr, 10000);

t1.join();
t2.join();
t4.join();
t5.join();
cout << t;

}