﻿using System;
using System.Collections.Generic;


namespace Ramone.HyperMedia
{
  public abstract class SelectableBase
  {
    protected void SetRelationType(string rel)
    {
      AssignRelationTypes(rel);
    }


    protected string GetRelationType()
    {
      return _relationType;
    }


    protected IEnumerable<string> GetRelationTypes()
    {
      return _relationTypes;
    }


    protected void SetMediaType(MediaType mediaType)
    {
      _mediaType = mediaType;
    }


    protected MediaType GetMediaType()
    {
      return _mediaType;
    }


    protected string GetMediaTypeText()
    {
      return _mediaType != null ? (string)_mediaType : null;
    }



    #region Internals

    private string _relationType;

    private List<string> _relationTypes = new List<string>();

    private MediaType _mediaType;

    private void AssignRelationTypes(string rel)
    {
      _relationType = rel;
      if (rel != null)
        _relationTypes.AddRange(rel.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
      else
        _relationTypes = new List<string>();
    }

    #endregion
  }
}
