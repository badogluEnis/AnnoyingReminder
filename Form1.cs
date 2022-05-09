using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jürg_Reminder
{
    public partial class ReminderForm : Form
    {
        public ReminderForm(Random r, Size screenSize, string[] reminders, string[] titles)
        {
            Color color = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
            TopMost = true;
            StartPosition = FormStartPosition.Manual;

            InitializeComponent();

            textBox1.Text = reminders[r.Next(reminders.Length)];
            Text = titles[r.Next(titles.Length)];
            Location = new Point(r.Next(-Width, screenSize.Width), r.Next(-Height, screenSize.Height));
            BackColor = color;
            textBox1.ForeColor = color;

            var cts = new CancellationTokenSource();
            RecurringTask recurringTask = new RecurringTask();
            recurringTask.RTask(() => recurringTask.MoveWindow(this, r), 60, cts.Token);
        }
    }
}
