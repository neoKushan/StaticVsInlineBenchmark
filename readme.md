``` ini

BenchmarkDotNet=v0.10.6, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-6600U CPU 2.60GHz (Skylake), ProcessorCount=4
Frequency=2742186 Hz, Resolution=364.6726 ns, Timer=TSC
dotnet cli version=1.0.0-preview2-003131
  [Host]     : .NET Core 4.6.25211.01, 64bit RyuJIT
  DefaultJob : .NET Core 4.6.24628.01, 64bit RyuJIT


```
 |      Method |     Mean |     Error |   StdDev |   Median |
 |------------ |---------:|----------:|---------:|---------:|
 | CheckInline | 27.73 us | 0.7605 us | 2.242 us | 27.10 us |
 | CheckStatic | 28.18 us | 0.9045 us | 2.581 us | 27.33 us |
