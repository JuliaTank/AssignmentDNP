#pragma checksum "D:\dnp1\AssignmentDNP\AssignmentDNP\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "700cdd1a79ab526d110292a2e7a2a16ca003462b"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace AssignmentDNP.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\dnp1\AssignmentDNP\AssignmentDNP\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\dnp1\AssignmentDNP\AssignmentDNP\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\dnp1\AssignmentDNP\AssignmentDNP\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\dnp1\AssignmentDNP\AssignmentDNP\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\dnp1\AssignmentDNP\AssignmentDNP\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\dnp1\AssignmentDNP\AssignmentDNP\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\dnp1\AssignmentDNP\AssignmentDNP\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\dnp1\AssignmentDNP\AssignmentDNP\_Imports.razor"
using AssignmentDNP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\dnp1\AssignmentDNP\AssignmentDNP\_Imports.razor"
using AssignmentDNP.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\dnp1\AssignmentDNP\AssignmentDNP\Shared\MainLayout.razor"
using AssignmentDNP.Authentication;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 27 "D:\dnp1\AssignmentDNP\AssignmentDNP\Shared\MainLayout.razor"
      

    public async Task PerformLogout()
    {
        try
        {
            ((UserCustomAuthenticationStateProvider) AuthenticationStateProvider).Logout();
            NavigationManager.NavigateTo("/");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
