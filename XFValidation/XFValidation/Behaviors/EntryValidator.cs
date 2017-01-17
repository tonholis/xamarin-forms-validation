using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XFValidation.Behaviors
{
	public class EntryValidator : Behavior<Entry>
	{
		public static readonly BindableProperty ErrorProperty = BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(EmailValidator), default(string));
		public static readonly BindableProperty SuccessProperty = BindableProperty.Create(nameof(Success), typeof(bool), typeof(EmailValidator), false);
		private ValidatorBase<Entry>[] _validators;

		public string ErrorMessage
		{
			get { return (string)GetValue(ErrorProperty); }
			set { SetValue(ErrorProperty, value); }
		}

		public bool Success
		{
			get { return (bool)GetValue(SuccessProperty); }
			set { SetValue(SuccessProperty, value); }
		}

		void HandleTextChanged(object sender, TextChangedEventArgs e)
		{
			var error = _validators
				.Where(validator => validator.IsActive && !validator.IsValid)
				.Select(validator => validator.ErrorMessage)
				.FirstOrDefault();

			Success = error == null;
			ErrorMessage = error;
		}
		
		protected override void OnAttachedTo(Entry bindable)
		{
			_validators = (bindable as Entry).Behaviors.OfType<ValidatorBase<Entry>>().ToArray();
			if (_validators.Length > 0)
				bindable.TextChanged += HandleTextChanged;
		}

		protected override void OnDetachingFrom(Entry bindable)
		{
			if (_validators.Length <= 0) return;

			bindable.TextChanged -= HandleTextChanged;
			_validators = null;
		}

	}
}
