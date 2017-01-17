using Xamarin.Forms;

namespace XFValidation.Behaviors
{
	public class RequiredValidator : ValidatorBase<Entry>
	{
		public RequiredValidator()
		{
			IsActive = true;
		}
		
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
			IsValid = (e.NewTextValue.Length > 0);
		}

	}
}
