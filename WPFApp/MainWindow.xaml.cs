using System.Windows;

namespace WPFApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        CreateTask();
    }
    void AddMessage(string Message)
    {
        int CurrentThreadId = Thread.CurrentThread.ManagedThreadId;
        this.Dispatcher.Invoke(() =>
            {

                message.Content +=
                    $"Mesaje: {Message}," +
                    $"hilo actual:{CurrentThreadId}\n";
            });
    }

    void CreateTask()
    {
        Task T;
        Action Code = new Action(ShowMesage);
        T = new Task(Code);
        Task T2 = new Task(delegate
        {
            MessageBox.Show("ejecute tarea del metodo anonimo");
        }
        );
        Task T3A = new Task(() => ShowMesage());
        Task T3 = new Task(
            () => ShowMesage());
        Task T4 = new Task(() => MessageBox.Show("Ejecutando la tarea"));

        Task T5 = new Task(() =>
        {
            DateTime CurrentDate = DateTime.Today;
            DateTime StartDate = CurrentDate.AddDays(30);
            MessageBox.Show($"Tarea 5. Fecha calculada: {StartDate}");
        }
        );
        Task T6 = new Task((message) =>
        MessageBox.Show(message.ToString()), "exprecion lambda con parametros");

        Task T7 = new Task(() => AddMessage("ejecutando la tarea"));
        T7.Start();
        AddMessage("el hilo principal");
    }


    void ShowMesage()
    {
        MessageBox.Show("Ejecutando el metodo show message");
    }
}