using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace CSharpFormLibrary
{
	public class IMECandidateForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lbCandidates;
		//������index
		//int now_index;		
		int baseSize;	//�򥻪���(�S��candidate��form���j�p)
		private System.ComponentModel.Container components = null;

		public IMECandidateForm()
		{
			InitializeComponent();
			baseSize = this.lbCandidates.Location.Y+100;
			this.Opacity = 0.85;
		}
		public IMECandidateForm(string[] candidates)
		{
			InitializeComponent();
		}
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lbCandidates = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// lbCandidates
			// 
			this.lbCandidates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lbCandidates.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.lbCandidates.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbCandidates.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbCandidates.ItemHeight = 15;
			this.lbCandidates.Location = new System.Drawing.Point(0, 0);
			this.lbCandidates.Name = "lbCandidates";
			this.lbCandidates.Size = new System.Drawing.Size(120, 90);
			this.lbCandidates.TabIndex = 0;
			this.lbCandidates.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbCandidates_KeyPress);
			// 
			// IMECandidateForm
			// 
			this.AllowDrop = true;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(80, 160);
			this.Controls.Add(this.lbCandidates);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Location = new System.Drawing.Point(199, 199);
			this.Name = "IMECandidateForm";
			this.Opacity = 0;
			this.ShowInTaskbar = false;
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		#region public methods

		public void SetCandidates(string inputs)
		{
			string[] a_inputs = inputs.Split(' ');
			if(a_inputs==null) return;			
			this.lbCandidates.Height=(a_inputs.Length+1)*15;
			this.ShowListView(a_inputs); // not show, only setstring
		}

		public void SetLocation(int x, int y)
		{
			this.Location = new Point(x,y);
		}

		public void DisposeForm()
		{
			this.Dispose(true);
		}

		public int GetValue()
		{
			return this.lbCandidates.SelectedIndex;
		}

		#endregion

		#region a protected override method for WS_POPUP

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.Style = unchecked((int)0x80000000); //WS_POPUP
				return cp;
			}
		}

		#endregion

		#region private methods

		private void ShowListView(string[] pageCandidates)
		{
			this.lbCandidates.Items.Clear();
			this.lbCandidates.Items.AddRange(pageCandidates);
			this.lbCandidates.SelectedItem= this.lbCandidates.Items[0];
			

			//DepthOfList(pageCandidates.Length);
		}
		public void ClearCandidates()
		{
			this.lbCandidates.Items.Clear();
		}
		public void DepthOfList(int number)
		{
			//14 = lbCandidate.Size.Height/9 �i�� - Height%9
			this.Size = new Size(this.Size.Width,baseSize+number*13);			
		}

		#endregion

		/*
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			CSharpFormLibrary.IMECandidateForm form = new CSharpFormLibrary.IMECandidateForm();
			Application.Run(form);
		}
		*/

		private void lbCandidates_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
		
		}	
		public int GetWidth()
		{
			return this.Width;
		}
		public int GetHeight()
		{
			return this.Height;
		}
		public void ShowNoActive()
		{
			UtilFuncs.SetVisibleNoActivate(this, true); // true to show. 
		}
		public void HideNoActive()
		{
			UtilFuncs.SetVisibleNoActivate(this, false); // false to hide.  
		}
	}
}

