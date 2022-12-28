# Async/Await in IL Code

This project demonstrates how the async and await keywords are transformed into IL code during compilation.

Within the repository, you will find pairs of implementations demonstrating this concept. Each pair consists of an implementation using `async/await` and its equivalent representation in IL code, denoted by the suffix "Il" at the end of a class name. 

In addition to the pairs of implementations, the repository also contains the file `ConwayCleanCode` class, which is a refactored version with the goal of improving readability for humans. While this implementation may be less efficient, it serves as a demonstration of the logic and intent behind the IL code generated during compilation.

# Output

```
Alright Async Await!

01 Global - Knuth
20:08:02.767 MethodFirst
20:08:05.813 MethodSecond
02 Global

03 Global - Knuth IL
20:08:05.815 MethodFirst
20:08:08.821 MethodSecond
04 Global

05 Global - Graham
20:08:08.825 MethodFirst
20:08:11.821 MethodSecond
20:08:14.836 MethodThird
06 Global

07 Global - Graham IL
20:08:14.841 MethodFirst
20:08:17.848 MethodSecond
20:08:20.852 MethodThird
08 Global

09 Global - Riemann
20:08:20.856 MethodFirst
20:08:23.852 MethodSecond
20:08:26.852 MethodThird
20:08:29.859 MethodFourth
10 Global

11 Global - Riemann IL
20:08:29.862 MethodFirst
20:08:32.861 MethodSecond
20:08:35.867 MethodThird
20:08:38.873 MethodFourth
11 Global

12 Global - Conway
20:08:38.881 MethodFirst
20:08:41.876 MethodSecond
20:08:44.884 MethodThird
20:08:47.895 MethodFourth
20:08:50.908 MethodFifth
13 Global

14 Global - Conway IL
20:08:50.916 MethodFirst
20:08:53.912 MethodSecond
20:08:56.921 MethodThird
20:08:59.933 MethodFourth
20:09:02.941 MethodFifth
15 Global

16 Global - Conway Clean Code
20:09:02.950 MethodFirst
20:09:02.951 MethodSecond
20:09:05.953 MethodThird
20:09:05.954 MethodFourth
20:09:08.969 MethodFifth
17 Global

18 Global - Planck
20:09:08.979 MethodFirst 100
20:09:08.981 MethodSecond 200
20:09:08.983 MethodThird 300
20:09:08.989 MethodFourth 400
20:09:08.991 MethodFifth 500
19 Global: 500

19 Global - Planck IL
20:09:09.008 MethodFirst 100
20:09:09.009 MethodSecond 200
20:09:09.011 MethodThird 300
20:09:09.012 MethodFourth 400
20:09:09.013 MethodFirst 500
20 Global: 500
```
