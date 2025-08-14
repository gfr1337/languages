#import <Foundation/Foundation.h> 
  
int main(int argc, const char * argv[]) { 
    int u = [[NSString stringWithUTF8String:argv[1]] intValue];  // Get an input number from the command line
    int r = arc4random() % 10000;                                // Get a random integer 0 <= r < 10k
    
    int32_t a[10000] = {0};                                      // Array of 10k elements initialized to 0
    for (int i = 0; i < 10000; i++) {                            // 10k outer loop iterations    
        for (int j = 0; j < 100000; j++) {                       // 100k inner loop iterations, per outer loop iteration
            a[i] = a[i] + j % u;                                 // Simple sum
        }
        a[i] += r;                                               // Add a random value to each element in array
    }
    printf("%d\n", a[r]);                                        // Print out a single element from the array

    return 0; 
} 
