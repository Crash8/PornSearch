# PornSearch

Simple library to search adult content.

## Installation

Add the following Nuget packages:

 - AngleSharp >= 1.0.1
 - Jint >= 2.11.58
 - Newtonsoft.Json >= 13.0.2

## Starting point

### With dependency injection

```cs
// #### Program.cs in ASP.NET Core Web Application
using PornSearch.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddPornSearch(); // <== Add PornSearch for dependency injection


// #### HomeController.cs
using Microsoft.AspNetCore.Mvc;
using PornSearch;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly IPornSearch _pornSearch;

    public HomeController(IPornSearch pornSearch) { // <== Example of dependency injection in a Controller
        _pornSearch = pornSearch;
    }

    public async Task<IActionResult> Index() {
        PornSearchFilter searchFilter = new() {
            Website = PornWebsite.Pornhub,
            SexOrientation = PornSexOrientation.Straight,
            Filter = "french girl",
            Page = 1
        };
        List<PornVideoThumb> videoThumbs = await _pornSearch.SearchAsync(searchFilter); // <== Search adult videos
        return View(videoThumbs);
    }
}
```

### Without dependency injection

```cs
using PornSearch;

IPornSearch pornSearch = new PornSearchEngine();

PornSearchFilter searchFilter = new() {
    Website = PornWebsite.Pornhub,
    SexOrientation = PornSexOrientation.Straight,
    Filter = "french girl",
    Page = 1
};

List<PornVideoThumb> videoThumbs = await pornSearch.SearchAsync(searchFilter);
```

## Search


```cs
PornSearchFilter searchFilter = new() {
    Website = PornWebsite.Pornhub,
    SexOrientation = PornSexOrientation.Straight,
    Filter = "french girl",
    Page = 1
};

List<PornVideoThumb> videoThumbs = await pornSearch.SearchAsync(searchFilter);
```

**Search criteria**

| Name | Description | Default value |
| :--- | :---------- | :-----------: |
| Website | Search source website | Pornhub |
| SexOrientation | Sexual orientation | Straight |
| Filter | Search filter | "" |
| Page | Search page number | 1 |

_coming soon_
