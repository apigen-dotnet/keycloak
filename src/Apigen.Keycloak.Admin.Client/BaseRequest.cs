using System.Collections.Generic;
using System.Linq;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Base class for request objects
/// </summary>
public abstract class BaseRequest
{
  public virtual string ToQueryString() => string.Empty;
}
