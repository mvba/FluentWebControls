//  * **************************************************************************
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

namespace FluentWebControls.Tests.Extensions
{
	public class CheckBoxDataExtensionsTest
	{
		public abstract class CheckBoxDataExtensionsTestBase
		{
			protected CheckBoxData CheckBoxData;
			protected bool IsChecked;

			[SetUp]
			public void BeforeEachTest()
			{
				IsChecked = true;
				CheckBoxData = new CheckBoxData(true);
			}
		}

		[TestFixture]
		public class When_asked_to_add_TabIndex : CheckBoxDataExtensionsTestBase
		{
			[Test]
			public void Should_return_a_CheckBoxData_With_TabIndex_initialized()
			{
				const string tabIndex = "1";

				var checkBoxData = CheckBoxData.WithTabIndex(tabIndex);
				Assert.AreSame(CheckBoxData, checkBoxData);
				checkBoxData.ToString().ParseHtmlTag()["tabindex"].ShouldBeEqualTo(tabIndex);
				checkBoxData.ToString().Contains(tabIndex).ShouldBeTrue();
			}
		}

		[TestFixture]
		public class When_asked_to_assign_Id : CheckBoxDataExtensionsTestBase
		{
			[Test]
			public void Should_return_a_CheckBoxData_With_Id_initialized()
			{
				var checkBoxData = CheckBoxData.WithId("isChecked");
				Assert.AreSame(CheckBoxData, checkBoxData);
				var propertyName = Reflection.GetPropertyName(() => IsChecked).ToCamelCase();
				CheckBoxData.ToString().ParseHtmlTag()["id"].ShouldBeEqualTo(propertyName.ToCamelCase());
// ReSharper disable once AssignNullToNotNullAttribute
				checkBoxData.ToString().Contains(propertyName).ShouldBeTrue();
			}
		}

		[TestFixture]
		public class When_asked_to_assign_IsChecked : CheckBoxDataExtensionsTestBase
		{
			[Test]
			public void Should_return_a_CheckBoxData_With_IsChecked_initialized()
			{
				var checkBoxData = CheckBoxData.IsChecked(IsChecked);
				Assert.AreSame(CheckBoxData, checkBoxData);
				const string checkedAttribute = "checked";
				CheckBoxData.ToString().ParseHtmlTag()[checkedAttribute].ShouldBeEqualTo("checked");
				checkBoxData.ToString().Contains(checkedAttribute).ShouldBeTrue();
			}
		}

		[TestFixture]
		public class When_asked_to_assign_Label : CheckBoxDataExtensionsTestBase
		{
			[Test]
			public void Should_return_a_CheckBoxData_With_Label_initialized()
			{
				var label = new LabelData("Id");
				var blankLabel = new LabelData
				                 {
					                 Text = "&nbsp;"
				                 };

				var checkBoxData = CheckBoxData.WithLabel(label);
				Assert.AreSame(CheckBoxData, checkBoxData);
				checkBoxData.ToString().Contains(label.ToString()).ShouldBeTrue();
				checkBoxData.ToString().Contains(blankLabel.ToString()).ShouldBeTrue();
			}
		}

		[TestFixture]
		public class When_asked_to_assign_Label_on_left : CheckBoxDataExtensionsTestBase
		{
			[Test]
			public void Should_return_a_CheckBoxData_With_Label_initialized()
			{
				var label = new LabelData("Id");
				var blankLabel = new LabelData
				                 {
					                 Text = "&nbsp;"
				                 };

				var checkBoxData = CheckBoxData.WithLabelAlignedLeft(label);
				Assert.AreSame(CheckBoxData, checkBoxData);
				checkBoxData.ToString().Contains(label.ToString()).ShouldBeTrue();
				checkBoxData.ToString().Contains(blankLabel.ToString()).ShouldBeFalse();
			}
		}

		[TestFixture]
		public class When_asked_to_assign_value : CheckBoxDataExtensionsTestBase
		{
			[Test]
			public void Should_return_a_CheckBoxData_With_Value_initialized()
			{
				Test.Given(CheckBoxData)
					.When(value_set_to_false)
					.Should(put_the_value_in_the_generated_html)
					.Verify();
			}

			[Test]
			public void Should_return_a_CheckBoxData_With_Value_initialized_to_true_by_default()
			{
				Test.Given(CheckBoxData)
					.When(value_not_set)
					.Should(set_the_value_to_true_in_the_generated_html)
					.Verify();
			}

			private void put_the_value_in_the_generated_html(CheckBoxData checkBoxData)
			{
				CheckBoxData.ToString().ParseHtmlTag()["value"].ShouldBeEqualTo("false");
			}

			private void set_the_value_to_true_in_the_generated_html(CheckBoxData obj)
			{
				CheckBoxData.ToString().ParseHtmlTag()["value"].ShouldBeEqualTo("true");
			}

			private static void value_not_set(CheckBoxData checkBoxData)
			{
				checkBoxData.WithValue(null);
			}

			private static void value_set_to_false(CheckBoxData checkBoxData)
			{
				checkBoxData.WithValue("false");
			}
		}
	}
}