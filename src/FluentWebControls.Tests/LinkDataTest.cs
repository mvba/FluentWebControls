//  * **************************************************************************
//  * Copyright (c) McCreary, Veselka, Bragg & Allen, P.C.
//  * This source code is subject to terms and conditions of the MIT License.
//  * A copy of the license can be found in the License.txt file
//  * at the root of this distribution. 
//  * By using this source code in any fashion, you are agreeing to be bound by 
//  * the terms of the MIT License.
//  * You must not remove this notice from this software.
//  * **************************************************************************

using FluentAssert;

using FluentWebControls.Extensions;

using NUnit.Framework;

namespace FluentWebControls.Tests
{
	public class LinkDataTest
	{
		[TestFixture]
		public class When_asked_to_create_a_empty_link
		{
			[Test]
			public void Should_return_HTML_code_representing_a_link_with_all_the_values_set()
			{
				var linkData = new LinkData();

				const string htmlText = "<a href=''></a>";
				linkData.ToString().ShouldBeEqualTo(htmlText);
			}
		}

		[TestFixture]
		public class When_asked_to_create_a_link_that_is_disabled_with_no_query_parameters
		{
			[Test]
			public void Should_return_HTML_code_representing_a_link_with_all_the_values_set()
			{
				var linkData = new LinkData()
					.WithUrl("AdminTest")
					.WithCssClass("Css")
					.WithMouseOverText("MouseOver")
					.WithLinkText("Link")
					.DisabledIf(true);

				const string htmlText = "<a disabled class='Css' title='MouseOver'>Link</a>";

				linkData.ToString().ShouldBeEqualTo(htmlText);
			}
		}

		[TestFixture]
		public class When_asked_to_create_a_link_that_is_enabled_with_no_query_parameters
		{
			[Test]
			public void Should_return_HTML_code_representing_a_link_with_all_the_values_set()
			{
				var linkData = new LinkData()
					.WithUrl("AdminTest")
					.WithCssClass("Css")
					.WithMouseOverText("MouseOver")
					.WithLinkText("Link")
					.DisabledIf(false);

				const string htmlText = "<a href='AdminTest' class='Css' title='MouseOver'>Link</a>";

				linkData.ToString().ShouldBeEqualTo(htmlText);
			}
		}

		[TestFixture]
		public class When_asked_to_create_a_link_that_is_enabled_with_query_parameters
		{
			[Test]
			public void Should_return_HTML_code_representing_a_link_with_all_the_values_set()
			{
				var linkData = new LinkData()
					.WithUrl("AdminTest")
					.WithCssClass("Css")
					.WithMouseOverText("MouseOver")
					.WithLinkText("Link")
					.DisabledIf(false);

				linkData.AddQueryStringData("key1", "value");
				linkData.AddQueryStringData("key2", null);

				const string href = "AdminTest?key1=value&key2=&";
				var htmlText = $"<a href='{href}' class='Css' title='MouseOver'>Link</a>";
				linkData.ToString().ShouldBeEqualTo(htmlText);
				((ILinkData)linkData).Href.ShouldBeEqualTo(href);
			}
		}
	}
}