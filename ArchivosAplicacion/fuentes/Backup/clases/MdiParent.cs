using System;
using System.Windows.Forms;
namespace EPM.clases
{
	using EPM.formularios;
	public class MdiParent
	{
		private static frmMain father;
		public static void setFather(frmMain f)
		{
			father = f;
		}
		public static Form getFather()
		{
			return father;
		}
	}
}
