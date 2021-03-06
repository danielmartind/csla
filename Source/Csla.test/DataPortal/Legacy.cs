//-----------------------------------------------------------------------
// <copyright file="Legacy.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: https://cslanet.com
// </copyright>
// <summary>no summary</summary>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Csla.Test.DataPortalTest
{
  [Serializable()]
  class Legacy : BusinessBase<Legacy>
  {
    #region Business Methods

    public static PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id, RelationshipTypes.PrivateField);
    private int _id = IdProperty.DefaultValue;
    public int Id
    {
      get { return GetProperty(IdProperty, _id); }
      set { SetProperty(IdProperty, ref _id, value); }
    }

    #endregion


    #region Factory Methods

    public static Legacy NewObject()
    {
      return Csla.DataPortal.Create<Legacy>();
    }

    public static Legacy GetObject(int id)
    {
      return Csla.DataPortal.Fetch<Legacy>(new Criteria(id));
    }

    public static void DeleteObject(int id)
    {
      Csla.DataPortal.Delete<Legacy>(new Criteria(id));
    }

    #endregion

    #region Data Access

    [Serializable()]
    private class Criteria
    {
      private int _id;
      public int Id
      {
        get { return _id; }
      }
      public Criteria(int id)
      { _id = id; }
    }

    [Create]
		protected void DataPortal_Create()
    {
      _id = 0;
      Csla.ApplicationContext.GlobalContext.Clear();
      ApplicationContext.GlobalContext.Add("Legacy", "Created");
    }

    protected void DataPortal_Fetch(object criteria)
    {
      _id = ((Criteria)criteria).Id;
      Csla.ApplicationContext.GlobalContext.Clear();
      ApplicationContext.GlobalContext.Add("Legacy", "Fetched");
    }

    [Insert]
    protected void DataPortal_Insert()
    {
      Csla.ApplicationContext.GlobalContext.Clear();
      ApplicationContext.GlobalContext.Add("Legacy", "Inserted");
    }

    [Update]
		protected void DataPortal_Update()
    {
      Csla.ApplicationContext.GlobalContext.Clear();
      ApplicationContext.GlobalContext.Add("Legacy", "Updated");
    }

    [Delete]
		protected void DataPortal_Delete(object criteria)
    {
      Csla.ApplicationContext.GlobalContext.Clear();
      ApplicationContext.GlobalContext.Add("Legacy", "Deleted");
    }

    [DeleteSelf]
    protected void DataPortal_DeleteSelf()
    {
      Csla.ApplicationContext.GlobalContext.Clear();
      ApplicationContext.GlobalContext.Add("Legacy", "SelfDeleted");
    }

    #endregion
  }
}