using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    //http://192.168.88.7:3000/code
    public class GameImage
    {
        public int maxLeft = 0;
        public int maxTop = 0;
        public int Size { get; set; }
        public List<List<int>> Left { get; set; }
        public List<List<int>> Top { get; set; }

        public GameImage(DataGridView imgCross)
        {
            Bitmap image = new Bitmap(imgCross.RowCount, imgCross.ColumnCount);
            for (int x = 0; x < imgCross.RowCount; x++)
                for (int y = 0; y < imgCross.ColumnCount; y++)
                    if(imgCross[x,y].Style.BackColor == Color.Black)
                        image.SetPixel(x, y, Color.Black);
                    else
                        image.SetPixel(x, y, Color.White);
            Size = image.Size.Height;
            Left = new List<List<int>>();
            Top = new List<List<int>>();
            СreateNumber(image);
        }

        public GameImage(Bitmap image)
        {
            Size = image.Size.Height;
            Left = new List<List<int>>();
            Top = new List<List<int>>();
            СreateNumber(image);
        }

        public GameImage()
        {
            Left = new List<List<int>>();
            Top = new List<List<int>>();
        }

        public void СreateNumber(Bitmap image)
        {
            if (Left != null && Top != null)
            {
                //for(int i=0; i<Size; ++i)
                //{
                //    Left.Add(new List<int>());
                //    Top.Add(new List<int>());
                //}
                AddNumber(image);
            }
        }

        public void MaxTL()
        {
            foreach (List<int> top in Top)
                if (top.Count > maxTop)
                    maxTop = top.Count;
            foreach (List<int> left in Left)
                if (left.Count > maxLeft)
                    maxLeft = left.Count;
        }

        private void AddNumber(Bitmap image)
        {
            maxTop = 0;
            maxLeft = 0;
            for (int x = 0; x < Size; ++x)
            {
                var column = new List<int>();
                var prevPix = 1;
                var backCounter = 0;
                for (int y = 0; y < Size; ++y)
                {
                    var pixel = image.GetPixel(x, y);
                    if (pixel.R == 0)
                    {
                        backCounter++;
                        prevPix = 0;
                    }
                    else if (pixel.R != 0 && prevPix == 0)
                    {
                        column.Add(backCounter);
                        backCounter = 0;
                        prevPix = 1;
                    }
                    if (backCounter != 0 && y == Size - 1)
                    {
                        column.Add(backCounter);
                    }
                }
                Top.Add(column);
            }
            for (int y = 0; y < Size; ++y)
            {
                var row = new List<int>();
                var prevPix = 1;
                var backCounter = 0;
                for (int x = 0; x < Size; ++x)
                {
                    var pixel = image.GetPixel(x, y);
                    if (pixel.R == 0)
                    {
                        backCounter++;
                        prevPix = 0;
                    }
                    else if (pixel.R != 0 && prevPix == 0)
                    {
                        row.Add(backCounter);
                        backCounter = 0;
                        prevPix = 1;
                    }
                    if (backCounter != 0 && x == Size - 1)
                    {
                        row.Add(backCounter);
                    }
                }
                Left.Add(row);
            }

            //int count = 0;
            //for (int x = 0; x < Size; ++x)
            //{
            //    for (int y = 0; y < Size; ++y)
            //    {
            //        var pixel = image.GetPixel(x, y);
            //        while (pixel.R == 0 && y < Size)
            //        {
            //            ++y;
            //            if (y < Size)
            //                pixel = image.GetPixel(x, y);
            //            ++count;
            //        }
            //        if (count != 0)
            //        {
            //            Top[x].Add(count);
            //            count = 0;
            //        }
            //    }
            //}
            //for (int y = 0; y < Size; ++y)
            //{
            //    for (int x = 0; x < Size; ++x)
            //    {
            //        var pixel = image.GetPixel(x, y);
            //        while (pixel.R == 0 && x < Size)
            //        {
            //            ++x;
            //            if (x < Size)
            //                pixel = image.GetPixel(x, y);
            //            ++count;
            //        }
            //        if (count != 0)
            //        {
            //            Left[y].Add(count);
            //            count = 0;
            //        }
            //    }
            //}
        }

        public bool CheckCross(GameImage decision)
        {
            for(int i = 0; i < Size; ++i)
            {
                if (Top[i].Count != decision.Top[i].Count)
                    return false;
                for (int j = 0; j < decision.Top[i].Count; ++j)
                    if (Top[i][j] != decision.Top[i][j])
                        return false;
            }
            return true;
        }
    }
}
////Код Андрея
//namespace TheGame
//{
//    public class GameImage
//    {
//        // размер изображения (высота и ширина)
//        public int Size { get; set; }

//        public List<List<int>> Left;
//        public List<List<int>> Top;

//        public GameImage(
//            Bitmap image
//        )
//        {
//            Size = image.Height;

//            Left = new List<List<int>>();
//            Top = new List<List<int>>();

//            for (int x = 0; x < Size; x++)
//            {
//                // создаём новый столбец
//                var column = new List<int>();
//                // создаём новую строку
//                var row = new List<int>();

//                var prevPixel = 1;   // предыдущий пиксель
//                var blackCounter = 0; // счетчик черных пикселей

//                for (int y = 0; y < Size; y++)
//                {
//                    // берем пиксель x, y
//                    var pixel = image.GetPixel(x, y);
//                    // проверяем, что пиксель черный
//                    if (pixel.R == 0)
//                    {
//                        blackCounter++;
//                        prevPixel = 0;
//                    }
//                    // проверяем, что пиксель белый, а предыдущий - черный
//                    else if (pixel.R != 0 && prevPixel == 0)
//                    {
//                        column.Add(blackCounter);
//                        blackCounter = 0;
//                        prevPixel = 1;
//                    }

//                    // проверяем, что в счетчике не пусто и мы в конце столбца
//                    if (blackCounter != 0 && y == Size - 1)
//                    {
//                        column.Add(blackCounter);
//                    }
//                }
//                // добавляем столбец в верхнюю область
//                Top.Add(column);
//            }
//        }

//    }
//}
