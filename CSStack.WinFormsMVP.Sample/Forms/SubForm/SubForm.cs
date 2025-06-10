namespace CSStack.WinFormsMVP.Sample.Forms.SubForm
{
	public partial class SubForm : Form, ISubFormView
	{
		public SubForm()
		{
			InitializeComponent();
			Presenter = new SubFormPresenter(this);
			button1.Click += SubmitAction!.Invoke;
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

		public SubFormPresenter Presenter { get; }
	}
}
