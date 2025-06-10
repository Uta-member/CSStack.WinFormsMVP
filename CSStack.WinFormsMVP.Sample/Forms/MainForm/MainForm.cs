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
            Presenter = new MainFormPresenter(this);
        }

        public event EventHandler? SubmitAction;

        public string DisplayText
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }

        public string InputText
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }

        public MainFormPresenter Presenter { get; set; }
    }
}
