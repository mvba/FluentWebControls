using FluentWebControls.Extensions;
using FluentWebControls.Interfaces;

namespace FluentWebControls
{
	public static class PagedGrid
	{
		public static PagedGridData<TReturn> For<TReturn>(IPagedList<TReturn> pagedList, IPagedListParameters pagedListParameters, string controllerName, string actionName)
		{
			var items = pagedList
				.Page(pagedListParameters.PageNumber, pagedListParameters.PageSize)
				.OrderBy(pagedListParameters.SortField, pagedListParameters.SortDirection)
				.ToList();
			return new PagedGridData<TReturn>(pagedListParameters, controllerName, actionName, items, pagedList.Total());
		}

		public static PagedGridData<TReturn> For<TReturn>(IPagedList<string, TReturn> pagedList, IPagedListParameters pagedListParameters, string controllerName, string actionName, string filter)
		{
			var items = pagedList
				.Page(pagedListParameters.PageNumber, pagedListParameters.PageSize)
				.OrderBy(pagedListParameters.SortField, pagedListParameters.SortDirection)
				.ToList(filter);
			return new PagedGridData<TReturn>(pagedListParameters, controllerName, actionName, items, pagedList.Total(filter));
		}

		public static PagedGridData<TReturn> For<TReturn>(IPagedList<int?, TReturn> pagedList, IPagedListParameters pagedListParameters, string controllerName, string actionName, int? filter)
		{
			var items = pagedList
				.Page(pagedListParameters.PageNumber, pagedListParameters.PageSize)
				.OrderBy(pagedListParameters.SortField, pagedListParameters.SortDirection)
				.ToList(filter);
			return new PagedGridData<TReturn>(pagedListParameters, controllerName, actionName, items, pagedList.Total(filter));
		}

		public static PagedGridData<TReturn> For<TReturn>(IPagedList<int?, int?, TReturn> pagedList, IPagedListParameters pagedListParameters, string controllerName, string actionName, int? filter1, int? filter2)
		{
			var items = pagedList
				.Page(pagedListParameters.PageNumber, pagedListParameters.PageSize)
				.OrderBy(pagedListParameters.SortField, pagedListParameters.SortDirection)
				.ToList(filter1, filter2);
			return new PagedGridData<TReturn>(pagedListParameters, controllerName, actionName, items, pagedList.Total(filter1, filter2));
		}

		public static PagedGridData<TReturn> For<TReturn>(IPagedList<int?, int?, int?, TReturn> pagedList, IPagedListParameters pagedListParameters, string controllerName, string actionName, int? filter1, int? filter2, int? filter3)
		{
			var items = pagedList
				.Page(pagedListParameters.PageNumber, pagedListParameters.PageSize)
				.OrderBy(pagedListParameters.SortField, pagedListParameters.SortDirection)
				.ToList(filter1, filter2, filter3);
			return new PagedGridData<TReturn>(pagedListParameters, controllerName, actionName, items, pagedList.Total(filter1, filter2, filter3));
		}
	}
}