using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentWebControls.Extensions;

namespace FluentWebControls
{
	public class LinkData : WebControlBase
	{
		private readonly Dictionary<string, string> _queryStringData = new Dictionary<string, string>();
		private readonly List<string> _urlParameters = new List<string>();

		public string ControllerExtension { get; set; }
		public string CssClass { private get; set; }
		public bool Disabled { get; set; }
		public string Href { get; set; }
		public string Id { get; set; }
		public string LinkText { get; set; }
		public string MouseOverText { get; set; }
		public string Rel { get; set; }

		public void AddQueryStringData(string key, string value)
		{
			_queryStringData.Add(key, value);
		}

		public void AddUrlParameters(string parameter)
		{
			_urlParameters.Add(parameter);
		}

		public void AddUrlParameters(List<string> parameters)
		{
			_urlParameters.AddRange(parameters);
		}

		private string BuildQueryString()
		{
			if (_queryStringData.Count == 0)
			{
				return "";
			}
			var sb = new StringBuilder();
			var keylessItems = _queryStringData.Where(x => x.Key == "").ToList();
			foreach (var item in keylessItems)
			{
				sb.Append('/')
					.Append(item.Value);
			}

			var keyedItems = _queryStringData.Where(x => x.Key.Length > 0);
			if (keyedItems.Any())
			{
				sb.Append('?');
				foreach (var keyValuePair in keyedItems)
				{
					sb.AppendFormat("{0}={1}&", keyValuePair.Key.EscapeForUrl(), keyValuePair.Value.EscapeForUrl());
				}
			}
			return sb.ToString();
		}

		private string BuildUrlParameters()
		{
			if (_urlParameters.Count <= 0)
			{
				return "";
			}
			return String.Format("/{0}", _urlParameters.Join("/"));
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendFormat("<a");
			if (Id != null)
			{
				sb.Append(Id.CreateQuotedAttribute("id"));
				sb.Append(Id.CreateQuotedAttribute("name"));
			}

			if (Disabled)
			{
				sb.AppendFormat(" disabled");
			}
			else
			{
				sb.AppendFormat(" href='{0}{1}{2}'", Href, BuildUrlParameters(), BuildQueryString());
			}
			if (Rel != null)
			{
				sb.Append(Rel.CreateQuotedAttribute("rel"));
			}
			if (CssClass != null)
			{
				sb.Append(CssClass.CreateQuotedAttribute("class"));
			}
			if (MouseOverText != null)
			{
				sb.Append(MouseOverText.CreateQuotedAttribute("title"));
			}

			sb.Append('>');
			sb.Append(LinkText.EscapeForHtml());
			sb.Append("</a>");

			return sb.ToString();
		}
	}
}