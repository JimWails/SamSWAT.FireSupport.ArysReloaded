using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EFT.InventoryLogic;
using Newtonsoft.Json;
using SamSWAT.FireSupport.ArysReloaded.Utils;
using StayInTarkov;

namespace SamSWAT.FireSupport.ArysReloaded.Database
{
	public class AddItemToDatabasePatch : ModulePatch
	{
		protected override MethodBase GetTargetMethod()
		{
			return ItemFactoryUtil.Type.GetField("ItemTemplates").FieldType.GetMethod("Init");
		}

		[PatchPostfix]
		public static void PatchPostfix(Dictionary<string, ItemTemplate> __instance)
		{
			var t = StayInTarkovHelperConstants.EftTypes.Single(x => x.GetField("SerializerSettings") != null);
			var converters = (JsonConverter[]) t.GetField("Converters").GetValue(null);

			var json = File.ReadAllText($"{Plugin.Directory}/database/ammo_30x173_gau8_avenger.json");
			var gau8Ammo = JsonConvert.DeserializeObject<AmmoTemplate>(json, converters);
			__instance.Add("3780800a0e292ab0c6417e98", gau8Ammo);

			json = File.ReadAllText($"{Plugin.Directory}/database/weapon_ge_gau8_avenger_30x173.json");
			var gau8Weapon = JsonConvert.DeserializeObject<WeaponTemplate>(json, converters);
			__instance.Add("8c8c7dbd75e1820a76059d6b", gau8Weapon);
		}
	}
}
