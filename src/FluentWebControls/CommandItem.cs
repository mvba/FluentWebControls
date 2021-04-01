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
using System.Text;

using FluentWebControls.Extensions;

namespace FluentWebControls
{
	public class CommandItem
	{
		public static CommandItem<T> For<T>(Func<T, string> getHref)
		{
			return new CommandItem<T>(getHref);
		}

		public static CommandItem<T> For<T>(Func<T, string, string> getControl)
		{
			return new CommandItem<T>(getControl);
		}
	}

	public interface ICommandItem
	{
		AlignAttribute Align { get; }
		string Alt { get; }
		//string Href { get; }
		string CssClass { get; }
		string ImageUrl { get; }
		string Text { get; }
		bool WrapWithSpan { get; }
	}

	public class CommandItem<T> : ICommandItem, IListItem<T>
	{
		private readonly Func<T, string, string> _getControl;
		private readonly Func<T, string> _getLink;

		public CommandItem(Func<T, string> getLink)
		{
			_getLink = getLink;
			Align = AlignAttribute.Left;
		}

		public CommandItem(Func<T, string, string> getControl)
		{
			_getControl = getControl;
			Align = AlignAttribute.Center;
		}

		internal AlignAttribute Align { private get; set; }
		internal string Alt { private get; set; }
		internal string CssClass { private get; set; }
		internal string ImageUrl { private get; set; }
		internal string InnerHtml { private get; set; }
		internal string Text { private get; set; }
		internal bool WrapWithSpan { private get; set; }

		#region ICommandItem Members

		string ICommandItem.Text => Text;

		string ICommandItem.ImageUrl => ImageUrl;

		string ICommandItem.Alt => Alt;

		AlignAttribute ICommandItem.Align => Align;

		string ICommandItem.CssClass => CssClass;

		bool ICommandItem.WrapWithSpan => WrapWithSpan;

		#endregion

		#region IListItem<T> Members

		public StringBuilder Render(T item)
		{
			var listItem = new StringBuilder();
			var tag = WrapWithSpan ? "span" : "div";
			listItem.Append('<');
			listItem.Append(tag);
			listItem.Append(Align.Text.CreateQuotedAttribute("align"));
			if (CssClass != null)
			{
				listItem.Append(CssClass.CreateQuotedAttribute("class"));
			}
			listItem.Append('>');
			var control = _getControl == null ? GetLink(item).ToString() : _getControl(item, Text);
			listItem.Append(control);
			listItem.Append("</");
			listItem.Append(tag);
			listItem.Append('>');
			return listItem;
		}

		#endregion

		private LinkData GetLink(T item)
		{
			var navigateUrl = _getLink(item);
			var linkId = $"lnk{navigateUrl.Replace('/', '_').TrimStart('_')}";
			return new LinkData().WithId(linkId).WithUrl(navigateUrl).WithLinkText(Text).WithInnerHtml(InnerHtml).WithLinkImageUrl(ImageUrl, Alt);
		}
	}
}