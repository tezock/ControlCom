using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Forms;
using System.Windows.Shapes;
using System.Speech.Recognition;
using WindowsInput;
using System.Drawing;

namespace ModernDesign.MVVM.View
{

    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    /// 

    public partial class HomeView : System.Windows.Controls.UserControl
    {

        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine(); // Creates new Speech Recognition object
        InputSimulator isim = new InputSimulator(); // Creates InputSimulator Object
        String last = "";
        
        MouseRight mouseRight = new MouseRight();
        MouseLeft mouseLeft = new MouseLeft();
        MouseUp mouseUp = new MouseUp();
        MouseDown mouseDown = new MouseDown();

        public HomeView()
        {
            
            Choices commands = new Choices();
            Choices displacements = new Choices();
            displacements.Add(new string[] { "10", "20", "30", "40", "50", "60", "70", "80", "90", "100", "110", "120", "130", "140", "150", "160", "170", "180", "190", "200", "210", "220", "230", "240", "250", "260", "270", "280", "290", "300", "310", "320", "330", "340", "350", "360", "370", "380", "390", "400", "410", "420", "430", "440", "450", "460", "470", "480", "490", "500" });
            commands.Add(new string[] { "say hello", "print my name", "Escape", "Click", "Double", "Arrow Right", "Arrow Left", "Scroll Up", "Scroll Down", "Mouse Up", "Mouse Left", "Mouse Down", "Mouse Right", "Mouse Stop", "End Control", "10", "50", "100", "500" });

            GrammarBuilder gDisplacement = new GrammarBuilder(displacements);
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammer = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammer);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
            InitializeComponent();
        }

        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            DateTime now = DateTime.Now;
            int mouse_x = System.Windows.Forms.Cursor.Position.X;
            int mouse_y = System.Windows.Forms.Cursor.Position.Y;


            switch (e.Result.Text)
            {
                case "print my name":
                    CommandLog.Text += System.Environment.NewLine + now + ": rob";
                    break;

                case "Escape":
                    isim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.ESCAPE);
                    CommandLog.Text += System.Environment.NewLine + now + ": Escape Key Pressed";
                    break;

                case "Click":
                    isim.Mouse.LeftButtonClick();
                    CommandLog.Text += System.Environment.NewLine + now + ": Mouse Clicked";
                    break;

                case "Double":
                    isim.Mouse.LeftButtonDoubleClick();
                    CommandLog.Text += System.Environment.NewLine + now + ": Mouse Double Clicked";
                    break;

                case "Arrow Right":
                    isim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RIGHT);
                    CommandLog.Text += System.Environment.NewLine + now + ": Right Arrow Key Pressed";
                    break;

                case "Arrow Left":
                    isim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LEFT);
                    CommandLog.Text += System.Environment.NewLine + now + ": Left Arrow Key Pressed";
                    break;

                case "Scroll Up":
                    isim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.PRIOR);
                    CommandLog.Text += System.Environment.NewLine + now + ": Scrolled Up";
                    break;

                case "Scroll Down": //Scrolls Down
                    isim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.NEXT);
                    CommandLog.Text += System.Environment.NewLine + now + ": Scrolled Down";
                    break;

                case "Mouse Up":
                  
                    last = "Up";
                    CommandLog.Text += System.Environment.NewLine + now + ": Mouse Moved Up";
                    mouseUp.Top = mouse_y - 700;
                    mouseUp.Left = mouse_x - 700;
                    mouseUp.Show();
                    break;

                case "Mouse Down":
                
                    last = "Down";
                    CommandLog.Text += System.Environment.NewLine + now + ": Mouse Moved Down";
                    mouseDown.Top = mouse_y;
                    mouseDown.Left = mouse_x - 700;
                    mouseDown.Show();
                    break;

                case "Mouse Left":
                    
                    last = "Left";
                    CommandLog.Text += System.Environment.NewLine + now + ": Mouse Moved Left";
                    mouseLeft.Top = mouse_y - 350;
                    mouseLeft.Left = mouse_x - 1000;
                    mouseLeft.Show();
                    break;

                case "Mouse Right":
           
                    last = "Right";
                    CommandLog.Text += System.Environment.NewLine + now + ": Mouse Moved Right";
                    mouseRight.Top = mouse_y - 350;
                    mouseRight.Left = mouse_x;
                    mouseRight.Show();
                    break;

                /*
            case "Mouse Stop":

                textBox1.Text += System.Environment.NewLine + now + ": Mouse Stopped";
                break;
                */

                case "End Control": //Ends Control
                    System.Windows.MessageBox.Show("Voice Control Ended.");
                    CommandLog.Text += System.Environment.NewLine + now + ": Control Ended";
                    recEngine.RecognizeAsyncStop();
                    btnDisable.IsEnabled = false;
                    btnEnable.IsEnabled = true;

                    break;

                case "10":
                    CommandLog.Text += " 10 px";
                    if ((last.Equals("Up") || last.Equals("Down")) || (last.Equals("Left") || last.Equals("Right")))
                    {
                        MoveMouse(last, 10);
                    }
                    mouseRight.Hide();
                    mouseLeft.Hide();
                    mouseUp.Hide();
                    mouseDown.Hide();
                    break;

                case "50":
                    CommandLog.Text += " 50 px";
                    if ((last.Equals("Up") || last.Equals("Down")) || (last.Equals("Left") || last.Equals("Right")))
                    {
                        MoveMouse(last, 50);
                    }
                    mouseRight.Hide();
                    mouseLeft.Hide();
                    mouseUp.Hide();
                    mouseDown.Hide();
                    break;

                case "100":
                    CommandLog.Text += " 100 px";
                    if ((last.Equals("Up") || last.Equals("Down")) || (last.Equals("Left") || last.Equals("Right")))
                    {
                        MoveMouse(last, 100);
                    }
                    mouseRight.Hide();
                    mouseLeft.Hide();
                    mouseUp.Hide();
                    mouseDown.Hide();
                    break;
                case "150":
                    CommandLog.Text += " 150 px";
                    if ((last.Equals("Up") || last.Equals("Down")) || (last.Equals("Left") || last.Equals("Right")))
                    {
                        MoveMouse(last, 150);
                    }
                    mouseRight.Hide();
                    mouseLeft.Hide();
                    mouseUp.Hide();
                    mouseDown.Hide();
                    break;
                case "200":
                    CommandLog.Text += " 200 px";
                    if ((last.Equals("Up") || last.Equals("Down")) || (last.Equals("Left") || last.Equals("Right")))
                    {
                        MoveMouse(last, 200);
                    }
                    mouseRight.Hide();
                    mouseLeft.Hide();
                    mouseUp.Hide();
                    mouseDown.Hide();
                    break;
                case "250":
                    CommandLog.Text += " 250 px";
                    if ((last.Equals("Up") || last.Equals("Down")) || (last.Equals("Left") || last.Equals("Right")))
                    {
                        MoveMouse(last, 250);
                    }
                    mouseRight.Hide();
                    mouseLeft.Hide();
                    mouseUp.Hide();
                    mouseDown.Hide();
                    break;
                case "300":
                    CommandLog.Text += " 300 px";
                    if ((last.Equals("Up") || last.Equals("Down")) || (last.Equals("Left") || last.Equals("Right")))
                    {
                        MoveMouse(last, 300);
                    }
                    mouseRight.Hide();
                    mouseLeft.Hide();
                    mouseUp.Hide();
                    mouseDown.Hide();
                    break;
                case "350":
                    CommandLog.Text += " 350 px";
                    if ((last.Equals("Up") || last.Equals("Down")) || (last.Equals("Left") || last.Equals("Right")))
                    {
                        MoveMouse(last, 350);
                    }
                    mouseRight.Hide();
                    mouseLeft.Hide();
                    mouseUp.Hide();
                    mouseDown.Hide();
                    break;
                case "400":
                    CommandLog.Text += " 400 px";
                    if ((last.Equals("Up") || last.Equals("Down")) || (last.Equals("Left") || last.Equals("Right")))
                    {
                        MoveMouse(last, 400);
                    }
                    mouseRight.Hide();
                    mouseLeft.Hide();
                    mouseUp.Hide();
                    mouseDown.Hide();
                    break;
                case "450":
                    CommandLog.Text += " 450 px";
                    if ((last.Equals("Up") || last.Equals("Down")) || (last.Equals("Left") || last.Equals("Right")))
                    {
                        MoveMouse(last, 450);
                    }
                    mouseRight.Hide();
                    mouseLeft.Hide();
                    mouseUp.Hide();
                    mouseDown.Hide();
                    break;

                case "500":
                    CommandLog.Text += " 500 px";
                    if ((last.Equals("Up") || last.Equals("Down")) || (last.Equals("Left") || last.Equals("Right")))
                    {
                        MoveMouse(last, 500);
                    }
                    mouseRight.Hide();
                    mouseLeft.Hide();
                    mouseUp.Hide();
                    mouseDown.Hide();
                    break;


            }
        }

        void MoveMouse(String direction, int magnitude)
        {
            int dirx = 0;
            int diry = 0;
            switch (direction)
            {
                case "Up":
                    diry = -1 * magnitude;
                    break;
                case "Down":
                    diry = magnitude;
                    break;
                case "Left":
                    dirx = -1 * magnitude;
                    break;
                case "Right":
                    dirx = magnitude;
                    break;

            }

            isim.Mouse.MoveMouseBy(dirx, diry);

        }

        private void StartDictation(object sender, RoutedEventArgs e)
        {
            CommandLog.Text = "";
            CommandLog.Text += System.Environment.NewLine + DateTime.Now + ": New to ControlComs? Commands visible on 'Commands' page.";
            CommandLog.Text += System.Environment.NewLine + DateTime.Now + ": Please allow up to 10s for Dictation Technologies to load.";
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            btnEnable.IsEnabled = false;
            btnDisable.IsEnabled = true;
        }

        private void StopDictation(object sender, RoutedEventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            btnEnable.IsEnabled = true;
            btnDisable.IsEnabled = false;
        }
    }

}
