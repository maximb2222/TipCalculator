using System;
using Microsoft.Maui.Controls;

namespace TipCalculator;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        billInput.TextChanged += OnTextChanged;
        tipPercentSlider.ValueChanged += OnSliderValueChanged;
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        CalculateTip();
    }

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        tipPercent.Text = $"{e.NewValue:F0}%";
        CalculateTip();
    }

    private void OnNormalTip(object sender, EventArgs e)
    {
        tipPercentSlider.Value = 15;
    }

    private void OnGenerousTip(object sender, EventArgs e)
    {
        tipPercentSlider.Value = 20;
    }

    private void OnRoundDown(object sender, EventArgs e)
    {
        if (double.TryParse(billInput.Text, out double bill) &&
            double.TryParse(totalOutput.Text, out double total))
        {
            double newTotal = Math.Floor(total);
            double newTip = newTotal - bill;

            totalOutput.Text = newTotal.ToString("F2");
            tipOutput.Text = newTip.ToString("F2");
        }
    }

    private void OnRoundUp(object sender, EventArgs e)
    {
        if (double.TryParse(billInput.Text, out double bill) &&
            double.TryParse(totalOutput.Text, out double total))
        {
            double newTotal = Math.Ceiling(total);
            double newTip = newTotal - bill;

            totalOutput.Text = newTotal.ToString("F2");
            tipOutput.Text = newTip.ToString("F2");
        }
    }

    private void CalculateTip()
    {
        if (double.TryParse(billInput.Text, out double bill))
        {
            double tipPercentValue = tipPercentSlider.Value / 100;
            double tip = bill * tipPercentValue;
            double total = bill + tip;

            tipOutput.Text = tip.ToString("F2");
            totalOutput.Text = total.ToString("F2");
        }
        else
        {
            tipOutput.Text = "0.00";
            totalOutput.Text = "0.00";
        }
    }
}