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
using System.Collections.Generic;

using FluentAssert;

using FluentWebControls.Extensions;
using FluentWebControls.Interfaces;

using NUnit.Framework;

namespace FluentWebControls.Tests
{
	public class ButtonDataTest
	{
		private class TestPathUtility : IPathUtility
		{
			public string GetUrl(string virtualDirectory)
			{
				return String.Format("someapp/{0}", virtualDirectory);
			}
		}

		[TestFixture]
		public class When_asked_to_create_a_Basic_Button
		{
			private readonly ButtonData.ButtonType _buttonType = ButtonData.ButtonType.Basic;
			private readonly string _htmlText = "<input Id=\'btnBasic\' name=\'btnBasic\' value=\'Populate Button\' class=\'cancel\' type=\'button\' onClick=\'validate()\'/>";
			private ButtonData _buttonData;

			[Test]
			public void Should_return_HTML_code_representing_a_button_with_full_path_if_pathUtility_is_configured()
			{
				IPathUtility pathUtility = new TestPathUtility();
				_buttonData = new ButtonData(_buttonType, pathUtility);
				SetAdditionalParameters();
				_buttonData.ToString().ShouldBeEqualTo(_htmlText);
			}

			[Test]
			public void Should_return_HTML_code_representing_a_button_with_partial_path_if_pathutility_is_not_configured()
			{
				const IPathUtility pathUtility = null;
				_buttonData = new ButtonData(_buttonType, pathUtility);
				SetAdditionalParameters();
				_buttonData.ToString().ShouldBeEqualTo(_htmlText);
			}

			private void SetAdditionalParameters()
			{
				_buttonData.Text = "Populate Button";
				_buttonData.OnClickMethod = "validate()";
			}
		}

		[TestFixture]
		public class When_asked_to_create_a_Basic_Button_with_given_width
		{
			private readonly ButtonData.ButtonType _buttonType = ButtonData.ButtonType.Basic;
			private readonly string _htmlText = "<input Id=\'btnBasic\' name=\'btnBasic\' value=\'Basic\' class=\'cancel\' style=\'width:400px\' type=\'button\'/>";
			private ButtonData _buttonData;

			[Test]
			public void Should_return_HTML_code_representing_a_button_with_full_path_if_pathUtility_is_configured()
			{
				IPathUtility pathUtility = new TestPathUtility();
				_buttonData = new ButtonData(_buttonType, pathUtility);
				SetAdditionalParameters();
				_buttonData.ToString().ShouldBeEqualTo(_htmlText);
			}

			[Test]
			public void Should_return_HTML_code_representing_a_button_with_partial_path_if_pathutility_is_not_configured()
			{
				const IPathUtility pathUtility = null;
				_buttonData = new ButtonData(_buttonType, pathUtility);
				SetAdditionalParameters();
				_buttonData.ToString().ShouldBeEqualTo(_htmlText);
			}

			private void SetAdditionalParameters()
			{
				_buttonData.Width = "400px";
			}
		}

		[TestFixture]
		public class When_asked_to_create_a_Button_for_Delete
		{
			private const string ControllerName = "Admin";
			private readonly ButtonData.ButtonType _buttonType = ButtonData.ButtonType.Delete;
			private ButtonData _buttonData;

			[Test]
			public void Should_return_HTML_code_representing_a_button_with_full_path_if_pathUtility_is_configured()
			{
				IPathUtility pathUtility = new TestPathUtility();
				_buttonData = new ButtonData(_buttonType, pathUtility, ControllerName)
				              {
					              ControllerExtension = ".mvc"
				              };

				var htmlText = String.Format("<input Id='btnDelete' name='btnDelete' value='Delete' class='cancel' type='submit' action='{2}' onClick='javascript:return confirmThenChangeFormAction({0}{1}{0}, this)'/>", "\"".EscapeForTagAttribute(), ButtonData.ButtonType.Delete.ConfirmationMessage, pathUtility.GetUrl("/Admin.mvc/Delete"));
				_buttonData.ToString().ShouldBeEqualTo(htmlText);
			}

			[Test]
			public void Should_return_HTML_code_representing_a_button_with_partial_path_if_pathutility_is_not_configured()
			{
				const IPathUtility pathUtility = null;
				_buttonData = new ButtonData(_buttonType, pathUtility, ControllerName)
				              {
					              ControllerExtension = ".mvc"
				              };

				var htmlText = String.Format("<input Id='btnDelete' name='btnDelete' value='Delete' class='cancel' type='submit' action='{2}' onClick='javascript:return confirmThenChangeFormAction({0}{1}{0}, this)'/>", "\"".EscapeForTagAttribute(), ButtonData.ButtonType.Delete.ConfirmationMessage, "/Admin.mvc/Delete");
				_buttonData.ToString().ShouldBeEqualTo(htmlText);
			}
		}

		[TestFixture]
		public class When_asked_to_create_a_Button_for_Delete_with_additional_parameters
		{
			private const string ControllerName = "Admin";
			private readonly ButtonData.ButtonType _buttonType = ButtonData.ButtonType.Delete;
			private ButtonData _buttonData;

			[Test]
			public void Should_return_HTML_code_representing_a_button_with_full_path_if_pathUtility_is_configured()
			{
				IPathUtility pathUtility = new TestPathUtility();
				_buttonData = new ButtonData(_buttonType, pathUtility, ControllerName)
				              {
					              ControllerExtension = ".mvc"
				              };
				SetAdditionalParameters();
				var htmlText = String.Format("<input Id='btnDelete' name='btnDelete' value='Text' class='cancel' type='submit' action='{2}' onClick='javascript:return confirmThenChangeFormAction({0}{1}{0}, this)'/>", "\"".EscapeForTagAttribute(), _buttonData.ConfirmMessage, pathUtility.GetUrl("/Admin.mvc/Test"));
				_buttonData.ToString().ShouldBeEqualTo(htmlText);
			}

			[Test]
			public void Should_return_HTML_code_representing_a_button_with_partial_path_if_pathutility_is_not_configured()
			{
				const IPathUtility pathUtility = null;
				_buttonData = new ButtonData(_buttonType, pathUtility, ControllerName)
				              {
					              ControllerExtension = ".mvc"
				              };
				SetAdditionalParameters();
				var htmlText = String.Format("<input Id='btnDelete' name='btnDelete' value='Text' class='cancel' type='submit' action='{2}' onClick='javascript:return confirmThenChangeFormAction({0}{1}{0}, this)'/>", "\"".EscapeForTagAttribute(), _buttonData.ConfirmMessage, "/Admin.mvc/Test");
				_buttonData.ToString().ShouldBeEqualTo(htmlText);
			}

			private void SetAdditionalParameters()
			{
				_buttonData.Text = "Text";
				_buttonData.ActionName = "Test";
				_buttonData.ConfirmMessage = "Test Message";
			}
		}

		[TestFixture]
		public class When_asked_to_create_a_Button_for_Save
		{
			private const string ControllerName = "Admin";
			private readonly ButtonData.ButtonType _buttonType = ButtonData.ButtonType.Save;
			private ButtonData _buttonData;

			[Test]
			public void Should_return_HTML_code_representing_a_button_with_full_path_if_pathUtility_is_configured()
			{
				IPathUtility pathUtility = new TestPathUtility();
				_buttonData = new ButtonData(_buttonType, pathUtility, ControllerName)
				              {
					              ControllerExtension = ".mvc"
				              };

				var htmlText = String.Format("<input Id='btnSave' name='btnSave' value='Save' class='button' type='submit' action='{0}' onClick='javascript:return changeFormAction(this)'/>", pathUtility.GetUrl("/Admin.mvc/Save"));
				_buttonData.ToString().ShouldBeEqualTo(htmlText);
			}

			[Test]
			public void Should_return_HTML_code_representing_a_button_with_partial_path_if_pathutility_is_not_configured()
			{
				const IPathUtility pathUtility = null;
				_buttonData = new ButtonData(_buttonType, pathUtility, ControllerName)
				              {
					              ControllerExtension = ".mvc"
				              };
				var htmlText = String.Format("<input Id='btnSave' name='btnSave' value='Save' class='button' type='submit' action='{0}' onClick='javascript:return changeFormAction(this)'/>", "/Admin.mvc/Save");
				_buttonData.ToString().ShouldBeEqualTo(htmlText);
			}
		}

		[TestFixture]
		public class When_asked_to_create_a_Button_with_Default_set
		{
			private const string ControllerName = "Admin";
			private readonly ButtonData.ButtonType _buttonType = ButtonData.ButtonType.Save;
			private ButtonData _buttonData;

			[Test]
			public void Should_return_HTML_code_representing_a_button_with_full_path_if_pathUtility_is_configured()
			{
				IPathUtility pathUtility = new TestPathUtility();
				_buttonData = new ButtonData(_buttonType, pathUtility, ControllerName)
				              {
					              ControllerExtension = ".mvc"
				              };
				SetAdditionalParameters();
				var htmlText = String.Format("<input Id='btnSave' name='btnSave' value='Save' class='button default' type='submit' action='{0}' onClick='javascript:return changeFormAction(this)'/>", pathUtility.GetUrl("/Admin.mvc/Save"));
				_buttonData.ToString().ShouldBeEqualTo(htmlText);
			}

			[Test]
			public void Should_return_HTML_code_representing_a_button_with_partial_path_if_pathutility_is_not_configured()
			{
				const IPathUtility pathUtility = null;
				_buttonData = new ButtonData(_buttonType, pathUtility, ControllerName)
				              {
					              ControllerExtension = ".mvc"
				              };
				SetAdditionalParameters();
				var htmlText = String.Format("<input Id='btnSave' name='btnSave' value='Save' class='button default' type='submit' action='{0}' onClick='javascript:return changeFormAction(this)'/>", "/Admin.mvc/Save");
				_buttonData.ToString().ShouldBeEqualTo(htmlText);
			}

			protected void SetAdditionalParameters()
			{
				_buttonData.AsDefault();
			}
		}

		[TestFixture]
		public class When_asked_to_create_a_Button_with_Visibility_set_to_false
		{
			private const string ControllerName = "Admin";
			private const string HtmlText = "";
			private readonly ButtonData.ButtonType _buttonType = ButtonData.ButtonType.Save;
			private ButtonData _buttonData;

			[Test]
			public void Should_return_HTML_code_representing_a_button_with_full_path_if_pathUtility_is_configured()
			{
				IPathUtility pathUtility = new TestPathUtility();
				_buttonData = new ButtonData(_buttonType, pathUtility, ControllerName)
				              {
					              ControllerExtension = ".mvc"
				              };
				SetAdditionalParameters();
				_buttonData.ToString().ShouldBeEqualTo(HtmlText);
			}

			[Test]
			public void Should_return_HTML_code_representing_a_button_with_partial_path_if_pathutility_is_not_configured()
			{
				const IPathUtility pathUtility = null;
				_buttonData = new ButtonData(_buttonType, pathUtility, ControllerName)
				              {
					              ControllerExtension = ".mvc"
				              };
				SetAdditionalParameters();
				_buttonData.ToString().ShouldBeEqualTo(HtmlText);
			}

			protected void SetAdditionalParameters()
			{
				_buttonData.Visible = false;
			}
		}

		[TestFixture]
		public class When_asked_to_create_a_Link_Button
		{
			private readonly ButtonData.ButtonType _buttonType = ButtonData.ButtonType.Link;
			private ButtonData _buttonData;

			[Test]
			public void Should_return_HTML_code_representing_a_button_with_full_path_if_pathUtility_is_configured()
			{
				IPathUtility pathUtility = new TestPathUtility();
				_buttonData = new ButtonData(_buttonType, pathUtility);
				SetAdditionalParameters();
				var htmlText = String.Format("<input Id='btnLink' name='btnLink' value='Cancel' class='cancel' type='button' onClick='javascript:location.href=&quot;{0}&quot;'/>", pathUtility.GetUrl("/Test/Action/4/name"));
				_buttonData.ToString().ShouldBeEqualTo(htmlText);
			}

			[Test]
			public void Should_return_HTML_code_representing_a_button_with_partial_path_if_pathutility_is_not_configured()
			{
				const IPathUtility pathUtility = null;
				_buttonData = new ButtonData(_buttonType, pathUtility);
				SetAdditionalParameters();
				var htmlText = String.Format("<input Id='btnLink' name='btnLink' value='Cancel' class='cancel' type='button' onClick='javascript:location.href=&quot;{0}&quot;'/>", "/Test/Action/4/name");
				_buttonData.ToString().ShouldBeEqualTo(htmlText);
			}

			protected void SetAdditionalParameters()
			{
				_buttonData.Text = "Cancel";
				_buttonData.ControllerName = "Test";
				_buttonData.ActionName = "Action";
				_buttonData.AddUrlParameters(new List<string>
				                             {
					                             "4",
					                             "name"
				                             });
			}
		}
	}
}