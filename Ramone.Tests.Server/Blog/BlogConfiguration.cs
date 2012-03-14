﻿using OpenRasta.Configuration;
using Ramone.Tests.Server.Blog.Codecs;
using Ramone.Tests.Server.Blog.Handlers;
using Ramone.Tests.Server.Blog.Resources;
using Ramone.Tests.Server.Handlers.Blog;


namespace Ramone.Tests.Server.Blog
{
  public static class BlogConfiguration
  {
    public static void Configure()
    {
      ResourceSpace.Has.ResourcesOfType<BlogList>()
                   .AtUri(BlogConstants.BlogListPath)
                   .HandledBy<BlogListHandler>()
                   .RenderedByAspx("~/Blog/Views/List.aspx");
      
      ResourceSpace.Has.ResourcesOfType<BlogItem>()
                   .AtUri(BlogConstants.BlogItemPath)
                   .HandledBy<BlogItemHandler>()
                   .RenderedByAspx("~/Blog/Views/Item.aspx");

      ResourceSpace.Has.ResourcesOfType<BlogItemCreationDescriptor>()
                   .AtUri(BlogConstants.BlogItemCreationPath)
                   .HandledBy<BlogItemCreationDescriptorHandler>()
                   .RenderedByAspx("~/Blog/Views/BlogItemCreationDescriptor.aspx");

      ResourceSpace.Has.ResourcesOfType<Author>()
                   .AtUri(BlogConstants.AuthorPath)
                   .HandledBy<AuthorHandler>()
                   .RenderedByAspx("~/Blog/Views/Author.aspx");

      ResourceSpace.Has.ResourcesOfType<Image>()
                   .AtUri(BlogConstants.ImagePath)
                   .HandledBy<ImageHandler>()
                   .TranscodedBy<ImageCodec>();

      ResourceSpace.Has.ResourcesOfType<SearchDescription>()
                   .AtUri(BlogConstants.SearchDescriptionPath)
                   .HandledBy<SearchDescriptionHandler>()
                   .RenderedByAspx("~/Blog/Views/SearchDescription.aspx")
                   .ForMediaType("application/opensearchdescription+xml");
    }
  }
}