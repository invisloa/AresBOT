using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3
{
    public class Memory
    {
        [DllImport("kernel32.dll")]
        static extern bool ReadProcessMemory(IntPtr proc, IntPtr address, byte[] buffer, int size, ref int read);

        [DllImport("kernel32.dll")]
        static extern bool WriteProcessMemory(IntPtr proc, IntPtr address, byte[] buffer, int size, ref int written);

        int read, write;
        byte[] ptr = new byte[8];
        byte[] bytesBuffer = new byte[1024];
        byte[] bufferByte = new byte[1];
        byte[] bytesShortBuffer = new byte[2];

        public IntPtr readpointer(IntPtr proc, IntPtr address)
        {
            ReadProcessMemory(proc, address, bytesBuffer, 4, ref read);

            return (IntPtr)BitConverter.ToInt32(bytesBuffer, 0);

        }
        public byte[] readbytes(IntPtr proc, IntPtr address, int size)
        {
            ReadProcessMemory(proc, address, bytesBuffer, size, ref read);

            return bytesBuffer;
        }
        public byte[] readShort (IntPtr proc, IntPtr address)
        {
            ReadProcessMemory(proc, address, bytesBuffer, 2, ref read);

            return bytesBuffer;
        }
        public byte readByte(IntPtr proc, IntPtr address)
        {
            ReadProcessMemory(proc, address, bufferByte, 1, ref read);
            return bufferByte[0];
        }

        public void writebytes(IntPtr proc, IntPtr address, byte[] newbytes)
        {
            WriteProcessMemory(proc, address, newbytes, newbytes.Length, ref write);
        }
    }
}
