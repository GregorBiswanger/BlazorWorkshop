using Microsoft.AspNetCore.Components;
using PetShop.App.Services;
using PetShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace PetShop.App.Pages
{
    public partial class EmployeeEdit
    {
        [Parameter]
        public int EmployeeId { get; set; }

        [Inject]
        private IEmployeeDataService EmployeeDataService { get; set; }

        [Inject]
        private ICountryDataService CountryDataService { get; set; }

        [Inject]
        private IJobCategoryDataService JobCategoryDataService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public List<Country> Countries { get; set; } = new List<Country>();

        public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved = false;

        protected override async Task OnInitializedAsync()
        {
            Countries = (await CountryDataService.GetAllCountries()).ToList();
            JobCategories = (await JobCategoryDataService.GetAllJobCategories()).ToList();

            if(EmployeeId == 0)
            {
                Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
            }
            else
            {
                Employee = await EmployeeDataService.GetEmployee(EmployeeId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if(EmployeeId == 0)
            {
                var addedEmployee = await EmployeeDataService.AddEmployee(Employee);
                if (addedEmployee != null)
                {
                    StatusClass = "alert-success";
                    Message = "Neuer Mitarbeiter erfolgreich angelegt.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Fehler beim speichern.";
                    Saved = false;
                }
            } 
            else
            {
                await EmployeeDataService.UpdateEmployee(Employee);
                StatusClass = "alert-success";
                Message = "Mitarbeiter erfolgreich geändert.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "Fehler mit dem Formular. Bitte erneut versuchen.";
        }

        protected async Task DeleteEmployee()
        {
            await EmployeeDataService.DeleteEmployee(EmployeeId);

            StatusClass = "alert-success";
            Message = "Löschen erfolgreich!";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }
    }
}
























