









 
//------------------------------------------------------------------------------
//     Add a global shortcut in MSVS for beeing able to generate this file after 
//     you modify localization strings from resource files use:
//     MENU / TOOLS / OPTIONS / Keyboard
//     Add Command 'Build.TransformAllT4Templates' with shortcut Ctrl+Shift+Alt+T
//------------------------------------------------------------------------------

using Windows.ApplicationModel.Resources; 

namespace TruePhonebook.Strings
{
    public class StringResources
	{
	  static StringResources()
		{
			AllKeys = new LocalizedStrings();
		}

		public static LocalizedStrings AllKeys { get; }

		public LocalizedStrings Keys => AllKeys;
	}

    public class LocalizedStrings
	{
		static readonly ResourceLoader ResourceLoader = ResourceLoader.GetForViewIndependentUse(); 	
  
		public string EnterNameOrNumber => ResourceLoader.GetString("EnterNameOrNumber");
  
		public string NumberTypeHome => ResourceLoader.GetString("NumberTypeHome");
  
		public string NumberTypeMobile => ResourceLoader.GetString("NumberTypeMobile");
  
		public string NumberTypeOther => ResourceLoader.GetString("NumberTypeOther");
  
		public string NumberTypeWork => ResourceLoader.GetString("NumberTypeWork");
 
	}
}

