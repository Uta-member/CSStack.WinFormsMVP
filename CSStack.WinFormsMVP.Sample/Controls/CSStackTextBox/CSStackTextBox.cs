using System;
using System.Linq;

namespace CSStack.WinFormsMVP.Sample.Controls.CSStackTextBox
{
    public partial class CSStackTextBox : TextBox, ICSStackTextBoxView
    {
        public CSStackTextBox()
        {
            InitializeComponent();
            Presenter = new CSStackTextBoxPresenter(this);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public CSStackTextBoxPresenter Presenter { get; set; }
    }
}
