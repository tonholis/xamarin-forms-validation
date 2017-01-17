using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace XFValidation.Behaviors
{
	public class EmailValidator : ValidatorBase<Entry>
	{
		const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
	   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

		protected override void OnAttachedTo(Entry bindable)
		{
			bindable.TextChanged += HandleTextChanged;
		}

		protected override void OnDetachingFrom(Entry bindable)
		{
			bindable.TextChanged -= HandleTextChanged;
		}

		void HandleTextChanged(object sender, TextChangedEventArgs e)
		{
			IsActive = (e.NewTextValue.Length > 0);
			if (!IsActive)
				return;

			IsValid = Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase);
		}

	}
}
