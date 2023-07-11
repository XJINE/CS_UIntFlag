using System;
using System.Linq;
using System.Runtime.CompilerServices;

public static class UIntFlag
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Invert(uint bitFlag)
    {
        return bitFlag ^ uint.MaxValue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Clear(uint bitFlag)
    {
        return 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint On(uint bitFlag, int index)
    {
        return bitFlag |= 1u << index;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint On(uint bitFlag, params int[] indexes)
    {
        return indexes.Aggregate(bitFlag, (current, index) => current | 1u << index);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Off(uint bitFlag, int index)
    {
        return bitFlag &= ~(1u << index);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Off(uint bitFlag, params int[] index)
    {
        return index.Aggregate(bitFlag, (current, i) => current & ~(1u << i));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOn(uint bitFlag, int index)
    {
        return (bitFlag & (1u << index)) != 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOn(uint bitFlagA, uint bitFlagB)
    {
        return (bitFlagA & bitFlagB) != 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool[] ToStates(uint bitFlag)
    {
        var result = new bool[32];

        for (var i = 0; i < 32; i++)
        {
            result[i] = (bitFlag & (1 << i)) != 0;
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint FromStates(bool[] states)
    {
        var result = 0u;

        for (var i = 0; i < states.Length; i++)
        {
            if (states[i])
            {
                result |= 1u << i;
            }
        }
        
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string To01Text(uint bitFlag, int digits = 32)
    {
        // return Convert.ToString(bitFlag, 2);
        return Convert.ToString(bitFlag, 2).PadLeft(digits, '0');
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint From01Text(string text)
    {
        return Convert.ToUInt32(text, 2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ToIndex(uint bitFlag)
    {
        // 0111 returns 2, 0011 returns 1.
        return (int)Math.Log(bitFlag, 2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint FromIndex(int index)
    {
        return On(0, index);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int[] ToIndexes(uint bitFlag)
    {
        return Enumerable.Range(0, 32).Where(index => (bitFlag & (1 << index)) != 0).ToArray();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint FromIndexes(params int[] indexes)
    {
        return On(0, indexes);
    }
}