using Xamarin.Forms;


namespace XFValidation.Behaviors
{
	public class MaxLengthBehavior : Behavior<Entry>
	{		
		public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(MaxLengthBehavior), 0);
		
		public int MaxLength
		{
			get { return (int)GetValue(MaxLengthProperty); }
			set { SetValue(MaxLengthProperty, value); }
		}

		protected override void OnAttachedTo(Entry bindable)
		{
			bindable.TextChanged += HandleTextChanged;
		}

		protected override void OnDetachingFrom(Entry bindable)
		{
			bindable.TextChanged -= HandleTextChanged;

		}
		private void HandleTextChanged(object sender, TextChangedEventArgs e)
		{
			//if (MaxLength != null && MaxLength.HasValue)
			if (e.NewTextValue.Length > 0 && e.NewTextValue.Length > MaxLength)
				((Entry)sender).Text = e.NewTextValue.Substring(0, MaxLength);
		}
	}
}
