﻿using NUnit.Framework;
using Ramone.HyperMedia;
using Ramone.Tests.Common.CMS;


namespace Ramone.Tests.HyperMedia
{
  [TestFixture]
  public class FollowTests : TestHelper
  {
    [Test]
    public void CanFollowRelativeLinksInContextDependentData()
    {
      // Arrange
      Request dossierReq = Session.Bind(DossierTemplate, new { id = 8 });
      using (var r = dossierReq.Get<Dossier>())
      {
        Dossier dossier = r.Body;

        // Act
        Request documentsReq = dossier.Links.Select(CMSConstants.DocumentsLinkRelType).Follow();
        using (var r2 = documentsReq.Get<DossierDocumentList>())
        {
          DossierDocumentList documents = r2.Body;

          // Assert
          Assert.IsNotNull(documents);
          Assert.AreEqual(2, documents.Count);
        }
      }
    }


    [Test]
    public void CanFollowLinksInGeneral()
    {
      // Arrange
      Request dossierReq = Session.Bind(DossierTemplate, new { id = 8 });
      using (var r = dossierReq.Get<Dossier>())
      {
        Dossier dossier = r.Body;

        // Act
        using (var r2 = dossier.Links.Select(CMSConstants.DocumentsLinkRelType).Follow(Session).Get<DossierDocumentList>())
        {
          DossierDocumentList documents1 = r2.Body;

          // Assert
          Assert.IsNotNull(documents1);
          Assert.AreEqual(2, documents1.Count);
        }
      }
    }


    [Test]
    public void FollowCanSelectLinkByItself()
    {
      // Arrange
      Request dossierReq = Session.Bind(DossierTemplate, new { id = 8 });
      using (var r = dossierReq.Get<Dossier>())
      {
        // Act
        using (var r2 = r.Body.Links.Follow(Session, CMSConstants.DocumentsLinkRelType).Get<DossierDocumentList>())
        {
          DossierDocumentList documents1 = r2.Body;

          // Assert
          Assert.IsNotNull(documents1);
          Assert.AreEqual(2, documents1.Count);
        }
      }
    }


    [Test]
    public void FollowCanSelectLinkByItselfWithoutUsingSession()
    {
      // Arrange
      Request dossierReq = Session.Bind(DossierTemplate, new { id = 8 });
      using (var r = dossierReq.Get<Dossier>())
      {
        // Act
        using (var r2 = r.Body.Links.Follow(CMSConstants.DocumentsLinkRelType).Get<DossierDocumentList>())
        {
          DossierDocumentList documents1 = r2.Body;

          // Assert
          Assert.IsNotNull(documents1);
          Assert.AreEqual(2, documents1.Count);
        }
      }
    }
  }
}
