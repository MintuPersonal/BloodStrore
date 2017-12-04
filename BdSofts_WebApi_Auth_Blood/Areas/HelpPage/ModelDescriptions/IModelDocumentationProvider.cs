using System;
using System.Reflection;

namespace BdSofts_WebApi_Auth_Blood.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}