#pragma checksum "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "defb74fb8171f1b7d059bdd5982c1ed32b1b2705"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_GetProduct), @"mvc.1.0.view", @"/Views/Product/GetProduct.cshtml")]
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
#line 1 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
using FreshShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"defb74fb8171f1b7d059bdd5982c1ed32b1b2705", @"/Views/Product/GetProduct.cshtml")]
    public class Views_Product_GetProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
  
    ViewData["Title"] = "Product " + Model.ProductName;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <h3 class=""display-4"">Product details</h3>
    <div class=""row"">
        <div class=""col-md-6"">
            <div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">
                <ol class=""carousel-indicators"">
                    <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
                    <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
                    <li data-target=""#carouselExampleIndicators"" data-slide-to=""2""></li>
                </ol>
                <div class=""carousel-inner"">
                    <div class=""carousel-item active"">
                        <img class=""d-block w-100"" src="".../800x400?auto=yes&bg=777&fg=555&text=First slide"" alt=""First slide"">
                    </div>
                    <div class=""carousel-item"">
                        <img class=""d-block w-100"" src="".../800x400?auto=yes&bg=666&fg=444&text=Second slide"" alt=""Second slide"">
   ");
            WriteLiteral(@"                 </div>
                    <div class=""carousel-item"">
                        <img class=""d-block w-100"" src="".../800x400?auto=yes&bg=555&fg=333&text=Third slide"" alt=""Third slide"">
                    </div>
                </div>
                <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
                    <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                    <span class=""sr-only"">Previous</span>
                </a>
                <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
                    <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                    <span class=""sr-only"">Next</span>
                </a>
            </div>
        </div>
        <div class=""col-md-6"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <h1>");
#nullable restore
#line 41 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
                   Write(Model.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"row\">\r\n                <div class=\"col-md-12 text-primary\">\r\n                    <span class=\"label label-primary\">By:</span>\r\n                    <span class=\"monospaced\">");
#nullable restore
#line 48 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
                                        Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"row\">\r\n                <div class=\"col-md-12\">\r\n                    <p class=\"description\">\r\n                        ");
#nullable restore
#line 55 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
                   Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>
                </div>
            </div>


            <div class=""row"">
                <div class=""col-md-4"">
                    <button class=""btn btn-outline-primary"">
                        Add to Cart
                    </button>
                </div>
            </div>

            <hr />

            <ul class=""list-group"">
                <li class=""list-group-item""><span class=""font-weight-bold"">Category - </span>");
#nullable restore
#line 72 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
                                                                                        Write(Model.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
            WriteLiteral("            </ul>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductModel> Html { get; private set; }
    }
}
#pragma warning restore 1591