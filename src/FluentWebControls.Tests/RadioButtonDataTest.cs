﻿//  * **************************************************************************
//  * Copyright (c) McCreary, Veselka, Bragg & Allen, P.C.
//  * This source code is subject to terms and conditions of the MIT License.
//  * A copy of the license can be found in the License.txt file
//  * at the root of this distribution. 
//  * By using this source code in any fashion, you are agreeing to be bound by 
//  * the terms of the MIT License.
//  * You must not remove this notice from this software.
//  * **************************************************************************

using System;

using FluentAssert;

using FluentWebControls.Extensions;

using MvbaCore;

using NUnit.Framework;

namespace FluentWebControls.Tests
{
	public class RadioButtonDataTest
	{
		[TestFixture]
		public class When_asked_to_create_a_radio_that_is_checked
		{
			private const string HtmlText = "<input type='radio' id='value' name='value' checked='checked' value='true'/>";

			[Test]
			public void Should_return_HTML_code_representing_a_radio_field_with_its_value_embedded_in_it()
			{
				// ReSharper disable once ConvertToConstant.Local
				var value = true;
				// ReSharper disable once ConditionIsAlwaysTrueOrFalse
				var checkBoxData = new RadioButtonData(value).WithId(Reflection.GetPropertyName(() => value).ToCamelCase());
				var actual = checkBoxData.ToString();
				actual.ShouldBeEqualTo(HtmlText, actual);
			}
		}

		[TestFixture]
		public class When_asked_to_create_a_radio_that_is_not_checked
		{
			private const string HtmlText = "<input type='radio' id='value' name='value' value='true'/>";

			[Test]
			public void Should_return_HTML_code_representing_a_radio_field_with_its_value_embedded_in_it()
			{
				// ReSharper disable once ConvertToConstant.Local
				var value = false;
				// ReSharper disable once ConditionIsAlwaysTrueOrFalse
				var checkBoxData = new RadioButtonData(value).WithId(Reflection.GetPropertyName(() => value).ToCamelCase());
				var actual = checkBoxData.ToString();
				actual.ShouldBeEqualTo(HtmlText, actual);
			}
		}

		[TestFixture]
		public class When_asked_to_create_a_radio_with_label_in_the_left
		{
			private const string HtmlText = "<label for='value'>Label</label><input type='radio' id='value' name='value' value='true'/>";

			[Test]
			public void Should_return_HTML_code_representing_a_radio_field_with_its_value_embedded_in_it()
			{
				// ReSharper disable once ConvertToConstant.Local
				var value = false;
				// ReSharper disable once ConditionIsAlwaysTrueOrFalse
				var checkBoxData = new RadioButtonData(value).WithId(Reflection.GetPropertyName(() => value).ToCamelCase());
				SetLabel(checkBoxData);
				var actual = checkBoxData.ToString();
				actual.ShouldBeEqualTo(HtmlText, actual);
			}

			private static void SetLabel(RadioButtonData checkBoxData)
			{
				var label = new LabelData
				            {
					            Text = "Label"
				            };
				checkBoxData.WithLabel(label);
				checkBoxData.WithLabelAlignedLeft(label);
			}
		}

		[TestFixture]
		public class When_asked_to_create_a_radio_with_label_in_the_right
		{
			private const string HtmlText = "<label>&nbsp;</label><input type='radio' id='value' name='value' value='true'/><label for='value'>Label</label>";

			[Test]
			public void Should_return_HTML_code_representing_a_radio_field_with_its_value_embedded_in_it()
			{
				// ReSharper disable once ConvertToConstant.Local
				var value = false;
				// ReSharper disable once ConditionIsAlwaysTrueOrFalse
				var checkBoxData = new RadioButtonData(value).WithId(Reflection.GetPropertyName(() => value).ToCamelCase());
				SetLabel(checkBoxData);
				var actual = checkBoxData.ToString();
				actual.ShouldBeEqualTo(HtmlText, actual);
			}

			private static void SetLabel(RadioButtonData checkBoxData)
			{
				var label = new LabelData
				            {
					            Text = "Label:"
				            };
				checkBoxData.WithLabel(label);
			}
		}
	}
}