``` ini

BenchmarkDotNet=v0.10.11, OS=macOS 10.13.3 (17D102) [Darwin 17.4.0]
Processor=Intel Core i5-5287U CPU 2.90GHz (Broadwell), ProcessorCount=4
.NET Core SDK=2.1.300-preview2-008251
  [Host]     : .NET Core 2.1.0-preview2-26130-04 (Framework 4.6.26130.05), 64bit RyuJIT
  Job-RSCSGR : .NET Core 2.1.0-preview2-26130-04 (Framework 4.6.26130.05), 64bit RyuJIT

RemoveOutliers=False  Runtime=Core  Server=True  
Toolchain=.NET Core 2.1  LaunchCount=3  RunStrategy=Throughput  
TargetCount=10  WarmupCount=5  

```
|                    Method | Iterations |       Mean |     Error |     StdDev |    Op/s |    Gen 0 |  Allocated |
|-------------------------- |----------- |-----------:|----------:|-----------:|--------:|---------:|-----------:|
|  **Rfc2898DeriveBytesSHA512** |       **1000** |   **2.483 ms** | **0.3441 ms** |  **0.5150 ms** | **402.674** |        **-** |      **888 B** |
| KeyDerivationPBKDF2SHA512 |       1000 |   2.552 ms | 0.2142 ms |  0.3207 ms | 391.864 |   3.9063 |   176504 B |
|  **Rfc2898DeriveBytesSHA512** |      **10000** |  **21.696 ms** | **0.6027 ms** |  **0.9021 ms** |  **46.091** |        **-** |      **888 B** |
| KeyDerivationPBKDF2SHA512 |      10000 |  23.534 ms | 1.1734 ms |  1.7563 ms |  42.491 |  62.5000 |  1760504 B |
|  **Rfc2898DeriveBytesSHA512** |     **100000** | **221.153 ms** | **8.2108 ms** | **12.2895 ms** |   **4.522** |        **-** |      **888 B** |
| KeyDerivationPBKDF2SHA512 |     100000 | 235.548 ms | 9.2109 ms | 13.7865 ms |   4.245 | 750.0000 | 17600504 B |
