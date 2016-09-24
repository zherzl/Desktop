using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UltimateCommander.Settings;

namespace UltimateCommander
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() { InitializeComponent(); }

        private SettingsVM context;
        private TabControl currentPane;
        public int TabCountLeft { get { return currentPane.Items.Count; } }

        private void MainWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            AppSettings settings = SettingsLoader.LoadData();
            context = new SettingsVM(settings);
            currentPane = tabCtrlLeft;

            // Write inital settings (first time launch)
            if (!File.Exists(context.FileName))
            {
                context.ColDefLeftListValue = GetColRatio();
                context.SaveData();
            }

            grid.DataContext = context;

            // Loop items in TabControl and attach events -> required for dynamic tabs
            foreach (TabItem item in tabCtrlLeft.Items)
                AddTabEvents(item);

            btnMinControl btnMin = new btnMinControl(this);
            stackPanelState.Children.Add(btnMin);
            btnMaxControl btnMax = new btnMaxControl(this);
            stackPanelState.Children.Add(btnMax);
            btnCloseControl btnClose = new btnCloseControl(this);
            stackPanelState.Children.Add(btnClose);

            //Charts ch = new Charts();
            //ch.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            //ch.ShowDialog();
        }



        private void AddTabEvents(TabItem item)
        {
            item.MouseDoubleClick += tabItem_MouseDoubleClick;
            item.MouseUp += item_MouseUp;
            //item.MouseEnter += item_MouseEnter;
            TextBlock block = item.Header as TextBlock;

            try
            {
                foreach (Run run in block.Inlines)
                {
                    run.MouseEnter += run_MouseEnter;
                    run.MouseLeave += run_MouseLeave;
                }
            }
            catch (NullReferenceException)
            {
                // just skip
            }
            
        }

        

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem lbItem = sender as ListBoxItem;

            String[] first = lbItem.Content.ToString().Split(':');
            String[] second = lbItem.Content.ToString().Split('\\');

            TextBlock block = ((TabItem)currentPane.SelectedItem).Header as TextBlock; // Textblock within current tab header
            block.Inlines.Clear();

            foreach (String s in second)
            {
                if (!s.Trim().Equals(""))
                {
                    Run r = new Run(s);
                    block.Inlines.Add(r);
                    r.MouseEnter += run_MouseEnter;
                    r.MouseLeave += run_MouseLeave;
                    r.MouseUp += r_MouseUp;
                    r = new Run("\\");
                    block.Inlines.Add(r);
                }
            }
        }


        void run_MouseEnter(object sender, MouseEventArgs e)
        {
            Run r = sender as Run;
            
        }

        void run_MouseLeave(object sender, MouseEventArgs e)
        {
            Run r = sender as Run;
        }

        void r_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Run r = sender as Run;
            TextBlock block = r.Parent as TextBlock;
            StringBuilder str = new StringBuilder();
            
            // Loop all inlines and retrieve dir path -> finish after clicked inline is added
            foreach (Run run in block.Inlines)
            {
                str.Append(run.Text);
                if (run.Text.Equals(r.Text))
                    break;
            }
            AddListItem(str.ToString());
        }

        private void AddListItem(string path)
        {
            ListBoxItem item = new ListBoxItem();
            item.Content = path;
            TabItem tab = currentPane.SelectedItem as TabItem;
            ListBox lb = tab.Content as ListBox;
            lb.Items.Add(item);
        }


        void item_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                TabItem lastTab = (TabItem)tabCtrlLeft.Items[TabCountLeft - 1];
                TabItem item = new TabItem();

                item.Header = item.Name = "MyNewTab" + (TabCountLeft + 1);
                item.MouseUp += item_MouseUp;
                item.MouseDoubleClick += tabItem_MouseDoubleClick;
                item.Style = (Style)FindResource("MyTabItem");

                tabCtrlLeft.Items.Insert(TabCountLeft, item);
            }
        }

        void tabItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TabItem item = sender as TabItem;
            Storyboard sb = FontSizeAnimation(item, "FontSize");
            sb.Begin();
            
        }



        /// <summary>
        /// Effect used to animate font size on copy path action (will be implemented)
        /// </summary>
        /// <param name="item">A control that has FontSize parameter</param>
        /// <param name="propPathName">A property to animate, ex: FontSize, Width etc</param>
        /// <returns></returns>
        private Storyboard FontSizeAnimation(Control item, String propPathName)
        {
            Storyboard sb = new Storyboard();
            Storyboard.SetTarget(sb, item);
            Storyboard.SetTargetProperty(sb, new PropertyPath(propPathName));

            DoubleAnimation dblAnim = new DoubleAnimation();
            dblAnim.Duration = new TimeSpan(0, 0, 0, 0, 100);
            dblAnim.From = 12;
            dblAnim.To = 8;
            dblAnim.AutoReverse = true;
            sb.Children.Add(dblAnim);

            return sb;
        }



        private void gridSplitter_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            GridSplitter splitter = sender as GridSplitter;
            double ratioLeft = GetColRatio();
            context.ColDefLeftListValue = ratioLeft;
        }

        private double GetColRatio()
        {
            double left = grid.ColumnDefinitions[0].Width.Value;
            double right = grid.ColumnDefinitions[2].Width.Value;
            double ratioLeft = left / right;
            return ratioLeft;
        }

        // Move entire window with mouse
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        
        private void WindowStateButtons_Click(object sender, RoutedEventArgs e)
        {
        }

        private void WindowStateButtons_Click(object sender, MouseButtonEventArgs e)
        {
        }

       

        









    }
}
