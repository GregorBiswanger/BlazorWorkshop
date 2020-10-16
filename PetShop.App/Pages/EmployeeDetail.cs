using Microsoft.AspNetCore.Components;
using PetShop.App.Services;
using PetShop.ComponentsLibrary.Map;
using PetShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShop.App.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public List<Marker> MapMarkers { get; set; } = new List<Marker>();

        [Inject]
        private IEmployeeDataService EmployeeDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployee(int.Parse(EmployeeId));
            MapMarkers = new List<Marker>
            {
                new Marker 
                { 
                    Description = $"{Employee.FirstName} {Employee.LastName}", 
                    ShowPopup = false, 
                    X = Employee.Longitude, 
                    Y = Employee.Latitude 
                }
            };
        }
    }
}











