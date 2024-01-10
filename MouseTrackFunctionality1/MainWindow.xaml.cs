using Gma.System.MouseKeyHook;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MouseClickCounter
{
    public partial class MainWindow : Window
    {
        private IKeyboardMouseEvents keyboardHook;
        private IKeyboardMouseEvents mouseHook;
        private int clickCount = 0;
        private int keyPressCount = 0;

        public MainWindow()
        {
            InitializeComponent();

            // Set up a click event handler for the "Click Me" button
            btnClick.Click += btnClick_Click;

            // Set up the global mouse hook
            SubscribeGlobalMouseHook();
            SubscribeGlobalKeyboardHook();
        }

        private void SubscribeGlobalMouseHook()
        {
            mouseHook = Hook.GlobalEvents();

            // Subscribe to the MouseClick event
            mouseHook.MouseClick += MouseHook_MouseClick;
        }

        private void SubscribeGlobalKeyboardHook()
        {
            keyboardHook = Hook.GlobalEvents();

            // Subscribe to the KeyDown event
            keyboardHook.KeyDown += KeyboardHook_KeyDown;
        }

        private void KeyboardHook_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // Handle global key press events here
            Key pressedKey = (Key)e.KeyValue;

            // Increment the key press count
            keyPressCount++;

            // Update the text block to display the key press count
            Dispatcher.Invoke(() =>
            {
                txtKeyPressCount.Text = $"Key Presses: {keyPressCount}";
            });
        }
       
        private void MouseHook_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Handle global mouse click events here
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // Increment the click count when a left mouse click occurs globally
                clickCount++;
                // Update the text block to display the click count
                Dispatcher.Invoke(() =>
                {
                    txtMouseClickCount.Text = $"Mouse Clicks: {clickCount}";
                });
            }
        }

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            // Increment the click count when the button is clicked
            clickCount++;

            // Update the text block to display the click count
            txtMouseClickCount.Text = $"Mouse Clicks: {clickCount}";
        }

        // Don't forget to unhook both the mouse and keyboard hooks when the application closes
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            UnsubscribeGlobalMouseHook();
            UnsubscribeGlobalKeyboardHook();
        }

        private void UnsubscribeGlobalMouseHook()
        {
            if (mouseHook != null)
            {
                mouseHook.MouseClick -= MouseHook_MouseClick;
                mouseHook.Dispose();
            }
        }

        private void UnsubscribeGlobalKeyboardHook()
        {
            if (keyboardHook != null)
            {
                keyboardHook.KeyDown -= KeyboardHook_KeyDown;
                keyboardHook.Dispose();
            }
        }
    }
}
