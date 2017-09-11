using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Robot {
    internal static partial class DLL {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out MousePoint lpMousePoint);

        [DllImport("user32.dll", SetLastError = false)]
        public static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern bool GetCursorInfo(ref CursorInfo pci);
        public const Int32 CURSOR_SHOWING = 0x00000001;
    }

    public class Mouse {
        [Flags]
        public enum MouseFlags {
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            Move = 0x0001,
            Absolute = 0x8000,
            RightDown = 0x0008,
            RightUp = 0x0010,
            Wheel = 0x0800
        }

        public enum CursorHandle {
            AppStarting = 65561,
            Arrow = 65539,
            Cross = 65545,
            Default = 65539,
            Hand = 67988,
            Help = 65563,
            HSplit = 67990,
            IBeam = 65541,
            No = 65559,
            NoMove2D = 67992,
            NoMoveHoriz = 67994,
            NoMoveVert = 67996,
            PanEast = 3933966,
            PanNE = 67998,
            PanNorth = 68000,
            PanNW = 68002,
            PanSE = 68004,
            PanSouth = 68006,
            PanSW = 68008,
            PanWest = 68012,
            SizeAll = 65557,
            SizeNESW = 65551,
            SizeNS = 65555,
            SizeNWSE = 65549,
            SizeWE = 65553,
            UpArrow = 65547,
            VSplit = 68016,
            WaitCursor = 65543
        };

        public enum MouseButtons {
            Left = 0,
            Middle,
            Right
        };

        public static MousePoint Position {
            get {
                MousePoint pos;
                bool got = DLL.GetCursorPos(out pos);
                if (!got) {
                    pos = new MousePoint(0, 0);
                }
                return pos;
            }
            set {
                MoveTo(value.X, value.Y);
            }
        }

        public static CursorInfo CursorInfo {
            get {
                CursorInfo pci = new CursorInfo();
                pci.cbSize = Marshal.SizeOf(typeof(CursorInfo));
                DLL.GetCursorInfo(ref pci);
                return pci;
            }
        }

        public static CursorHandle Handle {
            get {
                return (CursorHandle)CursorInfo.hCursor;
            }
        }

        public static void MoveTo(int x, int y) {
            x = (int)(x * 65536.0 / Desktop.ScreenWidth);
            y = (int)(y * 65536.0 / Desktop.ScreenHeight);
            DLL.mouse_event((int)(MouseFlags.Absolute | MouseFlags.Move), x, y, 0, DLL.GetMessageExtraInfo());
        }

        public static void MoveBy(int x, int y) {
            DLL.mouse_event((int)MouseFlags.Move, x, y, 0, DLL.GetMessageExtraInfo());
        }

        public static void MoveToCenter() {
            MoveTo(Desktop.Center.X, Desktop.Center.Y);
        }

        public static void Trigger(MouseFlags flags) {
            MousePoint pos = Position;
            DLL.mouse_event((int)flags, pos.X, pos.Y, 0, DLL.GetMessageExtraInfo());
        }

        public static void Scroll(int delta) {
            DLL.mouse_event((int)MouseFlags.Wheel, 0, 0, delta, DLL.GetMessageExtraInfo());
        }
        
        public static void Down(MouseButtons button) {
            MouseFlags flags;
            switch (button) {
                case MouseButtons.Right: flags = MouseFlags.RightDown; break;
                case MouseButtons.Middle: flags = MouseFlags.MiddleDown; break;
                default: flags = MouseFlags.LeftDown; break;
            }
            Trigger(flags);
        }

        public static void Up(MouseButtons button) {
            MouseFlags flags;
            switch (button) {
                case MouseButtons.Right: flags = MouseFlags.RightUp; break;
                case MouseButtons.Middle: flags = MouseFlags.MiddleUp; break;
                default: flags = MouseFlags.LeftUp; break;
            }
            Trigger(flags);
        }
        
        public static void Click(MouseButtons button) {
            Down(button);
            Up(button);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MousePoint {
        public int X;
        public int Y;

        public MousePoint(int x, int y) {
            X = x;
            Y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CursorInfo {
        public Int32 cbSize;            // 구조체의 바이트 크기
                                        // Marshal.SizeOf(typeof(CURSORINFO))로 반드시 초기화
        public Int32 flags;             // 커서의 상태, 0은 안보임 CURSOR_SHOWING은 보여줌
        public IntPtr hCursor;          // 커서의 핸들
        public MousePoint ptScreenPos;  // 커서의 위치
    }
}
