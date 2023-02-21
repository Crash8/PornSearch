# PornSearch

Simple library to search adult content.

## Installation

Add the following Nuget packages:

 - ```AngleSharp``` >= ```1.0.1```
 - ```Jint``` >= ```2.11.58```
 - ```Newtonsoft.Json``` >= ```13.0.2```

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

## List of source websites and sexual orientations

```cs
List<PornSource> sources = pornSearch.GetSources();
```

| Name | Description |
| :--- | :---------- |
| Website | Source website |
| SexOrientations | List of sexual orientations |

**Available values by website**

|    | Pornhub | XVideos |
| :- | :-----: | :-----: |
| Straight | :white_check_mark: | :white_check_mark: |
| Gay | :white_check_mark: | :white_check_mark: |
| Trans |  | :white_check_mark: |

## How to search ?

```cs
PornSearchFilter searchFilter = new() {
    Website = PornWebsite.Pornhub,
    SexOrientation = PornSexOrientation.Straight,
    Filter = "french girl",
    Page = 1
};

List<PornVideoThumb> videoThumbs = await pornSearch.SearchAsync(searchFilter);
```

**Search filter**

| Name | Description | Default value |
| :--- | :---------- | :-----------: |
| Website | Search source website | Pornhub |
| SexOrientation | Sexual orientation | Straight |
| Filter | Search filter | "" |
| Page | Search page number | 1 |

```SearchAsync``` returns ```null``` if the sexual orientation is not available for the website. Used filter-targeted keywords and ```Straigth``` orientation for best results.

**Video thumb**

| Name | Description |
| :--- | :---------- |
| Website | Source website |
| SexOrientation | Sexual orientation |
| IsFreePremium | Is video free premium |
| Id | Video Id |
| Title | Video Title |
| Channel > Id | Channel Id |
| Channel > Name | Channel Name |
| ThumbnailUrl | Video thumbnail url |
| PageUrl | Video page url |

**Available values by website**

|    | Pornhub | XVideos |
| :- | :-----: | :-----: |
| Website | :white_check_mark: | :white_check_mark: |
| SexOrientation | :white_check_mark: | :white_check_mark: |
| IsFreePremium | :white_check_mark: | |
| Id | :white_check_mark: | :white_check_mark: |
| Title | :white_check_mark: | :white_check_mark: _(1)_ |
| Channel > Id | :white_check_mark: | :white_check_mark: _(1)_ |
| Channel > Name | :white_check_mark: | :white_check_mark: _(1)_ |
| ThumbnailUrl | :white_check_mark: | :white_check_mark: |
| PageUrl | :white_check_mark: | :white_check_mark: |

_(1) Empty value possible_

_coming soon_
