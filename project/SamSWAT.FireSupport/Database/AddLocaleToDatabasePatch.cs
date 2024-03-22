using StayInTarkov;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SamSWAT.FireSupport.ArysReloaded.Database
{
    public class AddLocaleToDatabasePatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            var desiredType = StayInTarkovHelperConstants.EftTypes.First(IsTargetType);
            var desiredMethod = desiredType.GetMethod("GetLocalization", StayInTarkovHelperConstants.PublicDeclaredFlags);
            return desiredMethod;
        }

        private bool IsTargetType(Type t)
        {
            return typeof(ISession1).IsAssignableFrom(t) && t.IsPublic;
        }

        [PatchPostfix]
        private static async void PatchPostfix(Task<Dictionary<string, string>> __result)
        {
            var locales = await __result;
            locales.Add("3780800a0e292ab0c6417e98 Name", "PGU-13/B HEI High Explosive Incendiary");
            locales.Add("3780800a0e292ab0c6417e98 ShortName", "PGU-13/B HEI");
            locales.Add("3780800a0e292ab0c6417e98 Description", "The PGU-13/B HEI High Explosive Incendiary round employs a standard M505 fuze and explosive mixture with a body of naturally fragmenting material that is effective against lighter vehicle and material targets.");
            
            locales.Add("8c8c7dbd75e1820a76059d6b Name", "Fairchild Republic A-10 Thunderbolt II");
            locales.Add("8c8c7dbd75e1820a76059d6b ShortName", "A-10 Thunderbolt II");
            locales.Add("8c8c7dbd75e1820a76059d6b Description", "Close air support attack aircraft developed by Fairchild Republic for the USAF with mounted GAU-8/A Avenger 30mm autocannon.");
        }
    }
}
