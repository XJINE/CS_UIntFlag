# CS_UIntFlag

Some utility functions to handle uint value as flag.

```cs
public static uint Invert(uint bitFlag)
public static uint Clear(uint bitFlag)
public static uint On(uint bitFlag, int index)
public static uint On(uint bitFlag, params int[] indexes)
public static uint Off(uint bitFlag, int index)
public static uint Off(uint bitFlag, params int[] index)
public static bool IsOn(uint bitFlag, int index)
public static bool IsOn(uint bitFlagA, uint bitFlagB)
public static bool[] ToStates(uint bitFlag)
public static uint FromStates(bool[] states)
public static string To01Text(uint bitFlag, int digits = 32)
public static uint From01Text(string text)
public static int ToIndex(uint bitFlag)
public static uint FromIndex(int index)
public static int[] ToIndexes(uint bitFlag)
public static uint FromIndexes(params int[] indexes)
```
