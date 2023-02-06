using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Shors_algorithm
{
    internal class Controller
    {
        View view;
        Model model;

        public Controller(View view, Model model)
        {
            view.SetVisualisationVisibility(false);
            this.view = view;
            this.model = model;
            
            view.OnInput += ProcessInput;

            ShowMessage(model.resultMessages[State.Start]);
            SetColor(model.resultColors[DataType.None]);
        }

        public void ShowMessage(string message) => view.ShowMessage(message);
        public void SetColor(Color color) => view.ChangeInputFieldBackgroundColor(color);

        private string GetData() => view.inputTextBox.Text;

        public void ProcessInput()
        {
            var s = GetData();
            if (s == "")
            {
                view.SetVisualisationVisibility(false);
                ShowMessage(model.resultMessages[State.Start]);
                SetColor(model.resultColors[DataType.None]);
                return;
            }

            if (Int32.TryParse(s, out var number) && number > 1)
            {
                SetColor(model.resultColors[DataType.Correct]);

                view.SetVisualisationVisibility(false);
                view.SetVisualisationVisibility(true);
                view.SetVisualisationProcessing(true);


                DelayedAction(Model.VisualisationTimeMs, delegate
                {
                    view.SetVisualisationProcessing(false);
                    ShowMessage(PrintCarnege<int, int>(CalculateResult(number)));
                });
            }
            else
            {
                view.SetVisualisationVisibility(false);
                ShowMessage(model.resultMessages[State.WrongInput]);
                SetColor(model.resultColors[DataType.Wrong]);
            }
        }

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public void DelayedAction(int delay, Action action)
        {
            if(timer.Enabled) timer.Stop();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = delay;
            
            timer.Tick += (s, e) => {
                action();
                timer.Stop();
            };
            timer.Start();
        }

        private (int, int) CalculateResult(int n)
        {
            for (int i = 1; i < Math.Ceiling(Math.Sqrt(n)); i++)
            {
                if (n % i == 0)
                {
                    if ((IsSimple(i)) && IsSimple(n / i)) return (i, n / i);
                }
            }

            return (1, n);
        }

        private bool IsSimple(int n)
        {
            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(n)); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private string PrintCarnege<T, V>((T, V) n)
        {
            return n.Item1 + " " + n.Item2;
        }
    }
}
