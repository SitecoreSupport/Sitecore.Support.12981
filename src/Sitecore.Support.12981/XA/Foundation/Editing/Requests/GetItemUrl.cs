using Sitecore.Data.Items;
using Sitecore.ExperienceEditor.Speak.Server.Requests;
using Sitecore.ExperienceEditor.Speak.Server.Responses;
using Sitecore.Text;
using Sitecore.XA.Foundation.Editing.Requests.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.XA.Foundation.Editing.Requests
{
  public class GetItemUrl: PipelineProcessorRequest<TargetContext>
  {
    public override PipelineProcessorResponseValue ProcessRequest()
    {
      UrlString str = new UrlString("/");
      str.Add("sc_mode", "edit");
      str.Add("sc_itemid", this.TargetItem.ID.ToString());
      str.Add("sc_lang", base.RequestContext.Language);
      str.Add("sc_version", base.RequestContext.TargetItem.Versions.GetLatestVersion().Version.Number.ToString());
      str.Append("sc_site", base.RequestContext.SiteName);
      return new PipelineProcessorResponseValue { Value = "/?" + str.Query };
    }

    protected Item TargetItem =>
    base.RequestContext.TargetItem;
  }
}