using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot {
    internal static partial class DLL {
        public delegate bool EnumWindowCallback(IntPtr hwnd, int lParam);

        [DllImport("user32.dll")]
        public static extern int EnumWindows(EnumWindowCallback callback, int y);

        [DllImport("user32.dll")]
        public static extern int GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        public static extern long GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern IntPtr GetClassLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);

        [DllImport("user32")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("kernel32.dll")]
        public static extern uint SetThreadExecutionState(uint esFlags);
        public const uint ES_CONTINUOUS = 0x80000000;
        public const uint ES_SYSTEM_REQUIRED = 0x00000001;
    }

    public static class Desktop {

        static DLL.EnumWindowCallback _callback = new DLL.EnumWindowCallback(EnumWindowsProc);
        private static List<WindowData> _windows = new List<WindowData>();
        public static WindowData ActiveWindow {
            get {
                return GetWindowData(DLL.GetForegroundWindow());
            }
        }

        public static int ScreenWidth {
            get {
                return SystemInformation.VirtualScreen.Width;
            }
        }

        public static int ScreenHeight {
            get {
                return SystemInformation.VirtualScreen.Height;
            }
        }

        public static Point Center {
            get {
                return new Point(ScreenWidth / 2, ScreenHeight / 2);
            }
        }

        public static List<WindowData> GetWindows() {
            DLL.EnumWindows(_callback, 0);
            return _windows;
        }

        public static bool EnumWindowsProc(IntPtr hWnd, int lParam) {
            WindowData winData = GetWindowData(hWnd);
            if (!IsEmptyRect(winData.Rect)) {
                _windows.Add(winData);
            }
            return true;
        }

        private static WindowData GetWindowData(IntPtr hWnd) {
            string title = null;
            Rect rect;

            UInt32 style = (UInt32)DLL.GetWindowLong(hWnd, -16);
            // 해당 윈도우가 Visible인지 확인
            if ((style & 0x10000000L) == 0x10000000L) {
                StringBuilder buf = new StringBuilder(512);
                if (DLL.GetWindowText(hWnd, buf, 512) > 0) {
                    title = buf.ToString();
                }
            }

            DLL.GetWindowRect(hWnd, out rect);
            WindowData winData;
            winData.Title = title;
            winData.Rect = rect;

            return winData;
        }

        private static bool IsEmptyRect(Rect rect) {
            return rect.Left == rect.Right && rect.Top == rect.Bottom;
        }

        static uint lastExecutionState = 0;
        public static void SetKeepSystemAlive(bool keepAlive) {
            if (keepAlive) {
                lastExecutionState = DLL.SetThreadExecutionState(DLL.ES_CONTINUOUS | DLL.ES_SYSTEM_REQUIRED);
            } else {
                DLL.SetThreadExecutionState(lastExecutionState);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Rect {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    public struct WindowData {
        public string Title;
        public Rect Rect;
    }
}
