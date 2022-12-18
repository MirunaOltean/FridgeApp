using Project.DataService;
using Project.Models;
using Project.Validators;
using Project.Validators.Rules;
using Project.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Project.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Fields

        private ValidatableObject<string> email;
        private readonly SQLiteDataService _sqliteDataService;

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the email ID from user in the login page.
        /// </summary>
        public ValidatableObject<string> Email
        {
            get => email;
            set
            {
                if (email == value)
                {
                    return;
                }

                SetProperty(ref email, value);
            }
        }
        #endregion

        #region Constructor

        public LoginViewModel()
        {
            _sqliteDataService = new SQLiteDataService();
            InitializeProperties();
            AddValidationRules();
        }

        #endregion

        #region Methods

        public bool IsEmailFieldValid()
        {
            bool isEmailValid = Email.Validate();
            return isEmailValid;
        }

        private void InitializeProperties()
        {
            Email = new ValidatableObject<string>();
        }

        private void AddValidationRules()
        {
            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email Required" });
            Email.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Invalid Email" });
        }

        public async void OnLogInClicked(object password)
        {
            ValidatableObject<string> Password = (ValidatableObject<string>)password;
            Person person = _sqliteDataService.LogInCheck(Email.Value, Password.Value);
            if (person != null )
            {
                await Shell.Current.GoToAsync($"//{nameof(HealthProfilePage)}?name={person.Id}");
            }
            else
            {
                Email.IsValid = false;
                Password.IsValid = false;
            }
        }

        public async void OnSignUpClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(SignUpPage)}");
        }

        public void AddPerson(Person person)
        {
            _sqliteDataService.AddPerson(person);
        }

        #endregion
    }
}
