#pragma checksum "C:\Users\tanki\DNPexercises\AssignmentDNP\AssignmentDNP\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "700cdd1a79ab526d110292a2e7a2a16ca003462b"
// <auto-generated/>
#pragma warning disable 1591
namespace AssignmentDNP.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\tanki\DNPexercises\AssignmentDNP\AssignmentDNP\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tanki\DNPexercises\AssignmentDNP\AssignmentDNP\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\tanki\DNPexercises\AssignmentDNP\AssignmentDNP\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\tanki\DNPexercises\AssignmentDNP\AssignmentDNP\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\tanki\DNPexercises\AssignmentDNP\AssignmentDNP\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\tanki\DNPexercises\AssignmentDNP\AssignmentDNP\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\tanki\DNPexercises\AssignmentDNP\AssignmentDNP\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\tanki\DNPexercises\AssignmentDNP\AssignmentDNP\_Imports.razor"
using AssignmentDNP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\tanki\DNPexercises\AssignmentDNP\AssignmentDNP\_Imports.razor"
using AssignmentDNP.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\tanki\DNPexercises\AssignmentDNP\AssignmentDNP\Shared\MainLayout.razor"
using AssignmentDNP.Authentication;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "sidebar");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenComponent<AssignmentDNP.Shared.NavMenu>(3);
            __builder.CloseComponent();
            __builder.AddMarkupContent(4, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\r\n\r\n");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "main");
            __builder.AddMarkupContent(8, "\r\n    ");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "top-row px-4");
            __builder.AddMarkupContent(11, "\r\n        ");
            __builder.OpenElement(12, "Login");
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n      \r\n        ");
            __builder.OpenElement(14, "button");
            __builder.AddAttribute(15, "class", "buttonMenu");
            __builder.AddMarkupContent(16, "\r\n            ");
            __builder.OpenElement(17, "a");
            __builder.AddAttribute(18, "href", "");
            __builder.AddAttribute(19, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 15 "C:\Users\tanki\DNPexercises\AssignmentDNP\AssignmentDNP\Shared\MainLayout.razor"
                                 PerformLogout

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(20, "\r\n                ");
            __builder.AddMarkupContent(21, "<span>\r\n                    Log out\r\n                </span>\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n\r\n    ");
            __builder.OpenElement(25, "div");
            __builder.AddAttribute(26, "class", "content px-4");
            __builder.AddMarkupContent(27, "\r\n        ");
            __builder.AddContent(28, 
#nullable restore
#line 24 "C:\Users\tanki\DNPexercises\AssignmentDNP\AssignmentDNP\Shared\MainLayout.razor"
         Body

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(29, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 27 "C:\Users\tanki\DNPexercises\AssignmentDNP\AssignmentDNP\Shared\MainLayout.razor"
      

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
