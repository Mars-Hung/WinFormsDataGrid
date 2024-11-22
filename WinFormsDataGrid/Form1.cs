using WinFormsDataGrid.Services;

namespace WinFormsDataGrid
{
    public partial class Form1 : Form
    {
        const int defaultCountdown = 3;
        private int countdownSeconds = defaultCountdown; // �˼ƭp�ɪ����
        System.Timers.Timer timer;// differ from system.form.timer

        //drawing related
        private bool isDrawing = false; // �O�_���bø�s
        private Point lastPoint; // �W�@�����ƹ���m
        private List<Point> points = new List<Point>(); // �s�xø�s�L�{�����Ҧ��I

        public Form1()
        {
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            InitializeTimer();
            InitializeDrawing();
            lblThreadInfo.Text = $"{DateTime.Now.ToString("HH:mm:ss.fff")} �D�n�u�{(UI) Thread ID�G{Thread.CurrentThread.ManagedThreadId}";


            await UpdateStockInfoAsync();
            //timerGvMain.Start();
            timer.Start();
        }
        private void InitializeTimer()
        {
            timer = new System.Timers.Timer(1000); // �C��Ĳ�o�@��
            timer.Elapsed += Timer_Elapsed; ; // ���w�B�z�ƥ�
            timer.AutoReset = true; // �۰ʭ��ư���
        }
        private void InitializeDrawing()
        {
            this.DoubleBuffered = true;
        }


        private async void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            int timerThreadId = Thread.CurrentThread.ManagedThreadId;

            this.Invoke((MethodInvoker)(() =>
            {
                //lblSecondThreadInfo.Text = $"Timer �����u�{ ID�G{Thread.CurrentThread.ManagedThreadId}";
                lblSecondThreadInfo.Text = $"{DateTime.Now.ToString("HH:mm:ss.fff")} �ĤG�u�{ Thread ID�G{timerThreadId}";

            }));
            if (countdownSeconds > 0)
            {
                countdownSeconds--;
                // ���^�D�u�{��s UI
                this.Invoke((MethodInvoker)(() =>
                {
                    lblTimerGvMainDesc.Text = $"��s�˼ơG{countdownSeconds} ��";
                }));
            }
            else
            {
                timer.Stop();
                await UpdateStockInfoAsync();
                countdownSeconds = defaultCountdown; // ���m�˼ƭp��
                timer.Start();
            }
        }

        private async void btnGetStockInfo_Click(object sender, EventArgs e)
        {
            await UpdateStockInfoAsync();
            countdownSeconds = defaultCountdown; // ���m�˼ƭp��
            timerMain.Start();
        }
        private async Task UpdateStockInfoAsync()
        {
            try
            {
                TwseService twseService = new TwseService();
                var stockData = await twseService.GetStockPricesAsync(new List<string>() { "tse_2330.tw", "tse_6669.tw", "tse_0050.tw", "tse_0056.tw", "tse_1301.tw", "tse_2690.tw", "tse_2317.tw", "tse_2892.tw", "tse_3008.tw", "tse_2603.tw", "tse_2603.tw", "tse_2454.tw", "tse_2303.tw" });
                //gvMain.AutoGenerateColumns = false;
                //gvMain.DataSource = stockData;
                //lblTimerGvMainDesc.Text = "��Ƥw��s";
                // ���^�D�u�{��s UI
                this.Invoke((MethodInvoker)(() =>
                {
                    gvMain.AutoGenerateColumns = false;
                    gvMain.DataSource = stockData;
                    lblTimerGvMainDesc.Text = "��Ƥw��s";
                }));
            }
            catch (Exception ex)
            {
                //lblTimerGvMainDesc.Text = "��s���ѡG" + ex.Message;
                this.Invoke((MethodInvoker)(() =>
                {
                    lblTimerGvMainDesc.Text = "��s���ѡG" + ex.Message;
                }));
            }
        }


        private void chkAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoUpdate.Checked)
            {
                countdownSeconds = defaultCountdown; // ���m�˼ƭp��
                timer.Start();
            }
            else
            {
                lblTimerGvMainDesc.Text = "";
                timer.Stop();
            }
        }

        private void gvMain_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // �ˬd�O�_�O�ؼЦC
            if (e.ColumnIndex == 6 && e.RowIndex >= 0 && e.Value != null)
            {
                e.Handled = true; // �T���q�{ø��
                e.PaintBackground(e.CellBounds, true); // ø��I��

                // ����椸�檺��
                // ���ձN�椸�檺���ഫ���Ʀr
                if (decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    // �]�m��r�C��M�b�Y�Ϥ�
                    Color textColor = value >= 0 ? Color.Red : Color.Green;
                    Image arrowImage = value >= 0
                        ? Properties.Resources.arrow_up // �V�W�b�Y�Ϥ�
                        : Properties.Resources.arrow_down; // �V�U�b�Y�Ϥ�

                    // �]�m�Ϥ��ؤo
                    int imageWidth = 16;
                    int imageHeight = 16;

                    // �p��Ϥ��M��r����m
                    int imageX = e.CellBounds.Right - imageWidth - 8; // �Ϥ��Z���k�� 5 ����
                    int imageY = e.CellBounds.Top + (e.CellBounds.Height - imageHeight) / 2;

                    string cellText = e.Value.ToString();
                    using (Brush textBrush = new SolidBrush(textColor))
                    {
                        // �p���r��ø���m�A����r��K�Ϥ�����
                        SizeF textSize = e.Graphics.MeasureString(cellText, e.CellStyle.Font);
                        int textX = imageX - (int)textSize.Width - 3; // ��r�Z���Ϥ����� 5 ����
                        int textY = e.CellBounds.Top + (e.CellBounds.Height - (int)textSize.Height) / 2;

                        // ø���r
                        e.Graphics.DrawString(
                            cellText,
                            e.CellStyle.Font,
                            textBrush,
                            new PointF(textX, textY)
                        );
                    }

                    // ø��b�Y�Ϥ�
                    if (arrowImage != null)
                    {
                        e.Graphics.DrawImage(arrowImage, new Rectangle(imageX, imageY, imageWidth, imageHeight));
                    }

                    // ø��椸�����
                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds);
                }
            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            lblThreadInfo.Text = $"{DateTime.Now.ToString("HH:mm:ss.fff")} �D�n�u�{(UI) Thread ID�G{Thread.CurrentThread.ManagedThreadId}";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            lastPoint = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (isDrawing)
            {
                points.Add(lastPoint); // �O�s��e�I
                points.Add(e.Location); // �O�s���ʹL�{�����s�I

                lastPoint = e.Location; // ��s�W����m

                // Ĳ�o��ø
                this.Invalidate();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Pen pen = new Pen(Color.Black, 2); // �]�m�e���C��M�ʲ�

            for (int i = 0; i < points.Count - 1; i += 2)
            {
                g.DrawLine(pen, points[i], points[i + 1]);
            }
        }

        private void btnClearPainting_Click(object sender, EventArgs e)
        {
            points.Clear(); // �M�ũҦ�ø�s���I
            this.Invalidate(); // ���sø�s�e��
        }
    }
}
