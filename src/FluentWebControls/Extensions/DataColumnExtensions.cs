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

namespace FluentWebControls.Extensions
{
	public static class DataColumnExtensions
	{
		public static DataColumn<T> AlignCenter<T>(this DataColumn<T> dataColumn)
		{
			dataColumn.Align = AlignAttribute.Center;
			return dataColumn;
		}

		public static DataColumn<T> AlignHeaderLeft<T>(this DataColumn<T> dataColumn)
		{
			dataColumn.HeaderAlign = AlignAttribute.Left;
			return dataColumn;
		}

		public static DataColumn<T> AlignHeaderRight<T>(this DataColumn<T> dataColumn)
		{
			dataColumn.HeaderAlign = AlignAttribute.Right;
			return dataColumn;
		}

		public static DataColumn<T> AlignRight<T>(this DataColumn<T> dataColumn)
		{
			dataColumn.Align = AlignAttribute.Right;
			return dataColumn;
		}

		public static DataColumn<T> AsCheckBox<T>(this DataColumn<T> dataColumn, Func<T, string> forId)
		{
			dataColumn.ColumnTextType = ColumnTextType.CheckBox;
			dataColumn.GetItemId = forId;
			return dataColumn;
		}

		public static DataColumn<T> AsCheckBox<T>(this DataColumn<T> dataColumn, string forId)
		{
			dataColumn.ColumnTextType = ColumnTextType.CheckBox;
			dataColumn.InputTextId = forId;
			return dataColumn;
		}

		public static DataColumn<T> AsHidden<T>(this DataColumn<T> dataColumn, Func<T, string> forId)
		{
			dataColumn.ColumnTextType = ColumnTextType.Hidden;
			dataColumn.GetItemId = forId;
			return dataColumn;
		}

		public static DataColumn<T> AsHidden<T>(this DataColumn<T> dataColumn, string forId)
		{
			dataColumn.ColumnTextType = ColumnTextType.Hidden;
			dataColumn.InputTextId = forId;
			return dataColumn;
		}

		public static DataColumn<T> AsSpan<T>(this DataColumn<T> dataColumn, Func<T, string> forId)
		{
			dataColumn.ColumnTextType = ColumnTextType.Span;
			dataColumn.GetItemId = forId;
			return dataColumn;
		}

		public static DataColumn<T> AsTextBox<T>(this DataColumn<T> dataColumn, Func<T, string> forId)
		{
			dataColumn.ColumnTextType = ColumnTextType.TextBox;
			dataColumn.GetItemId = forId;
			return dataColumn;
		}

		public static DataColumn<T> AsTextBox<T>(this DataColumn<T> dataColumn, string forId)
		{
			dataColumn.ColumnTextType = ColumnTextType.TextBox;
			dataColumn.InputTextId = forId;
			return dataColumn;
		}

		public static DataColumn<T> WithCssClass<T>(this DataColumn<T> dataColumn, string cssClass)
		{
			dataColumn.CssClass = cssClass;
			return dataColumn;
		}

		public static DataColumn<T> WithHeader<T>(this DataColumn<T> dataColumn, string header)
		{
			dataColumn.HeaderText = header;
			return dataColumn;
		}

		public static DataColumn<T> WithHeaderCssClass<T>(this DataColumn<T> dataColumn, string cssClass)
		{
			dataColumn.HeaderCssClass = cssClass;
			return dataColumn;
		}

		public static DataColumn<T> WithInputCssClass<T>(this DataColumn<T> dataColumn, string inputCssClass)
		{
			dataColumn.InputCssClass = inputCssClass;
			return dataColumn;
		}

		public static DataColumn<T> WithName<T>(this DataColumn<T> dataColumn, string name)
		{
			dataColumn.InputTextName = name;
			return dataColumn;
		}

		public static DataColumn<T> WithPrefix<T>(this DataColumn<T> dataColumn, string prefix)
		{
			dataColumn.Prefix = prefix;
			return dataColumn;
		}
	}
}