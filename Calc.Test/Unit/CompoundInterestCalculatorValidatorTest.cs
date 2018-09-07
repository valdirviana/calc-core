using Calc.Core.Validators;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Calc.Test.Unit
{
    public class CompoundInterestCalculatorValidatorTest
    {
        private readonly CompoundInterestCalculatorValidator _compoundInterestCalculatorValidator;

        public CompoundInterestCalculatorValidatorTest()
        {
            _compoundInterestCalculatorValidator = new CompoundInterestCalculatorValidator();
        }

        [Fact]
        public void ShouldValidadeIfAmountIsInvalid()
        {
            var validatedFields = _compoundInterestCalculatorValidator.Validate(string.Empty, "10");
            validatedFields.Item1.Should().BeFalse();
            validatedFields.Item2.Count.Should().BeGreaterThan(0);
            validatedFields.Item2.FirstOrDefault(x => x == "Amount is invalid").Should().NotBeEmpty();
        }

        [Fact]
        public void ShouldValidadeIfAmountIsInvalidByNotValidFloat()
        {
            var validatedFields = _compoundInterestCalculatorValidator.Validate("n12", "10");
            validatedFields.Item1.Should().BeFalse();
            validatedFields.Item2.Count.Should().BeGreaterThan(0);
            validatedFields.Item2.FirstOrDefault(x => x == "Amount is not a valid float number").Should().NotBeEmpty();
        }

        [Fact]
        public void ShouldValidadeIfAmountIsInvalidByContainsBlankSpace()
        {
            var validatedFields = _compoundInterestCalculatorValidator.Validate(" ", "10");
            validatedFields.Item1.Should().BeFalse();
            validatedFields.Item2.Count.Should().BeGreaterThan(0);
            validatedFields.Item2.FirstOrDefault(x => x == "Amount contains a blank space").Should().NotBeEmpty();
        }

        [Fact]
        public void ShouldValidadeIfAmountIsInvalidByContainsDotInSeparator()
        {
            var validatedFields = _compoundInterestCalculatorValidator.Validate("100.50", "10");
            validatedFields.Item1.Should().BeFalse();
            validatedFields.Item2.Count.Should().BeGreaterThan(0);
            validatedFields.Item2.FirstOrDefault(x => x == "Amount contains a dot, replace to comma").Should().NotBeEmpty();
        }

        [Fact]
        public void ShouldValidadeIfPeriodIsInvalid()
        {
            var validatedFields = _compoundInterestCalculatorValidator.Validate("100", string.Empty);
            validatedFields.Item1.Should().BeFalse();
            validatedFields.Item2.Count.Should().BeGreaterThan(0);
            validatedFields.Item2.FirstOrDefault(x => x == "Period is null or empty").Should().NotBeEmpty();
        }

        [Fact]
        public void ShouldValidadeIfPeriodIsInvalidByNotValidInt()
        {
            var validatedFields = _compoundInterestCalculatorValidator.Validate("100", "n10");
            validatedFields.Item1.Should().BeFalse();
            validatedFields.Item2.Count.Should().BeGreaterThan(0);
            validatedFields.Item2.FirstOrDefault(x => x == "Period is not a valid number").Should().NotBeEmpty();
        }

        [Fact]
        public void ShouldValidadeIfPeriodIsInvalidByContainsBlankSpace()
        {
            var validatedFields = _compoundInterestCalculatorValidator.Validate("100", " ");
            validatedFields.Item1.Should().BeFalse();
            validatedFields.Item2.Count.Should().BeGreaterThan(0);
            validatedFields.Item2.FirstOrDefault(x => x == "Period contains a blank space").Should().NotBeEmpty();
        }
    }
}
