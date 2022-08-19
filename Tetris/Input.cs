using SFML.System;
using SFML.Window;

namespace Tetris
{
    public enum KeyState
    {
        down,      // first frame when button is pressed
        pressed,   // 2nd frame when button is pressed until it is released
        up,        // first frame when button is released
        released   // button is not pressed
    }

    //public enum Keys
    //{
    //    Unknown,
    //    A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z,
    //    Nr0, Nr1, Nr2, Nr3, Nr4, Nr5, Nr6, Nr7, Nr8, Nr9,
    //    Numpad0, Numpad1, Numpad2, Numpad3, Numpad4, Numpad5, Numpad6, Numpad7, Numpad8, Numpad9,
    //    F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12,
    //    LCtrl, RCtrl, LShift, RShift, LAlt, RAlt, LSys, RSys,
    //    PageUp, PageDown, Home, End, Insert, Delete, Print, Menu, Pause,
    //    Backspace, Enter, Tab, Space, Esc,
    //    Add, Subtract, Divide, Multiply, Left, Right, Up, Down,
    //    LBracket, RBracket, Semicolon, Comma, Perios, Slash, Backslash, Tilde, Equal, Hyphen
    //}

    public class Keyboard
    {
        public KeyState A = KeyState.released;
        public KeyState B = KeyState.released; 
        public KeyState C = KeyState.released; 
        public KeyState D = KeyState.released; 
        public KeyState E = KeyState.released; 
        public KeyState F = KeyState.released; 
        public KeyState G = KeyState.released; 
        public KeyState H = KeyState.released; 
        public KeyState I = KeyState.released; 
        public KeyState J = KeyState.released; 
        public KeyState K = KeyState.released; 
        public KeyState L = KeyState.released; 
        public KeyState M = KeyState.released; 
        public KeyState N = KeyState.released; 
        public KeyState O = KeyState.released; 
        public KeyState P = KeyState.released; 
        public KeyState Q = KeyState.released; 
        public KeyState R = KeyState.released; 
        public KeyState S = KeyState.released; 
        public KeyState T = KeyState.released; 
        public KeyState U = KeyState.released; 
        public KeyState V = KeyState.released; 
        public KeyState W = KeyState.released; 
        public KeyState X = KeyState.released; 
        public KeyState Y = KeyState.released; 
        public KeyState Z = KeyState.released; 
        public KeyState Nr0 = KeyState.released; 
        public KeyState Nr1 = KeyState.released; 
        public KeyState Nr2 = KeyState.released; 
        public KeyState Nr3 = KeyState.released; 
        public KeyState Nr4 = KeyState.released; 
        public KeyState Nr5 = KeyState.released; 
        public KeyState Nr6 = KeyState.released; 
        public KeyState Nr7 = KeyState.released; 
        public KeyState Nr8 = KeyState.released; 
        public KeyState Nr9 = KeyState.released; 
        public KeyState Numpad0 = KeyState.released; 
        public KeyState Numpad1 = KeyState.released; 
        public KeyState Numpad2 = KeyState.released; 
        public KeyState Numpad3 = KeyState.released; 
        public KeyState Numpad4 = KeyState.released; 
        public KeyState Numpad5 = KeyState.released; 
        public KeyState Numpad6 = KeyState.released; 
        public KeyState Numpad7 = KeyState.released; 
        public KeyState Numpad8 = KeyState.released; 
        public KeyState Numpad9 = KeyState.released; 
        public KeyState F1 = KeyState.released; 
        public KeyState F2 = KeyState.released; 
        public KeyState F3 = KeyState.released; 
        public KeyState F4 = KeyState.released; 
        public KeyState F5 = KeyState.released; 
        public KeyState F6 = KeyState.released; 
        public KeyState F7 = KeyState.released; 
        public KeyState F8 = KeyState.released; 
        public KeyState F9 = KeyState.released; 
        public KeyState F10 = KeyState.released; 
        public KeyState F11 = KeyState.released; 
        public KeyState F12 = KeyState.released; 
        public KeyState LCtrl = KeyState.released; 
        public KeyState RCtrl = KeyState.released; 
        public KeyState LShift = KeyState.released; 
        public KeyState RShift = KeyState.released; 
        public KeyState LAlt = KeyState.released; 
        public KeyState RAlt = KeyState.released; 
        public KeyState LSys = KeyState.released; 
        public KeyState RSys = KeyState.released; 
        public KeyState PageUp = KeyState.released; 
        public KeyState PageDown = KeyState.released; 
        public KeyState Home = KeyState.released; 
        public KeyState End = KeyState.released; 
        public KeyState Insert = KeyState.released; 
        public KeyState Delete = KeyState.released; 
        public KeyState Print = KeyState.released; 
        public KeyState Menu = KeyState.released; 
        public KeyState Pause = KeyState.released; 
        public KeyState Backspace = KeyState.released; 
        public KeyState Enter = KeyState.released; 
        public KeyState Tab = KeyState.released; 
        public KeyState Space = KeyState.released; 
        public KeyState Esc = KeyState.released; 
        public KeyState Add = KeyState.released; 
        public KeyState Subtract = KeyState.released; 
        public KeyState Divide = KeyState.released; 
        public KeyState Multiply = KeyState.released; 
        public KeyState Left = KeyState.released; 
        public KeyState Right = KeyState.released; 
        public KeyState Up = KeyState.released; 
        public KeyState Down = KeyState.released; 
        public KeyState LBracket = KeyState.released; 
        public KeyState RBracket = KeyState.released; 
        public KeyState Semicolon = KeyState.released; 
        public KeyState Comma = KeyState.released; 
        public KeyState Perios = KeyState.released; 
        public KeyState Slash = KeyState.released; 
        public KeyState Backslash = KeyState.released; 
        public KeyState Tilde = KeyState.released; 
        public KeyState Equal = KeyState.released; 
        public KeyState Hyphen = KeyState.released;
        public KeyState Quote = KeyState.released;
        public KeyState Period = KeyState.released;
    }

    public static class Input
    {
        public static Keyboard Keyboard { get; private set; } = new Keyboard();

        public static void Update()
        {
            foreach (var key in typeof(Keyboard).GetFields())
            {
                foreach (SFML.Window.Keyboard.Key SFMLKey in Enum.GetValues(typeof(SFML.Window.Keyboard.Key)))
                {
                    if (key.Name == SFMLKey.ToString())
                    {
                        KeyState state = (KeyState)key.GetValue(Keyboard);
                        if (SFML.Window.Keyboard.IsKeyPressed(SFMLKey))
                        {
                            if (state == KeyState.down) key.SetValue(Keyboard, KeyState.pressed);
                            else if (state != KeyState.pressed) key.SetValue(Keyboard, KeyState.down);
                        }
                        else
                        {
                            if (state == KeyState.up) key.SetValue(Keyboard, KeyState.released);
                            else if (state != KeyState.released) key.SetValue(Keyboard, KeyState.up);
                        }
                    }
                }
            }
        }

        public static void OnKeyPress(object sender, KeyEventArgs e)
        { 
            switch (e.Code)
            {
                case SFML.Window.Keyboard.Key.A:
                    if (Keyboard.A == KeyState.down) Keyboard.A = KeyState.pressed;
                    if (Keyboard.A == KeyState.released || Keyboard.A == KeyState.up) Keyboard.A = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.B:
                    if (Keyboard.B == KeyState.down) Keyboard.B = KeyState.pressed;
                    if (Keyboard.B == KeyState.released || Keyboard.B == KeyState.up) Keyboard.B = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.C:
                    if (Keyboard.C == KeyState.down) Keyboard.C = KeyState.pressed;
                    if (Keyboard.C == KeyState.released || Keyboard.C == KeyState.up) Keyboard.C = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.D:
                    if (Keyboard.D == KeyState.down) Keyboard.D = KeyState.pressed;
                    if (Keyboard.D == KeyState.released || Keyboard.D == KeyState.up) Keyboard.D = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.E:
                    if (Keyboard.E == KeyState.down) Keyboard.E = KeyState.pressed;
                    if (Keyboard.E == KeyState.released || Keyboard.E == KeyState.up) Keyboard.E = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.F:
                    if (Keyboard.F == KeyState.down) Keyboard.F = KeyState.pressed;
                    if (Keyboard.F == KeyState.released || Keyboard.F == KeyState.up) Keyboard.F = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.G:
                    if (Keyboard.G == KeyState.down) Keyboard.G = KeyState.pressed;
                    if (Keyboard.G == KeyState.released || Keyboard.G == KeyState.up) Keyboard.G = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.H:
                    if (Keyboard.H == KeyState.down) Keyboard.H = KeyState.pressed;
                    if (Keyboard.H == KeyState.released || Keyboard.H == KeyState.up) Keyboard.H = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.I:
                    if (Keyboard.I == KeyState.down) Keyboard.I = KeyState.pressed;
                    if (Keyboard.I == KeyState.released || Keyboard.I == KeyState.up) Keyboard.I = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.J:
                    if (Keyboard.J == KeyState.down) Keyboard.J = KeyState.pressed;
                    if (Keyboard.J == KeyState.released || Keyboard.J == KeyState.up) Keyboard.J = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.K:
                    if (Keyboard.K == KeyState.down) Keyboard.K = KeyState.pressed;
                    if (Keyboard.K == KeyState.released || Keyboard.K == KeyState.up) Keyboard.K = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.L:
                    if (Keyboard.L == KeyState.down) Keyboard.L = KeyState.pressed;
                    if (Keyboard.L == KeyState.released || Keyboard.L == KeyState.up) Keyboard.L = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.M:
                    if (Keyboard.M == KeyState.down) Keyboard.M = KeyState.pressed;
                    if (Keyboard.M == KeyState.released || Keyboard.M == KeyState.up) Keyboard.M = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.N:
                    if (Keyboard.N == KeyState.down) Keyboard.N = KeyState.pressed;
                    if (Keyboard.N == KeyState.released || Keyboard.N == KeyState.up) Keyboard.N = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.O:
                    if (Keyboard.O == KeyState.down) Keyboard.O = KeyState.pressed;
                    if (Keyboard.O == KeyState.released || Keyboard.O == KeyState.up) Keyboard.O = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.P:
                    if (Keyboard.P == KeyState.down) Keyboard.P = KeyState.pressed;
                    if (Keyboard.P == KeyState.released || Keyboard.P == KeyState.up) Keyboard.P = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Q:
                    if (Keyboard.Q == KeyState.down) Keyboard.Q = KeyState.pressed;
                    if (Keyboard.Q == KeyState.released || Keyboard.Q == KeyState.up) Keyboard.Q = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.R:
                    if (Keyboard.R == KeyState.down) Keyboard.R = KeyState.pressed;
                    if (Keyboard.R == KeyState.released || Keyboard.R == KeyState.up) Keyboard.R = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.S:
                    if (Keyboard.S == KeyState.down) Keyboard.S = KeyState.pressed;
                    if (Keyboard.S == KeyState.released || Keyboard.S == KeyState.up) Keyboard.S = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.T:
                    if (Keyboard.T == KeyState.down) Keyboard.T = KeyState.pressed;
                    if (Keyboard.T == KeyState.released || Keyboard.T == KeyState.up) Keyboard.T = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.U:
                    if (Keyboard.U == KeyState.down) Keyboard.U = KeyState.pressed;
                    if (Keyboard.U == KeyState.released || Keyboard.U == KeyState.up) Keyboard.U = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.V:
                    if (Keyboard.V == KeyState.down) Keyboard.V = KeyState.pressed;
                    if (Keyboard.V == KeyState.released || Keyboard.V == KeyState.up) Keyboard.V = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.W:
                    if (Keyboard.W == KeyState.down) Keyboard.W = KeyState.pressed;
                    if (Keyboard.W == KeyState.released || Keyboard.W == KeyState.up) Keyboard.W = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.X:
                    if (Keyboard.X == KeyState.down) Keyboard.X = KeyState.pressed;
                    if (Keyboard.X == KeyState.released || Keyboard.X == KeyState.up) Keyboard.X = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Y:
                    if (Keyboard.Y == KeyState.down) Keyboard.Y = KeyState.pressed;
                    if (Keyboard.Y == KeyState.released || Keyboard.Y == KeyState.up) Keyboard.Y = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Z:
                    if (Keyboard.Z == KeyState.down) Keyboard.Z = KeyState.pressed;
                    if (Keyboard.Z == KeyState.released || Keyboard.Z == KeyState.up) Keyboard.Z = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Num0:
                    if (Keyboard.Nr0 == KeyState.down) Keyboard.Nr0 = KeyState.pressed;
                    if (Keyboard.Nr0 == KeyState.released || Keyboard.Nr0 == KeyState.up) Keyboard.Nr0 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Num1:
                    if (Keyboard.Nr1 == KeyState.down) Keyboard.Nr1 = KeyState.pressed;
                    if (Keyboard.Nr1 == KeyState.released || Keyboard.Nr1 == KeyState.up) Keyboard.Nr1 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Num2:
                    if (Keyboard.Nr2 == KeyState.down) Keyboard.Nr2 = KeyState.pressed;
                    if (Keyboard.Nr2 == KeyState.released || Keyboard.Nr2 == KeyState.up) Keyboard.Nr2 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Num3:
                    if (Keyboard.Nr3 == KeyState.down) Keyboard.Nr3 = KeyState.pressed;
                    if (Keyboard.Nr3 == KeyState.released || Keyboard.Nr3 == KeyState.up) Keyboard.Nr3 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Num4:
                    if (Keyboard.Nr4 == KeyState.down) Keyboard.Nr4 = KeyState.pressed;
                    if (Keyboard.Nr4 == KeyState.released || Keyboard.Nr4 == KeyState.up) Keyboard.Nr4 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Num5:
                    if (Keyboard.Nr5 == KeyState.down) Keyboard.Nr5 = KeyState.pressed;
                    if (Keyboard.Nr5 == KeyState.released || Keyboard.Nr5 == KeyState.up) Keyboard.Nr5 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Num6:
                    if (Keyboard.Nr6 == KeyState.down) Keyboard.Nr6 = KeyState.pressed;
                    if (Keyboard.Nr6 == KeyState.released || Keyboard.Nr6 == KeyState.up) Keyboard.Nr6 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Num7:
                    if (Keyboard.Nr7 == KeyState.down) Keyboard.Nr7 = KeyState.pressed;
                    if (Keyboard.Nr7 == KeyState.released || Keyboard.Nr7 == KeyState.up) Keyboard.Nr7 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Num8:
                    if (Keyboard.Nr8 == KeyState.down) Keyboard.Nr8 = KeyState.pressed;
                    if (Keyboard.Nr8 == KeyState.released || Keyboard.Nr8 == KeyState.up) Keyboard.Nr8 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Num9:
                    if (Keyboard.Nr9 == KeyState.down) Keyboard.Nr9 = KeyState.pressed;
                    if (Keyboard.Nr9 == KeyState.released || Keyboard.Nr9 == KeyState.up) Keyboard.Nr9 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Escape:
                    if (Keyboard.Esc == KeyState.down) Keyboard.Esc = KeyState.pressed;
                    if (Keyboard.Esc == KeyState.released || Keyboard.Esc == KeyState.up) Keyboard.Esc = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.LControl:
                    if (Keyboard.LCtrl == KeyState.down) Keyboard.LCtrl = KeyState.pressed;
                    if (Keyboard.LCtrl == KeyState.released || Keyboard.LCtrl == KeyState.up) Keyboard.LCtrl = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.LShift:
                    if (Keyboard.LShift == KeyState.down) Keyboard.LShift = KeyState.pressed;
                    if (Keyboard.LShift == KeyState.released || Keyboard.LShift == KeyState.up) Keyboard.LShift = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.LAlt:
                    if (Keyboard.LAlt == KeyState.down) Keyboard.LAlt = KeyState.pressed;
                    if (Keyboard.LAlt == KeyState.released || Keyboard.LAlt == KeyState.up) Keyboard.LAlt = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.LSystem:
                    if (Keyboard.LSys == KeyState.down) Keyboard.LSys = KeyState.pressed;
                    if (Keyboard.LSys == KeyState.released || Keyboard.LSys == KeyState.up) Keyboard.LSys = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.RControl:
                    if (Keyboard.RCtrl == KeyState.down) Keyboard.RCtrl = KeyState.pressed;
                    if (Keyboard.RCtrl == KeyState.released || Keyboard.RCtrl == KeyState.up) Keyboard.RCtrl = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.RShift:
                    if (Keyboard.RShift == KeyState.down) Keyboard.RShift = KeyState.pressed;
                    if (Keyboard.RShift == KeyState.released || Keyboard.RShift == KeyState.up) Keyboard.RShift = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.RAlt:
                    if (Keyboard.RAlt == KeyState.down) Keyboard.RAlt = KeyState.pressed;
                    if (Keyboard.RAlt == KeyState.released || Keyboard.RAlt == KeyState.up) Keyboard.RAlt = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.RSystem:
                    if (Keyboard.RSys == KeyState.down) Keyboard.RSys = KeyState.pressed;
                    if (Keyboard.RSys == KeyState.released || Keyboard.RSys == KeyState.up) Keyboard.RSys = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Menu:
                    if (Keyboard.Menu == KeyState.down) Keyboard.Menu = KeyState.pressed;
                    if (Keyboard.Menu == KeyState.released || Keyboard.Menu == KeyState.up) Keyboard.Menu = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.LBracket:
                    if (Keyboard.LBracket == KeyState.down) Keyboard.LBracket = KeyState.pressed;
                    if (Keyboard.LBracket == KeyState.released || Keyboard.LBracket == KeyState.up) Keyboard.LBracket = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.RBracket:
                    if (Keyboard.RBracket == KeyState.down) Keyboard.RBracket = KeyState.pressed;
                    if (Keyboard.RBracket == KeyState.released || Keyboard.RBracket == KeyState.up) Keyboard.RBracket = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Semicolon:
                    if (Keyboard.Semicolon == KeyState.down) Keyboard.Semicolon = KeyState.pressed;
                    if (Keyboard.Semicolon == KeyState.released || Keyboard.Semicolon == KeyState.up) Keyboard.Semicolon = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Comma:
                    if (Keyboard.Comma == KeyState.down) Keyboard.Comma = KeyState.pressed;
                    if (Keyboard.Comma == KeyState.released || Keyboard.Comma == KeyState.up) Keyboard.Comma = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Period:
                    if (Keyboard.Period == KeyState.down) Keyboard.Period = KeyState.pressed;
                    if (Keyboard.Period == KeyState.released || Keyboard.Period == KeyState.up) Keyboard.Period = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Quote:
                    if (Keyboard.Quote == KeyState.down) Keyboard.Quote = KeyState.pressed;
                    if (Keyboard.Quote == KeyState.released || Keyboard.Quote == KeyState.up) Keyboard.Quote = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Slash:
                    if (Keyboard.Slash == KeyState.down) Keyboard.Slash = KeyState.pressed;
                    if (Keyboard.Slash == KeyState.released || Keyboard.Slash == KeyState.up) Keyboard.Slash = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Backslash:
                    if (Keyboard.Backslash == KeyState.down) Keyboard.Backslash = KeyState.pressed;
                    if (Keyboard.Backslash == KeyState.released || Keyboard.Backslash == KeyState.up) Keyboard.Backslash = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Tilde:
                    if (Keyboard.Tilde == KeyState.down) Keyboard.Tilde = KeyState.pressed;
                    if (Keyboard.Tilde == KeyState.released || Keyboard.Tilde == KeyState.up) Keyboard.Tilde = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Equal:
                    if (Keyboard.Equal == KeyState.down) Keyboard.Equal = KeyState.pressed;
                    if (Keyboard.Equal == KeyState.released || Keyboard.Equal == KeyState.up) Keyboard.Equal = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Hyphen:
                    if (Keyboard.Hyphen == KeyState.down) Keyboard.Hyphen = KeyState.pressed;
                    if (Keyboard.Hyphen == KeyState.released || Keyboard.Hyphen == KeyState.up) Keyboard.Hyphen = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Space:
                    if (Keyboard.Space == KeyState.down) Keyboard.Space = KeyState.pressed;
                    if (Keyboard.Space == KeyState.released || Keyboard.Space == KeyState.up) Keyboard.Space = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Enter:
                    if (Keyboard.Enter == KeyState.down) Keyboard.Enter = KeyState.pressed;
                    if (Keyboard.Enter == KeyState.released || Keyboard.Enter == KeyState.up) Keyboard.Enter = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Backspace:
                    if (Keyboard.Backspace == KeyState.down) Keyboard.Backspace = KeyState.pressed;
                    if (Keyboard.Backspace == KeyState.released || Keyboard.Backspace == KeyState.up) Keyboard.Backspace = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Tab:
                    if (Keyboard.Tab == KeyState.down) Keyboard.Tab = KeyState.pressed;
                    if (Keyboard.Tab == KeyState.released || Keyboard.Tab == KeyState.up) Keyboard.Tab = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.PageUp:
                    if (Keyboard.PageUp == KeyState.down) Keyboard.PageUp = KeyState.pressed;
                    if (Keyboard.PageUp == KeyState.released || Keyboard.PageUp == KeyState.up) Keyboard.PageUp = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.PageDown:
                    if (Keyboard.PageDown == KeyState.down) Keyboard.PageDown = KeyState.pressed;
                    if (Keyboard.PageDown == KeyState.released || Keyboard.PageDown == KeyState.up) Keyboard.PageDown = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.End:
                    if (Keyboard.End == KeyState.down) Keyboard.End = KeyState.pressed;
                    if (Keyboard.End == KeyState.released || Keyboard.End == KeyState.up) Keyboard.End = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Home:
                    if (Keyboard.Home == KeyState.down) Keyboard.Home = KeyState.pressed;
                    if (Keyboard.Home == KeyState.released || Keyboard.Home == KeyState.up) Keyboard.Home = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Insert:
                    if (Keyboard.Insert == KeyState.down) Keyboard.Insert = KeyState.pressed;
                    if (Keyboard.Insert == KeyState.released || Keyboard.Insert == KeyState.up) Keyboard.Insert = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Delete:
                    if (Keyboard.Delete == KeyState.down) Keyboard.Delete = KeyState.pressed;
                    if (Keyboard.Delete == KeyState.released || Keyboard.Delete == KeyState.up) Keyboard.Delete = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Add:
                    if (Keyboard.Add == KeyState.down) Keyboard.Add = KeyState.pressed;
                    if (Keyboard.Add == KeyState.released || Keyboard.Add == KeyState.up) Keyboard.Add = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Subtract:
                    if (Keyboard.Subtract == KeyState.down) Keyboard.Subtract = KeyState.pressed;
                    if (Keyboard.Subtract == KeyState.released || Keyboard.Subtract == KeyState.up) Keyboard.Subtract = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Multiply:
                    if (Keyboard.Multiply == KeyState.down) Keyboard.Multiply = KeyState.pressed;
                    if (Keyboard.Multiply == KeyState.released || Keyboard.Multiply == KeyState.up) Keyboard.Multiply = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Divide:
                    if (Keyboard.Divide == KeyState.down) Keyboard.Divide = KeyState.pressed;
                    if (Keyboard.Divide == KeyState.released || Keyboard.Divide == KeyState.up) Keyboard.Divide = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Left:
                    if (Keyboard.Left == KeyState.down) Keyboard.Left = KeyState.pressed;
                    if (Keyboard.Left == KeyState.released || Keyboard.Left == KeyState.up) Keyboard.Left = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Right:
                    if (Keyboard.Right == KeyState.down) Keyboard.Right = KeyState.pressed;
                    if (Keyboard.Right == KeyState.released || Keyboard.Right == KeyState.up) Keyboard.Right = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Up:
                    if (Keyboard.Up == KeyState.down) Keyboard.Up = KeyState.pressed;
                    if (Keyboard.Up == KeyState.released || Keyboard.Up == KeyState.up) Keyboard.Up = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Down:
                    if (Keyboard.Down == KeyState.down) Keyboard.Down = KeyState.pressed;
                    if (Keyboard.Down == KeyState.released || Keyboard.Down == KeyState.up) Keyboard.Down = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Numpad0:
                    if (Keyboard.Numpad0 == KeyState.down) Keyboard.Numpad0 = KeyState.pressed;
                    if (Keyboard.Numpad0 == KeyState.released || Keyboard.Numpad0 == KeyState.up) Keyboard.Numpad0 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Numpad1:
                    if (Keyboard.Numpad1 == KeyState.down) Keyboard.Numpad1 = KeyState.pressed;
                    if (Keyboard.Numpad1 == KeyState.released || Keyboard.Numpad1 == KeyState.up) Keyboard.Numpad1 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Numpad2:
                    if (Keyboard.Numpad2 == KeyState.down) Keyboard.Numpad2 = KeyState.pressed;
                    if (Keyboard.Numpad2 == KeyState.released || Keyboard.Numpad2 == KeyState.up) Keyboard.Numpad2 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Numpad3:
                    if (Keyboard.Numpad3 == KeyState.down) Keyboard.Numpad3 = KeyState.pressed;
                    if (Keyboard.Numpad3 == KeyState.released || Keyboard.Numpad3 == KeyState.up) Keyboard.Numpad3 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Numpad4:
                    if (Keyboard.Numpad4 == KeyState.down) Keyboard.Numpad4 = KeyState.pressed;
                    if (Keyboard.Numpad4 == KeyState.released || Keyboard.Numpad4 == KeyState.up) Keyboard.Numpad4 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Numpad5:
                    if (Keyboard.Numpad5 == KeyState.down) Keyboard.Numpad5 = KeyState.pressed;
                    if (Keyboard.Numpad5 == KeyState.released || Keyboard.Numpad5 == KeyState.up) Keyboard.Numpad5 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Numpad6:
                    if (Keyboard.Numpad6 == KeyState.down) Keyboard.Numpad6 = KeyState.pressed;
                    if (Keyboard.Numpad6 == KeyState.released || Keyboard.Numpad6 == KeyState.up) Keyboard.Numpad6 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Numpad7:
                    if (Keyboard.Numpad7 == KeyState.down) Keyboard.Numpad7 = KeyState.pressed;
                    if (Keyboard.Numpad7 == KeyState.released || Keyboard.Numpad7 == KeyState.up) Keyboard.Numpad7 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Numpad8:
                    if (Keyboard.Numpad8 == KeyState.down) Keyboard.Numpad8 = KeyState.pressed;
                    if (Keyboard.Numpad8 == KeyState.released || Keyboard.Numpad8 == KeyState.up) Keyboard.Numpad8 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Numpad9:
                    if (Keyboard.Numpad9 == KeyState.down) Keyboard.Numpad9 = KeyState.pressed;
                    if (Keyboard.Numpad9 == KeyState.released || Keyboard.Numpad9 == KeyState.up) Keyboard.Numpad9 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.F1:
                    if (Keyboard.F1 == KeyState.down) Keyboard.F1 = KeyState.pressed;
                    if (Keyboard.F1 == KeyState.released || Keyboard.F1 == KeyState.up) Keyboard.F1 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.F2:
                    if (Keyboard.F2 == KeyState.down) Keyboard.F2 = KeyState.pressed;
                    if (Keyboard.F2 == KeyState.released || Keyboard.F2 == KeyState.up) Keyboard.F2 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.F3:
                    if (Keyboard.F3 == KeyState.down) Keyboard.F3 = KeyState.pressed;
                    if (Keyboard.F3 == KeyState.released || Keyboard.F3 == KeyState.up) Keyboard.F3 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.F4:
                    if (Keyboard.F4 == KeyState.down) Keyboard.F4 = KeyState.pressed;
                    if (Keyboard.F4 == KeyState.released || Keyboard.F4 == KeyState.up) Keyboard.F4 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.F5:
                    if (Keyboard.F5 == KeyState.down) Keyboard.F5 = KeyState.pressed;
                    if (Keyboard.F5 == KeyState.released || Keyboard.F5 == KeyState.up) Keyboard.F5 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.F6:
                    if (Keyboard.F6 == KeyState.down) Keyboard.F6 = KeyState.pressed;
                    if (Keyboard.F6 == KeyState.released || Keyboard.F6 == KeyState.up) Keyboard.F6 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.F7:
                    if (Keyboard.F7 == KeyState.down) Keyboard.F7 = KeyState.pressed;
                    if (Keyboard.F7 == KeyState.released || Keyboard.F7 == KeyState.up) Keyboard.F7 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.F8:
                    if (Keyboard.F8 == KeyState.down) Keyboard.F8 = KeyState.pressed;
                    if (Keyboard.F8 == KeyState.released || Keyboard.F8 == KeyState.up) Keyboard.F8 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.F9:
                    if (Keyboard.F9 == KeyState.down) Keyboard.F9 = KeyState.pressed;
                    if (Keyboard.F9 == KeyState.released || Keyboard.F9 == KeyState.up) Keyboard.F9 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.F10:
                    if (Keyboard.F10 == KeyState.down) Keyboard.F10 = KeyState.pressed;
                    if (Keyboard.F10 == KeyState.released || Keyboard.F10 == KeyState.up) Keyboard.F10 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.F11:
                    if (Keyboard.F11 == KeyState.down) Keyboard.F11 = KeyState.pressed;
                    if (Keyboard.F11 == KeyState.released || Keyboard.F11 == KeyState.up) Keyboard.F11 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.F12:
                    if (Keyboard.F12 == KeyState.down) Keyboard.F12 = KeyState.pressed;
                    if (Keyboard.F12 == KeyState.released || Keyboard.F12 == KeyState.up) Keyboard.F12 = KeyState.down;
                    break;
                case SFML.Window.Keyboard.Key.Pause:
                    if (Keyboard.Pause == KeyState.down) Keyboard.Pause = KeyState.pressed;
                    if (Keyboard.Pause == KeyState.released || Keyboard.Pause == KeyState.up) Keyboard.Pause = KeyState.down;
                    break;
                default:
                    break;
            }
        }

        public static void OnKeyReleased(object sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case SFML.Window.Keyboard.Key.A:
                    if (Keyboard.A == KeyState.pressed || Keyboard.A == KeyState.down) Keyboard.A = KeyState.up;
                    if (Keyboard.A == KeyState.up) Keyboard.A = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.B:
                    if (Keyboard.B == KeyState.pressed || Keyboard.B == KeyState.down) Keyboard.B = KeyState.up;
                    if (Keyboard.B == KeyState.up) Keyboard.B = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.C:
                    if (Keyboard.C == KeyState.pressed || Keyboard.C == KeyState.down) Keyboard.C = KeyState.up;
                    if (Keyboard.C == KeyState.up) Keyboard.C = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.D:
                    if (Keyboard.D == KeyState.pressed || Keyboard.D == KeyState.down) Keyboard.D = KeyState.up;
                    if (Keyboard.D == KeyState.up) Keyboard.D = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.E:
                    if (Keyboard.E == KeyState.pressed || Keyboard.E == KeyState.down) Keyboard.E = KeyState.up;
                    if (Keyboard.E == KeyState.up) Keyboard.E = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.F:
                    if (Keyboard.F == KeyState.pressed || Keyboard.F == KeyState.down) Keyboard.F = KeyState.up;
                    if (Keyboard.F == KeyState.up) Keyboard.F = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.G:
                    if (Keyboard.G == KeyState.pressed || Keyboard.G == KeyState.down) Keyboard.G = KeyState.up;
                    if (Keyboard.G == KeyState.up) Keyboard.G = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.H:
                    if (Keyboard.H == KeyState.pressed || Keyboard.H == KeyState.down) Keyboard.H = KeyState.up;
                    if (Keyboard.H == KeyState.up) Keyboard.H = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.I:
                    if (Keyboard.I == KeyState.pressed || Keyboard.I == KeyState.down) Keyboard.I = KeyState.up;
                    if (Keyboard.I == KeyState.up) Keyboard.I = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.J:
                    if (Keyboard.J == KeyState.pressed || Keyboard.J == KeyState.down) Keyboard.J = KeyState.up;
                    if (Keyboard.J == KeyState.up) Keyboard.J = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.K:
                    if (Keyboard.K == KeyState.pressed || Keyboard.K == KeyState.down) Keyboard.K = KeyState.up;
                    if (Keyboard.K == KeyState.up) Keyboard.K = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.L:
                    if (Keyboard.L == KeyState.pressed || Keyboard.L == KeyState.down) Keyboard.L = KeyState.up;
                    if (Keyboard.L == KeyState.up) Keyboard.L = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.M:
                    if (Keyboard.M == KeyState.pressed || Keyboard.M == KeyState.down) Keyboard.M = KeyState.up;
                    if (Keyboard.M == KeyState.up) Keyboard.M = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.N:
                    if (Keyboard.N == KeyState.pressed || Keyboard.N == KeyState.down) Keyboard.N = KeyState.up;
                    if (Keyboard.N == KeyState.up) Keyboard.N = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.O:
                    if (Keyboard.O == KeyState.pressed || Keyboard.O == KeyState.down) Keyboard.O = KeyState.up;
                    if (Keyboard.O == KeyState.up) Keyboard.O = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.P:
                    if (Keyboard.P == KeyState.pressed || Keyboard.P == KeyState.down) Keyboard.P = KeyState.up;
                    if (Keyboard.P == KeyState.up) Keyboard.P = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Q:
                    if (Keyboard.Q == KeyState.pressed || Keyboard.Q == KeyState.down) Keyboard.Q = KeyState.up;
                    if (Keyboard.Q == KeyState.up) Keyboard.Q = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.R:
                    if (Keyboard.R == KeyState.pressed || Keyboard.R == KeyState.down) Keyboard.R = KeyState.up;
                    if (Keyboard.R == KeyState.up) Keyboard.R = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.S:
                    if (Keyboard.S == KeyState.pressed || Keyboard.S == KeyState.down) Keyboard.S = KeyState.up;
                    if (Keyboard.S == KeyState.up) Keyboard.S = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.T:
                    if (Keyboard.T == KeyState.pressed || Keyboard.T == KeyState.down) Keyboard.T = KeyState.up;
                    if (Keyboard.T == KeyState.up) Keyboard.T = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.U:
                    if (Keyboard.U == KeyState.pressed || Keyboard.U == KeyState.down) Keyboard.U = KeyState.up;
                    if (Keyboard.U == KeyState.up) Keyboard.U = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.V:
                    if (Keyboard.V == KeyState.pressed || Keyboard.V == KeyState.down) Keyboard.V = KeyState.up;
                    if (Keyboard.V == KeyState.up) Keyboard.V = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.W:
                    if (Keyboard.W == KeyState.pressed || Keyboard.W == KeyState.down) Keyboard.W = KeyState.up;
                    if (Keyboard.W == KeyState.up) Keyboard.W = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.X:
                    if (Keyboard.X == KeyState.pressed || Keyboard.X == KeyState.down) Keyboard.X = KeyState.up;
                    if (Keyboard.X == KeyState.up) Keyboard.X = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Y:
                    if (Keyboard.Y == KeyState.pressed || Keyboard.Y == KeyState.down) Keyboard.Y = KeyState.up;
                    if (Keyboard.Y == KeyState.up) Keyboard.Y = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Z:
                    if (Keyboard.Z == KeyState.pressed || Keyboard.Z == KeyState.down) Keyboard.Z = KeyState.up;
                    if (Keyboard.Z == KeyState.up) Keyboard.Z = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Num0:
                    if (Keyboard.Nr0 == KeyState.pressed || Keyboard.Nr0 == KeyState.down) Keyboard.Nr0 = KeyState.up;
                    if (Keyboard.Nr0 == KeyState.up) Keyboard.Nr0 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Num1:
                    if (Keyboard.Nr1 == KeyState.pressed || Keyboard.Nr1 == KeyState.down) Keyboard.Nr1 = KeyState.up;
                    if (Keyboard.Nr1 == KeyState.up) Keyboard.Nr1 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Num2:
                    if (Keyboard.Nr2 == KeyState.pressed || Keyboard.Nr2 == KeyState.down) Keyboard.Nr2 = KeyState.up;
                    if (Keyboard.Nr2 == KeyState.up) Keyboard.Nr2 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Num3:
                    if (Keyboard.Nr3 == KeyState.pressed || Keyboard.Nr3 == KeyState.down) Keyboard.Nr3 = KeyState.up;
                    if (Keyboard.Nr3 == KeyState.up) Keyboard.Nr3 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Num4:
                    if (Keyboard.Nr4 == KeyState.pressed || Keyboard.Nr4 == KeyState.down) Keyboard.Nr4 = KeyState.up;
                    if (Keyboard.Nr4 == KeyState.up) Keyboard.Nr4 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Num5:
                    if (Keyboard.Nr5 == KeyState.pressed || Keyboard.Nr5 == KeyState.down) Keyboard.Nr5 = KeyState.up;
                    if (Keyboard.Nr5 == KeyState.up) Keyboard.Nr5 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Num6:
                    if (Keyboard.Nr6 == KeyState.pressed || Keyboard.Nr6 == KeyState.down) Keyboard.Nr6 = KeyState.up;
                    if (Keyboard.Nr6 == KeyState.up) Keyboard.Nr6 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Num7:
                    if (Keyboard.Nr7 == KeyState.pressed || Keyboard.Nr7 == KeyState.down) Keyboard.Nr7 = KeyState.up;
                    if (Keyboard.Nr7 == KeyState.up) Keyboard.Nr7 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Num8:
                    if (Keyboard.Nr8 == KeyState.pressed || Keyboard.Nr8 == KeyState.down) Keyboard.Nr8 = KeyState.up;
                    if (Keyboard.Nr8 == KeyState.up) Keyboard.Nr8 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Num9:
                    if (Keyboard.Nr9 == KeyState.pressed || Keyboard.Nr9 == KeyState.down) Keyboard.Nr9 = KeyState.up;
                    if (Keyboard.Nr9 == KeyState.up) Keyboard.Nr9 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Escape:
                    if (Keyboard.Esc == KeyState.pressed || Keyboard.Esc == KeyState.down) Keyboard.Esc = KeyState.up;
                    if (Keyboard.Esc == KeyState.up) Keyboard.Esc = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.LControl:
                    if (Keyboard.LCtrl == KeyState.pressed || Keyboard.LCtrl == KeyState.down) Keyboard.LCtrl = KeyState.up;
                    if (Keyboard.LCtrl == KeyState.up) Keyboard.LCtrl = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.LShift:
                    if (Keyboard.LShift == KeyState.pressed || Keyboard.LShift == KeyState.down) Keyboard.LShift = KeyState.up;
                    if (Keyboard.LShift == KeyState.up) Keyboard.LShift = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.LAlt:
                    if (Keyboard.LAlt == KeyState.pressed || Keyboard.LAlt == KeyState.down) Keyboard.LAlt = KeyState.up;
                    if (Keyboard.LAlt == KeyState.up) Keyboard.LAlt = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.LSystem:
                    if (Keyboard.LSys == KeyState.pressed || Keyboard.LSys == KeyState.down) Keyboard.LSys = KeyState.up;
                    if (Keyboard.LSys == KeyState.up) Keyboard.LSys = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.RControl:
                    if (Keyboard.RCtrl == KeyState.pressed || Keyboard.RCtrl == KeyState.down) Keyboard.RCtrl = KeyState.up;
                    if (Keyboard.RCtrl == KeyState.up) Keyboard.RCtrl = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.RShift:
                    if (Keyboard.RShift == KeyState.pressed || Keyboard.RShift == KeyState.down) Keyboard.RShift = KeyState.up;
                    if (Keyboard.RShift == KeyState.up) Keyboard.RShift = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.RAlt:
                    if (Keyboard.RAlt == KeyState.pressed || Keyboard.RAlt == KeyState.down) Keyboard.RAlt = KeyState.up;
                    if (Keyboard.RAlt == KeyState.up) Keyboard.RAlt = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.RSystem:
                    if (Keyboard.RSys == KeyState.pressed || Keyboard.RSys == KeyState.down) Keyboard.RSys = KeyState.up;
                    if (Keyboard.RSys == KeyState.up) Keyboard.RSys = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Menu:
                    if (Keyboard.Menu == KeyState.pressed || Keyboard.Menu == KeyState.down) Keyboard.Menu = KeyState.up;
                    if (Keyboard.Menu == KeyState.up) Keyboard.Menu = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.LBracket:
                    if (Keyboard.LBracket == KeyState.pressed || Keyboard.LBracket == KeyState.down) Keyboard.LBracket = KeyState.up;
                    if (Keyboard.LBracket == KeyState.up) Keyboard.LBracket = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.RBracket:
                    if (Keyboard.RBracket == KeyState.pressed || Keyboard.RBracket == KeyState.down) Keyboard.RBracket = KeyState.up;
                    if (Keyboard.RBracket == KeyState.up) Keyboard.RBracket = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Semicolon:
                    if (Keyboard.Semicolon == KeyState.pressed || Keyboard.Semicolon == KeyState.down) Keyboard.Semicolon = KeyState.up;
                    if (Keyboard.Semicolon == KeyState.up) Keyboard.Semicolon = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Comma:
                    if (Keyboard.Comma == KeyState.pressed || Keyboard.Comma == KeyState.down) Keyboard.Comma = KeyState.up;
                    if (Keyboard.Comma == KeyState.up) Keyboard.Comma = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Period:
                    if (Keyboard.Period == KeyState.pressed || Keyboard.Period == KeyState.down) Keyboard.Period = KeyState.up;
                    if (Keyboard.Period == KeyState.up) Keyboard.Period = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Quote:
                    if (Keyboard.Quote == KeyState.pressed || Keyboard.Quote == KeyState.down) Keyboard.Quote = KeyState.up;
                    if (Keyboard.Quote == KeyState.up) Keyboard.Quote = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Slash:
                    if (Keyboard.Slash == KeyState.pressed || Keyboard.Slash == KeyState.down) Keyboard.Slash = KeyState.up;
                    if (Keyboard.Slash == KeyState.up) Keyboard.Slash = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Backslash:
                    if (Keyboard.Backslash == KeyState.pressed || Keyboard.Backslash == KeyState.down) Keyboard.Backslash = KeyState.up;
                    if (Keyboard.Backslash == KeyState.up) Keyboard.Backslash = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Tilde:
                    if (Keyboard.Tilde == KeyState.pressed || Keyboard.Tilde == KeyState.down) Keyboard.Tilde = KeyState.up;
                    if (Keyboard.Tilde == KeyState.up) Keyboard.Tilde = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Equal:
                    if (Keyboard.Equal == KeyState.pressed || Keyboard.Equal == KeyState.down) Keyboard.Equal = KeyState.up;
                    if (Keyboard.Equal == KeyState.up) Keyboard.Equal = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Hyphen:
                    if (Keyboard.Hyphen == KeyState.pressed || Keyboard.Hyphen == KeyState.down) Keyboard.Hyphen = KeyState.up;
                    if (Keyboard.Hyphen == KeyState.up) Keyboard.Hyphen = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Space:
                    if (Keyboard.Space == KeyState.pressed || Keyboard.Space == KeyState.down) Keyboard.Space = KeyState.up;
                    if (Keyboard.Space == KeyState.up) Keyboard.Space = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Enter:
                    if (Keyboard.Enter == KeyState.pressed || Keyboard.Enter == KeyState.down) Keyboard.Enter = KeyState.up;
                    if (Keyboard.Enter == KeyState.up) Keyboard.Enter = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Backspace:
                    if (Keyboard.Backspace == KeyState.pressed || Keyboard.Backspace == KeyState.down) Keyboard.Backspace = KeyState.up;
                    if (Keyboard.Backspace == KeyState.up) Keyboard.Backspace = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Tab:
                    if (Keyboard.Tab == KeyState.pressed || Keyboard.Tab == KeyState.down) Keyboard.Tab = KeyState.up;
                    if (Keyboard.Tab == KeyState.up) Keyboard.Tab = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.PageUp:
                    if (Keyboard.PageUp == KeyState.pressed || Keyboard.PageUp == KeyState.down) Keyboard.PageUp = KeyState.up;
                    if (Keyboard.PageUp == KeyState.up) Keyboard.PageUp = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.PageDown:
                    if (Keyboard.PageDown == KeyState.pressed || Keyboard.PageDown == KeyState.down) Keyboard.PageDown = KeyState.up;
                    if (Keyboard.PageDown == KeyState.up) Keyboard.PageDown = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.End:
                    if (Keyboard.End == KeyState.pressed || Keyboard.End == KeyState.down) Keyboard.End = KeyState.up;
                    if (Keyboard.End == KeyState.up) Keyboard.End = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Home:
                    if (Keyboard.Home == KeyState.pressed || Keyboard.Home == KeyState.down) Keyboard.Home = KeyState.up;
                    if (Keyboard.Home == KeyState.up) Keyboard.Home = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Insert:
                    if (Keyboard.Insert == KeyState.pressed || Keyboard.Insert == KeyState.down) Keyboard.Insert = KeyState.up;
                    if (Keyboard.Insert == KeyState.up) Keyboard.Insert = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Delete:
                    if (Keyboard.Delete == KeyState.pressed || Keyboard.Delete == KeyState.down) Keyboard.Delete = KeyState.up;
                    if (Keyboard.Delete == KeyState.up) Keyboard.Delete = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Add:
                    if (Keyboard.Add == KeyState.pressed || Keyboard.Add == KeyState.down) Keyboard.Add = KeyState.up;
                    if (Keyboard.Add == KeyState.up) Keyboard.Add = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Subtract:
                    if (Keyboard.Subtract == KeyState.pressed || Keyboard.Subtract == KeyState.down) Keyboard.Subtract = KeyState.up;
                    if (Keyboard.Subtract == KeyState.up) Keyboard.Subtract = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Multiply:
                    if (Keyboard.Multiply == KeyState.pressed || Keyboard.Multiply == KeyState.down) Keyboard.Multiply = KeyState.up;
                    if (Keyboard.Multiply == KeyState.up) Keyboard.Multiply = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Divide:
                    if (Keyboard.Divide == KeyState.pressed || Keyboard.Divide == KeyState.down) Keyboard.Divide = KeyState.up;
                    if (Keyboard.Divide == KeyState.up) Keyboard.Divide = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Left:
                    if (Keyboard.Left == KeyState.pressed || Keyboard.Left == KeyState.down) Keyboard.Left = KeyState.up;
                    if (Keyboard.Left == KeyState.up) Keyboard.Left = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Right:
                    if (Keyboard.Right == KeyState.pressed || Keyboard.Right == KeyState.down) Keyboard.Right = KeyState.up;
                    if (Keyboard.Right == KeyState.up) Keyboard.Right = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Up:
                    if (Keyboard.Up == KeyState.pressed || Keyboard.Up == KeyState.down) Keyboard.Up = KeyState.up;
                    if (Keyboard.Up == KeyState.up) Keyboard.Up = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Down:
                    if (Keyboard.Down == KeyState.pressed || Keyboard.Down == KeyState.down) Keyboard.Down = KeyState.up;
                    if (Keyboard.Down == KeyState.up) Keyboard.Down = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Numpad0:
                    if (Keyboard.Numpad0 == KeyState.pressed || Keyboard.Numpad0 == KeyState.down) Keyboard.Numpad0 = KeyState.up;
                    if (Keyboard.Numpad0 == KeyState.up) Keyboard.Numpad0 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Numpad1:
                    if (Keyboard.Numpad1 == KeyState.pressed || Keyboard.Numpad1 == KeyState.down) Keyboard.Numpad1 = KeyState.up;
                    if (Keyboard.Numpad1 == KeyState.up) Keyboard.Numpad1 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Numpad2:
                    if (Keyboard.Numpad2 == KeyState.pressed || Keyboard.Numpad2 == KeyState.down) Keyboard.Numpad2 = KeyState.up;
                    if (Keyboard.Numpad2 == KeyState.up) Keyboard.Numpad2 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Numpad3:
                    if (Keyboard.Numpad3 == KeyState.pressed || Keyboard.Numpad3 == KeyState.down) Keyboard.Numpad3 = KeyState.up;
                    if (Keyboard.Numpad3 == KeyState.up) Keyboard.Numpad3 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Numpad4:
                    if (Keyboard.Numpad4 == KeyState.pressed || Keyboard.Numpad4 == KeyState.down) Keyboard.Numpad4 = KeyState.up;
                    if (Keyboard.Numpad4 == KeyState.up) Keyboard.Numpad4 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Numpad5:
                    if (Keyboard.Numpad5 == KeyState.pressed || Keyboard.Numpad5 == KeyState.down) Keyboard.Numpad5 = KeyState.up;
                    if (Keyboard.Numpad5 == KeyState.up) Keyboard.Numpad5 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Numpad6:
                    if (Keyboard.Numpad6 == KeyState.pressed || Keyboard.Numpad6 == KeyState.down) Keyboard.Numpad6 = KeyState.up;
                    if (Keyboard.Numpad6 == KeyState.up) Keyboard.Numpad6 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Numpad7:
                    if (Keyboard.Numpad7 == KeyState.pressed || Keyboard.Numpad7 == KeyState.down) Keyboard.Numpad7 = KeyState.up;
                    if (Keyboard.Numpad7 == KeyState.up) Keyboard.Numpad7 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Numpad8:
                    if (Keyboard.Numpad8 == KeyState.pressed || Keyboard.Numpad8 == KeyState.down) Keyboard.Numpad8 = KeyState.up;
                    if (Keyboard.Numpad8 == KeyState.up) Keyboard.Numpad8 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Numpad9:
                    if (Keyboard.Numpad9 == KeyState.pressed || Keyboard.Numpad9 == KeyState.down) Keyboard.Numpad9 = KeyState.up;
                    if (Keyboard.Numpad9 == KeyState.up) Keyboard.Numpad9 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.F1:
                    if (Keyboard.F1 == KeyState.pressed || Keyboard.F1 == KeyState.down) Keyboard.F1 = KeyState.up;
                    if (Keyboard.F1 == KeyState.up) Keyboard.F1 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.F2:
                    if (Keyboard.F2 == KeyState.pressed || Keyboard.F2 == KeyState.down) Keyboard.F2 = KeyState.up;
                    if (Keyboard.F2 == KeyState.up) Keyboard.F2 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.F3:
                    if (Keyboard.F3 == KeyState.pressed || Keyboard.F3 == KeyState.down) Keyboard.F3 = KeyState.up;
                    if (Keyboard.F3 == KeyState.up) Keyboard.F3 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.F4:
                    if (Keyboard.F4 == KeyState.pressed || Keyboard.F4 == KeyState.down) Keyboard.F4 = KeyState.up;
                    if (Keyboard.F4 == KeyState.up) Keyboard.F4 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.F5:
                    if (Keyboard.F5 == KeyState.pressed || Keyboard.F5 == KeyState.down) Keyboard.F5 = KeyState.up;
                    if (Keyboard.F5 == KeyState.up) Keyboard.F5 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.F6:
                    if (Keyboard.F6 == KeyState.pressed || Keyboard.F6 == KeyState.down) Keyboard.F6 = KeyState.up;
                    if (Keyboard.F6 == KeyState.up) Keyboard.F6 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.F7:
                    if (Keyboard.F7 == KeyState.pressed || Keyboard.F7 == KeyState.down) Keyboard.F7 = KeyState.up;
                    if (Keyboard.F7 == KeyState.up) Keyboard.F7 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.F8:
                    if (Keyboard.F8 == KeyState.pressed || Keyboard.F8 == KeyState.down) Keyboard.F8 = KeyState.up;
                    if (Keyboard.F8 == KeyState.up) Keyboard.F8 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.F9:
                    if (Keyboard.F9 == KeyState.pressed || Keyboard.F9 == KeyState.down) Keyboard.F9 = KeyState.up;
                    if (Keyboard.F9 == KeyState.up) Keyboard.F9 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.F10:
                    if (Keyboard.F10 == KeyState.pressed || Keyboard.F10 == KeyState.down) Keyboard.F10 = KeyState.up;
                    if (Keyboard.F10 == KeyState.up) Keyboard.F10 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.F11:
                    if (Keyboard.F11 == KeyState.pressed || Keyboard.F11 == KeyState.down) Keyboard.F11 = KeyState.up;
                    if (Keyboard.F11 == KeyState.up) Keyboard.F11 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.F12:
                    if (Keyboard.F12 == KeyState.pressed || Keyboard.F12 == KeyState.down) Keyboard.F12 = KeyState.up;
                    if (Keyboard.F12 == KeyState.up) Keyboard.F12 = KeyState.released;

                    break;
                case SFML.Window.Keyboard.Key.Pause:
                    if (Keyboard.Pause == KeyState.pressed || Keyboard.Pause == KeyState.down) Keyboard.Pause = KeyState.up;
                    if (Keyboard.Pause == KeyState.up) Keyboard.Pause = KeyState.released;
                    break;
                default:
                    break;
            }
        }
    }
}
