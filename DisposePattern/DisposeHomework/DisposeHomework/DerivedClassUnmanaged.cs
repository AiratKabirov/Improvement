using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DisposeHomework
{
    public class DerivedClassUnmanaged : BaseClassUnmanaged
    {
        // Define additional constants.
        protected const uint GENERIC_WRITE = 0x40000000;
        protected const uint OPEN_ALWAYS = 4;

        // Define additional APIs.
        [DllImport("kernel32.dll")]
        protected static extern bool WriteFile(
                                     SafeFileHandle safeHandle, string lpBuffer,
                                     int nNumberOfBytesToWrite, out int lpNumberOfBytesWritten,
                                     IntPtr lpOverlapped);

        // Define locals.
        private bool disposed = false;
        private string filename;
        private bool created = false;
        private SafeFileHandle safeHandle;

        public DerivedClassUnmanaged(string filename) : base(filename)
        {
            this.filename = filename;
        }

        public void WriteFileInfo()
        {
            if (!created)
            {
                IntPtr hFile = CreateFile(@".\FileInfo.txt", GENERIC_WRITE, 0,
                                          IntPtr.Zero, OPEN_ALWAYS,
                                          FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
                if (hFile != INVALID_HANDLE_VALUE)
                    safeHandle = new SafeFileHandle(hFile, true);
                else
                    throw new IOException("Unable to create output file.");

                created = true;
            }

            string output = String.Format("{0}: {1:N0} bytes\n", filename, Size);
            int bytesWritten;
            bool result = WriteFile(safeHandle, output, output.Length, out bytesWritten, IntPtr.Zero);
        }

        protected new virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            // Release any managed resources here.
            if (disposing)
                safeHandle.Dispose();

            disposed = true;

            // Release any unmanaged resources not wrapped by safe handles here.

            // Call the base class implementation.
            base.Dispose(disposing);
        }
    }
}
