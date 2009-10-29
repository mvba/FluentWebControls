using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using FluentWebControls.Extensions;

namespace FluentWebControls.Tools
{
	public static class NameUtility
	{
		public static string GetCamelCaseMultiLevelPropertyName(params string[] propertyNames)
		{
			return GetMultiLevelPropertyName(propertyNames).ToCamelCase();
		}

		public static string GetCamelCasePropertyName<T, TReturn>(Expression<Func<T, TReturn>> expression)
		{
			return GetPropertyName(expression).ToCamelCase();
		}

		[DebuggerStepThrough]
		public static string GetMethodName<T, TReturn>(Expression<Func<T, TReturn>> expression)
		{
			var memberExpression = expression.Body as MethodCallExpression;
			if (memberExpression == null)
			{
				throw new ArgumentException("expression must be in the form: (Foo instance) => instance.Method");
			}
			return memberExpression.Method.Name;
		}

		public static string GetMultiLevelPropertyName(params string[] propertyNames)
		{
			return propertyNames.Join(".");
		}

		[DebuggerStepThrough]
		public static string GetPropertyName<T, TReturn>(Expression<Func<T, TReturn>> expression)
		{
			MemberExpression memberExpression = expression.Body as MemberExpression;
			if (memberExpression == null)
			{
				throw new ArgumentException(
					"expression must be in the form: (Thing instance) => instance.Property[.Optional.Other.Properties.In.Chain]");
			}
			List<string> names = GetNames(memberExpression);
			string name = names.Join(".");
			return name;
		}

		[DebuggerStepThrough]
		public static string GetFinalPropertyName<T>(Expression<Func<T>> expression)
		{
			MemberExpression memberExpression = expression.Body as MemberExpression;
			if (memberExpression == null)
			{
				throw new ArgumentException("expression must be in the form: () => instance.Property");
			}
			List<string> names = GetNames(memberExpression);
			return names.Last();
		}

		[DebuggerStepThrough]
		public static string GetPropertyName<T>(Expression<Func<T>> expression)
		{
			MemberExpression memberExpression = expression.Body as MemberExpression;
			if (memberExpression == null)
			{
				throw new ArgumentException("expression must be in the form: () => instance.Property");
			}
			List<string> names = GetNames(memberExpression);
			string name = names.Count > 1 ? names.Skip(1).Join(".") : names.Join(".");
			return name;
		}

		private static List<string> GetNames(MemberExpression memberExpression)
		{
			List<string> names = new List<string>
				{
					memberExpression.Member.Name
				};
			while (memberExpression.Expression as MemberExpression != null)
			{
				memberExpression = (MemberExpression)memberExpression.Expression;
				names.Insert(0, memberExpression.Member.Name);
			}
			return names;
		}
	}
}