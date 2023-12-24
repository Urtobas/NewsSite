// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NewsSite.Areas.Identity.Pages.Account
{
    public class AccessDeniedModel : PageModel
    {

        public IActionResult OnGet(string returnUrl = null)
        {
            returnUrl ??= "/Index";
            return RedirectToPage(returnUrl);
        }
    }
}
