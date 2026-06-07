using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using YoutubeExplode;

namespace pielx
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MediaPlayer mediaPlayer = new MediaPlayer();

        readonly object defaultSource;
        string directory;
        string link = "";
        Project project;
        public static long finalsize;
        public static int videoCounter = 1;
        public List<video> videoList = new List<video>();
        readonly List<TabItem> tabItems = new List<TabItem>();
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
                this.Title = "VidsToPix";
                this.Icon = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/LOGO.ico"));
                Slider.Minimum = 30;
                Slider.Maximum = 100;
                Slider.Value = 30;
                defaultSource = photoImage.Source;

                ControlDirectory();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ControlDirectory()
        {
            try
            {
                directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\VidsToPix";
                makeDir(directory);
                makeDir(directory + @"\downloadedVideos");
                directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\VidsToPix\Project1";
                for (int i = 2; ; i++)
                {
                    if (Directory.Exists(directory))
                    {
                        directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\VidsToPix\Project" + i.ToString();
                    }
                    else
                        break;
                }
                pathLbl.Content = directory;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void makeDir(string _directory)
        {
            try
            {
                if (!Directory.Exists(_directory))
                {
                    Directory.CreateDirectory(_directory);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            Process.Start("https://vidstopix.com/");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myBrowser.Navigate("https://vidstopix.com/ad.html");
            try
            {
                homeTab.TabIndex = 0;
                photoTab.TabIndex = 1;
                youtubeVideoTab.TabIndex = 2;
                videoTab.TabIndex = 3;
                customizeTab.TabIndex = 4;
                FinishTab.TabIndex = 5;
                tabItems.Add(homeTab);
                tabItems.Add(photoTab);
                tabItems.Add(youtubeVideoTab);
                tabItems.Add(videoTab);
                tabItems.Add(customizeTab);
                tabItems.Add(FinishTab);
                EnableDisableTabs(homeTab.TabIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void EnableDisableTabs(int tabIndex)
        {
            foreach (var item in tabItems)
            {
                if (item.TabIndex == tabIndex)
                {
                    item.IsEnabled = true;
                }
                else
                {
                    item.IsEnabled = false;
                }
            }
        }

        private void myBrowser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Process.Start("https://vidstopix.com/");
            }
            
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            MessageBoxResult result = MessageBox.Show("Are you sure to want to quit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void AddListboxİtem()
        {
            if (finalsize <= 8)
            {
                socialListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/Social/500px.png")), Width = 70, Name = "px5" });
            }
            if (finalsize <= 10)
            {
                socialListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/Social/imgbox.png")), Width = 75, Name = "imgbo" });
            }
            if (finalsize <= 16)
            {
                socialListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/Social/Whatsapp.png")), Width = 75, Name = "whats" });
            }
            if (finalsize <= 20)
            {
                socialListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/Social/pinterest.jpg")), Width = 85, Name = "pint" });
                socialListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/Social/imgur.png")), Width = 85, Name = "imgu" });
            }
            if (finalsize <= 24)
            {
                socialListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/Social/postimages.png")), Width = 85, Name = "post" });
            }
            if (finalsize <= 30)
            {
                socialListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/Social/facebook.jpg")), Width = 47, Name = "face" });
                socialListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/Social/instagram.png")), Width = 47, Name = "insta" });
            }
            if (finalsize <= 32)
            {
                socialListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/Social/imgbb.jpg")), Width = 70, Name = "imgb" });
            }
            if (finalsize <= 50)
            {
                socialListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/Social/photobucket-logo.png")), Width = 120, Name = "bucket" });
                socialListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/Social/Shutterstock.png")), Width = 110, Name = "shutter" });
            }
            if (finalsize <= 75)
            {
                socialListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/Social/googlephotos.jpeg")), Width = 90, Name = "gphotos" });
            }
            socialListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/Social/SmugMug.png")), Width = 90, Name = "smug" });
            socialListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/Social/flickr.png")), Width = 70, Name = "flick" });
            socialListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/Social/dropbox.png")), Width = 90, Name = "drop" });
            socialListBox.Items.Add(new Image() { Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/Social/Google_Drive.png")), Width = 110, Name = "drive" });
        }

        private void minimize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            WindowState = WindowState.Minimized;
        }

        private void photoImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            OpenFileDialog dlg = new OpenFileDialog
            {
                DefaultExt = ".jpg", // Default file extension
                Filter = "Image Files (*.jpg; *.jpeg)|*.jpg; *.jpeg", // Filter files by extension
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };
            bool? result = dlg.ShowDialog();
            try
            {
                if (result == true)
                {
                    FileInfo info = new FileInfo(dlg.FileName);
                    if (info.Length <= 15728640)
                    {
                        Uri fileUri = new Uri(dlg.FileName);
                        photoImage.Source = new BitmapImage(fileUri);
                        photoImage.Tag = dlg.FileName.ToString();
                        nextToSelectPhoto.Visibility = Visibility.Visible;
                        photoSelectedImage.Visibility = Visibility.Visible;
                        photoSelectedLbl.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("File size cannot exceed 15 MB!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addVideoButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Video files(*.mpg; *.mpeg; *.avi; *.mp4)| *.mpg; *.mpeg; *.avi; *.mp4",
                DefaultExt = ".mp4",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\VidsToPix\downloadedVideos\"
            };
            bool? result = dlg.ShowDialog();
            if (result == false)
            {
                return;
            }
            try
            {
                if (result == true && videoCounter < 6)
                {
                    video vd = new video(dlg.FileName)
                    {
                        safeFileName = dlg.SafeFileName
                    };

                    if (!(Path.GetExtension(vd.filename) != ".mpeg" || Path.GetExtension(vd.filename) != ".avi" || Path.GetExtension(vd.filename) != ".mpg" || Path.GetExtension(vd.filename) != ".mp4"))
                    {
                        MessageBox.Show("You selected the wrong file extension.");
                        return;
                    }
                    foreach (var item in videoList)
                    {
                        if (item.safeFileName == vd.safeFileName)
                        {
                            MessageBox.Show("The video has already been added.");
                            return;
                        }
                    }
                    videoList.Add(vd);

                    if (IsVideosOk(videoList))
                    {
                        videoCounter++;
                        videoListBox.Items.Add(new ListboxItem() { Name = vd.safeFileName, Time = Math.Round((double)(vd.seconds / 60)).ToString() + ":" + (((vd.seconds % 60) < 10) ? ("0" + vd.seconds % 60) : ("" + vd.seconds % 60)) });
                        timeCalculator();
                    }
                    else
                    {
                        videoList.Remove(vd);
                        timeCalculator();
                        MessageBox.Show("You have exceeded the Total Video Time. No Video Added.");
                    }
                }
                else if (!(videoCounter < 6))
                {
                    MessageBox.Show("You have reached the maximum number of videos that can be added.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timeCalculator()
        {
            VideoController vds = new VideoController(videoList);
            totalTime.Content = "Total Time(mm:ss): " + Math.Round((double)(vds.totalSeconds / 60)).ToString() + ":" + (((vds.totalSeconds % 60) < 10) ? ("0" + vds.totalSeconds % 60) : ("" + vds.totalSeconds % 60));
        }

        public bool IsVideosOk(List<video> vdList)
        {
            VideoController vd = new VideoController(vdList);
            return vd.Isok;
        }

        private void nextPage(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            tabControl.SelectedIndex++;
            EnableDisableTabs(tabControl.SelectedIndex);
        }

        private void backPage(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            tabControl.SelectedIndex--;
            EnableDisableTabs(tabControl.SelectedIndex);
        }

        private void nextPage()
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            tabControl.SelectedIndex++;
            EnableDisableTabs(tabControl.SelectedIndex);
        }

        private void NewProject_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            photoImage.Source = (ImageSource)defaultSource;
            videoListBox.Items.Clear();
            videoList.Clear();
            videoCounter = 1;
            photoSelectedImage.Visibility = Visibility.Hidden;
            photoSelectedLbl.Visibility = Visibility.Hidden;
            youtubeLinkTextBox.Text = "";
            downloadVideo.IsEnabled = true;
            downloadVideo.Visibility = Visibility.Visible;
            status.Text = "";
            status.Foreground = Brushes.Red;
            youtubeVideoTitle.Content = "";
            youtubeVideoAuthor.Content = "";
            youtubeVideoDuriation.Content = "";
            nextToSelectPhoto.Visibility = Visibility.Hidden;
            nextToSelectOtherVideos.Content = "Skip";
            search.IsEnabled = true;
            loading.Visibility = Visibility.Visible;
            thumbImage.Visibility = Visibility.Hidden;
            social.Visibility = Visibility.Visible;
            youtubeVideoImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/pielx;component/Images/youtube2.png"));
            socialListBox.Items.Clear();
            shareButton.Visibility = Visibility.Hidden;
            sizeOfImage.Visibility = Visibility.Hidden;
            totalTime.Content = "Total Time(mm:ss): 0:00";
            nextPage();
        }

        private void deleteVideo_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            try
            {
                if (videoListBox.SelectedItem != null)
                {
                    ListboxItem lbItem = videoListBox.SelectedItem as ListboxItem;
                    foreach (var item in videoList)
                    {
                        if (item.safeFileName == lbItem.Name)
                        {
                            videoList.Remove(item);
                            videoCounter--;
                            videoListBox.Items.Remove(videoListBox.SelectedItem);
                            timeCalculator();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NextToCustomize_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            if (videoList.Count != 0)
            {
                nextPage();
            }
            else
            {
                MessageBox.Show("Video List is empty. Please add at least one video.");
            }
        }

        private void browseProjectButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog
                {
                    RootFolder = Environment.SpecialFolder.MyDocuments,
                    ShowNewFolderButton = true,
                    SelectedPath = path + @"\VidsToPix\"
                };
                if (dialog.ShowDialog(this).GetValueOrDefault())
                {
                    pathLbl.Content = dialog.SelectedPath;
                    directory = dialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void finish(int value)
        {
            try
            {
                nextPage();
                donate.Visibility = Visibility.Hidden;
                makeDir(directory);
                project = new Project(photoImage.Tag.ToString(), directory,value);
                string loadingSourceDirectory = directory;
                directory += @"\VideoJpegs\";
                makeDir(directory);
                project.videoList = videoList;
                foreach (var item in project.videoList)
                {
                    await Task.Run(() => Project.videoToJpg(item.filename, directory));
                }
                await Task.Run(() => project.piecer(project.squareImagePath, value));
                await Task.Run(() => project.mainPhotoGetDominant());
                await Task.Run(() => project.customizePhotos(directory));
                await Task.Run(() => Project.siraBulucu(project.imagePieces, project.addedImageList, project.renkler));
                finalsize = await Task.Run(() => project.finalImage(Project.lastBitmaps, value)) / (1024 * 1024);
                Directory.Delete(directory, true);
                File.Delete(project.squareImagePath);
                restart.IsEnabled = true;
                OpenImagePath.IsEnabled = true;
                OpenImagePath.Content = "Open Image";
                restart.Visibility = Visibility.Visible;
                loading.Visibility = Visibility.Hidden;
                social.Visibility = Visibility.Hidden;
                thumbImage.Source = new BitmapImage(new Uri(loadingSourceDirectory + @"/finalThumb.jpg"));
                thumbImage.Visibility = Visibility.Visible;
                sizeOfImage.Content = "Image Size: " + finalsize.ToString() + " MB's";
                sizeOfImage.Visibility = Visibility.Visible;
                donate.Visibility = Visibility.Visible;
                mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\finished.wav"));
                mediaPlayer.Play();
                AddListboxİtem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nextToFinish_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            restart.Visibility = Visibility.Hidden;
            restart.IsEnabled = false;
            OpenImagePath.Content = "Please Wait..";
            OpenImagePath.IsEnabled = false;
            finish((int)Slider.Value);
        }

        private async void search_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            var youtube = new YoutubeClient();
            try
            {
                var video = await youtube.Videos.GetAsync(youtubeLinkTextBox.Text);
                youtubeVideoTitle.Content = video.Title.Length >= 55 ? video.Title.Substring(0, 50) + "..." : video.Title;
                youtubeVideoAuthor.Content = video.Author.Title;
                youtubeVideoDuriation.Content = video.Duration.ToString();
                var thumblist = video.Thumbnails;
                foreach (var item in thumblist)
                {
                    if (item.Resolution.Height >= 360 && item.Url.EndsWith("jpg"))
                    {
                        youtubeVideoImage.Source = new BitmapImage(new Uri(item.Url));
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void youtubeLinkTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            object br = brush.ImageSource;
            if (youtubeLinkTextBox.Text == "")
            {
                ImageBrush textImageBrush = new ImageBrush
                {
                    ImageSource = (ImageSource)br,
                    AlignmentX = AlignmentX.Left
                };
                youtubeLinkTextBox.Background = textImageBrush;
            }
            else
            {
                youtubeLinkTextBox.Background = Brushes.White;
            }
        }

        private async void downloadVideo_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            var adirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\VidsToPix";
            try
            {
                var youtube = new YoutubeClient();
                var video = await youtube.Videos.GetAsync(youtubeLinkTextBox.Text);
                if (video.Duration.Value.Seconds + video.Duration.Value.Minutes * 60 > 900)
                {
                    MessageBox.Show("Video Duriation Maximum Limit is 15 Minutes. Please try another video to download");
                }
                else
                {
                    downloading.Visibility = Visibility.Visible;
                    status.Text = "Downloading. Please wait!";
                    downloadVideo.IsEnabled = false;
                    nextToSelectOtherVideos.IsEnabled = false;
                    search.IsEnabled = false;
                    backtoPhotoSelect.IsEnabled = false;
                    var streamManifest = await youtube.Videos.Streams.GetManifestAsync(youtubeLinkTextBox.Text);
                    var streamInfo = streamManifest.GetMuxedStreams().Where(x => x.VideoQuality.MaxHeight == 360);
                    var stream = await youtube.Videos.Streams.GetAsync(streamInfo.First());
                    string fileName = video.Title.Length > 25
                        ? video.Title.Substring(0, 25)
                        : video.Title;

                    fileName = fileName.Replace(' ', '_')
                                       .Replace('|', '_');

                    await youtube.Videos.Streams.DownloadAsync(
                        streamInfo.First(),
                        Path.Combine(
                            adirectory,
                            "downloadedVideos",
                            $"{fileName}video.{streamInfo.First().Container}"
                        )); downloading.Visibility = Visibility.Hidden;
                    AddYoutubeVideo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to download video: "+ex.Message);

                downloadVideo.Visibility = Visibility.Visible;
                search.IsEnabled = true;
                downloading.Visibility = Visibility.Hidden;
                downloadVideo.IsEnabled = true;
                status.Text = "Try to download another video please.";
            }
            nextToSelectOtherVideos.IsEnabled = true;
            backtoPhotoSelect.IsEnabled = true;
        }

        private void AddYoutubeVideo()
        {
            try
            {
                if (videoCounter < 6)
                {
                    var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\VidsToPix\downloadedVideos\");
                    var myFile = directory.GetFiles().OrderByDescending(f => f.LastWriteTime).First();
                    video vd = new video(myFile.FullName)
                    {
                        safeFileName = myFile.Name
                    };
                    foreach (var item in videoList)
                    {
                        if (item.safeFileName == vd.safeFileName)
                        {
                            MessageBox.Show("The video has already been added.");
                            status.Text = "";
                            return;
                        }
                    }
                    videoList.Add(vd);
                    if (IsVideosOk(videoList))
                    {
                        videoCounter++;
                        videoListBox.Items.Add(new ListboxItem() { Name = vd.safeFileName, Time = Math.Round((double)(vd.seconds / 60)).ToString() + ":" + (((vd.seconds % 60) < 10) ? ("0" + vd.seconds % 60) : ("" + vd.seconds % 60)) });
                        search.IsEnabled = false;
                        downloadVideo.IsEnabled = false;
                        downloadVideo.Visibility = Visibility.Hidden;
                        status.Foreground = Brushes.Green;
                        status.Text = "The Video has been Downloaded and Added. Click to 'Next' Button!";
                        nextToSelectOtherVideos.Content = "Next";
                        search.IsEnabled = false;
                        timeCalculator();
                    }
                    else
                    {
                        videoList.Remove(vd);
                        timeCalculator();
                        status.Foreground = Brushes.Yellow;
                        status.Text = "The Video has been Downloaded but not Added to the List because of Total Video Time. Try to Download another video.";
                        downloadVideo.Visibility = Visibility.Visible;
                        search.IsEnabled = true;
                        downloadVideo.IsEnabled = true;
                        MessageBox.Show("You have exceeded the Total Video Time. No video has been added. Please check the Added Video List.");
                    }
                }
                else if (!(videoCounter < 6))
                {
                    MessageBox.Show("You have reached the maximum number of videos that can be added.");
                }
            }
            catch (Exception ex)
            {
                downloadVideo.Visibility = Visibility.Visible;
                search.IsEnabled = true;
                downloadVideo.IsEnabled = true;
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenoldProjects_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\VidsToPix");
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            px500.Visibility = Visibility.Visible;
            imgbox.Visibility = Visibility.Visible;
            whatsapp.Visibility = Visibility.Visible;
            imgur.Visibility = Visibility.Visible;
            pinterest.Visibility = Visibility.Visible;
            postimage.Visibility = Visibility.Visible;
            facebook.Visibility = Visibility.Visible;
            instagram.Visibility = Visibility.Visible;
            imgbb.Visibility = Visibility.Visible;
            photobucket.Visibility = Visibility.Visible;
            shutterstock.Visibility = Visibility.Visible;

            if (Slider.Value > 39)
            {
                px500.Visibility = Visibility.Hidden;
            }
            if (Slider.Value > 44)
            {
                imgbox.Visibility = Visibility.Hidden;
            }
            if (Slider.Value > 55)
            {
                whatsapp.Visibility = Visibility.Hidden;
            }
            if (Slider.Value > 62)
            {
                imgur.Visibility = Visibility.Hidden;
                pinterest.Visibility = Visibility.Hidden;
            }
            if (Slider.Value > 68)
            {
                postimage.Visibility = Visibility.Hidden;
            }
            if (Slider.Value > 76)
            {
                facebook.Visibility = Visibility.Hidden;
                instagram.Visibility = Visibility.Hidden;
            }
            if (Slider.Value > 79)
            {
                imgbb.Visibility = Visibility.Hidden;
            }
            if (Slider.Value > 99)
            {
                photobucket.Visibility = Visibility.Hidden;
                shutterstock.Visibility = Visibility.Hidden;
            }
            double value = Slider.Value;
            tileCount.Content = value + " x " + value;
            tileCount_Copy2.Content = Math.Pow(value, 2) + " Pieces";
            tileCount_Copy3.Content = value * 216 + " x " + value * 216 + " Pixels (Approximately " + (int)(value * value * 216 * 216) / 1000000 + " Megapixels)";
            double deger = (int)(value * value * 216 * 216) / 1000000 * 0.1 + (int)(value * value * 216 * 216) / 1000000 * 0.01;
            tileCount_Copy.Content = (int)(value * value * 216 * 216) / 1000000 * 0.1 + (int)(value * value * 216 * 216) / 1000000 * 0.01 + "~ MBs On Disk (Min: " + deger / 2 + " MBs - Max: " + deger * 2 + " MBs)";
            tileCount_Copy1.Content = (int)(value * value * 216 * 216) / 1000000 * 4 + "~ MBs On RAM";
        }

        private void restart_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            homeTab.IsSelected = true;
            homeTab.IsEnabled = true;
            FinishTab.IsEnabled = false;
            project = null;
            ControlDirectory();
            search.IsEnabled = true;
        }

        private void OpenImagePath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            Process.Start(project.projectPath);
        }

        private void loading_MediaEnded(object sender, RoutedEventArgs e)
        {
            loading.Position = new TimeSpan(0, 0, 1);
            loading.Play();
        }

        private void downloading_MediaEnded(object sender, RoutedEventArgs e)
        {
            downloading.Position = new TimeSpan(0, 0, 1);
            downloading.Play();
        }

        private void social_MediaEnded(object sender, RoutedEventArgs e)
        {
            social.Position = new TimeSpan(0, 0, 1);
            social.Play();
        }

        private void donate_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            Process.Start("https://vidstopix.com/donation/");
        }

        private void shareButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            Process.Start(link);
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem item)
            {
                shareButton.Visibility = Visibility.Visible;
                switch (((Image)item.Content).Name)
                {
                    case "px5":
                        { link = "https://500px.com"; }
                        break;
                    case "imgbo":
                        { link = "https://imgbox.com"; }
                        break;
                    case "whats":
                        { link = "https://web.whatsapp.com/"; }
                        break;
                    case "pint":
                        { link = "www.pinterest.com"; }
                        break;
                    case "imgu":
                        { link = "https://imgur.com/"; }
                        break;
                    case "post":
                        { link = "https://postimages.org/"; }
                        break;
                    case "face":
                        { link = "www.facebook.com"; }
                        break;
                    case "insta":
                        { link = "https://www.instagram.com/"; }
                        break;
                    case "imgb":
                        { link = "https://imgbb.com/"; }
                        break;
                    case "bucket":
                        { link = "https://app.photobucket.com/"; }
                        break;
                    case "shutter":
                        { link = "https://www.shutterstock.com/"; }
                        break;
                    case "gphotos":
                        { link = "https://photos.google.com/"; }
                        break;
                    case "smug":
                        { link = "https://www.smugmug.com/"; }
                        break;
                    case "flick":
                        { link = "https://www.flickr.com/"; }
                        break;
                    case "drop":
                        { link = "https://www.dropbox.com/"; }
                        break;
                    case "drive":
                        { link = "https://drive.google.com/"; }
                        break;
                    default:

                        break;
                }
            }
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            Process.Start("https://vidstopix.com");
        }

        private void TextBlock_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            Process.Start("https://vidstopix.com/how-it-works/");
        }

        private void TextBlock_PreviewMouseDown_2(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            Process.Start("https://vidstopix.com/donation/");
        }

        private void TextBlock_PreviewMouseDown_3(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            Process.Start("https://vidstopix.com/frequently-asked-questions/");
        }

        private void instagramLink_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            Process.Start("www.instagram.com/vidstopix");
        }

        private void facebookLink_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayer.Open(new Uri(Environment.CurrentDirectory + @"\sounds\click.wav"));
            mediaPlayer.Play();
            Process.Start("www.facebook.com/vidstopix");
        }

    }
}