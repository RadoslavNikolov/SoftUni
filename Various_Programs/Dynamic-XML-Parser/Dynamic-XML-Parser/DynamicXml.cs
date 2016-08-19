﻿namespace Dynamic_Language_Runtime_Exercise
{
    using System.Collections;
    using System.Dynamic;
    using System.Xml.Linq;

    public class DynamicXml : DynamicObject, IEnumerable
    {
        private readonly dynamic _xml;

        public DynamicXml(string fileName)
        {
            _xml = XDocument.Load(fileName);
        }

        public DynamicXml(dynamic xml)
        {
            this._xml = xml;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var child in this._xml.Elements())
            {
                yield return new DynamicXml(child);
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var xml = _xml.Element(binder.Name);

            if (xml != null)
            {
                result = new DynamicXml(xml);

                return true;
            }

            result = null;

            return false;
        }

        public static implicit operator string(DynamicXml xml)
        {
            return xml._xml.Value;
        }
    }
}