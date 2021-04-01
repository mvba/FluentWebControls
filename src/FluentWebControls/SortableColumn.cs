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

namespace FluentWebControls
{
	public class SortableColumn<T> : RegularColumn<T>
	{
		public SortableColumn(Func<T, string> getValue, string fieldName, string columnHeader)
			: base(getValue, fieldName, columnHeader)
		{
		}

		public override GridColumnType Type => GridColumnType.Sortable;
	}
}