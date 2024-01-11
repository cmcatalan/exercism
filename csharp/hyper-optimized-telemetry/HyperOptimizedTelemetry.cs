using System;

public static class TelemetryBuffer
{
    private const ushort NegativeStart = byte.MaxValue + 1;
    public static byte[] ToBuffer(long reading)
    {
        (byte lengthBytes, bool haveSign) bytesInfo = reading switch
        {
            > uint.MaxValue => (sizeof(long), true),
            > int.MaxValue => (sizeof(uint), false),
            > ushort.MaxValue => (sizeof(int), true),
            >= ushort.MinValue => (sizeof(ushort), false),
            >= short.MinValue => (sizeof(short), true),
            >= int.MinValue => (sizeof(int), true),
            _ => (sizeof(long), true)
        };

        var bytes = BitConverter.GetBytes(reading);

        var buffer = new byte[9];
        buffer[0] = bytesInfo.haveSign ? (byte)(NegativeStart - bytesInfo.lengthBytes) : bytesInfo.lengthBytes;

        for (int i = 0; i < bytesInfo.lengthBytes; i++)
            buffer[i + 1] = bytes[i];

        return buffer;
    }

    public static long FromBuffer(byte[] buffer) => buffer[0] switch
    {
        sizeof(ushort) or sizeof(uint) or NegativeStart - sizeof(long) => BitConverter.ToInt64(buffer, 1),
        NegativeStart - sizeof(int) => BitConverter.ToInt32(buffer, 1),
        NegativeStart - sizeof(short) => BitConverter.ToInt16(buffer, 1),
        _ => 0,
    };
}
