using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCRM
{
	public class CursorWait : IDisposable
	{
		public CursorWait(bool appStarting = false, bool applicationCursor = false)
		{
			// Wait
			Cursor.Current = appStarting ? Cursors.AppStarting : Cursors.WaitCursor;
			if (applicationCursor) System.Windows.Forms.Application.UseWaitCursor = true;
		}

		public void Dispose()
		{
			// Reset
			Cursor.Current = Cursors.Default;
			System.Windows.Forms.Application.UseWaitCursor = false;
		}
	}
}
