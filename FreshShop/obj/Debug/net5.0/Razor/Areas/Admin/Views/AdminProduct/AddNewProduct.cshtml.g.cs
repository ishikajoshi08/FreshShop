#pragma checksum "G:\FreshShop\FreshShop\FreshShop\Areas\Admin\Views\AdminProduct\AddNewProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a503320cdd3abcc4920ad6a0eae4918720d554f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminProduct_AddNewProduct), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminProduct/AddNewProduct.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a503320cdd3abcc4920ad6a0eae4918720d554f8", @"/Areas/Admin/Views/AdminProduct/AddNewProduct.cshtml")]
    public class Areas_Admin_Views_AdminProduct_AddNewProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "G:\FreshShop\FreshShop\FreshShop\Areas\Admin\Views\AdminProduct\AddNewProduct.cshtml"
  
    ViewData["Title"] = "AddNewProduct";
    Layout = "~/Areas/Admin/Views/Shared/_Layout1.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\" style=\"padding-left:200px\">\r\n    <h3 class=\"display-4\">Add New Product</h3>\r\n    <hr />\r\n");
            WriteLiteral(@"
    <form method=""post"" enctype=""multipart/form-data"">
        <div class=""form-group"">
            <label asp-for=""ProductName"" class=""control-label"">ProductName</label>
            <input type=""text"" asp-for=""ProductName"" class=""form-control"" />
            <span asp-validation-for=""ProductName"" class=""text-danger""></span>
        </div>

        <div class=""form-group"">
            <label asp-for=""CategoryId"" class=""control-label"">Category</label>
            <select asp-for=""CategoryId"" class=""form-control"" asp-items=""(await _categoryRepo.GetCategories()).Select(x => new SelectListItem() { Text = x.Name,Value=x.Id.ToString()})"">
                <option");
            BeginWriteAttribute("value", " value=\"", 1369, "\"", 1377, 0);
            EndWriteAttribute();
            WriteLiteral(@">Please choose Product Category</option>
            </select>
            <span asp-validation-for=""CategoryId"" class=""text-danger""></span>
        </div>

        <div class=""form-group"">
            <label asp-for=""Price"" class=""control-label"">Price</label>
            <input type=""number"" asp-for=""Price"" class=""form-control"" />
            <span asp-validation-for=""Price"" class=""text-danger""></span>
        </div>

        <div class=""form-group"">
            <label asp-for=""Description"" class=""control-label"">Description</label>
            <textarea class=""form-control"" asp-for=""Description"" rows=""3""></textarea>
            <span asp-validation-for=""Description"" class=""text-danger""></span>
        </div>

        <div class=""form-group"">
            <label asp-for=""CoverPhoto"" class=""control-label"">ProductName</label>
            <div class=""custom-file"">
                <input asp-for=""CoverPhoto"" class=""custom-file-input"" id=""customFile"">
                <label class=""custom-file-l");
            WriteLiteral(@"abel"" for=""customFile"">Choose file</label>
            </div>
            <span asp-validation-for=""CoverPhoto"" class=""text-danger""></span>
        </div>

        <div class=""form-group"">
            <label asp-for=""GalleryFiles"" class=""control-label""></label>
            <div class=""custom-file"">
                <input asp-for=""GalleryFiles"" class=""custom-file-input"" id=""customFile"">
                <label class=""custom-file-label"" for=""customFile"">Choose file</label>
            </div>
            <span asp-validation-for=""GalleryFiles"" class=""text-danger""></span>
        </div>

        <div class=""form-group"">
            <button type=""submit"" class=""btn btn-primary"">Add New Product </button>
        </div>
    </form>
</div>

");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591