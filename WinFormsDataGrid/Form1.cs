using WinFormsDataGrid.Services;

namespace WinFormsDataGrid
{
    public partial class Form1 : Form
    {
        const int defaultCountdown = 3;
        private int countdownSeconds = defaultCountdown; // 倒數計時的秒數
        System.Timers.Timer timer;// differ from system.form.timer

        //drawing related
        private bool isDrawing = false; // 是否正在繪製
        private Point lastPoint; // 上一次的滑鼠位置
        private List<Point> points = new List<Point>(); // 存儲繪製過程中的所有點

        public Form1()
        {
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            InitializeTimer();
            InitializeDrawing();
            lblThreadInfo.Text = $"{DateTime.Now.ToString("HH:mm:ss.fff")} 主要線程(UI) Thread ID：{Thread.CurrentThread.ManagedThreadId}";


            await UpdateStockInfoAsync();
            //timerGvMain.Start();
            timer.Start();
        }
        private void InitializeTimer()
        {
            timer = new System.Timers.Timer(1000); // 每秒觸發一次
            timer.Elapsed += Timer_Elapsed; ; // 指定處理事件
            timer.AutoReset = true; // 自動重複執行
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
                //lblSecondThreadInfo.Text = $"Timer 執行於線程 ID：{Thread.CurrentThread.ManagedThreadId}";
                lblSecondThreadInfo.Text = $"{DateTime.Now.ToString("HH:mm:ss.fff")} 第二線程 Thread ID：{timerThreadId}";

            }));
            if (countdownSeconds > 0)
            {
                countdownSeconds--;
                // 切回主線程更新 UI
                this.Invoke((MethodInvoker)(() =>
                {
                    lblTimerGvMainDesc.Text = $"更新倒數：{countdownSeconds} 秒";
                }));
            }
            else
            {
                timer.Stop();
                await UpdateStockInfoAsync();
                countdownSeconds = defaultCountdown; // 重置倒數計時
                timer.Start();
            }
        }

        private async void btnGetStockInfo_Click(object sender, EventArgs e)
        {
            await UpdateStockInfoAsync();
            countdownSeconds = defaultCountdown; // 重置倒數計時
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
                //lblTimerGvMainDesc.Text = "資料已更新";
                // 切回主線程更新 UI
                this.Invoke((MethodInvoker)(() =>
                {
                    gvMain.AutoGenerateColumns = false;
                    gvMain.DataSource = stockData;
                    lblTimerGvMainDesc.Text = "資料已更新";
                }));
            }
            catch (Exception ex)
            {
                //lblTimerGvMainDesc.Text = "更新失敗：" + ex.Message;
                this.Invoke((MethodInvoker)(() =>
                {
                    lblTimerGvMainDesc.Text = "更新失敗：" + ex.Message;
                }));
            }
        }


        private void chkAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoUpdate.Checked)
            {
                countdownSeconds = defaultCountdown; // 重置倒數計時
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
            // 檢查是否是目標列
            if (e.ColumnIndex == 6 && e.RowIndex >= 0 && e.Value != null)
            {
                e.Handled = true; // 禁用默認繪制
                e.PaintBackground(e.CellBounds, true); // 繪制背景

                // 獲取單元格的值
                // 嘗試將單元格的值轉換為數字
                if (decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    // 設置文字顏色和箭頭圖片
                    Color textColor = value >= 0 ? Color.Red : Color.Green;
                    Image arrowImage = value >= 0
                        ? Properties.Resources.arrow_up // 向上箭頭圖片
                        : Properties.Resources.arrow_down; // 向下箭頭圖片

                    // 設置圖片尺寸
                    int imageWidth = 16;
                    int imageHeight = 16;

                    // 計算圖片和文字的位置
                    int imageX = e.CellBounds.Right - imageWidth - 8; // 圖片距離右側 5 像素
                    int imageY = e.CellBounds.Top + (e.CellBounds.Height - imageHeight) / 2;

                    string cellText = e.Value.ToString();
                    using (Brush textBrush = new SolidBrush(textColor))
                    {
                        // 計算文字的繪制位置，讓文字緊貼圖片左側
                        SizeF textSize = e.Graphics.MeasureString(cellText, e.CellStyle.Font);
                        int textX = imageX - (int)textSize.Width - 3; // 文字距離圖片左側 5 像素
                        int textY = e.CellBounds.Top + (e.CellBounds.Height - (int)textSize.Height) / 2;

                        // 繪制文字
                        e.Graphics.DrawString(
                            cellText,
                            e.CellStyle.Font,
                            textBrush,
                            new PointF(textX, textY)
                        );
                    }

                    // 繪制箭頭圖片
                    if (arrowImage != null)
                    {
                        e.Graphics.DrawImage(arrowImage, new Rectangle(imageX, imageY, imageWidth, imageHeight));
                    }

                    // 繪制單元格邊框
                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds);
                }
            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            lblThreadInfo.Text = $"{DateTime.Now.ToString("HH:mm:ss.fff")} 主要線程(UI) Thread ID：{Thread.CurrentThread.ManagedThreadId}";
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
                points.Add(lastPoint); // 保存當前點
                points.Add(e.Location); // 保存移動過程中的新點

                lastPoint = e.Location; // 更新上次位置

                // 觸發重繪
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

            Pen pen = new Pen(Color.Black, 2); // 設置畫筆顏色和粗細

            for (int i = 0; i < points.Count - 1; i += 2)
            {
                g.DrawLine(pen, points[i], points[i + 1]);
            }
        }

        private void btnClearPainting_Click(object sender, EventArgs e)
        {
            points.Clear(); // 清空所有繪製的點
            this.Invalidate(); // 重新繪製畫布
        }
    }
}
