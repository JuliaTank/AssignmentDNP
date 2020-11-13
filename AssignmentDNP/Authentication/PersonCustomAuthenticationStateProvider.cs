using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using AssignmentDNP.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Models;

namespace AssignmentDNP.Authentication
{
    public class PersonCustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime jsRuntime;
        private readonly IPersonService personService;

        private Adult cachedAdult;

        public PersonCustomAuthenticationStateProvider(IJSRuntime jsRuntime, IPersonService personService)
        {
            this.jsRuntime = jsRuntime;
            this.personService = personService;
        }
        
        /*public void ValidateAdd(string firstName, string lastName, string sex, int id)
        {
            Console.WriteLine("Validating adding");
            if (string.IsNullOrEmpty(firstName)) throw new Exception("Enter first name");
            if (string.IsNullOrEmpty(lastName)) throw new Exception("Enter last name");
            if (string.IsNullOrEmpty(sex)) throw new Exception("Enter sex");
            if (string.IsNullOrEmpty(id.ToString())) throw new Exception("Enter id");

            ClaimsIdentity identity = new ClaimsIdentity();
            try
            {
                Adult adult = personService.ValidatePerson(firstName, lastName, sex,id);
                identity = SetupClaimsForAdult(adult);
                string serialisedData = JsonSerializer.Serialize(adult);
                jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentAdult", serialisedData);
                cachedAdult = adult;
            }
            catch (Exception e)
            {
                throw e;
            }

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }*/

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (cachedAdult == null)
            {
                string personAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentPerson");
                if (!string.IsNullOrEmpty(personAsJson))
                {
                    cachedAdult = JsonSerializer.Deserialize<Adult>(personAsJson);

                    identity = SetupClaimsForAdult(cachedAdult);
                }
            }
            else
            {
                identity = SetupClaimsForAdult(cachedAdult);
            }

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }
        

        private ClaimsIdentity SetupClaimsForAdult(Adult adult)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, adult.FirstName));
            claims.Add(new Claim("LastName", adult.LastName));
            claims.Add(new Claim("ID", adult.Id.ToString()));
            claims.Add(new Claim("HairColor", adult.HairColor));
            claims.Add(new Claim("EyeColor", adult.EyeColor));
            claims.Add(new Claim("Age", adult.Age.ToString()));
            claims.Add(new Claim("Weight", adult.Weight.ToString()));
            claims.Add(new Claim("Height", adult.Height.ToString()));
            claims.Add(new Claim("Sex", adult.Sex));
            claims.Add(new Claim("JobTitle", adult.JobTitle));


            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
    }
}