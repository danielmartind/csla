﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csla.Server.Hosts.Silverlight
{
  /// <summary>
  /// Defines an interface to be implemented by
  /// a factory object that returns MobileFactory
  /// objects based on the MobileFactory attributes
  /// used to decorate CSLA Light business objects.
  /// </summary>
  public interface IMobileFactoryLoader
  {
    /// <summary>
    /// Returns a MobileFactory object.
    /// </summary>
    /// <param name="factoryName">
    /// Name of the factory to create, typically
    /// an assembly qualified type name.
    /// </param>
    object GetFactory(string factoryName);
  }
}
