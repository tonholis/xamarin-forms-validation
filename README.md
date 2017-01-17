# xamarin-forms-validation
A sample entry validation using Behaviors and XAML in Xamarin Forms 

This sample is based on this article:

https://blog.xamarin.com/behaviors-in-xamarin-forms/


But I need to attach multiple validators (behaviors) on a Entry field and get which validator fails to display the right the right error message. 
That's why I created a class called EntryValidator that evaluates the Behaviors attached to a Entry field. It tests the IsValid property of each Validator and gets the ErrorMessage provided on XAML from the first failed validation. Also, there are Validators that is considered Active if there is an actual Value on the field. For example, EmailValidator is active if there is a Text value to check, otherwise it won't be considered in the EntryValidator. 

##Required Validator
![Required Validator](https://raw.githubusercontent.com/tonholis/xamarin-forms-validation/master/screenshot1.png)

##Email Validator
![Email Validator](https://raw.githubusercontent.com/tonholis/xamarin-forms-validation/master/screenshot1.png)

##Success State 
![Success State](https://raw.githubusercontent.com/tonholis/xamarin-forms-validation/master/screenshot1.png)
