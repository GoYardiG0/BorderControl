using System.ComponentModel;
using System.Data;

namespace BorderControl;


public class CalculatorBrain : INotifyPropertyChanged
{

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion

    public CalculatorBrain()
    {
        lbl = "";
    }

    string lbl {  get; set; }

    private void Print(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        lbl += btn;
    }
    private void MethodPrint(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (lbl.Length > 0 && (lbl[lbl.Length - 1] != '.'
            && lbl[lbl.Length - 1] != '+'
            && lbl[lbl.Length - 1] != '-'
            && lbl[lbl.Length - 1] != '*'
            && lbl[lbl.Length - 1] != '/'
            && lbl[lbl.Length - 1] != '%'))
        {
            lbl += btn;
        }
        else if (lbl.Length == 0 && btn == "-")
        {
            lbl += btn;
        }
    }
    private void Delete()
    {
        if (lbl.Length > 0) lbl = lbl.Remove(lbl.Length - 1);
    }
    private void Reset(object sender, EventArgs e)
    {
        lbl = "";
    }
    private void Calculate(object sender, EventArgs e)
    {
        if (lbl.Length > 0 && (lbl[lbl.Length - 1] == '.'
            || lbl[lbl.Length - 1] == '+'
            || lbl[lbl.Length - 1] == '-'
            || lbl[lbl.Length - 1] == '*'
            || lbl[lbl.Length - 1] == '/'
            || lbl[lbl.Length - 1] == '%'))
        {
            lbl = lbl.Remove(lbl.Length - 1);
        }
        try
        {
            lbl = $"{new DataTable().Compute(lbl, null)}";
        }
        catch
        {
            lbl = "Error";
        }
    }

}


public partial class ThisIsBorderingInsanity : ContentPage
{
    CalculatorBrain Calc;
	public ThisIsBorderingInsanity()
	{
		InitializeComponent();
        Calc = new CalculatorBrain();

        Bindin gContext = Calc;
	}

   
}