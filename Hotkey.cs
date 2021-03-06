using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Binder
{
    public class Hotkey : IMessageFilter
    {
        #region Interop

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int UnregisterHotKey(IntPtr hWnd, int id);

        private const uint WM_HOTKEY = 0x312;

        private const uint MOD_ALT = 0x1;
        private const uint MOD_CONTROL = 0x2;
        private const uint MOD_SHIFT = 0x4;
        private const uint MOD_WIN = 0x8;

        private const uint ERROR_HOTKEY_ALREADY_REGISTERED = 1409;

        #endregion Interop

        private static int currentID;
        private const int maximumID = 0xBFFF;

        private Keys keyCode;
        private bool shift;
        private bool control;
        private bool alt;
        private bool windows;

        [XmlIgnore]
        private int id;

        [XmlIgnore]
        private bool registered;

        [XmlIgnore]
        private Control windowControl;

        public event HandledEventHandler Pressed;

        public Hotkey() : this(Keys.None, false, false, false, false)
        {
            // No work done here!
        }

        public Hotkey(Keys keyCode, bool shift, bool control, bool alt, bool windows)
        {
            // Assign properties
            KeyCode = keyCode;
            Shift = shift;
            Control = control;
            Alt = alt;
            Windows = windows;

            // Register us as a message filter
            Application.AddMessageFilter(this);
        }

        ~Hotkey()
        {
            // Unregister the hotkey if necessary
            if (Registered)
            { Unregister(); }
        }

        public Hotkey Clone()
        {
            // Clone the whole object
            return new Hotkey(keyCode, shift, control, alt, windows);
        }

        public bool GetCanRegister(Control windowControl)
        {
            // Handle any exceptions: they mean "no, you can't register" :)
            try
            {
                // Attempt to register
                if (!Register(windowControl))
                { return false; }

                // Unregister and say we managed it
                Unregister();
                return true;
            }
            catch (Win32Exception)
            { return false; }
            catch (NotSupportedException)
            { return false; }
        }

        public bool Register(Control windowControl)
        {
            // Check that we have not registered
            if (registered)
            { throw new NotSupportedException("You cannot register a hotkey that is already registered"); }

            // We can't register an empty hotkey
            if (Empty)
            { throw new NotSupportedException("You cannot register an empty hotkey"); }

            // Get an ID for the hotkey and increase current ID
            id = currentID;
            currentID += 1 % maximumID;

            // Translate modifier keys into unmanaged version
            uint modifiers = (Alt ? MOD_ALT : 0) | (Control ? MOD_CONTROL : 0) |
                            (Shift ? MOD_SHIFT : 0) | (Windows ? MOD_WIN : 0);

            // Register the hotkey
            if (RegisterHotKey(windowControl.Handle, id, modifiers, keyCode) == 0)
            {
                // Is the error that the hotkey is registered?
                if (Marshal.GetLastWin32Error() == ERROR_HOTKEY_ALREADY_REGISTERED)
                { return false; }
                else
                { throw new Win32Exception(); }
            }

            // Save the control reference and register state
            registered = true;
            this.windowControl = windowControl;

            // We successfully registered
            return true;
        }

        public void Unregister()
        {
            // Check that we have registered
            if (!registered)
            { throw new NotSupportedException("You cannot unregister a hotkey that is not registered"); }

            // It's possible that the control itself has died: in that case, no need to unregister!
            if (!windowControl.IsDisposed)
            {
                // Clean up after ourselves
                if (UnregisterHotKey(windowControl.Handle, id) == 0)
                { throw new Win32Exception(); }
            }

            // Clear the control reference and register state
            registered = false;
            windowControl = null;
        }

        private void Reregister()
        {
            // Only do something if the key is already registered
            if (registered)
            {             // Save control reference
                Control windowControl = this.windowControl;

                // Unregister and then reregister again
                Unregister();
                Register(windowControl);
            }
        }

        public bool PreFilterMessage(ref Message message)
        {
            // Only process WM_HOTKEY messages
            if (message.Msg == WM_HOTKEY)
            {             // Check that the ID is our key and we are registerd
                if (registered && (message.WParam.ToInt32() == id))
                {
                    // Fire the event and pass on the event if our handlers didn't handle it
                    return OnPressed();
                }
                else
                { return false; }
            }
            return false;
        }

        private bool OnPressed()
        {
            // Fire the event if we can
            HandledEventArgs handledEventArgs = new HandledEventArgs(false);
            Pressed?.Invoke(this, handledEventArgs);
            // Return whether we handled the event or not
            return handledEventArgs.Handled;
        }

        public override string ToString()
        {
            // We can be empty
            if (Empty)
            { return "(none)"; }

            // Build key name
            string keyName = Enum.GetName(typeof(Keys), keyCode);
            switch (keyCode)
            {
                case Keys.D0:
                    keyName =  "0";
                    break;
                case Keys.D1:
                    keyName = "1";
                    break;
                case Keys.D2:
                    keyName = "2";
                    break;
                case Keys.D3:
                    keyName = "3";
                    break;
                case Keys.D4:
                    keyName = "4";
                    break;
                case Keys.D5:
                    keyName = "5";
                    break;
                case Keys.D6:
                    keyName = "6";
                    break;
                case Keys.D7:
                    keyName = "7";
                    break;
                case Keys.D8:
                    keyName = "8";
                    break;
                case Keys.D9:
                    keyName = "9";
                    break;
                default:
                    // Leave everything alone
                    break;
            }
            // Return result
            return keyName;
        }

        public bool Empty => keyCode == Keys.None;

        public bool Registered => registered;

        public Keys KeyCode
        {
            get => keyCode;
            set
            {
                // Save and reregister
                keyCode = value;
                Reregister();
            }
        }

        public bool Shift
        {
            get => shift;
            set
            {
                // Save and reregister
                shift = value;
                Reregister();
            }
        }

        public bool Control
        {
            get => control;
            set
            {
                // Save and reregister
                control = value;
                Reregister();
            }
        }

        public bool Alt
        {
            get => alt;
            set
            {
                // Save and reregister
                alt = value;
                Reregister();
            }
        }

        public bool Windows
        {
            get => windows;
            set
            {
                // Save and reregister
                windows = value;
                Reregister();
            }
        }
    }
}