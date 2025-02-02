using System;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    private const int STD_INPUT_HANDLE = -10;
    private const uint ENABLE_EXTENDED_FLAGS = 0x0080;
    private const uint ENABLE_QUICK_EDIT_MODE = 0x0040;
    private const uint ENABLE_MOUSE_INPUT = 0x0010;
    private const ushort MOUSE_EVENT = 0x0002;
    private const uint FROM_LEFT_1ST_BUTTON_PRESSED = 0x0001;

    [StructLayout(LayoutKind.Sequential)]
    public struct COORD
    {
        public short X;
        public short Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT_RECORD
    {
        public ushort EventType;
        public MOUSE_EVENT_RECORD MouseEvent;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSE_EVENT_RECORD
    {
        public COORD dwMousePosition;
        public uint dwButtonState;
        public uint dwControlKeyState;
        public uint dwEventFlags;
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool ReadConsoleInput(IntPtr hConsoleInput, out INPUT_RECORD lpBuffer, uint nLength, out uint lpNumberOfEventsRead);

    static COORD lastPosition = new COORD { X = -1, Y = -1 }; // Store last X,Y position
    static readonly object lockObject = new object(); // Lock for thread safety

    static void Main()
    {
        IntPtr handle = GetStdHandle(STD_INPUT_HANDLE);

        // Enable mouse input in the console
        if (GetConsoleMode(handle, out uint mode))
        {
            mode |= ENABLE_MOUSE_INPUT; // Enable mouse input
            mode &= ~ENABLE_QUICK_EDIT_MODE; // Disable Quick Edit mode
            mode &= ~ENABLE_EXTENDED_FLAGS;
            SetConsoleMode(handle, mode);
        }

        Console.Clear();
        Console.WriteLine("Click anywhere in the console. Press Ctrl+C to exit.");

        // Start mouse listener in a separate thread
        Thread mouseThread = new Thread(() => ListenForMouseClicks(handle));
        mouseThread.IsBackground = true;
        mouseThread.Start();

        // Keep the main thread alive
        while (true)
        {
            Thread.Sleep(100);
        }
    }

    static void ListenForMouseClicks(IntPtr handle)
    {
        while (true)
        {
            if (ReadConsoleInput(handle, out INPUT_RECORD record, 1, out uint _))
            {
                if (record.EventType == MOUSE_EVENT && record.MouseEvent.dwButtonState == FROM_LEFT_1ST_BUTTON_PRESSED)
                {
                    COORD newPosition = record.MouseEvent.dwMousePosition;
                    lock (lockObject) // Prevent race conditions
                    {
                        MarkLastClick(newPosition);
                    }
                }
            }
        }
    }

    static void MarkLastClick(COORD position)
    {
        lock (lockObject)
        {
            // Clear previous mark if it exists
            if (lastPosition.X >= 0 && lastPosition.Y >= 0)
            {
                Console.SetCursorPosition(lastPosition.X, lastPosition.Y);
                Console.Write(" "); // Erase old "X"
            }

            // Draw new "X" at the clicked position
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write("X");

            // Store last position
            lastPosition = position;
        }
    }
}