# PornSearch

Simple library to search adult content.

## Summary
- [Installation](#installation)
- [Starting point](#starting-point)
- [List of source websites and sexual orientations](#list-of-source-websites-and-sexual-orientations)
- [How to search ?](#how-to-search-)
- [Get information about a video](#get-information-about-a-video)
- [How to check that the URL of the video is correct ?](#how-to-check-that-the-url-of-the-video-is-correct-)

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

|    | Pornhub | XVideos | YouPorn |
| :- | :-----: | :-----: | :-----: |
| Straight | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| Gay | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| Trans |  | :white_check_mark: | |

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
| Id | Video id |
| Title | Video title |
| Channel > Id | Channel id |
| Channel > Name | Channel name |
| ThumbnailUrl | Video thumbnail url |
| PageUrl | Video page url |

**Available values by website**

|    | Pornhub | XVideos | YouPorn |
| :- | :-----: | :-----: | :-----: |
| Website | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| SexOrientation | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| IsFreePremium | :white_check_mark: | | |
| Id | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| Title | :white_check_mark: | :white_check_mark: _(1)_ | :white_check_mark: |
| Channel > Id | :white_check_mark: | :white_check_mark: _(1)_ | :white_check_mark: _(1)_ |
| Channel > Name | :white_check_mark: | :white_check_mark: _(1)_ | :white_check_mark: _(1)_ |
| ThumbnailUrl | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| PageUrl | :white_check_mark: | :white_check_mark: | :white_check_mark: |

_(1) Empty value possible_

## Get information about a video

```cs
PornVideo video1 = await pornSearch.GetVideoAsync("https://www.pornhub.com/view_video.php?viewkey=ph5d0bc9474a26b");

// Or

PornSourceVideo sourceVideo = new() {
    Website = PornWebsite.Pornhub,
    Id = "ph5d0bc9474a26b"
};
PornVideo video2 = await pornSearch.GetVideoAsync(sourceVideo);
```

| Name | Description |
| :--- | :---------- |
| Website | Source website |
| SexOrientation | Sexual orientation |
| IsFreePremium | Is video free premium |
| Id | Video id |
| Title | Video title |
| Channel > Id | Channel id |
| Channel > Name | Channel name |
| ThumbnailUrl | Video thumbnail url |
| SmallThumbnailUrl | Video small thumbnail url |
| PageUrl | Video page url |
| VideoEmbedUrl | Video embed url |
| Duration | Video duration |
| Categories[] > Id | Category id |
| Categories[] > Name | Category name |
| Tags[] > Id | Tag id |
| Tags[] > Name | Tag name |
| Actors[] > Id | Actor id |
| Actors[] > Name | Actor name |
| NbViews | Number of views |
| NbLikes | number of likes |
| NbDislikes | number of dislikes |
| Date | Upload date |
| RelatedVideos | List of related videos  |

**Available values by website**

|    | Pornhub | XVideos | YouPorn
| :- | :-----: | :-----: | :-----: |
| Website | :white_check_mark: | :white_check_mark: |
| SexOrientation | :white_check_mark: | :white_check_mark: _(2)_ | :white_check_mark: |
| IsFreePremium | :white_check_mark: | | |
| Id | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| Title | :white_check_mark: | :white_check_mark: _(1)_ | :white_check_mark: |
| Channel > Id | :white_check_mark: | :white_check_mark: _(1)_ | :white_check_mark: |
| Channel > Name | :white_check_mark: | :white_check_mark: _(1)_ | :white_check_mark: |
| ThumbnailUrl | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| SmallThumbnailUrl | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| PageUrl | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| VideoEmbedUrl | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| Duration | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| Categories[] > Id | :white_check_mark: | | :white_check_mark: |
| Categories[] > Name | :white_check_mark: | | :white_check_mark: |
| Tags[] > Id | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| Tags[] > Name | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| Actors[] > Id | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| Actors[] > Name | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| NbViews | :white_check_mark: | :white_check_mark: _(1)_ | :white_check_mark: |
| NbLikes | :white_check_mark: | :white_check_mark: _(3)_ | |
| NbDislikes | :white_check_mark: | :white_check_mark: _(3)_ | |
| Date | :white_check_mark: | :white_check_mark: | :white_check_mark: |
| RelatedVideos | :white_check_mark: | :white_check_mark: | :white_check_mark: |

_(1) Empty value possible / (2) Unreliable value / (3) Approximate value_

```GetVideoAsync``` returns ```null``` if the video is deleted, video not available in its country or url which does not correspond to the available websites.

## How to check that the URL of the video is correct ?

```cs
PornSourceVideo sourceVideo = pornSearch.GetSourceVideo("https://www.pornhub.com/view_video.php?viewkey=ph5d0bc9474a26b");
```

| Name | Description |
| :--- | :---------- |
| Website | Source website |
| Id | Video id |
