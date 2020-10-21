using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PetShop.App.Components;
using PetShop.App.Services;
using PetShop.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.App.Pages
{
    public partial class EmployeeOverview
    {
        [CascadingParameter]
        Task<AuthenticationState> AuthenticationState { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        [Inject]
        private IEmployeeDataService EmployeeDataService { get; set; }

        protected AddEmployeeDialog AddEmployeeDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = await EmployeeDataService.GetAllEmployees();
        }
        
        protected async Task QuickAddEmployee()
        {
            var authenticationState = await AuthenticationState;
            if(authenticationState.User.Identity.Name == "Gregor")
            {
                AddEmployeeDialog.Show();
            }
        }

        public async void AddEmployeeDialog_OnDialogClose()
        {
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
            StateHasChanged();
        }
    }
}







