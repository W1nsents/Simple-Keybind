using System;
using System.Windows.Forms;

namespace SimpleKeyBinds
{
    public partial class Form1 : Form
    {
        private KeyboardHook keyboardHook = new KeyboardHook();
        public Form1()
        {
            InitializeComponent();
            keyboardHook.KeyDown += KeyboardHook_KeyDown;
            keyboardHook.Install();

        }
        public KeyboardHook.VKeys KeyBind;
        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            KeyBind = KeyboardHook.ConvertToBindable(e);
            btn(button1);
            button1.Text = $"({KeyBind.ToString()})";

        }

        private void KeyboardHook_KeyDown(KeyboardHook.VKeys key)
        {
            if (key == KeyBind || key == KeyboardHook.VKeys.SHIFT)
            {
                checkBox1.Checked = !checkBox1.Checked;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Press key";
        }

        void btn(Button button)
        {
            button.Enabled = false;
            button.Enabled = true;
        }
        
    }
}
