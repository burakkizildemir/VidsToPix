using MediaToolkit;
using MediaToolkit.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace pielx
{
    class Project
    {
        public string projectPath { get; set; }
        public string squareImagePath { get; set; }

        public List<video> videoList = new List<video>();

        public Image[] imagePieces;

        public Color[] renkler;

        public AddedImage[] addedImageList;

        public static string[] lastBitmaps;

        public string lastImagePath { get; set; }

        public Project(string _mainPhoto, string _projectPath,int pieces)
        {
            try
            {
                projectPath = _projectPath;
                Image img = Image.FromFile(_mainPhoto);
                img = MakeSquarePhoto((Bitmap)img);
                img = resizeImage(img, pieces);
                squareImagePath = projectPath + @"\SquarePhoto.jpeg";
                img.Save(squareImagePath);
                img.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void mainPhotoGetDominant()
        {
            try
            {
                Thread.Sleep(500);
                renkler = new Color[imagePieces.Length];
                Parallel.For(0, imagePieces.Length, i =>
                {
                    Color renk = GetDominantColor((Bitmap)imagePieces[i]);
                    renkler[i] = renk;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void customizePhotos(string jpegPaths)
        {
            try
            {
                Thread.Sleep(500);
                string[] filePaths = System.IO.Directory.GetFiles(jpegPaths);
                addedImageList = new AddedImage[filePaths.Length];
                Parallel.For(0, filePaths.Length, i =>
                {
                    AddedImage addedImage = new AddedImage();
                    Color asd = GetDominantColor((Bitmap)Image.FromFile(@filePaths[i]));
                    addedImage.imageRgb.Red = asd.R;
                    addedImage.imageRgb.Green = asd.G;
                    addedImage.imageRgb.Blue = asd.B;
                    addedImage.imagePath = @filePaths[i];
                    addedImageList[i] = addedImage;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void videoToJpg(string inputPath, string outPath)
        {
            try
            {
                Thread.Sleep(500);
                string Width;
                string Height;
                using (var engine = new Engine())
                {
                    var mp4 = new MediaFile { Filename = inputPath };
                    engine.GetMetadata(mp4);
                    string[] s = mp4.Metadata.VideoData.FrameSize.ToString().Split('x');
                    string a1 = (Math.Abs(int.Parse(s[0]) - int.Parse(s[1])) / 2).ToString();
                    if (Convert.ToInt32(s[1]) < Convert.ToInt32(s[0]))
                    {
                        Width = s[1];
                        Height = s[1];
                    }
                    else
                    {
                        Width = s[0];
                        Height = s[0];
                    }
                    string asd = "-progress block.txt -i " +"\""+ inputPath+ "\""+ " -vf \"crop=" + Width + ":" + Height + ":" + a1 + ":0,scale=216:216\" -r 1 " + "\"" + outPath  + "out%d.jpg" + "\"";
                    engine.CustomCommand(asd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static Color GetDominantColor(Bitmap bmp)
        {
            try
            {
                int r = 0;
                int g = 0;
                int b = 0;
                int total = 0;
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        Color clr = bmp.GetPixel(x, y);
                        r += clr.R;
                        g += clr.G;
                        b += clr.B;
                        total++;
                    }
                }
                r /= total;
                g /= total;
                b /= total;
                bmp.Dispose();
                return Color.FromArgb(r, g, b);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
                return Color.FromArgb(11, 11, 11);
            }
        }

        public static Image resizeImage(Image img, int piece)
        {
            try
            {
                int waste = img.Height % piece;
                System.Drawing.Size size = new System.Drawing.Size(img.Height + (piece - waste), img.Width + (piece - waste));
                return (new Bitmap(img, size));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
                return (new Bitmap("asd"));
            }
        }

        public static Bitmap MakeSquarePhoto(Bitmap bmp)
        {
            int size;
            if (bmp.Width < bmp.Height)
            {
                size = bmp.Width;
            }
            else
            {
                size = bmp.Height;
            }
            try
            {
                Bitmap res = new Bitmap(size, size);
                Graphics g = Graphics.FromImage(res);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, size, size);
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Default;
                int t = 0, l = 0;
                if (bmp.Height > bmp.Width)
                    t = (bmp.Height - bmp.Width) / 2;
                else
                    l = (bmp.Width - bmp.Height) / 2;
                g.DrawImage(bmp, new Rectangle(0, 0, size, size), new Rectangle(l, t, bmp.Width - l * 2, bmp.Height - t * 2), GraphicsUnit.Pixel);
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
                return null;
            }
        }

        public void piecer(string path, int piece)
        {
            try
            {
                Thread.Sleep(500);
                var imgarray = new Image[piece * piece];
                var img2 = Image.FromFile(path);
                var height = img2.Height / piece;
                var width = img2.Width / piece;
                for (int i = 0; i < piece; i++)
                {
                    for (int j = 0; j < piece; j++)
                    {
                        var index = i * piece + j;
                        imgarray[index] = new Bitmap(width, height);
                        var graphics = Graphics.FromImage(imgarray[index]);
                        graphics.DrawImage(img2, new Rectangle(0, 0, width, height), new Rectangle(i * width, j * height, width, height), GraphicsUnit.Pixel);
                        graphics.Dispose();
                    }
                }
                imagePieces = imgarray;
                img2.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static List<int> min(double[] liste, int startindex, double mine)
        {
            try
            {
                List<int> list = new List<int>
                {
                    liste.ToList().IndexOf(mine, startindex)
                };
                if (startindex < liste.Length)
                {
                    return min(liste, liste.ToList().IndexOf(mine, startindex), mine);
                }
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
                return null;
            }

        }
        //public static Image MakeThumb(string path)
        //{
        //    Image image = Image.FromFile(path);
        //    Image thumb = image.GetThumbnailImage(Convert.ToInt32(image.Width * 0.3), Convert.ToInt32(image.Height * 0.3), () => false, IntPtr.Zero);
        //    image.Dispose();
        //    return thumb;
        //}

        public static void siraBulucu(Image[] imagePieces, AddedImage[] addedImageList, Color[] renkler)
        {
            try
            {
                double[] uzaklikList = new double[addedImageList.Length];
                string[] list = new string[imagePieces.Length];

                for (int i = 0; i < imagePieces.Length; i++)
                {
                    Parallel.For(0, addedImageList.Length, j =>
                    {
                        uzaklikList[j] = Math.Sqrt(((renkler[i].R - addedImageList[j].imageRgb.Red) * (renkler[i].R - addedImageList[j].imageRgb.Red))
                            + ((renkler[i].G - addedImageList[j].imageRgb.Green) * (renkler[i].G - addedImageList[j].imageRgb.Green))
                            + ((renkler[i].B - addedImageList[j].imageRgb.Blue) * (renkler[i].B - addedImageList[j].imageRgb.Blue)));
                    });
                    double min = uzaklikList.Min();
                    int minindex = uzaklikList.ToList().IndexOf(min);
                    list[i] = addedImageList[minindex].imagePath;
                    Array.Clear(uzaklikList, 0, uzaklikList.Length);
                }
                lastBitmaps = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public long finalImage(string[] files, int piece)
        {
            try
            {
                Thread.Sleep(500);
                Image last = new Bitmap(piece * 216, piece * 216);
                lastImagePath = projectPath + @"\final.jpg";
                Graphics g = Graphics.FromImage(last);
                int width, height = 0;
                int sayac = 0;
                for (int i = 0; i < piece; i++)
                {
                    width = 0;
                    for (int j = 0; j < piece; j++)
                    {
                        Image tinyImg = Image.FromFile(files[sayac]);
                        g.DrawImage(tinyImg, new System.Drawing.Point(height, width));
                        width += 216;
                        sayac += 1;
                        tinyImg.Dispose();
                    }
                    height += 216;
                }
                last.Save(lastImagePath, ImageFormat.Jpeg);
                long finalsize = new FileInfo(lastImagePath).Length;
                Image thumb = last.GetThumbnailImage(300, 300, () => false, IntPtr.Zero);
                thumb.Save(projectPath + @"\finalThumb.jpg", ImageFormat.Jpeg);
                File.SetAttributes(projectPath + @"\finalThumb.jpg", File.GetAttributes(projectPath + @"\finalThumb.jpg") | FileAttributes.Hidden);
                last.Dispose();
                last = null;
                thumb.Dispose();

                return finalsize;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
                return 0;
            }
        }
    }
}
