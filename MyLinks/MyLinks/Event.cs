using System;
using System.Windows.Forms;

namespace MyLinks
{
    internal class Event
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint control, Keys vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        
        public static Keys GetKeys(string keyName)
        {
            Keys vkey;
            switch (keyName)
            {
                case "BACKSPACE 键":
                    vkey = Keys.Back;
                    break;
                case "TAB 键":
                    vkey = Keys.Tab;
                    break;
                case "ENTER 键":
                    vkey = Keys.Enter;
                    break;
                case "PAUSE 键":
                    vkey = Keys.Pause;
                    break;
                case "CAPS LOCK 键":
                    vkey = Keys.CapsLock;
                    break;
                case "ESC 键":
                    vkey = Keys.Escape;
                    break;
                case "SPACEBAR 键":
                    vkey = Keys.Space;
                    break;
                case "PAGE UP 键":
                    vkey = Keys.PageUp;
                    break;
                case "PAGE DOWN 键":
                    vkey = Keys.PageDown;
                    break;
                case "END 键":
                    vkey = Keys.End;
                    break;
                case "HOME 键":
                    vkey = Keys.Home;
                    break;
                case "LEFT ARROW 键":
                    vkey = Keys.Left;
                    break;
                case "UP ARROW 键":
                    vkey = Keys.Up;
                    break;
                case "RIGHT ARROW 键":
                    vkey = Keys.Right;
                    break;
                case "DOWN ARROW 键":
                    vkey = Keys.Down;
                    break;
                case "PRINT SCREEN 键":
                    vkey = Keys.PrintScreen;
                    break;
                case "INSERT 键":
                    vkey = Keys.Insert;
                    break;
                case "DELETE 键":
                    vkey = Keys.Delete;
                    break;
                case "0 键":
                    vkey = Keys.D0;
                    break;
                case "1 键":
                    vkey = Keys.D1;
                    break;
                case "2 键":
                    vkey = Keys.D2;
                    break;
                case "3 键":
                    vkey = Keys.D3;
                    break;
                case "4 键":
                    vkey = Keys.D4;
                    break;
                case "5 键":
                    vkey = Keys.D5;
                    break;
                case "6 键":
                    vkey = Keys.D6;
                    break;
                case "7 键":
                    vkey = Keys.D7;
                    break;
                case "8 键":
                    vkey = Keys.D8;
                    break;
                case "9 键":
                    vkey = Keys.D9;
                    break;
                case "A 键":
                    vkey = Keys.A;
                    break;
                case "B 键":
                    vkey = Keys.B;
                    break;
                case "C 键":
                    vkey = Keys.C;
                    break;
                case "D 键":
                    vkey = Keys.D;
                    break;
                case "E 键":
                    vkey = Keys.E;
                    break;
                case "F 键":
                    vkey = Keys.F;
                    break;
                case "G 键":
                    vkey = Keys.G;
                    break;
                case "H 键":
                    vkey = Keys.H;
                    break;
                case "I 键":
                    vkey = Keys.I;
                    break;
                case "J 键":
                    vkey = Keys.J;
                    break;
                case "K 键":
                    vkey = Keys.K;
                    break;
                case "L 键":
                    vkey = Keys.L;
                    break;
                case "M 键":
                    vkey = Keys.M;
                    break;
                case "N 键":
                    vkey = Keys.N;
                    break;
                case "O 键":
                    vkey = Keys.O;
                    break;
                case "P 键":
                    vkey = Keys.P;
                    break;
                case "Q 键":
                    vkey = Keys.Q;
                    break;
                case "R 键":
                    vkey = Keys.R;
                    break;
                case "S 键":
                    vkey = Keys.S;
                    break;
                case "T 键":
                    vkey = Keys.T;
                    break;
                case "U 键":
                    vkey = Keys.U;
                    break;
                case "V 键":
                    vkey = Keys.V;
                    break;
                case "W 键":
                    vkey = Keys.W;
                    break;
                case "X 键":
                    vkey = Keys.X;
                    break;
                case "Y 键":
                    vkey = Keys.Y;
                    break;
                case "Z 键":
                    vkey = Keys.Z;
                    break;
                case "数字键盘上的 0 键":
                    vkey = Keys.NumPad0;
                    break;
                case "数字键盘上的 1 键":
                    vkey = Keys.NumPad1;
                    break;
                case "数字键盘上的 2 键":
                    vkey = Keys.NumPad2;
                    break;
                case "数字键盘上的 3 键":
                    vkey = Keys.NumPad3;
                    break;
                case "数字键盘上的 4 键":
                    vkey = Keys.NumPad4;
                    break;
                case "数字键盘上的 5 键":
                    vkey = Keys.NumPad5;
                    break;
                case "数字键盘上的 6 键":
                    vkey = Keys.NumPad6;
                    break;
                case "数字键盘上的 7 键":
                    vkey = Keys.NumPad7;
                    break;
                case "数字键盘上的 8 键":
                    vkey = Keys.NumPad8;
                    break;
                case "数字键盘上的 9 键":
                    vkey = Keys.NumPad9;
                    break;
                case "数字键盘上的乘号键":
                    vkey = Keys.Multiply;
                    break;
                case "数字键盘上的加号键":
                    vkey = Keys.Add;
                    break;
                case "数字键盘上的减号键":
                    vkey = Keys.Subtract;
                    break;
                case "数字键盘上的除号键":
                    vkey = Keys.Divide;
                    break;
                case "F1 键":
                    vkey = Keys.F1;
                    break;
                case "F2 键":
                    vkey = Keys.F2;
                    break;
                case "F3 键":
                    vkey = Keys.F3;
                    break;
                case "F4 键":
                    vkey = Keys.F4;
                    break;
                case "F5 键":
                    vkey = Keys.F5;
                    break;
                case "F6 键":
                    vkey = Keys.F6;
                    break;
                case "F7 键":
                    vkey = Keys.F7;
                    break;
                case "F8 键":
                    vkey = Keys.F8;
                    break;
                case "F9 键":
                    vkey = Keys.F9;
                    break;
                case "F10 键":
                    vkey = Keys.F10;
                    break;
                case "F11 键":
                    vkey = Keys.F11;
                    break;
                case "F12 键":
                    vkey = Keys.F12;
                    break;
                case "NUM LOCK 键":
                    vkey = Keys.NumLock;
                    break;
                case "SCROLL LOCK 键":
                    vkey = Keys.Scroll;
                    break;
                case "分号键":
                    vkey = Keys.OemSemicolon;
                    break;
                case "等于号键":
                    vkey = Keys.Oemplus;
                    break;
                case "逗号键":
                    vkey = Keys.Oemcomma;
                    break;
                case "减号键":
                    vkey = Keys.OemMinus;
                    break;
                case "句号键":
                    vkey = Keys.OemPeriod;
                    break;
                case "问号键":
                    vkey = Keys.OemQuestion;
                    break;
                case "颚化符键":
                    vkey = Keys.Oemtilde;
                    break;
                case "左中括号键":
                    vkey = Keys.OemOpenBrackets;
                    break;
                case "管道符键":
                    vkey = Keys.OemPipe;
                    break;
                case "右中括号键":
                    vkey = Keys.OemCloseBrackets;
                    break;
                case "引号键":
                    vkey = Keys.OemQuotes;
                    break;
                default:
                    vkey = Keys.None;
                    break;
            }
            return vkey;
        }

    }
}
