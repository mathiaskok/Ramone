﻿<%@ Import Namespace="Ramone.Tests.Server.Blog.Resources" %>
<%@ Page Language="C#" Inherits="OpenRasta.Codecs.WebForms.ResourceView<BlogList>" %>
<html>
   <head profile="http://a9.com/-/spec/opensearch/1.1/">
     <link rel="search"
           type="application/opensearchdescription+xml" 
           href="<%=Resource.SearchDescriptionLink%>"
           title="Content search" />
   </head>
   <body>
    <h1 class="blog-title"><%=Resource.Title %></h1>
    <p>Author: <a rel="author" href="<%=Resource.AuthorLink%>"><%=Resource.AuthorName%></a></p>
    <% foreach (BlogItem item in Resource.Items) { %>
      <div class="post">
        <h2><a class="post-title" rel="self" href="<%=item.SelfLink%>"><%=item.Title %></a></h2>
        <p class="post-content"><%=item.Text %></p>
      </div>
    <% } %>

    <p>
      <a rel="edit" href="<%=Resource.EditLink %>">Add new blog post</a>
    </p>
  </body>
</html>