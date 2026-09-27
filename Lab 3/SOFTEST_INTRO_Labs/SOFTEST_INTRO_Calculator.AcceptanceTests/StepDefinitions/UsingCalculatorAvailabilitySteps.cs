using System;
using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorAvailabilitySteps
{
    private readonly CalculatorContext _calculatorContext;
    private readonly ReliabilityContext _reliabilityContext;

    public UsingCalculatorAvailabilitySteps(CalculatorContext calculatorContext, ReliabilityContext reliabilityContext)
    {
        _calculatorContext = calculatorContext;
        _reliabilityContext = reliabilityContext;
    }

    [When("I have entered {double} and {int} into the calculator and press MTBF")]
    public void WhenIHaveEnteredAndPressMTBF(double operatingTime, int failures)
    {
        _calculatorContext.Result = null;
        _calculatorContext.Error = null;
        try
        {
            _calculatorContext.Result = _calculatorContext.Calculator.Mtbf(operatingTime, failures);
        }
        catch (Exception ex)
        {
            _calculatorContext.Error = ex;
        }
    }

    [When("I have entered {double} and {double} into the calculator and press Availability")]
    public void WhenIHaveEnteredAndPressAvailability(double mtbf, double mttr)
    {
        _calculatorContext.Result = null;
        _calculatorContext.Error = null;
        try
        {
            _calculatorContext.Result = _calculatorContext.Calculator.Availability(mtbf, mttr);
        }
        catch (Exception ex)
        {
            _calculatorContext.Error = ex;
        }
    }

    [Given("the reliability values are")]
    public void GivenTheReliabilityValuesAre(DataTable table)
    {
        var values = table.Rows[0];
        _reliabilityContext.Mtbf = double.Parse(values["MTBF"]);
        _reliabilityContext.Mttr = double.Parse(values["MTTR"]);
    }

    [When("I calculate Availability from these values")]
    public void WhenICalculateAvailabilityFromTheseValues()
    {
        _calculatorContext.Result = null;
        _calculatorContext.Error = null;
        try
        {
            _calculatorContext.Result = _calculatorContext.Calculator.Availability(
                _reliabilityContext.Mtbf, 
                _reliabilityContext.Mttr
            );
        }
        catch (Exception ex)
        {
            _calculatorContext.Error = ex;
        }
    }
}