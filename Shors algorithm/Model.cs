using Shors_algorithm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

internal class Model
{
    public Dictionary<State, string> resultMessages = new Dictionary<State, string>();
    public Dictionary<DataType, Color> resultColors = new Dictionary<DataType, Color>();
    public const int VisualisationTimeMs = 8000; 

    public Model()
    {
        resultMessages.Add(State.Start, "Ведите число");
        resultMessages.Add(State.WrongInput, "Неверный формат данных");
        resultMessages.Add(State.Processing, "Обработка...");

        resultColors.Add(DataType.Correct, Color.LightGreen);
        resultColors.Add(DataType.Wrong, Color.IndianRed);
        resultColors.Add(DataType.None, Color.White);
    }
}
