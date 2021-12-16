using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileConverter
{
    public partial class StartDialog : Form
    {
        public StartDialog()
        {
            InitializeComponent();
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btnExternal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle r = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            e.Graphics.DrawRectangle(new Pen(ColorTranslator.FromHtml("#A8A8A8")), r);
        }

        private bool startMoving = false;
        private Point initialPoint;
        private void StartDialog_MouseDown(object sender, MouseEventArgs e)
        {
            startMoving = true;
            initialPoint = e.Location;
        }

        private void StartDialog_MouseUp(object sender, MouseEventArgs e)
        {
            startMoving = false;
            if (this.Location.Y - 20 < 0)
                this.Location = new Point(this.Location.X, -10);
            if (this.Location.Y > Screen.PrimaryScreen.WorkingArea.Height - 10)
                this.Location = new Point(this.Location.X, Screen.PrimaryScreen.WorkingArea.Height - 30);
        }

        private void StartDialog_MouseMove(object sender, MouseEventArgs e)
        {
            if (initialPoint == null) return;
            if (startMoving)
                this.SetDesktopLocation(MousePosition.X - initialPoint.X, MousePosition.Y - initialPoint.Y);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x20000;
                return cp;
            }
        }

        private void btnTreeForm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
        }
    }
}
