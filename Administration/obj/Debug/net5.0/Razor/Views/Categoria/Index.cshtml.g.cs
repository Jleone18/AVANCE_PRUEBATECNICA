#pragma checksum "C:\Users\FullComputador\source\repos\ClassLibrary1\Administration\Views\Categoria\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e83f3dfca5f562909d5048e43edb1d94d668519a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categoria_Index), @"mvc.1.0.view", @"/Views/Categoria/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\FullComputador\source\repos\ClassLibrary1\Administration\Views\_ViewImports.cshtml"
using Administration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\FullComputador\source\repos\ClassLibrary1\Administration\Views\_ViewImports.cshtml"
using Administration.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e83f3dfca5f562909d5048e43edb1d94d668519a", @"/Views/Categoria/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5309c5231cda213032618a93a4ca17df7c116e14", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Categoria_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Administration.Models.CategoriaVm>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\FullComputador\source\repos\ClassLibrary1\Administration\Views\Categoria\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center contenedora"" style=""padding-top:200px"">
    <div class=""text-center homeTitle"">
        <h1 class=""display-10"">
            PRUEBA TÉCNICA
        </h1>

    </div>
</div>
<div class=""container"">

    <div class=""row"">
        <div class=""col-10"">
            <p><h2><i class=""fa-solid fa-users ""></i>Categorias</h2></p>
        </div>
        <div class=""col-2"">
            <button type=""button"" class=""btn bg-success text-white"" data-url=""");
#nullable restore
#line 22 "C:\Users\FullComputador\source\repos\ClassLibrary1\Administration\Views\Categoria\Index.cshtml"
                                                                         Write(Url.Action("Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" data-toggle=""modal"" data-target=""#exampleModal""><i class=""fa-solid fa-user-plus text-white""></i>  Crear Categoria</button>
        </div>


    </div>
    <div id=""modalGenerico"">
    </div>
    <div class=""row"" style=""padding-top:20px"">

        <table class=""table"">
            <thead>
                <tr>
                    <th>
                        ");
#nullable restore
#line 35 "C:\Users\FullComputador\source\repos\ClassLibrary1\Administration\Views\Categoria\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.IdCategoria));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 38 "C:\Users\FullComputador\source\repos\ClassLibrary1\Administration\Views\Categoria\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 44 "C:\Users\FullComputador\source\repos\ClassLibrary1\Administration\Views\Categoria\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 48 "C:\Users\FullComputador\source\repos\ClassLibrary1\Administration\Views\Categoria\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.IdCategoria));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 51 "C:\Users\FullComputador\source\repos\ClassLibrary1\Administration\Views\Categoria\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 54 "C:\Users\FullComputador\source\repos\ClassLibrary1\Administration\Views\Categoria\Index.cshtml"
                       Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                            ");
#nullable restore
#line 55 "C:\Users\FullComputador\source\repos\ClassLibrary1\Administration\Views\Categoria\Index.cshtml"
                       Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                            ");
#nullable restore
#line 56 "C:\Users\FullComputador\source\repos\ClassLibrary1\Administration\Views\Categoria\Index.cshtml"
                       Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 59 "C:\Users\FullComputador\source\repos\ClassLibrary1\Administration\Views\Categoria\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n\r\n    </div>\r\n\r\n\r\n</div>\r\n<div class=\"row\" style=\"height:30%\">\r\n\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Administration.Models.CategoriaVm>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
