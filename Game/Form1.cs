using System;
using System.Drawing;
using System.Net;
using System.Text.Json;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        const int maxSize = 20;
        GameImage gameImage;
        int cellSize = 65;//размер ячейки

        public Form1()
        {
            InitializeComponent();
            gameImage = new GameImage(new Bitmap("img.png"));
            gameImage.MaxTL();//вычислили максимальное кол-во чисел в вверхней и боковой таблицах
            cellSize = (gameImage.Size > maxSize) ? 50 : 65;
            SettingTables(gameImage);//создали таблицы
            FillingTables(gameImage);//Заполнили таблицы с числами
        }

        private GameImage UploadImage()
        {
            string url = "http://192.168.88.7:8000/img";
            WebClient client = new WebClient();
            string json = client.DownloadString(url);
            return JsonSerializer.Deserialize<GameImage>(json);
        }
        private void SettingTables(GameImage img2)
        {
            //Поле для заполнения
            imgCross.Rows.Clear();
            imgCross.ColumnCount = img2.Size;
            imgCross.RowCount = img2.Size;

            //Верхнее воле с числами
            topData.Rows.Clear();
            topData.ColumnCount = img2.Size;
            topData.RowCount = img2.maxTop;

            //Боковое поле с числами
            leftData.Rows.Clear();
            leftData.ColumnCount = img2.maxLeft;
            leftData.RowCount = img2.Size;

            //Настройка размера ячеек
            for (int i = 0; i < img2.Size; ++i)
            {
                imgCross.Columns[i].Width = cellSize;//ширина столбца
                imgCross.Rows[i].Height = cellSize;//высота строки
                topData.Columns[i].Width = cellSize;
                leftData.Rows[i].Height = cellSize;
            }
            for(int i = 0; i< img2.maxTop; ++i)
                topData.Rows[i].Height = cellSize;
            for (int i = 0; i < img2.maxLeft; ++i)
                leftData.Columns[i].Width = cellSize;

            //Настройка размеров таблиц
            imgCross.Width = cellSize * img2.Size;
            imgCross.Height = cellSize * img2.Size;

            topData.Width = cellSize * img2.Size;
            topData.Height = cellSize * img2.maxTop;

            leftData.Width = cellSize * img2.maxLeft;
            leftData.Height = cellSize * img2.Size;

            //Настройка координат таблиц при изменении их размера
            topData.Left = 20 + leftData.Width; //X coordinate
            leftData.Top = 120 + topData.Height; //Y coordinate
            imgCross.Left = 20 + leftData.Width; //X coordinate
            imgCross.Top = 120 + topData.Height; //Y coordinate

            //Изменение размеров формы
            Height = topData.Height + leftData.Height + 210;
            Width = leftData.Width + topData.Width + 65;
        }
        private void FillingTables(GameImage img2)
        {
            //заполняем верх
            //for (int i = 0; i < img2.Size; ++i)
            //{
            //    var row = img2.Top[i];
            //    for (int j = 0; j < row.Count; ++j)
            //    {
            //        topData.Rows[j].Cells[i].Value = row[j].ToString();
            //    }
            //}
            for (int i = 0; i < img2.Size; ++i)
            {
                var row = img2.Top[i];
                int j = img2.maxTop - row.Count;
                foreach (int el in row)
                    topData.Rows[j++].Cells[i].Value = el.ToString();
            }
            //заполняем бок
            //for (int i = 0; i < img2.Size; ++i)
            //{
            //    var row = img2.Left[i];
            //    for (int j = 0; j < row.Count; ++j)
            //    {
            //        leftData.Rows[i].Cells[j].Value = row[j].ToString();
            //    }
            //}
            for (int i = 0; i < img2.Size; ++i)
            {
                var row = img2.Left[i];
                int j = img2.maxLeft - row.Count;
                foreach (int el in row)
                    leftData.Rows[i].Cells[j++].Value = el.ToString();
            }
        }
        private void UpdatingTables()
        {
            var img2 = UploadImage();//скачали изображение
            img2.MaxTL();//вычислили максимальное кол-во чисел в вверхней и боковой таблицах
            SettingTables(img2);//создали таблицы
            FillingTables(img2);//заполнили боковую и верхнюю таблицы цифрами
        }

        private void imgCross_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (imgCross.CurrentCell.Style.BackColor != Color.Gray)
                imgCross.CurrentCell.Style.BackColor = (imgCross.CurrentCell.Style.BackColor == Color.White) ? Color.Black : Color.White;
        }
        private void imgCross_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                imgCross.CurrentCell.Style.BackColor = (imgCross.CurrentCell.Style.BackColor == Color.White) ? Color.Gray : Color.White;
        }

        private void imgCross_SelectionChanged(object sender, EventArgs e)
        {
            imgCross.ClearSelection();
        }
        private void topData_SelectionChanged(object sender, EventArgs e)
        {
            topData.ClearSelection();
        }
        private void leftData_SelectionChanged(object sender, EventArgs e)
        {
            leftData.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdatingTables();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            GameImage decision = new GameImage(imgCross);
            string str = (gameImage.CheckCross(decision))? "Поздавляем, Вы решили кросворд!!!": "Кроссворд еще не решён, попробуйте доделать!";
            MessageBox.Show(str);
        }
    }
}