#pragma checksum "D:\ItFresher\TestProject\MWG-Ecommerce\MWG-Ecommerce\Views\Admin\Discount\DiscountManager.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10ffc499a34dfecdba0beeae78bbc3d7eb2e7319"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Discount_DiscountManager), @"mvc.1.0.view", @"/Views/Admin/Discount/DiscountManager.cshtml")]
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
#line 1 "D:\ItFresher\TestProject\MWG-Ecommerce\MWG-Ecommerce\Views\_ViewImports.cshtml"
using MWG_Ecommerce;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ItFresher\TestProject\MWG-Ecommerce\MWG-Ecommerce\Views\_ViewImports.cshtml"
using MWG_Ecommerce.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10ffc499a34dfecdba0beeae78bbc3d7eb2e7319", @"/Views/Admin/Discount/DiscountManager.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e3622c4ad4370fe527936e717af2e1b232fa314", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_Discount_DiscountManager : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MWG_Ecommerce.Models.Discount>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return ajaxDelete(this);"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\ItFresher\TestProject\MWG-Ecommerce\MWG-Ecommerce\Views\Admin\Discount\DiscountManager.cshtml"
  
    ViewData["Title"] = "DiscountManager";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 style=\"text-align:center\">Quản lí khuyến mãi</h1>\r\n\r\n<p>\r\n    <a");
            BeginWriteAttribute("onclick", " onclick=\"", 226, "\"", 354, 5);
            WriteAttributeValue("", 236, "generalShowInPopup(\'", 236, 20, true);
#nullable restore
#line 11 "D:\ItFresher\TestProject\MWG-Ecommerce\MWG-Ecommerce\Views\Admin\Discount\DiscountManager.cshtml"
WriteAttributeValue("", 256, Url.Action("AddOrEditDiscount","DiscountManager",null,Context.Request.Scheme), 256, 78, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 334, "\',\'Thêm", 334, 7, true);
            WriteAttributeValue(" ", 341, "khuyến", 342, 7, true);
            WriteAttributeValue(" ", 348, "mãi\')", 349, 6, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-success btn btn-success text-white""> <i class=""fas fa-random""></i> Thêm khuyến mãi</a>
</p>


<!-- TABLE VIEW --> 
<div class=""table-responsive rounded-top rounded-bottom"">
    <table style=""text-align:center"" class=""table table-bordered"" id=""myTable"">
        <thead>
            <tr class=""table-warning"">
                <th style="" width:10%"" scope=""col"">
                   Mã số
                </th>
                <th style="" width:15%"" scope=""col"">
                    Nội dung khuyến mãi 
                </th>          
                <th style="" width:15%"" scope=""col"">
                    Giá khuyến mãi 
                </th>   
                <th style="" width:15%"" scope=""col"">
                    Thời gian bắt đầu
                </th>   
                <th style="" width:15%"" scope=""col"">
                    Thời gian kết thúc 
                </th>   
                <th class=""align-middle"" style="" width:15%;"" scope=""col"">Hoạt động</th>
            </tr>");
            WriteLiteral("\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 39 "D:\ItFresher\TestProject\MWG-Ecommerce\MWG-Ecommerce\Views\Admin\Discount\DiscountManager.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 43 "D:\ItFresher\TestProject\MWG-Ecommerce\MWG-Ecommerce\Views\Admin\Discount\DiscountManager.cshtml"
               Write(Html.DisplayFor(modelItem => item.DiscountId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 46 "D:\ItFresher\TestProject\MWG-Ecommerce\MWG-Ecommerce\Views\Admin\Discount\DiscountManager.cshtml"
               Write(Html.DisplayFor(modelItem => item.DiscountContent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>  \r\n                <td>\r\n                    ");
#nullable restore
#line 49 "D:\ItFresher\TestProject\MWG-Ecommerce\MWG-Ecommerce\Views\Admin\Discount\DiscountManager.cshtml"
               Write(String.Format("{0:0,0}", item.DiscountPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VND\r\n                </td>  \r\n                 <td>\r\n                    ");
#nullable restore
#line 52 "D:\ItFresher\TestProject\MWG-Ecommerce\MWG-Ecommerce\Views\Admin\Discount\DiscountManager.cshtml"
               Write(String.Format("{0:dd/MM/yyyy}", item.StartTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>  \r\n                 <td>\r\n                    ");
#nullable restore
#line 55 "D:\ItFresher\TestProject\MWG-Ecommerce\MWG-Ecommerce\Views\Admin\Discount\DiscountManager.cshtml"
               Write(String.Format("{0:dd/MM/yyyy}", item.EndTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>  \r\n                <td class=\"align-middle text-center\">\r\n                    <button type=\"button\" class=\"btn btn-info text-white\"");
            BeginWriteAttribute("onclick", " \r\n                            onclick=\"", 2195, "\"", 2367, 5);
            WriteAttributeValue("", 2235, "showInPopup(\'", 2235, 13, true);
#nullable restore
#line 59 "D:\ItFresher\TestProject\MWG-Ecommerce\MWG-Ecommerce\Views\Admin\Discount\DiscountManager.cshtml"
WriteAttributeValue("", 2248, Url.Action("AddOrEditDiscount","DiscountManager",new { id= item.DiscountId },Context.Request.Scheme), 2248, 101, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2349, "\',\'Sửa", 2349, 6, true);
            WriteAttributeValue(" ", 2355, "thông", 2356, 6, true);
            WriteAttributeValue(" ", 2361, "tin\')", 2362, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <i class=\"fas fa-pencil-alt\"></i>\r\n                    </button>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "10ffc499a34dfecdba0beeae78bbc3d7eb2e73199784", async() => {
                WriteLiteral("\r\n                    <button type=\"submit\" class=\"btn btn-danger\">\r\n                        <i style=\"color:black;\" class=\"far fa-trash-alt\"></i>\r\n                    </button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 62 "D:\ItFresher\TestProject\MWG-Ecommerce\MWG-Ecommerce\Views\Admin\Discount\DiscountManager.cshtml"
                                                WriteLiteral(item.DiscountId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 69 "D:\ItFresher\TestProject\MWG-Ecommerce\MWG-Ecommerce\Views\Admin\Discount\DiscountManager.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MWG_Ecommerce.Models.Discount>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
