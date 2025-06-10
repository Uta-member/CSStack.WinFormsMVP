namespace CSStack.WinFormsMVP.Sample.Forms.MainForm
{
	public partial class MainForm : Form, IMainFormView
	{
		public MainForm()
		{
			InitializeComponent();
			button1.Click += delegate
			{
				SubmitAction?.Invoke(this, EventArgs.Empty);
			};
		}

		public event EventHandler? SubmitAction;

		public string DisplayText
		{
			get => label1.Text;
			set => label1.Text = value;
		}

		public string InputText
		{
			get => textBox1.Text;
			set => textBox1.Text = value;
		}
	}
}
