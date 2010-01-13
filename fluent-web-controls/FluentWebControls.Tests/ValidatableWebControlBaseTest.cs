﻿using System;

using FluentAssert;

using FluentWebControls.Extensions;
using FluentWebControls.Interfaces;
using FluentWebControls.Tests.Extensions;

using NUnit.Framework;

namespace FluentWebControls.Tests
{
	public class ValidatableWebControlBaseTest
	{
		public class ValidatableTest : ValidatableWebControlBase
		{
			public string Validation(string cssClass)
			{
				return BuildJqueryValidation(cssClass);
			}
		}

		[TestFixture]
		public class When_asked_to_build_JQueryValidation_for_input
		{
			private string _cssClass;
			private IPropertyMetaData _propertyMetaData;

			[Test]
			public void Should_append_Date_validation_string_for_date_input()
			{
				_propertyMetaData = PropertyMetaDataMocker.CreateStub("Field", true, 0, 10, null, null, typeof(DateTime));
				_cssClass = "testClass";
				var validatableTest = new ValidatableTest().WithValidationFrom(_propertyMetaData);
				string expectedValiationString = String.Format("required {0} {1}", _cssClass, ValidatableWebControlBase.JQueryFieldValidationType.Date.Text);
				validatableTest.Validation(_cssClass).ShouldBeEqualTo(expectedValiationString);
			}

			[Test]
			public void Should_append_Digits_validation_string_for_int_input()
			{
				_propertyMetaData = PropertyMetaDataMocker.CreateStub("Field", true, 0, 10, 0, 100, typeof(int));
				_cssClass = "testClass";
				var validatableTest = new ValidatableTest().WithValidationFrom(_propertyMetaData);
				string expectedValiationString = String.Format("required {0} {1}", _cssClass, ValidatableWebControlBase.JQueryFieldValidationType.Digits.Text);
				validatableTest.Validation(_cssClass).ShouldBeEqualTo(expectedValiationString);
			}

			[Test]
			public void Should_append_Required_validation_string_for_input_that_maps_to_a_property_that_is_not_null()
			{
				_propertyMetaData = PropertyMetaDataMocker.CreateStub("Field", true, 0, 10, null, null, typeof(string));
				_cssClass = "testClass";
				var validatableTest = new ValidatableTest().WithValidationFrom(_propertyMetaData);
				string expectedValiationString = String.Format("required {0}", _cssClass);
				validatableTest.Validation(_cssClass).ShouldBeEqualTo(expectedValiationString);
			}

			[Test]
			public void Should_append_Text_validation_string_for_decimal_input()
			{
				_propertyMetaData = PropertyMetaDataMocker.CreateStub("Field", true, 0, 10, 0, 100, typeof(decimal));
				_cssClass = "testClass";
				var validatableTest = new ValidatableTest().WithValidationFrom(_propertyMetaData);
				string expectedValiationString = String.Format("required {0} {1}", _cssClass, ValidatableWebControlBase.JQueryFieldValidationType.Number.Text);
				validatableTest.Validation(_cssClass).ShouldBeEqualTo(expectedValiationString);
			}

			[Test]
			public void Should_not_append_Required_validation_string_for_input_that_maps_to_a_property_that_can_be_null()
			{
				_propertyMetaData = PropertyMetaDataMocker.CreateStub("Field", false, 0, 10, null, null, typeof(string));
				_cssClass = "testClass";
				var validatableTest = new ValidatableTest().WithValidationFrom(_propertyMetaData);
				string expectedValiationString = String.Format("{0}", _cssClass);
				validatableTest.Validation(_cssClass).ShouldBeEqualTo(expectedValiationString);
			}
		}
	}
}