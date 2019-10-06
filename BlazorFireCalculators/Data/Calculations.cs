using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;

namespace BlazorFireCalculators.Data
{
    enum Format
    {
        Currency,
        Percent,
        None
    }
    public class FVCalculation : ComponentBase
    {

        public double InitialValue { get; set; }
        public double MonthlyContribution { get; set; }
        public double NumYears { get; set; }
        public double AnnualInterest { get; set; }

        public double FutureValue { get; set; }
        public double TotalContributions { get; set; }
        public double InterestEarnings { get; set; }

        // Hopefully string hack will not be necessary once bind:format supports currency and number formatting
        public string InitialValueString { get; set; } = "";
        public string MonthlyContributionString { get; set; } = "";
        public string NumYearsString { get; set; } = "";
        public string AnnualInterestString { get; set; } = "";
        
        public string FutureValueString { get; set; } = "";
        public string TotalContributionsString { get; set; } = "";
        public string InterestEarningsString { get; set; } = "";


        public void CalculateFutureValue()
        {
            double annualContribution = MonthlyContribution * 12;
            double interestPercent = AnnualInterest / 100;

            FutureValue = (InitialValue + (annualContribution / interestPercent))
                * (Math.Pow((double)(1 + interestPercent), (double)NumYears))
                - (annualContribution / interestPercent);
            TotalContributions = InitialValue + (annualContribution * NumYears);
            InterestEarnings = FutureValue - TotalContributions;
        }
    }
    public class FireAgeCalculation : ComponentBase
    {
        public double CurrentAge { get; set; }
        public double CurrentBalance { get; set; }
        public double AnnualContribution { get; set; }
        public double RetirementExpenses { get; set; }
        public double ExpectedReturn { get; set; }
        public double WithdrawalRate { get; set; }

        public double FireAge { get; set; }
        public double FireBalance { get; set; }

        public string CurrentAgeString { get; set; } = "";
        public string CurrentBalanceString { get; set; } = "";
        public string AnnualContributionString { get; set; } = "";
        public string RetirementExpensesString { get; set; } = "";
        public string ExpectedReturnString { get; set; } = "";
        public string WithdrawalRateString { get; set; } = "";

        public string FireAgeString { get; set; } = "";
        public string FireBalanceString { get; set; } = "";

        public void CalculateFireAge()
        {
            double _expectedReturn = ExpectedReturn / 100;
            FireBalance = RetirementExpenses * (100 / WithdrawalRate);
            double _yearsToRetire = (Math.Log((FireBalance * _expectedReturn) + AnnualContribution)
                                            - Math.Log((_expectedReturn * CurrentBalance) + AnnualContribution))
                                        / (Math.Log(1 + _expectedReturn));
            FireAge = CurrentAge + _yearsToRetire;
        }
    }
}
