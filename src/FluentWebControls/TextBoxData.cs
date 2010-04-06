using System;
using System.Text;

using FluentWebControls.Extensions;
using FluentWebControls.Validation;

namespace FluentWebControls
{
	public interface ITextBoxData
	{
		string CssClass { get; }
		string IdWithPrefix { get; }
		LabelData Label { get; }
		int? MaxValue { get; }
		int? MinValue { get; }
		bool ReadOnly { get; }
		ValidatableWebControlBase.JQueryFieldValidationType ValidationType { get; }
		string Value { get; }
		string Width { get; }
	}

	public class TextBoxData : ValidatableWebControlBase, ITextBoxData
	{
		private const string DefaultCssClass = "textbox";
		private readonly string _value;
		private int? _maxValue;
		private int? _minValue;

		public TextBoxData(string value)
		{
			_value = value;
			CssClass = DefaultCssClass;
		}

		internal string CssClass { private get; set; }
		internal LabelData Label { private get; set; }
		internal int MaxValue
		{
			set { _maxValue = value > 0 ? value : (int?)null; }
		}
		internal int MinValue
		{
			set { _minValue = value >= 0 ? value : (int?)null; }
		}
		internal bool ReadOnly { private get; set; }
		internal JQueryFieldValidationType ValidationType { private get; set; }
		internal string Width { private get; set; }

		string ITextBoxData.IdWithPrefix
		{
			get { return IdWithPrefix; }
		}
		string ITextBoxData.CssClass
		{
			get { return CssClass; }
		}
		LabelData ITextBoxData.Label
		{
			get { return Label; }
		}

		string ITextBoxData.Value
		{
			get { return _value; }
		}

		int? ITextBoxData.MaxValue
		{
			get { return _maxValue; }
		}

		int? ITextBoxData.MinValue
		{
			get { return _minValue; }
		}

		bool ITextBoxData.ReadOnly
		{
			get { return ReadOnly; }
		}

		JQueryFieldValidationType ITextBoxData.ValidationType
		{
			get { return ValidationType; }
		}

		string ITextBoxData.Width
		{
			get { return Width; }
		}

		public override string ToString()
		{
			if (PropertyMetaData != null)
			{
				if (PropertyMetaData.MaxLength > 0 && Width.IsNullOrEmpty())
				{
					Width = (PropertyMetaData.ValidationType == FieldValidationType.Digits ? 11 : 4) * PropertyMetaData.MaxLength.Value + "px";
				}
				if (PropertyMetaData.ReturnType == typeof(DateTime) ||
				    PropertyMetaData.ReturnType == typeof(DateTime?))
				{
					if (CssClass.IsNullOrEmpty() ||
					    CssClass == DefaultCssClass)
					{
						CssClass = "datebox";
					}
				}
			}

			var sb = new StringBuilder();
			if (Label != null)
			{
				Label.ForId = IdWithPrefix;
				sb.Append(Label);
			}
			sb.Append("<input");
			sb.Append("text".CreateQuotedAttribute("type"));
			if (!IdWithPrefix.IsNullOrEmpty())
			{
				sb.Append(IdWithPrefix.CreateQuotedAttribute("id"));
				sb.Append(IdWithPrefix.CreateQuotedAttribute("name"));
			}
			if (Width != null)
			{
				string value = "width:" + Width;
				sb.Append(value.CreateQuotedAttribute("style"));
			}
			sb.Append(BuildJqueryValidation(CssClass).CreateQuotedAttribute("class"));

			if (PropertyMetaData != null)
			{
				if (PropertyMetaData.MinLength > 0)
				{
					sb.Append(PropertyMetaData.MinLength.CreateQuotedAttribute(JQueryFieldValidationType.MinLength.Text));
				}

				if (PropertyMetaData.MaxLength > 0)
				{
					sb.Append(PropertyMetaData.MaxLength.CreateQuotedAttribute(JQueryFieldValidationType.MaxLength.Text));
				}

				if (PropertyMetaData.MinValue > 0 || _minValue > 0)
				{
					var v = PropertyMetaData.MinValue ?? _minValue;
					sb.Append(v.CreateQuotedAttribute(JQueryFieldValidationType.MinValue.Text));
				}

				if (PropertyMetaData.MaxValue > 0 || _maxValue > 0)
				{
					var v = PropertyMetaData.MaxValue ?? _maxValue;
					sb.Append(v.CreateQuotedAttribute(JQueryFieldValidationType.MaxValue.Text));
				}
			}

			sb.Append(_value.CreateQuotedAttribute("value"));
			if (ReadOnly)
			{
				sb.Append(" READONLY");
			}
			sb.Append("/>");
			if (PropertyMetaData != null)
			{
				if (PropertyMetaData.IsRequired)
				{
					sb.Append("<em>*</em>");
				}
			}
			return sb.ToString();
		}
	}
}