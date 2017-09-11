using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Robot {
    internal static partial class DLL {
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
    }

    public static class Keyboard {
        [Flags]
        public enum VirtualKeys {
            ///<summary>
            ///Left mouse button
            ///</summary>
            LBUTTON = 0x01,
            ///<summary>
            ///Right mouse button
            ///</summary>
            RBUTTON = 0x02,
            ///<summary>
            ///Control-break processing
            ///</summary>
            CANCEL = 0x03,
            ///<summary>
            ///Middle mouse button (three-button mouse)
            ///</summary>
            MBUTTON = 0x04,
            ///<summary>
            ///Windows 2000/XP: X1 mouse button
            ///</summary>
            XBUTTON1 = 0x05,
            ///<summary>
            ///Windows 2000/XP: X2 mouse button
            ///</summary>
            XBUTTON2 = 0x06,
            ///<summary>
            ///BACKSPACE key
            ///</summary>
            BACK = 0x08,
            ///<summary>
            ///TAB key
            ///</summary>
            TAB = 0x09,
            ///<summary>
            ///CLEAR key
            ///</summary>
            CLEAR = 0x0C,
            ///<summary>
            ///ENTER key
            ///</summary>
            RETURN = 0x0D,
            ///<summary>
            ///SHIFT key
            ///</summary>
            SHIFT = 0x10,
            ///<summary>
            ///CTRL key
            ///</summary>
            CONTROL = 0x11,
            ///<summary>
            ///ALT key
            ///</summary>
            MENU = 0x12,
            ///<summary>
            ///PAUSE key
            ///</summary>
            PAUSE = 0x13,
            ///<summary>
            ///CAPS LOCK key
            ///</summary>
            CAPITAL = 0x14,
            ///<summary>
            ///Input Method Editor (IME) Kana mode
            ///</summary>
            KANA = 0x15,
            ///<summary>
            ///IME Hangul mode
            ///</summary>
            HANGUL = 0x15,
            ///<summary>
            ///IME Junja mode
            ///</summary>
            JUNJA = 0x17,
            ///<summary>
            ///IME final mode
            ///</summary>
            FINAL = 0x18,
            ///<summary>
            ///IME Hanja mode
            ///</summary>
            HANJA = 0x19,
            ///<summary>
            ///IME Kanji mode
            ///</summary>
            KANJI = 0x19,
            ///<summary>
            ///ESC key
            ///</summary>
            ESCAPE = 0x1B,
            ///<summary>
            ///IME convert
            ///</summary>
            CONVERT = 0x1C,
            ///<summary>
            ///IME nonconvert
            ///</summary>
            NONCONVERT = 0x1D,
            ///<summary>
            ///IME accept
            ///</summary>
            ACCEPT = 0x1E,
            ///<summary>
            ///IME mode change request
            ///</summary>
            MODECHANGE = 0x1F,
            ///<summary>
            ///SPACEBAR
            ///</summary>
            SPACE = 0x20,
            ///<summary>
            ///PAGE UP key
            ///</summary>
            PRIOR = 0x21,
            ///<summary>
            ///PAGE DOWN key
            ///</summary>
            NEXT = 0x22,
            ///<summary>
            ///END key
            ///</summary>
            END = 0x23,
            ///<summary>
            ///HOME key
            ///</summary>
            HOME = 0x24,
            ///<summary>
            ///LEFT ARROW key
            ///</summary>
            LEFT = 0x25,
            ///<summary>
            ///UP ARROW key
            ///</summary>
            UP = 0x26,
            ///<summary>
            ///RIGHT ARROW key
            ///</summary>
            RIGHT = 0x27,
            ///<summary>
            ///DOWN ARROW key
            ///</summary>
            DOWN = 0x28,
            ///<summary>
            ///SELECT key
            ///</summary>
            SELECT = 0x29,
            ///<summary>
            ///PRINT key
            ///</summary>
            PRINT = 0x2A,
            ///<summary>
            ///EXECUTE key
            ///</summary>
            EXECUTE = 0x2B,
            ///<summary>
            ///PRINT SCREEN key
            ///</summary>
            SNAPSHOT = 0x2C,
            ///<summary>
            ///INS key
            ///</summary>
            INSERT = 0x2D,
            ///<summary>
            ///DEL key
            ///</summary>
            DELETE = 0x2E,
            ///<summary>
            ///HELP key
            ///</summary>
            HELP = 0x2F,
            ///<summary>
            ///0 key
            ///</summary>
            KEY_0 = 0x30,
            ///<summary>
            ///1 key
            ///</summary>
            KEY_1 = 0x31,
            ///<summary>
            ///2 key
            ///</summary>
            KEY_2 = 0x32,
            ///<summary>
            ///3 key
            ///</summary>
            KEY_3 = 0x33,
            ///<summary>
            ///4 key
            ///</summary>
            KEY_4 = 0x34,
            ///<summary>
            ///5 key
            ///</summary>
            KEY_5 = 0x35,
            ///<summary>
            ///6 key
            ///</summary>
            KEY_6 = 0x36,
            ///<summary>
            ///7 key
            ///</summary>
            KEY_7 = 0x37,
            ///<summary>
            ///8 key
            ///</summary>
            KEY_8 = 0x38,
            ///<summary>
            ///9 key
            ///</summary>
            KEY_9 = 0x39,
            ///<summary>
            ///A key
            ///</summary>
            KEY_A = 0x41,
            ///<summary>
            ///B key
            ///</summary>
            KEY_B = 0x42,
            ///<summary>
            ///C key
            ///</summary>
            KEY_C = 0x43,
            ///<summary>
            ///D key
            ///</summary>
            KEY_D = 0x44,
            ///<summary>
            ///E key
            ///</summary>
            KEY_E = 0x45,
            ///<summary>
            ///F key
            ///</summary>
            KEY_F = 0x46,
            ///<summary>
            ///G key
            ///</summary>
            KEY_G = 0x47,
            ///<summary>
            ///H key
            ///</summary>
            KEY_H = 0x48,
            ///<summary>
            ///I key
            ///</summary>
            KEY_I = 0x49,
            ///<summary>
            ///J key
            ///</summary>
            KEY_J = 0x4A,
            ///<summary>
            ///K key
            ///</summary>
            KEY_K = 0x4B,
            ///<summary>
            ///L key
            ///</summary>
            KEY_L = 0x4C,
            ///<summary>
            ///M key
            ///</summary>
            KEY_M = 0x4D,
            ///<summary>
            ///N key
            ///</summary>
            KEY_N = 0x4E,
            ///<summary>
            ///O key
            ///</summary>
            KEY_O = 0x4F,
            ///<summary>
            ///P key
            ///</summary>
            KEY_P = 0x50,
            ///<summary>
            ///Q key
            ///</summary>
            KEY_Q = 0x51,
            ///<summary>
            ///R key
            ///</summary>
            KEY_R = 0x52,
            ///<summary>
            ///S key
            ///</summary>
            KEY_S = 0x53,
            ///<summary>
            ///T key
            ///</summary>
            KEY_T = 0x54,
            ///<summary>
            ///U key
            ///</summary>
            KEY_U = 0x55,
            ///<summary>
            ///V key
            ///</summary>
            KEY_V = 0x56,
            ///<summary>
            ///W key
            ///</summary>
            KEY_W = 0x57,
            ///<summary>
            ///X key
            ///</summary>
            KEY_X = 0x58,
            ///<summary>
            ///Y key
            ///</summary>
            KEY_Y = 0x59,
            ///<summary>
            ///Z key
            ///</summary>
            KEY_Z = 0x5A,
            ///<summary>
            ///Left Windows key (Microsoft Natural keyboard) 
            ///</summary>
            LWIN = 0x5B,
            ///<summary>
            ///Right Windows key (Natural keyboard)
            ///</summary>
            RWIN = 0x5C,
            ///<summary>
            ///Applications key (Natural keyboard)
            ///</summary>
            APPS = 0x5D,
            ///<summary>
            ///Computer Sleep key
            ///</summary>
            SLEEP = 0x5F,
            ///<summary>
            ///Numeric keypad 0 key
            ///</summary>
            NUMPAD0 = 0x60,
            ///<summary>
            ///Numeric keypad 1 key
            ///</summary>
            NUMPAD1 = 0x61,
            ///<summary>
            ///Numeric keypad 2 key
            ///</summary>
            NUMPAD2 = 0x62,
            ///<summary>
            ///Numeric keypad 3 key
            ///</summary>
            NUMPAD3 = 0x63,
            ///<summary>
            ///Numeric keypad 4 key
            ///</summary>
            NUMPAD4 = 0x64,
            ///<summary>
            ///Numeric keypad 5 key
            ///</summary>
            NUMPAD5 = 0x65,
            ///<summary>
            ///Numeric keypad 6 key
            ///</summary>
            NUMPAD6 = 0x66,
            ///<summary>
            ///Numeric keypad 7 key
            ///</summary>
            NUMPAD7 = 0x67,
            ///<summary>
            ///Numeric keypad 8 key
            ///</summary>
            NUMPAD8 = 0x68,
            ///<summary>
            ///Numeric keypad 9 key
            ///</summary>
            NUMPAD9 = 0x69,
            ///<summary>
            ///Multiply key
            ///</summary>
            MULTIPLY = 0x6A,
            ///<summary>
            ///Add key
            ///</summary>
            ADD = 0x6B,
            ///<summary>
            ///Separator key
            ///</summary>
            SEPARATOR = 0x6C,
            ///<summary>
            ///Subtract key
            ///</summary>
            SUBTRACT = 0x6D,
            ///<summary>
            ///Decimal key
            ///</summary>
            DECIMAL = 0x6E,
            ///<summary>
            ///Divide key
            ///</summary>
            DIVIDE = 0x6F,
            ///<summary>
            ///F1 key
            ///</summary>
            F1 = 0x70,
            ///<summary>
            ///F2 key
            ///</summary>
            F2 = 0x71,
            ///<summary>
            ///F3 key
            ///</summary>
            F3 = 0x72,
            ///<summary>
            ///F4 key
            ///</summary>
            F4 = 0x73,
            ///<summary>
            ///F5 key
            ///</summary>
            F5 = 0x74,
            ///<summary>
            ///F6 key
            ///</summary>
            F6 = 0x75,
            ///<summary>
            ///F7 key
            ///</summary>
            F7 = 0x76,
            ///<summary>
            ///F8 key
            ///</summary>
            F8 = 0x77,
            ///<summary>
            ///F9 key
            ///</summary>
            F9 = 0x78,
            ///<summary>
            ///F10 key
            ///</summary>
            F10 = 0x79,
            ///<summary>
            ///F11 key
            ///</summary>
            F11 = 0x7A,
            ///<summary>
            ///F12 key
            ///</summary>
            F12 = 0x7B,
            ///<summary>
            ///F13 key
            ///</summary>
            F13 = 0x7C,
            ///<summary>
            ///F14 key
            ///</summary>
            F14 = 0x7D,
            ///<summary>
            ///F15 key
            ///</summary>
            F15 = 0x7E,
            ///<summary>
            ///F16 key
            ///</summary>
            F16 = 0x7F,
            ///<summary>
            ///F17 key  
            ///</summary>
            F17 = 0x80,
            ///<summary>
            ///F18 key  
            ///</summary>
            F18 = 0x81,
            ///<summary>
            ///F19 key  
            ///</summary>
            F19 = 0x82,
            ///<summary>
            ///F20 key  
            ///</summary>
            F20 = 0x83,
            ///<summary>
            ///F21 key  
            ///</summary>
            F21 = 0x84,
            ///<summary>
            ///F22 key, (PPC only) Key used to lock device.
            ///</summary>
            F22 = 0x85,
            ///<summary>
            ///F23 key  
            ///</summary>
            F23 = 0x86,
            ///<summary>
            ///F24 key  
            ///</summary>
            F24 = 0x87,
            ///<summary>
            ///NUM LOCK key
            ///</summary>
            NUMLOCK = 0x90,
            ///<summary>
            ///SCROLL LOCK key
            ///</summary>
            SCROLL = 0x91,
            ///<summary>
            ///Left SHIFT key
            ///</summary>
            LSHIFT = 0xA0,
            ///<summary>
            ///Right SHIFT key
            ///</summary>
            RSHIFT = 0xA1,
            ///<summary>
            ///Left CONTROL key
            ///</summary>
            LCONTROL = 0xA2,
            ///<summary>
            ///Right CONTROL key
            ///</summary>
            RCONTROL = 0xA3,
            ///<summary>
            ///Left MENU key
            ///</summary>
            LMENU = 0xA4,
            ///<summary>
            ///Right MENU key
            ///</summary>
            RMENU = 0xA5,
            ///<summary>
            ///Windows 2000/XP: Browser Back key
            ///</summary>
            BROWSER_BACK = 0xA6,
            ///<summary>
            ///Windows 2000/XP: Browser Forward key
            ///</summary>
            BROWSER_FORWARD = 0xA7,
            ///<summary>
            ///Windows 2000/XP: Browser Refresh key
            ///</summary>
            BROWSER_REFRESH = 0xA8,
            ///<summary>
            ///Windows 2000/XP: Browser Stop key
            ///</summary>
            BROWSER_STOP = 0xA9,
            ///<summary>
            ///Windows 2000/XP: Browser Search key 
            ///</summary>
            BROWSER_SEARCH = 0xAA,
            ///<summary>
            ///Windows 2000/XP: Browser Favorites key
            ///</summary>
            BROWSER_FAVORITES = 0xAB,
            ///<summary>
            ///Windows 2000/XP: Browser Start and Home key
            ///</summary>
            BROWSER_HOME = 0xAC,
            ///<summary>
            ///Windows 2000/XP: Volume Mute key
            ///</summary>
            VOLUME_MUTE = 0xAD,
            ///<summary>
            ///Windows 2000/XP: Volume Down key
            ///</summary>
            VOLUME_DOWN = 0xAE,
            ///<summary>
            ///Windows 2000/XP: Volume Up key
            ///</summary>
            VOLUME_UP = 0xAF,
            ///<summary>
            ///Windows 2000/XP: Next Track key
            ///</summary>
            MEDIA_NEXT_TRACK = 0xB0,
            ///<summary>
            ///Windows 2000/XP: Previous Track key
            ///</summary>
            MEDIA_PREV_TRACK = 0xB1,
            ///<summary>
            ///Windows 2000/XP: Stop Media key
            ///</summary>
            MEDIA_STOP = 0xB2,
            ///<summary>
            ///Windows 2000/XP: Play/Pause Media key
            ///</summary>
            MEDIA_PLAY_PAUSE = 0xB3,
            ///<summary>
            ///Windows 2000/XP: Start Mail key
            ///</summary>
            LAUNCH_MAIL = 0xB4,
            ///<summary>
            ///Windows 2000/XP: Select Media key
            ///</summary>
            LAUNCH_MEDIA_SELECT = 0xB5,
            ///<summary>
            ///Windows 2000/XP: Start Application 1 key
            ///</summary>
            LAUNCH_APP1 = 0xB6,
            ///<summary>
            ///Windows 2000/XP: Start Application 2 key
            ///</summary>
            LAUNCH_APP2 = 0xB7,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_1 = 0xBA,
            ///<summary>
            ///Windows 2000/XP: For any country/region, the '+' key
            ///</summary>
            OEM_PLUS = 0xBB,
            ///<summary>
            ///Windows 2000/XP: For any country/region, the ',' key
            ///</summary>
            OEM_COMMA = 0xBC,
            ///<summary>
            ///Windows 2000/XP: For any country/region, the '-' key
            ///</summary>
            OEM_MINUS = 0xBD,
            ///<summary>
            ///Windows 2000/XP: For any country/region, the '.' key
            ///</summary>
            OEM_PERIOD = 0xBE,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_2 = 0xBF,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            OEM_3 = 0xC0,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            OEM_4 = 0xDB,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            OEM_5 = 0xDC,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            OEM_6 = 0xDD,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            OEM_7 = 0xDE,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_8 = 0xDF,
            ///<summary>
            ///Windows 2000/XP: Either the angle bracket key or the backslash key on the RT 102-key keyboard
            ///</summary>
            OEM_102 = 0xE2,
            ///<summary>
            ///Windows 95/98/Me, Windows NT 4.0, Windows 2000/XP: IME PROCESS key
            ///</summary>
            PROCESSKEY = 0xE5,
            ///<summary>
            ///Windows 2000/XP: Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
            ///</summary>
            PACKET = 0xE7,
            ///<summary>
            ///Attn key
            ///</summary>
            ATTN = 0xF6,
            ///<summary>
            ///CrSel key
            ///</summary>
            CRSEL = 0xF7,
            ///<summary>
            ///ExSel key
            ///</summary>
            EXSEL = 0xF8,
            ///<summary>
            ///Erase EOF key
            ///</summary>
            EREOF = 0xF9,
            ///<summary>
            ///Play key
            ///</summary>
            PLAY = 0xFA,
            ///<summary>
            ///Zoom key
            ///</summary>
            ZOOM = 0xFB,
            ///<summary>
            ///Reserved 
            ///</summary>
            NONAME = 0xFC,
            ///<summary>
            ///PA1 key
            ///</summary>
            PA1 = 0xFD,
            ///<summary>
            ///Clear key
            ///</summary>
            OEM_CLEAR = 0xFE,
            UNKNOWN
        }
        public struct KeyInput {
            public VirtualKeys vk;
            public byte scan;
            public bool isExtendedKey;
        }

        public static Dictionary<string, KeyInput> vkMap = new Dictionary<string, KeyInput>() {
            { "a",           new KeyInput { vk = VirtualKeys.KEY_A, scan = 0x1e } },
            { "b",           new KeyInput { vk = VirtualKeys.KEY_B, scan = 0x30 } },
            { "c",           new KeyInput { vk = VirtualKeys.KEY_C, scan = 0x2e } },
            { "d",           new KeyInput { vk = VirtualKeys.KEY_D, scan = 0x20 } },
            { "e",           new KeyInput { vk = VirtualKeys.KEY_E, scan = 0x12 } },
            { "f",           new KeyInput { vk = VirtualKeys.KEY_F, scan = 0x21 } },
            { "g",           new KeyInput { vk = VirtualKeys.KEY_G, scan = 0x22 } },
            { "h",           new KeyInput { vk = VirtualKeys.KEY_H, scan = 0x23 } },
            { "i",           new KeyInput { vk = VirtualKeys.KEY_I, scan = 0x17 } },
            { "j",           new KeyInput { vk = VirtualKeys.KEY_J, scan = 0x24 } },
            { "k",           new KeyInput { vk = VirtualKeys.KEY_K, scan = 0x25 } },
            { "l",           new KeyInput { vk = VirtualKeys.KEY_L, scan = 0x26 } },
            { "m",           new KeyInput { vk = VirtualKeys.KEY_M, scan = 0x32 } },
            { "n",           new KeyInput { vk = VirtualKeys.KEY_N, scan = 0x31 } },
            { "o",           new KeyInput { vk = VirtualKeys.KEY_O, scan = 0x18 } },
            { "p",           new KeyInput { vk = VirtualKeys.KEY_P, scan = 0x19 } },
            { "q",           new KeyInput { vk = VirtualKeys.KEY_Q, scan = 0x10 } },
            { "r",           new KeyInput { vk = VirtualKeys.KEY_R, scan = 0x13 } },
            { "s",           new KeyInput { vk = VirtualKeys.KEY_S, scan = 0x1f } },
            { "t",           new KeyInput { vk = VirtualKeys.KEY_T, scan = 0x14 } },
            { "u",           new KeyInput { vk = VirtualKeys.KEY_U, scan = 0x16 } },
            { "v",           new KeyInput { vk = VirtualKeys.KEY_V, scan = 0x2f } },
            { "w",           new KeyInput { vk = VirtualKeys.KEY_W, scan = 0x11 } },
            { "x",           new KeyInput { vk = VirtualKeys.KEY_X, scan = 0x2d } },
            { "y",           new KeyInput { vk = VirtualKeys.KEY_Y, scan = 0x15 } },
            { "z",           new KeyInput { vk = VirtualKeys.KEY_Z, scan = 0x2c } },
            { "0",           new KeyInput { vk = VirtualKeys.KEY_0, scan = 0x0b } },
            { "1",           new KeyInput { vk = VirtualKeys.KEY_1, scan = 0x02 } },
            { "2",           new KeyInput { vk = VirtualKeys.KEY_2, scan = 0x03 } },
            { "3",           new KeyInput { vk = VirtualKeys.KEY_3, scan = 0x04 } },
            { "4",           new KeyInput { vk = VirtualKeys.KEY_4, scan = 0x05 } },
            { "5",           new KeyInput { vk = VirtualKeys.KEY_5, scan = 0x06 } },
            { "6",           new KeyInput { vk = VirtualKeys.KEY_6, scan = 0x07 } },
            { "7",           new KeyInput { vk = VirtualKeys.KEY_7, scan = 0x08 } },
            { "8",           new KeyInput { vk = VirtualKeys.KEY_8, scan = 0x09 } },
            { "9",           new KeyInput { vk = VirtualKeys.KEY_9, scan = 0x0a } },
            { "f1",          new KeyInput { vk = VirtualKeys.F1, scan = 0x3b } },
            { "f2",          new KeyInput { vk = VirtualKeys.F2, scan = 0x3c } },
            { "f3",          new KeyInput { vk = VirtualKeys.F3, scan = 0x3d } },
            { "f4",          new KeyInput { vk = VirtualKeys.F4, scan = 0x3e } },
            { "f5",          new KeyInput { vk = VirtualKeys.F5, scan = 0x3f } },
            { "f6",          new KeyInput { vk = VirtualKeys.F6, scan = 0x40 } },
            { "f7",          new KeyInput { vk = VirtualKeys.F7, scan = 0x41 } },
            { "f8",          new KeyInput { vk = VirtualKeys.F8, scan = 0x42 } },
            { "f9",          new KeyInput { vk = VirtualKeys.F9, scan = 0x43 } },
            { "f10",         new KeyInput { vk = VirtualKeys.F10, scan = 0x44 } },
            { "f11",         new KeyInput { vk = VirtualKeys.F11, scan = 0xd9 } },
            { "f12",         new KeyInput { vk = VirtualKeys.F12, scan = 0xda } },
            { "shift",       new KeyInput { vk = VirtualKeys.LSHIFT, scan = 0x2a } },
            { "right shift", new KeyInput { vk = VirtualKeys.RSHIFT, scan = 0x36 } },
            { "ctrl",        new KeyInput { vk = VirtualKeys.LCONTROL, scan = 0x1d } },
            { "right ctrl",  new KeyInput { vk = VirtualKeys.RCONTROL, scan = 0x1d, isExtendedKey = true } },
            { "alt",         new KeyInput { vk = VirtualKeys.MENU, scan = 0x38 } },
            { "right alt",   new KeyInput { vk = VirtualKeys.RMENU, scan = 0x38, isExtendedKey = true } },
            { "win",         new KeyInput { vk = VirtualKeys.LWIN } },
            { "right win",   new KeyInput { vk = VirtualKeys.RWIN } },
            { "page up",     new KeyInput { vk = VirtualKeys.PRIOR, scan = 0x49, isExtendedKey = true } },
            { "page down",   new KeyInput { vk = VirtualKeys.NEXT, scan = 0x51, isExtendedKey = true } },
            { "tab",         new KeyInput { vk = VirtualKeys.TAB, scan = 0x0f } },
            { "backspace",   new KeyInput { vk = VirtualKeys.BACK, scan = 0x0e } },
            { "spacebar",    new KeyInput { vk = VirtualKeys.SPACE, scan = 0x39 } },
            { "pause",       new KeyInput { vk = VirtualKeys.PAUSE } },
            { "caps lock",   new KeyInput { vk = VirtualKeys.CAPITAL, scan = 0x3a } },
            { "num lock",    new KeyInput { vk = VirtualKeys.NUMLOCK, scan = 0xc5 } },
            { "scroll lock", new KeyInput { vk = VirtualKeys.SCROLL, scan = 0x46 } },
            { "printscreen", new KeyInput { vk = VirtualKeys.SNAPSHOT, scan =  0x6e } },
            { "insert",      new KeyInput { vk = VirtualKeys.INSERT, scan = 0x52, isExtendedKey = true } },
            { "delete",      new KeyInput { vk = VirtualKeys.DELETE, scan = 0x53, isExtendedKey = true } },
            { "select",      new KeyInput { vk = VirtualKeys.SELECT } },
            { ",",           new KeyInput { vk = VirtualKeys.OEM_COMMA, scan = 0x33 } },
            { ".",           new KeyInput { vk = VirtualKeys.OEM_PERIOD, scan = 0x34 } },
            { "=",           new KeyInput { vk = VirtualKeys.OEM_PLUS, scan = 0x0d } },
            { "+",           new KeyInput { vk = VirtualKeys.OEM_PLUS, scan = 0x0d } },
            { "-",           new KeyInput { vk = VirtualKeys.OEM_MINUS, scan = 0x0c } },
            { "esc",         new KeyInput { vk = VirtualKeys.ESCAPE, scan = 0x01 } },
            { ";",           new KeyInput { vk = VirtualKeys.OEM_1, scan = 0x27 } },
            { "/",           new KeyInput { vk = VirtualKeys.OEM_2, scan = 0x35 } },
            { "`",           new KeyInput { vk = VirtualKeys.OEM_3, scan = 0x29 } },
            { "[",           new KeyInput { vk = VirtualKeys.OEM_4, scan = 0x1a } },
            { "\\",          new KeyInput { vk = VirtualKeys.OEM_5, scan = 0xd5 } },
            { "]",           new KeyInput { vk = VirtualKeys.OEM_6, scan = 0x1b } },
            { "\'",          new KeyInput { vk = VirtualKeys.OEM_7, scan = 0x28 } },
            { "numpad -",    new KeyInput { vk = VirtualKeys.SUBTRACT, scan = 0x4a } },
            { "numpad +",    new KeyInput { vk = VirtualKeys.ADD, scan = 0x4e } },
            { "numpad .",    new KeyInput { vk = VirtualKeys.DECIMAL, scan = 0x53 } },
            { "numpad /",    new KeyInput { vk = VirtualKeys.DIVIDE, scan = 0x35, isExtendedKey = true } },
            { "numpad *",    new KeyInput { vk = VirtualKeys.MULTIPLY, scan = 0x37, isExtendedKey = true } },
            { "numpad 0",    new KeyInput { vk = VirtualKeys.NUMPAD0, scan = 0x52 } },
            { "numpad 1",    new KeyInput { vk = VirtualKeys.NUMPAD1, scan = 0x4f } },
            { "numpad 2",    new KeyInput { vk = VirtualKeys.NUMPAD2, scan = 0x50 } },
            { "numpad 3",    new KeyInput { vk = VirtualKeys.NUMPAD3, scan = 0x51 } },
            { "numpad 4",    new KeyInput { vk = VirtualKeys.NUMPAD4, scan = 0x4b } },
            { "numpad 5",    new KeyInput { vk = VirtualKeys.NUMPAD5, scan = 0x4c } },
            { "numpad 6",    new KeyInput { vk = VirtualKeys.NUMPAD6, scan = 0x4d } },
            { "numpad 7",    new KeyInput { vk = VirtualKeys.NUMPAD7, scan = 0x47 } },
            { "numpad 8",    new KeyInput { vk = VirtualKeys.NUMPAD8, scan = 0x48 } },
            { "numpad 9",    new KeyInput { vk = VirtualKeys.NUMPAD9, scan = 0x49 } },
            { "\0",          new KeyInput { vk = VirtualKeys.SPACE, scan = 0x39 } },
            { "enter",       new KeyInput { vk = VirtualKeys.RETURN, scan = 0x1c, isExtendedKey = true } },
            { "\n",          new KeyInput { vk = VirtualKeys.RETURN, scan = 0x1c, isExtendedKey = true } },
            { "left arrow",  new KeyInput { vk = VirtualKeys.LEFT, scan = 0x4b, isExtendedKey = true  } },
            { "up arrow",    new KeyInput { vk = VirtualKeys.UP, scan = 0x48, isExtendedKey = true   } },
            { "right arrow", new KeyInput { vk = VirtualKeys.RIGHT, scan = 0x4d, isExtendedKey = true } },
            { "down arrow",  new KeyInput { vk = VirtualKeys.DOWN, scan = 0x50, isExtendedKey = true } },
            { "hangul",      new KeyInput { vk = VirtualKeys.HANGUL } },
            { "hanja",       new KeyInput { vk = VirtualKeys.HANJA } },
            { "kanji",       new KeyInput { vk = VirtualKeys.KANJI } },
            { "kana",        new KeyInput { vk = VirtualKeys.KANA } },
            { "junja",       new KeyInput { vk = VirtualKeys.JUNJA } },
            { "final",       new KeyInput { vk = VirtualKeys.FINAL } },
            { "home",        new KeyInput { vk = VirtualKeys.HOME, scan = 0x47 } },
            { "end",         new KeyInput { vk = VirtualKeys.END, scan = 0x4f, isExtendedKey = true } }
        };

        static string specialChars = "!@#$%^&*()_+|{}:<>?\"~";
        static Dictionary<char, char> SpecialCharAlternatives = new Dictionary<char, char>() {
            { '~', '`' },
            { '!', '1' },
            { '@', '2' },
            { '#', '3' },
            { '$', '4' },
            { '%', '5' },
            { '^', '6' },
            { '&', '7' },
            { '*', '8' },
            { '(', '9' },
            { ')', '0' },
            { '_', '-' },
            { '+', '=' },
            { '|', '\\' },
            { '{', '[' },
            { '}', ']' },
            { ':', ';' },
            { '"', '\'' },
            { '<', ',' },
            { '>', '.' },
            { '?', '/' },
        };

        [Flags]
        public enum KeyFlags {
            KEYEVENTF_EXTENDEDKEY = 0x00000001,
            KEYEVENTF_KEYUP = 0x0002
        };

        public static KeyInput GetKeyInput(string key) {
            KeyInput keyInput = new KeyInput() { vk = VirtualKeys.UNKNOWN, scan = 0x00 };
            if (vkMap.ContainsKey(key)) {
                keyInput = vkMap[key];
            }
            return keyInput;
        }

        public static void Trigger(KeyFlags flags, string key) {
            Trigger(flags, GetKeyInput(key));
        }

        public static void Trigger(KeyFlags flags, KeyInput key) {
            DLL.keybd_event((byte)key.vk, (byte)key.scan, (uint)flags, 1);
        }

        public static void Press(string key) {
            KeyInput keyInput = GetKeyInput(key);
            Trigger((keyInput.isExtendedKey ? KeyFlags.KEYEVENTF_EXTENDEDKEY : 0) | 0, keyInput);
        }

        public static void Press(KeyInput keyInput) {
            Trigger((keyInput.isExtendedKey ? KeyFlags.KEYEVENTF_EXTENDEDKEY : 0) | 0, keyInput);
        }

        public static void Release(string key) {
            KeyInput keyInput = GetKeyInput(key);
            Trigger((keyInput.isExtendedKey ? KeyFlags.KEYEVENTF_EXTENDEDKEY : 0) | KeyFlags.KEYEVENTF_KEYUP, keyInput);
        }

        public static void Release(KeyInput keyInput) {
            Trigger((keyInput.isExtendedKey ? KeyFlags.KEYEVENTF_EXTENDEDKEY : 0) | KeyFlags.KEYEVENTF_KEYUP, keyInput);
        }

        public static bool IsSpecialChar(char c) {
            foreach (char specialChar in specialChars) {
                if (c == specialChar) {
                    return true;
                }
            }
            return false;
        }

        public static void Type(char c) {
            string s;
            if (IsSpecialChar(c)) {
                Keyboard.Press("shift");
                s = SpecialCharAlternatives[c].ToString();
                Keyboard.Press(s);
                Keyboard.Release(s);
                Keyboard.Release("shift");
            } else {
                s = c.ToString();
                Keyboard.Press(s);
                Keyboard.Release(s);
            }
        }

        public static void Write(string str, int delay = 0) {
            if (delay == 0) {
                foreach (char c in str) {
                    Type(c);
                }
            } else {
                new Thread(new ThreadStart(() => {
                    foreach (char c in str) {
                        Type(c);
                        Thread.Sleep(delay);
                    }
                })).Start();
            }
        }

        public static void WriteLine(string str, int delay = 0) {
            Write(str + '\n', delay);
        }
    }
}
