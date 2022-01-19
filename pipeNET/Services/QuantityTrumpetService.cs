using System;
<<<<<<< HEAD
using System.Text.RegularExpressions;
using SpeechNet.Controllers;
=======
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections.Generic;
<<<<<<< HEAD
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;
=======
using System.IO;
using System.Diagnostics;
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b

namespace SpeechNet.Services
{
    public class Pipe
    {
        public Color colorPIPE = Color.Orange;

        public List<int> PathX;
        public List<int> PathY;
        public List<int> PathSum;

        public int CoeffDiff;
        
        public int TrumpSize;
        public int Number;
        public int XcoordTrump;
        public int YcoordTrump;
        public int TargetcoordTrumpX;
        public int TargetcoordTrumpY;
        public int TargetCoordXleft;
        public int TargetCoordYleft;
        public int TargetCoordXright;
        public int TargetCoordYright;

        public static List<T> Swap<T>(List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
            return list;
        }

        public Pipe(int num, int X, int Y, int argXleft, int argYleft, int argXright, int argYright, int size, List<int> pathX, List<int> pathY)
        {
            int buf;

            PathX = pathX;
            PathY = pathY;

            for (int i = 0; i < PathX.Count; i++)
            {
                buf = Math.Abs(argXleft - pathX[i]);

                for (int j = 1; j < PathX.Count; j++)
                {
                    if (Math.Abs(argXleft - pathX[j]) < buf) pathX = Swap(pathX, i, j);
                }                
            }

            for (int i = 0; i < PathY.Count; i++)
            {
                buf = Math.Abs(argYleft - pathY[i]);

                for (int j = 1; j < PathX.Count; j++)
                {
                    if (Math.Abs(argYleft - pathY[j]) < buf) pathY = Swap(pathY, i, j);
                }
            }

            int start = PathX[0];

            for (int i = 0; i < PathX.Count; i++)
            {
                pathX[i] = PathX[i] - start;
            }

            start = PathY[0];

            for (int i = 0; i < PathY.Count; i++)
            {
                pathX[i] = PathY[i] - start;
            }

<<<<<<< HEAD
            //SortMinMAx();

=======
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
            Number = num;

            TrumpSize = size;

            XcoordTrump = X;
            YcoordTrump = Y;

            TargetCoordXleft = argXleft;
            TargetCoordYleft = argYleft;
            TargetCoordXright = argXright;
            TargetCoordYright = argYright;

            TargetcoordTrumpX = Math.Abs(TargetCoordXleft - TargetCoordXright) / 2 + TargetCoordXleft;
            TargetcoordTrumpY = Math.Abs(TargetCoordYleft - TargetCoordYright) / 2 + TargetCoordYleft;
        }
    }

    public class PipeDeleted : Pipe
    {
        public new Color colorPIPE = Color.Red;
        public int lastIDX;
        public PipeDeleted(int index, int num, int X, int Y, int argXleft, int argYleft, int argXright, int argYright, int size, List<int> pathX, List<int> pathY) 
            : base (num, X, Y, argXleft, argYleft, argXright, argYright, size, pathX, pathY)
        {
            lastIDX = index;
        }
    }

    public static class QuantityTrumpetService
    {
<<<<<<< HEAD
=======
        static string file;
        static string username;

        static int bufI = 0;
        static int bufJ = 0;

        static Bitmap image;
        static void CreatePaths(string args)
        {
            username = args;

            file = @"wwwroot\Files";

            args = file + "\\" + args + ".bmp";

            file = @"wwwroot\Files\" + username + "mod.bmp";
        }

>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
        static int GetDecimalDigitsCount(double number)
        {
            string[] str = number.ToString(new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." }).Split('.');
            return str.Length == 2 ? str[1].Length : 0;
        }

        public static Bitmap AdjustContrast(Bitmap Image, float Value)
        {
            Value = (100.0f + Value) / 100.0f;
            Value *= Value;
<<<<<<< HEAD
            Bitmap NewBitmap = new Bitmap(Image);
=======

            Bitmap NewBitmap = new Bitmap(Image);

>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
            BitmapData data = NewBitmap.LockBits(
                new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
                ImageLockMode.ReadWrite,
                NewBitmap.PixelFormat);
<<<<<<< HEAD
=======

>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
            int Height = NewBitmap.Height;
            int Width = NewBitmap.Width;

            unsafe
            {
                for (int y = 0; y < Height; ++y)
                {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < Width; ++x)
                    {
                        byte B = row[columnOffset];
                        byte G = row[columnOffset + 1];
                        byte R = row[columnOffset + 2];

                        float Red = R / 255.0f;
                        float Green = G / 255.0f;
                        float Blue = B / 255.0f;
                        Red = (((Red - 0.5f) * Value) + 0.5f) * 255.0f;
                        Green = (((Green - 0.5f) * Value) + 0.5f) * 255.0f;
                        Blue = (((Blue - 0.5f) * Value) + 0.5f) * 255.0f;

                        int iR = (int)Red;
                        iR = iR > 255 ? 255 : iR;
                        iR = iR < 0 ? 0 : iR;
                        int iG = (int)Green;
                        iG = iG > 255 ? 255 : iG;
                        iG = iG < 0 ? 0 : iG;
                        int iB = (int)Blue;
                        iB = iB > 255 ? 255 : iB;
                        iB = iB < 0 ? 0 : iB;

                        row[columnOffset] = (byte)iB;
                        row[columnOffset + 1] = (byte)iG;
                        row[columnOffset + 2] = (byte)iR;

                        columnOffset += 4;
                    }
                }
            }

            Image.Dispose();

            NewBitmap.UnlockBits(data);

            return NewBitmap;
        }

        static int checkDifferenceFORtwo(Pipe a, Pipe b)
        {
            int SUMX = 0, SUMY = 0;

            if (a.PathX.Count == b.PathX.Count)
            {
                for (int i = 0; i < a.PathX.Count; i++)
                    SUMX += Math.Abs(a.PathX[i] - b.PathX[i]);
            }
            else if (a.PathX.Count > b.PathX.Count)
            {
                int bufMax = a.PathX.Count - b.PathX.Count;

                for (int i = 0; i <= bufMax; i++)
                    b.PathX.Add(0);
                
                for (int i = 0; i < a.PathX.Count; i++)
                    SUMX += Math.Abs(a.PathX[i] - b.PathX[i]);
            }
            else
            {
                int bufMax = b.PathX.Count - a.PathX.Count;

                for (int i = 0; i <= bufMax; i++) 
                    a.PathX.Add(0);

                for (int i = 0; i < b.PathX.Count; i++)
                    SUMX += Math.Abs(b.PathX[i] - a.PathX[i]);
            }

            if (a.PathY.Count == b.PathY.Count)
            {
                for (int i = 0; i < a.PathY.Count; i++)
                    SUMY += Math.Abs(a.PathY[i] - b.PathY[i]);
            }
            else if (a.PathY.Count > b.PathY.Count)
            {
                int bufMax = a.PathY.Count - b.PathY.Count;

                for (int i = 0; i < bufMax; i++)
                    b.PathY.Add(0);

                for (int i = 0; i < a.PathY.Count; i++)
                    SUMY += Math.Abs(a.PathY[i] - b.PathY[i]);
            }
            else
            {
                int bufMax = b.PathY.Count - a.PathY.Count;

                for (int i = 0; i < bufMax; i++)
                    a.PathY.Add(0);

                for (int i = 0; i < b.PathY.Count; i++)
                    SUMY += Math.Abs(b.PathY[i] - a.PathY[i]);
            }

            return SUMX + SUMY;
        }

<<<<<<< HEAD
=======
        static Bitmap SaveResized_Image(Bitmap image, string file, string username, int width = 128, int height = 128)
        {
            var resized = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(resized))
            {
                graphics.CompositingQuality = CompositingQuality.HighSpeed;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.DrawImage(image, 0, 0, width, height);

                file = @"wwwroot\Files\" + username + "mod2.bmp";

                resized.Save(file, ImageFormat.Bmp);

                Bitmap image_buf = new Bitmap(file);

                image = image_buf;

                file = @"wwwroot\Files\" + username + "mod.bmp";
            }

            resized.Dispose();

            return image;
        }

>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
        static decimal checkDifference(List<Pipe> pipes, bool right = false)
        {
            int SUMdiff = 0, LF;

            if (right)
                LF = (int)Math.Sqrt(pipes.Count) - (int)Math.Sqrt(pipes.Count) / 2;
            else
            {
                LF = (int)Math.Round(Math.Sqrt(pipes.Count)) + 1;

                if(LF > 6) LF = 6;
            }

            for (int i = 0; i < pipes.Count; i++)
            {
                for (int j = 0; j < pipes.Count; j++)
                {
                    if (i != j)
                        SUMdiff += (checkDifferenceFORtwo(pipes[i], pipes[j]) / pipes.Count);
                }
            }
            if (SUMdiff != 0)
                return (decimal)Math.Round((1.0 - (double)pipes.Count / SUMdiff), LF);
            else return 0;
        }

<<<<<<< HEAD
        static List<Pipe> SearchPipes(List<Pipe> Pipes)
        {
            for (int i = 0; i < Pipes.Count; i++)
                for (int j = i; j < Pipes.Count; j++)
                    if (Pipes[i].TrumpSize > Pipes[j].TrumpSize) Pipes = Pipe.Swap(Pipes, i, j);

            for (int i = 0; i < Pipes.Count; i++)
                Pipes[i].Number = i;

            int AVG_TS = 0;

            for (int i = 0; i < Pipes.Count; i++)
                AVG_TS += Pipes[i].TrumpSize;

            AVG_TS /= Pipes.Count;

            for (int i = 0; i < Pipes.Count; i++)
                if (Pipes[i].TrumpSize < AVG_TS / 4)
                {
                    Pipes.RemoveAt(i);

                    i--;
                }

            for (int i = 0; i < Pipes.Count; i++)
                if (Pipes[i].TrumpSize > AVG_TS * 4)
                {
                    Pipes.RemoveAt(i);

                    i--;
                }

            decimal diff_PipesTargetSearch = checkDifference(Pipes);

            decimal buf = diff_PipesTargetSearch;

            bool LeftRight = true; // true - лево

            List<Pipe> PipesBuf = new List<Pipe>(Pipes);

            decimal mult = 0;

            do
            {
                if (LeftRight == true)
                {                    
                    PipesBuf.RemoveAt(0);

                    diff_PipesTargetSearch = checkDifference(PipesBuf);
                }
                else
                {                  
                    PipesBuf.RemoveAt(PipesBuf.Count - 1);

                    diff_PipesTargetSearch = checkDifference(PipesBuf, true);

                    mult = (decimal)0.0002 / (decimal)Math.Sqrt(Pipes.Count);
                }                            

                if (buf > diff_PipesTargetSearch + mult)
                {
                    Pipes = new List<Pipe>(PipesBuf);

                    buf = diff_PipesTargetSearch;
                }
                else if (!LeftRight) break;
                else
                {                  
                    LeftRight = false;

                    PipesBuf = new List<Pipe>(Pipes);                   
                }
            }
            while (true);


            return Pipes;
        }

        static public int CalcTrump(string args)
        {
            List<Pipe> pipe = new List<Pipe>();

            List<PipeDeleted> pipeDEL = new List<PipeDeleted>();

            string username = args;

            var file = @"wwwroot\Files";

            args = file + "\\" + args + ".bmp";

            file = @"wwwroot\Files\" + username + "mod.bmp";

            FileStream jpegStream = new FileStream(args, FileMode.Open, FileAccess.Read);

            Bitmap image;
            try
            {
                image = new Bitmap(jpegStream);
            }
            catch
            {
                jpegStream.Close();

                return -1;
            }

            int bufI = 0, bufJ = 0;

            bool checkPX(UInt32 lol, UInt32 targetColor, int i, int j, bool SETcoord = true)
            {
                UInt32 colorPX;

                colorPX = (UInt32)image.GetPixel(i - 1, j - 1).ToArgb();
                if (colorPX > targetColor - lol && colorPX < targetColor + lol)
                {
                    i--;
=======
        static void create_resImg(List<Pipe> pipes, FileStream imageStream)
        {
            int widthOrig = 1280;
            int heightOrig = 1280;
            int width = 128;
            int height = 128;

            Bitmap image3 = new Bitmap(imageStream);

            image3 = SaveResized_Image(image3, file, username, 1280, 1280);


            for (int i = 0; i < pipes.Count; i++)
            {
                for (int j = pipes[i].TrumpSize / 2; j != 0; j--)
                {
                    image.SetPixel(pipes[i].XcoordTrump, pipes[i].YcoordTrump, Color.Green);

                    image.SetPixel(pipes[i].TargetcoordTrumpX, pipes[i].TargetcoordTrumpY, Color.Blue);

                    int otstup = pipes[i].TrumpSize / 16;

                    for (int k = pipes[i].TrumpSize / 2; k != 0; k--)
                    {
                        if
                          (
                           (int)Math.Round((double)(pipes[i].TargetcoordTrumpX) * (widthOrig / width)) + j - otstup < image3.Width
                           &&
                           (int)Math.Round((double)(pipes[i].TargetcoordTrumpY) * (heightOrig / height)) + k - otstup < image3.Height
                          )
                            image3.SetPixel((int)Math.Round((double)(pipes[i].TargetcoordTrumpX) * (widthOrig / width)) + j - otstup, (int)Math.Round((double)(pipes[i].TargetcoordTrumpY) * (heightOrig / height)) + k - otstup, pipes[i].colorPIPE);
                    }
                }
            }

            file = @"wwwroot\Files\" + username + "mod3.bmp";

            image3.Save(file, ImageFormat.Bmp);

            image3.Dispose();

            imageStream.Dispose();
        }

        static bool checkPX(UInt32 lol, UInt32 targetColor, int i, int j, bool SETcoord = true)
        {
            UInt32 colorPX;

            colorPX = (UInt32)image.GetPixel(i - 1, j - 1).ToArgb();
            if (colorPX > targetColor - lol && colorPX < targetColor + lol)
            {
                i--;
                j--;
            }
            else
            {
                colorPX = (UInt32)image.GetPixel(i, j - 1).ToArgb();
                if (colorPX > targetColor - lol && colorPX < targetColor + lol)
                {
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
                    j--;
                }
                else
                {
<<<<<<< HEAD
                    colorPX = (UInt32)image.GetPixel(i, j - 1).ToArgb();
                    if (colorPX > targetColor - lol && colorPX < targetColor + lol)
                    {
=======
                    colorPX = (UInt32)image.GetPixel(i + 1, j - 1).ToArgb();
                    if (colorPX > targetColor - lol && colorPX < targetColor + lol)
                    {
                        i++;
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
                        j--;
                    }
                    else
                    {
<<<<<<< HEAD
                        colorPX = (UInt32)image.GetPixel(i + 1, j - 1).ToArgb();
                        if (colorPX > targetColor - lol && colorPX < targetColor + lol)
                        {
                            i++;
                            j--;
                        }
                        else
                        {
                            colorPX = (UInt32)image.GetPixel(i - 1, j).ToArgb();
                            if (colorPX > targetColor - lol && colorPX < targetColor + lol)
                            {
                                i--;
                            }
                            else
                            {
                                colorPX = (UInt32)image.GetPixel(i + 1, j).ToArgb();
                                if (colorPX > targetColor - lol && colorPX < targetColor + lol)
                                {
                                    i++;
                                }
                                else
                                {
                                    colorPX = (UInt32)image.GetPixel(i - 1, j + 1).ToArgb();
                                    if (colorPX > targetColor - lol && colorPX < targetColor + lol)
                                    {
                                        i--;
=======
                        colorPX = (UInt32)image.GetPixel(i - 1, j).ToArgb();
                        if (colorPX > targetColor - lol && colorPX < targetColor + lol)
                        {
                            i--;
                        }
                        else
                        {
                            colorPX = (UInt32)image.GetPixel(i + 1, j).ToArgb();
                            if (colorPX > targetColor - lol && colorPX < targetColor + lol)
                            {
                                i++;
                            }
                            else
                            {
                                colorPX = (UInt32)image.GetPixel(i - 1, j + 1).ToArgb();
                                if (colorPX > targetColor - lol && colorPX < targetColor + lol)
                                {
                                    i--;
                                    j++;
                                }
                                else
                                {
                                    colorPX = (UInt32)image.GetPixel(i, j + 1).ToArgb();
                                    if (colorPX > targetColor - lol && colorPX < targetColor + lol)
                                    {
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
                                        j++;
                                    }
                                    else
                                    {
<<<<<<< HEAD
                                        colorPX = (UInt32)image.GetPixel(i, j + 1).ToArgb();
                                        if (colorPX > targetColor - lol && colorPX < targetColor + lol)
                                        {
                                            j++;
                                        }
                                        else
                                        {
                                            colorPX = (UInt32)image.GetPixel(i + 1, j + 1).ToArgb();
                                            if (colorPX > targetColor - lol && colorPX < targetColor + lol)
                                            {
                                                i++;
                                                j++;
                                            }
                                            else return false;
                                        }
=======
                                        colorPX = (UInt32)image.GetPixel(i + 1, j + 1).ToArgb();
                                        if (colorPX > targetColor - lol && colorPX < targetColor + lol)
                                        {
                                            i++;
                                            j++;
                                        }
                                        else return false;
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
                                    }
                                }
                            }
                        }
                    }
                }
<<<<<<< HEAD

                if (SETcoord == true)
                {
                    bufI = i;
                    bufJ = j;
                }

                return true;
            }

            int quantity = 0;
            int widthOrig = 1280;
            int heightOrig = 1280;
            int width = 128;
            int height = 128;

            UInt32 colorPX;
            UInt32 colorGray = (UInt32)Color.Gray.ToArgb();
            UInt32 colorWhite = (UInt32)Color.White.ToArgb();
            UInt32 colorBlack = (UInt32)Color.Black.ToArgb();
            UInt32 lol = 1100000;
            UInt32 targetColorLocal = 0xFF000000;
            UInt32 targetColorInter = 0;
            UInt32 targetColorSet = (UInt32)Color.Red.ToArgb();

            var resized = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(resized))
            {
                graphics.CompositingQuality = CompositingQuality.HighSpeed;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.DrawImage(image, 0, 0, width, height);

                file = @"wwwroot\Files\" + username + "mod2.bmp"; 
                
                resized.Save(file, ImageFormat.Bmp);

                Bitmap image2 = new Bitmap(file);

                image = image2;

                file = @"wwwroot\Files\" + username + "mod.bmp";
            }

            resized.Dispose();

            for(int i = 0; i < image.Width; i++)
            {
                image.SetPixel(i, 0, Color.White);
            }

            for (int i = 0; i < image.Width; i++)
            {
                image.SetPixel(i, image.Height - 1, Color.White);
            }

            for (int i = 0; i < image.Height; i++)
            {
                image.SetPixel(0, i, Color.White);
            }

            for (int i = 0; i < image.Height; i++)
            {
                image.SetPixel(0, i, Color.White);
=======
            }

            if (SETcoord == true)
            {
                bufI = i;
                bufJ = j;
            }

            return true;
        }

        static void Redrawing()
        {
            UInt32 colorPX;
            UInt32 colorGray = (UInt32)Color.Gray.ToArgb();
            UInt32 colorBlack = (UInt32)Color.Black.ToArgb();
            UInt32 lol = 1100000;
            UInt32 targetColorLocal = 0xFF000000;

            image = SaveResized_Image(image, file, username);

            //
            for (int i = 0; i < image.Width; i++)
            {
                image.SetPixel(i, 0, Color.White); image.SetPixel(i, image.Height - 1, Color.White);
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
            }

            for (int i = 0; i < image.Height; i++)
            {
<<<<<<< HEAD
                image.SetPixel(image.Width - 1, i, Color.White);
            }        

            float qBlack = 0, qGray = 0;        
=======
                image.SetPixel(0, i, Color.White); image.SetPixel(0, i, Color.White);
                image.SetPixel(image.Width - 1, i, Color.White);
            }
            // новый код - разобратся, сука разберись а не забей хуй, уебок.

            float qBlack = 0, qGray = 0;
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b

            for (int j = 0; j < image.Height; j++)
            {
                for (int i = 0; i < image.Width; i++)
                {
                    colorPX = (UInt32)image.GetPixel(i, j).ToArgb();

                    UInt32 colorB;
                    UInt32 colorG;

                    if (colorPX < colorGray) colorG = colorGray - colorPX;
                    else colorG = colorPX - colorGray;

                    if (colorPX < colorBlack) colorB = colorBlack - colorPX;
                    else colorB = colorPX - colorBlack;

<<<<<<< HEAD
                    if (colorG / 2 < colorB) qGray++;             
                    else qBlack++;
                    
                }
            }          

            if(qBlack / qGray < 0.07)
=======
                    if (colorG / 2 < colorB) qGray++;
                    else qBlack++;

                }
            }

            if (qBlack / qGray < 0.07)
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
                image = AdjustContrast(image, 2 + (1 - (1 - qBlack / qGray)) * 100 * 2); // увилечение контрастности
            else if (qBlack / qGray < 0.90)
                image = AdjustContrast(image, -1); // увилечение контрастности

            image.Save(file, ImageFormat.Bmp);// убрать на релизе, это для отслеживания;

            for (int j = 0; j < image.Height; j++)
            {
                for (int i = 0; i < image.Width; i++)
                {
                    colorPX = (UInt32)image.GetPixel(i, j).ToArgb();

                    UInt32 colorB;
                    UInt32 colorG;

                    if (colorPX < colorGray) colorG = colorGray - colorPX;
                    else colorG = colorPX - colorGray;

                    if (colorPX < colorBlack) colorB = colorBlack - colorPX;
                    else colorB = colorPX - colorBlack;

                    if (colorG / 2 < colorB) image.SetPixel(i, j, Color.Gray);
                    else image.SetPixel(i, j, Color.Black);
                }
            }

            const int qDel = 1;

            for (int q = 0; q < qDel; q++)
            {
                for (int k = 0; k < 1; k++)// k для возможно будущего определение съедания границ
                {
                    for (int j = 0; j < image.Height; j++)
                    {
                        for (int i = 0; i < image.Width; i++)
                        {
                            colorPX = (UInt32)image.GetPixel(i, j).ToArgb();

                            if (colorPX > targetColorLocal - lol && colorPX < targetColorLocal + lol)
                            {
                                if (checkPX(1, colorGray, i, j, false) == true)
                                {
                                    image.SetPixel(i, j, Color.Red);
                                }
                            }
                        }
                    }
                }
                for (int j = 0; j < image.Height; j++)
                {
                    for (int i = 0; i < image.Width; i++)
                    {
                        colorPX = (UInt32)image.GetPixel(i, j).ToArgb();
                        if (colorPX == (UInt32)Color.Red.ToArgb())
                        {
                            image.SetPixel(i, j, Color.Gray);
                        }
                    }
                }

                bufI = 0;
                bufJ = 0;

                for (int k = 0; k < 1; k++)// k для возможно будущего определение добаления границ
                {
                    for (int j = 0; j < image.Height; j++)
                    {
                        for (int i = 0; i < image.Width; i++)
                        {
                            colorPX = (UInt32)image.GetPixel(i, j).ToArgb();

                            if (colorPX > targetColorLocal - lol && colorPX < targetColorLocal + lol)
                            {
                                if (checkPX(1, colorGray, i, j) == true)
                                {
                                    image.SetPixel(bufI, bufJ, Color.Red);
                                }
                            }
                        }
                    }
                }
                for (int j = 0; j < image.Height; j++)
                {
                    for (int i = 0; i < image.Width; i++)
                    {
                        colorPX = (UInt32)image.GetPixel(i, j).ToArgb();
                        if (colorPX == (UInt32)Color.Red.ToArgb())
                        {
                            image.SetPixel(i, j, Color.Black);
                        }
                    }
                }

                bufI = 0;
                bufJ = 0;
            }
<<<<<<< HEAD

            image.Save(file, ImageFormat.Bmp);// убрать на релизе, это для отслеживания;
=======
        }

        static List<Pipe> SearchPipes()
        {
            List<Pipe> pipe = new List<Pipe>();

            UInt32 colorPX;
            UInt32 lol = 1100000;
            UInt32 targetColorLocal = 0xFF000000;
            UInt32 targetColorInter = 0;
            UInt32 targetColorSet = (UInt32)Color.Red.ToArgb();
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b

            int num = 0;

            for (int j = 0; j < image.Height; j++)
            {
                for (int i = 0; i < image.Width; i++)
                {
                    colorPX = (UInt32)image.GetPixel(i, j).ToArgb();

                    if (colorPX > targetColorLocal - lol && colorPX < targetColorLocal + lol && checkPX(2, targetColorSet, i, j, false) == false)
                    {
                        image.SetPixel(i, j, Color.Red);

<<<<<<< HEAD
                        if(targetColorInter == 0) targetColorInter = (UInt32) image.GetPixel(i, j - 1).ToArgb();
=======
                        if (targetColorInter == 0) targetColorInter = (UInt32)image.GetPixel(i, j - 1).ToArgb();
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b

                        int SizeCircuit = 0;

                        int bufTargetCoordXleft = i;
                        int bufTargetCoordYleft = j;
                        int bufTargetCoordXright = i;
                        int bufTargetCoordYright = j;
                        int startX = i;
                        int startY = j;

<<<<<<< HEAD
                        List<int> bufPathX = new List<int>();
                        List<int> bufPathY = new List<int>();
                        List<int> bufCoordColorX = new List<int>();
                        List<int> bufCoordColorY = new List<int>();
                     
=======
                        List<int> bufPathX = new();
                        List<int> bufPathY = new();
                        List<int> bufCoordColorX = new();
                        List<int> bufCoordColorY = new();
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b

                        while (true)
                        {
                            if (checkPX(lol, targetColorLocal, i, j) == true)
                            {
                                SizeCircuit++;

                                bufPathX.Add(i);
                                bufPathY.Add(j);

                                if (checkPX(lol, targetColorInter, bufI, bufJ, false) == true)
                                {
                                    if (image.GetPixel(bufI, bufJ).ToArgb() != Color.Gray.ToArgb())
                                    {
                                        if (bufCoordColorX.Count != 0)
                                        {
                                            for (int icolor = 0; icolor < bufCoordColorX.Count; icolor++)
                                                image.SetPixel(bufCoordColorX[icolor], bufCoordColorY[icolor], Color.Black);

                                            bufCoordColorX.Clear();
                                            bufCoordColorY.Clear();
                                        }

                                        if (bufTargetCoordXleft > i) bufTargetCoordXleft = i;
                                        if (bufTargetCoordYleft > j) bufTargetCoordYleft = j;
                                        if (bufTargetCoordXright < i) bufTargetCoordXright = i;
                                        if (bufTargetCoordYright < j) bufTargetCoordYright = j;

                                        image.SetPixel(bufI, bufJ, Color.Red);

                                        i = bufI;
<<<<<<< HEAD
                                        j = bufJ;              
=======
                                        j = bufJ;
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
                                    }
                                }
                                else
                                {
                                    bufCoordColorX.Add(bufI);
                                    bufCoordColorY.Add(bufJ);
<<<<<<< HEAD
             
                                    image.SetPixel(bufI, bufJ, Color.Red);
                                }
                            }
                            else 
=======

                                    image.SetPixel(bufI, bufJ, Color.Red);
                                }
                            }
                            else
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
                            {
                                if (bufCoordColorX.Count != 0)
                                {
                                    for (int icolor = 0; icolor < bufCoordColorX.Count; icolor++)
                                        image.SetPixel(bufCoordColorX[icolor], bufCoordColorY[icolor], Color.Black);

                                    bufCoordColorX.Clear();
                                    bufCoordColorY.Clear();
                                }

                                if (SizeCircuit != 0)
                                {
                                    num++;

                                    pipe.Add(
                                        new Pipe(
                                            num,
                                            i,
                                            j,
                                            bufTargetCoordXleft,
                                            bufTargetCoordYleft,
                                            bufTargetCoordXright,
                                            bufTargetCoordYright,
                                            SizeCircuit,
                                            bufPathX,
                                            bufPathY
                                            )
                                        );

                                    UInt32 colorPXbuf = (UInt32)image.GetPixel(pipe[pipe.Count - 1].TargetcoordTrumpX, pipe[pipe.Count - 1].TargetcoordTrumpY).ToArgb();

                                    if (colorPXbuf == targetColorInter) pipe.RemoveAt(pipe.Count - 1);
                                }
<<<<<<< HEAD
                                
=======

>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
                                i = 0;
                                j = 0;

                                bufI = 0;
                                bufJ = 0;

                                break;
                            }
                        }
                    }
                    else if (colorPX == targetColorSet)
                    {
                        i++;

<<<<<<< HEAD
                        while(true)
=======
                        while (true)
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
                        {
                            colorPX = (UInt32)image.GetPixel(i, j).ToArgb();

                            if (colorPX > targetColorLocal - lol && colorPX < targetColorLocal + lol || colorPX == targetColorSet) i++;
                            else break;
                        }
                    }
                }
            }

<<<<<<< HEAD
            image.Save(file, ImageFormat.Bmp);// убрать на релизе, это для отслеживания;

            pipe = SearchPipes(pipe);

            Bitmap image3 = new Bitmap(jpegStream);

            var resized2 = new Bitmap(widthOrig, heightOrig);
            using (var graphics = Graphics.FromImage(resized2))
            {
                graphics.CompositingQuality = CompositingQuality.HighSpeed;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.DrawImage(image3, 0, 0, widthOrig, heightOrig);

                file = @"wwwroot\Files\" + username + "mod4.bmp";

                resized2.Save(file, ImageFormat.Bmp);

                Bitmap image2 = new Bitmap(file);

                image3 = image2;

                file = @"wwwroot\Files\" + username + "mod.bmp";
            }

            

            quantity = pipe.Count;

            for (int i = 0; i < pipe.Count; i++)
            {
                for (int j = pipe[i].TrumpSize / 2; j != 0; j--)
                {
                    image.SetPixel(pipe[i].XcoordTrump, pipe[i].YcoordTrump, Color.Green);

                    image.SetPixel(pipe[i].TargetcoordTrumpX, pipe[i].TargetcoordTrumpY, Color.Blue);

                    

                    int otstup = pipe[i].TrumpSize / 16;

                    for (int k = pipe[i].TrumpSize / 2; k != 0; k--)
                    {
                        if
                          (
                           (int)Math.Round((double)(pipe[i].TargetcoordTrumpX) * (widthOrig / width)) + j - otstup < image3.Width 
                           && 
                           (int)Math.Round((double)(pipe[i].TargetcoordTrumpY) * (heightOrig / height)) + k - otstup < image3.Height
                          ) 
                          image3.SetPixel((int)Math.Round((double)(pipe[i].TargetcoordTrumpX) * (widthOrig / width)) + j - otstup, (int)Math.Round((double)(pipe[i].TargetcoordTrumpY) * (heightOrig / height)) + k - otstup, pipe[i].colorPIPE);
                    }
                }
            }

            image.Save(file, ImageFormat.Bmp);// убрать на релизе, это для отслеживания; 

            file = @"wwwroot\Files\" + username + "mod3.bmp";

            image3.Save(file, ImageFormat.Bmp);

            image3.Dispose();
            image.Dispose();
            jpegStream.Close();

            return quantity;
=======
            return pipe;
        }

        static List<Pipe> SortPipes(List<Pipe> Pipes)
        {
            for (int i = 0; i < Pipes.Count; i++)
                for (int j = i; j < Pipes.Count; j++)
                    if (Pipes[i].TrumpSize > Pipes[j].TrumpSize) Pipes = Pipe.Swap(Pipes, i, j);

            for (int i = 0; i < Pipes.Count; i++)
                Pipes[i].Number = i;

            int AVG_TS = 0;

            for (int i = 0; i < Pipes.Count; i++)
                AVG_TS += Pipes[i].TrumpSize;

            AVG_TS /= Pipes.Count;

            for (int i = 0; i < Pipes.Count; i++)
                if (Pipes[i].TrumpSize < AVG_TS / 4)
                {
                    Pipes.RemoveAt(i);

                    i--;
                }

            for (int i = 0; i < Pipes.Count; i++)
                if (Pipes[i].TrumpSize > AVG_TS * 4)
                {
                    Pipes.RemoveAt(i);

                    i--;
                }

            decimal diff_PipesTargetSearch = checkDifference(Pipes);

            decimal buf = diff_PipesTargetSearch;

            bool LeftRight = true; // true - лево

            List<Pipe> PipesBuf = new List<Pipe>(Pipes);

            decimal mult = 0;

            do
            {
                if (LeftRight == true)
                {                    
                    PipesBuf.RemoveAt(0);

                    diff_PipesTargetSearch = checkDifference(PipesBuf);
                }
                else
                {                  
                    PipesBuf.RemoveAt(PipesBuf.Count - 1);

                    diff_PipesTargetSearch = checkDifference(PipesBuf, true);

                    mult = (decimal)0.0002 / (decimal)Math.Sqrt(Pipes.Count);
                }                            

                if (buf > diff_PipesTargetSearch + mult)
                {
                    Pipes = new List<Pipe>(PipesBuf);

                    buf = diff_PipesTargetSearch;
                }
                else if (!LeftRight) break;
                else
                {                  
                    LeftRight = false;

                    PipesBuf = new List<Pipe>(Pipes);                   
                }
            }
            while (true);


            return Pipes;
        }

        static public int CalcTrump(string args)
        {
            List<Pipe> pipes = new();

            CreatePaths(args);

            FileStream imageStream = new FileStream(args, FileMode.Open, FileAccess.Read);           
            try
            {
                image = new Bitmap(imageStream);
            }
            catch
            {
                imageStream.Close();

                return -1;
            }

            Redrawing();

            pipes = SortPipes(SearchPipes());

            create_resImg(pipes, imageStream);

            imageStream.Dispose();

            return pipes.Count;
>>>>>>> 2f7fd0a50208aa0c842bf8f425ec758bc1d3e65b
        }
    }
}
// image.Save(file, ImageFormat.Bmp);// убрать на релизе, это для отслеживания;