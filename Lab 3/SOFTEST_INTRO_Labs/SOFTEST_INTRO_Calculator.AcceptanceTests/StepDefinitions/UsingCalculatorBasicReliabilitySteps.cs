using System;
using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorBasicReliabilitySteps
{
    private readonly CalculatorContext _calcContext;
    private readonly MusaContext _musaContext;

    public UsingCalculatorBasicReliabilitySteps(CalculatorContext calcContext, MusaContext musaContext)
    {
        _calcContext = calcContext;
        _musaContext = musaContext;
    }

    [Given("Musa parameters initial intensity {double}, total failures {double}, and execution time {double} hours")]
    public void GivenMusaParameters(double lambda0, double nu0, double tau)
    {
        _musaContext.Lambda0 = lambda0;
        _musaContext.Nu0 = nu0;
        _musaContext.Tau = tau;
    }

    [When("I calculate the current failure intensity")]
    public void WhenICalculateTheCurrentFailureIntensity()
    {
        _calcContext.Result = null;
        _calcContext.Error = null;
        try
        {
            _calcContext.Result = _calcContext.Calculator.MusaCurrentFailureIntensity(
                _musaContext.Lambda0, _musaContext.Nu0, _musaContext.Tau);
        }
        catch (Exception ex)
        {
            _calcContext.Error = ex;
        }
    }

    [When("I calculate the expected cumulative failures")]
    public void WhenICalculateTheExpectedCumulativeFailures()
    {
        _calcContext.Result = null;
        _calcContext.Error = null;
        try
        {
            _calcContext.Result = _calcContext.Calculator.MusaExpectedCumulativeFailures(
                _musaContext.Lambda0, _musaContext.Nu0, _musaContext.Tau);
        }
        catch (Exception ex)
        {
            _calcContext.Error = ex;
        }
    }
}