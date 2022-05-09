using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jürg_Reminder
{
    class RecurringTask
    {
        public void RTask(Action action, int milliseconds, CancellationToken token)
        {
            if (action == null)
                return;
            Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    action();
                    await Task.Delay(TimeSpan.FromMilliseconds(milliseconds), token);
                }
            }, token);
        }

        public void MoveWindow(Form form, Random r)
        {
            if (form.InvokeRequired)
            {
                form.Invoke((Action)(() =>
                {
                    form.Location = new Point((int)form.Location.X + r.Next(-12, 12), (int)form.Location.Y + r.Next(-12, 12));
                }));
            }
        }
    }
}
