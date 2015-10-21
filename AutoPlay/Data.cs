using System.Xml.Serialization;

namespace AutoPlay
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class script
    {
        [XmlArrayItem("language", IsNullable = false)]
        public scriptLanguage[] languageSettings { get; set; }

        /// <remarks/>
        [XmlArrayItem("page", IsNullable = false)]
        public scriptPage[] pageProtocol { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class scriptLanguage
    {
        public scriptLanguageMainPage MainPage { get; set; }

        [XmlAttribute()]
        public string key { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class scriptLanguageMainPage
    {
        [XmlAttribute()]
        public string Text { get; set; }

        [XmlAttribute()]
        public string Numeric { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class scriptPage
    {
        [XmlAttribute()]
        public string name { get; set; }

        [XmlAttribute()]
        public string Action { get; set; }
    }
}
