using System;
using System.Reflection;

namespace Araretama.BomNaEscolaBomDeBola.API.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}