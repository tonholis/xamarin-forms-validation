using Xamarin.Forms;

namespace XFValidation.Behaviors
{
	public class ValidatorBase<T> : Behavior<T> where T: BindableObject
	{
		public static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(ValidatorBase<T>), default(string));
		
		public string ErrorMessage
		{
			get { return (string)GetValue(ErrorMessageProperty); }
			set { SetValue(ErrorMessageProperty, value); }
		}

		public bool IsActive { get; set; }
		public bool IsValid { get; set; }
	

	}
}
